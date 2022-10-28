using Net_Lab_6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart
{
    public class User
    {
        public string userName { get; set; } = "";
        private bool currectAuth = false;

        private Socket userHandle;
     
        private Thread userThread;
        public User(Socket handle)
        {
            userHandle = handle;
            userThread = new Thread(new ThreadStart(Listner));
            userThread.IsBackground = true;
            userThread.Start();
        }
        private void Listner()
        {
            try
            {
                //Send("#" + Types.MESSAGE + "|Вы зашли на сервер\nТеперь вам нужно авторизоваться!");
                while (userHandle.Connected)
                {
                    byte[] buffer = new byte[2048];
                    int lenghtByte = userHandle.Receive(buffer);
                    HandleCommand(Encoding.Unicode.GetString(buffer, 0, lenghtByte));
                }
            }
            catch
            {

            }
        }

        //const string SETNAME = "#SETNAME";
        //const string USERLIST = "#USERLIST";
        //const string MESSAGEALLUSER = "#MESSAGEALLUSER";
        //const string PRIVATEMESSAGE = "#PRIVATEMESSAGE";
        //const string GETFILE = "#GETFILE";
        //const string SETFILETO = "#SETFILETO";

        private void HandleCommand(string data)
        {
            try
            {
                string[] commands = data.Split('#');
                foreach (string partCommand in commands)
                {
                    string command = partCommand.Split('|')[0];
                    if (string.IsNullOrEmpty(command))
                        continue; ;
                    switch (command)
                    {
                        case Types.SETNAME:
                            InitUser(partCommand);
                            break;
                        case Types.MESSAGE:
                            SendMessageAllUser(partCommand);
                            break;
                        case Types.PRIVATEMESSAGE:
                            SendMessageToChat(partCommand);
                            break;
                        case Types.CHATCREATE:
                            CreateChat(partCommand);
                            break;
                        case Types.SETFILETO:
                            HandlerIntentionFile(partCommand);
                            break;
                        case Types.GETFILE:
                            SendFile(partCommand);
                            break;
                        case Types.EXITSERVER:
                            Server.DeleteUser(this);
                            break;
                        default:
                            Console.WriteLine("Command is not currect");
                            break;
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void SendFile(string data)
        {
            string fileID = data.Split('|')[1];
            MyFile file = Server.GetFileByID(int.Parse(fileID));
            if (file.ID == 0)
            {
                return;
            }
            Send(file.fileBuffer);
            Server.Files.Remove(file);
        }

        //Обработчик файлов полученых от пользователя
        public void HandlerIntentionFile(string data)
        {
            string[] arguments = data.Split('|');
            string chatID = arguments[1];
            int FileSize = int.Parse(arguments[2]);
            string FileName = arguments[3];
            byte [] file = new byte[FileSize];
            userHandle.Receive(file);

            MyFile myFile = new MyFile()
            {
                ID = Server.Files.Count + 1,
                FileName = FileName,
                From = userName,
                fileBuffer = file,
                FileSize = file.Length
            };

            Server.Files.Add(myFile);
            if (chatID == "NONE")
                Server.SendIntentionFileUsers(myFile, Server.UserList);
            else
                Server.SendIntentionFileToChat(chatID, myFile);
        }

        //Подготавливаем сообщение для сервера
        public void SendMessageAllUser(string data)
        {
            string[] splitMessage = data.Split('|');
            string message = $"[{userName}] {splitMessage[1]}";
            //Сообщаем серверу что хотим отправить сообщение всем пользователям
            Server.SendAllUserMessage(message);
        }

        //Отправить сообщение в чат
        public void SendMessageToChat(string data)
        {
            string[] splitMessage = data.Split('|');
            string id = splitMessage[1];
            string message = $"[{userName}] {splitMessage[2]}";
            Server.SendMessageToChat(id, message);
        }

        public void CreateChat(string data)
        {
            string[] splitUsers = data.Split('|')[1].Split(',');
            Server.SendUsersCreateChat(splitUsers);
        }

        ////Отправляем конкретному пользователю сообщение
        //public void SendMessageToUsers(string message)
        //{
        //    Send(Types.MESSAGEALLUSER + $"|[{userName}] " + message);
        //}

        ////Отправляем конкретному пользователю список пользователей
        //public void SendUsersListToUser(string message)
        //{
        //    Send(Types.USERLIST + message);
        //}

        //Инициализация пользователя
        public void InitUser(string data)
        {
            string[] splitMessage = data.Split('|');
            string name = splitMessage[1];
            if (!HasUserFound(name))
            {
                userName = name;
                Send($"#{Types.SETNAME}|SUCCESS");
                Server.AddUser(this);
            }
            else
                Send($"#{Types.SETNAME}|FAIL");
        }

        //Проверка есть ли пользователь с таким именем
        public bool HasUserFound(string name)
        {
            if (Server.UserList.Count == 0)
                return false;
            User user = Server.UserList.FirstOrDefault(UL => UL.userName == name);
            if (user == null)
                return false;
            return true;
        }

        //Отправить с сервера пользователю буффер
        public void Send(byte[] buffer)
        {
            try
            {
                userHandle.Send(buffer);
            }
            catch { }
        }
        //Отправить с сервера пользователю строку
        public void Send(string str)
        {
            try
            {
                userHandle.Send(Encoding.Unicode.GetBytes(str));
            }
            catch { }
        }

        public void EndUser()
        {
            try
            {
                userHandle.Close();
            }
            catch { }
        }


    }
}
