using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Net_Lab_6
{
    public partial class Form1 : Form
    {
        private Socket serverSocket;
        private Thread listenThread;

        private delegate void ChatEvent(string content);
        private Dictionary<string, List<string>> MissedMessagesChats = new Dictionary<string, List<string>>();
        private ChatEvent addMessage;
        private string myName;
        private bool imAuth = false;

        public Form1()
        {
            InitializeComponent();
            addMessage = new ChatEvent(AddMessage);
        }

        private void Start()
        {
            try
            {
                while (serverSocket.Connected)
                {
                    byte[] buffer = new byte[2048];
                    int lenghtByte = serverSocket.Receive(buffer);
                    HandleCommand(Encoding.Unicode.GetString(buffer, 0, lenghtByte));
                }
            }
            catch
            {
                MessageBox.Show("Связь с сервером прервана");
                Application.Exit();
            }
        }

        private void TrySetName()
        {
            myName = InputName.Text;
            if(!string.IsNullOrEmpty(myName))
                Send("#" + Types.SETNAME + "|" + myName);
        }

        //Обработка сообщений от сервера
        private void HandleCommand(string data)
        {
            try
            {
                string[] commands = data.Split('#');
                foreach (string partCommand in commands)
                {
                    string command = partCommand.Split('|')[0];
                    if (string.IsNullOrEmpty(command))
                        continue;
                    //if (!imAuth && command == Types.SETNAME)
                    //    HandlerSetName(partCommand);
                    //else
                    //{
                        switch (command)
                        {
                            case Types.SETNAME:
                                HandlerSetName(partCommand);
                                break;
                            case Types.MESSAGE:
                                HandlerMessage(partCommand);
                                break;
                            case Types.PRIVATEMESSAGE:
                                HandlerPrivateMessage(partCommand);
                                break;
                            case Types.USERLIST:
                                HandlerUsersList(partCommand);
                                break;
                            case Types.CHATCREATE:
                                HandlerChatCreate(partCommand);
                                break;
                            case Types.SETFILETO:
                                HandlerIntentionFile(partCommand);
                                break;
                    }
                    //}
                }
                    
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Вывести сообщение в textbox
        private void AddMessage(string content)
        {
            if (InvokeRequired)
            {
                Invoke(addMessage, content);
                return;
            }
            ChatTextBox.SelectionStart = ChatTextBox.TextLength;
            ChatTextBox.SelectionLength = content.Length;
            ChatTextBox.AppendText(content + Environment.NewLine);
        }

        public void HandlerIntentionFile(string data)
        {
            string[] arguments = data.Split('|');
            string fileID = arguments[1];
            string fileName = arguments[2];
            string fromUser = arguments[3];
            int fileSize = int.Parse(arguments[4]);

            DialogResult Result = MessageBox.Show($"Вы хотите принять файл {fileName} размером {fileSize} от {fromUser}", "Файл", MessageBoxButtons.YesNo);

            if (Result == DialogResult.Yes)
            {
                Thread.Sleep(1000);
                Send($"#{Types.GETFILE}|" + fileID);
                byte[] fileBuffer = new byte[fileSize];
                serverSocket.Receive(fileBuffer);
                File.WriteAllBytes(fileName, fileBuffer);
                MessageBox.Show($"Файл {fileName} принят.");
            }
        }

        public void HandlerChatCreate(string data)
        {
            string[] splitMessage = data.Split('|');
            CreateChatOnForm(splitMessage[1]);
        }

        //Создать чат
        public void CreateChatOnForm(string id)
        {
            TabPage tabPage = new TabPage();
            tabPage.Text = "Чат_" + id;
            tabPage.Name = "Чат_" + id;

            MissedMessagesChats.Add(id, new List<string>());

            TextBox chatTextBox = new TextBox();
            chatTextBox.Name = "chatTextBox_" + id.ToString();
            chatTextBox.ReadOnly = true;
            chatTextBox.Multiline = true;
            chatTextBox.Dock = DockStyle.Fill;

            ChatListTab.Invoke((MethodInvoker)delegate
            {
                PrivateChatRadioButton.Enabled = true;
                EnterChatMessageTextBox.Enabled = true;

                tabPage.Controls.Add(chatTextBox);
                ChatListTab.TabPages.Add(tabPage);
            });
        }

        public void DisableLogInBlock()
        {
            InputName.Enabled = false;
            LogInButton.Enabled = false;
        }

        public void HandlerSetName(string data)
        {
            string[] splitAnswer = data.Split('|');
            string Answer = splitAnswer[1];
            if (Answer == "SUCCESS")
            {
                imAuth = true;
                InterfaceActivated();
                DisableLogInBlock();
            }
            else
                MessageBox.Show("Данное имя уже занято! Измените его","Ошибка");
        }

        //Обработчик полученых сообщений общего чата
        public void HandlerMessage(string data)
        {
            string[] splitMessage = data.Split('|');
            AddMessage(splitMessage[1]);
        }

        //Обработчик полученых сообщений для приватного чата
        public void HandlerPrivateMessage(string data)
        {
            string[] splitMessage = data.Split('|');
            AddMessageOnChat(splitMessage[1], splitMessage[2]);
        }

        //Вернуть выбранный чат
        public string GetSelectedChatId()
        {
            string name = ChatListTab.TabPages[ChatListTab.SelectedIndex].Name;
            return name.Split('_')[1];
        }

        //Добавление полученного от сервера сообщения в чат
        public void AddMessageOnChat(string id, string message)
        {
            ChatListTab.Invoke((MethodInvoker)delegate
            {
                //Если чат выбран то добавить в TextBox
                if (GetSelectedChatId() == id)
                {
                    ((TextBox)ChatListTab.TabPages[ChatListTab.SelectedIndex].Controls["chatTextBox_" + id]).AppendText(message );
                    ((TextBox)ChatListTab.TabPages[ChatListTab.SelectedIndex].Controls["chatTextBox_" + id]).AppendText(Environment.NewLine);
                }
                else //Добавить в список пропущенных сообщений этого чата
                    MissedMessagesChats[id].Add(message);
            });
        }

        //Обработчик полученного списка пользователей
        public void HandlerUsersList(string data)
        {
            string[] splitUsers = data.Split('|')[1].Split(',');
            UsersListOnForm.Invoke((MethodInvoker)delegate
            {
                UsersListOnForm.Items.Clear();
            });
            foreach(string user in splitUsers)
            {
                UsersListOnForm.Invoke((MethodInvoker)delegate
                {
                    if(!string.IsNullOrEmpty(user) && user != myName)
                        UsersListOnForm.Items.Add(user);
                });
            }
        }

        public void Send(string Buffer)
        {
            try
            {
                serverSocket.Send(Encoding.Unicode.GetBytes(Buffer));
            }
            catch { }
        }

        public void Send(byte[] buffer)
        {
            try
            {
                serverSocket.Send(buffer);
            }
            catch { }
        }

        public void DisableConnectBlock()
        {
            Invoke((MethodInvoker)delegate
            {
                LogInButton.Enabled = true;
                InputIP.Enabled = false;
                InputPort.Enabled = false;
                ConnectToServerButton.Enabled = false;
            });
   
        }

        public void TryConnectToServer(string ipaddress, int port)
        {
            try
            {
                IPAddress iPAddress = IPAddress.Parse(ipaddress);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Connect(new IPEndPoint(iPAddress, port));
                if (serverSocket.Connected)
                {
                    DisableConnectBlock();
                    listenThread = new Thread(new ThreadStart(Start));
                    listenThread.Start();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка при подключении к cерверу", "Ошибка");
            }
        }

        private void ConnectToServerButton_Click(object sender, EventArgs e)
        {
            string ipaddress = InputIP.Text;
            int port;
            if(int.TryParse(InputPort.Text, out port) && !string.IsNullOrEmpty(ipaddress))
                TryConnectToServer(ipaddress, port);
        }

        private void LogInButton_Click(object sender, EventArgs e)
        {
            TrySetName();
        }

        private void SendCreateChat()
        {
          
            string usersCreateChat = $"{myName},";
            foreach(var user in UsersListOnForm.CheckedItems)
                usersCreateChat += user.ToString() + ",";
            Send($"#{Types.CHATCREATE}|{usersCreateChat}");
        }

        private void CreateChatButton_Click(object sender, EventArgs e)
        {
            SendCreateChat();
        }

        private void ChatListTab_Selecting(object sender, TabControlCancelEventArgs e)
        {
            ChatListTab.Invoke((MethodInvoker)delegate
            {
                string id = GetSelectedChatId();
                List<string> missedMessage = MissedMessagesChats[id];
                foreach (string message in missedMessage)
                {
                    ((TextBox)ChatListTab.TabPages[ChatListTab.SelectedIndex].Controls["chatTextBox_" + id]).AppendText(message);
                    ((TextBox)ChatListTab.TabPages[ChatListTab.SelectedIndex].Controls["chatTextBox_" + id]).AppendText(Environment.NewLine);
                }
                MissedMessagesChats[id].Clear();
            });
        }

        private void InterfaceActivated()
        {
            Invoke((MethodInvoker)delegate
            {
                
                EnterMessageTextBox.Enabled = true;
                CreateChatButton.Enabled = true;
                SendFileButton.Enabled = true;
            });
        }

        private void EnterChatMessageTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string msgData = EnterChatMessageTextBox.Text;
                if (string.IsNullOrEmpty(msgData))
                    return;
                Send($"#{Types.PRIVATEMESSAGE}|{GetSelectedChatId()}|{msgData}");
                EnterChatMessageTextBox.Text = string.Empty;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (imAuth)
            {
                Send($"#{Types.EXITSERVER}");
                listenThread.Abort();
            }
        }

        private void EnterMessageTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                string msgData = EnterMessageTextBox.Text;
                if (string.IsNullOrEmpty(msgData))
                    return;
                Send($"#{Types.MESSAGE}|{msgData}");
                EnterMessageTextBox.Text = string.Empty;
            }
        }

        private void NeedsendFile()
        {
            OpenFileDialog ofp = new OpenFileDialog();
            ofp.ShowDialog();
            if (!File.Exists(ofp.FileName))
            {
                MessageBox.Show($"Файл {ofp.FileName} не найден!");
                return;
            }
            FileInfo fi = new FileInfo(ofp.FileName);
            byte[] buffer = File.ReadAllBytes(ofp.FileName);

            string chatID = "NONE";
            if(PrivateChatRadioButton.Checked)
                chatID = GetSelectedChatId();

            Send($"#{Types.SETFILETO}|{chatID}|{buffer.Length}|{fi.Name}");
            Send(buffer);
        }


        private void SendFileButton_Click(object sender, EventArgs e)
        {
            NeedsendFile();
        }
    }
}
