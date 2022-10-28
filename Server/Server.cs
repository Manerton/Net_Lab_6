using Net_Lab_6;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerPart
{
    public static class Server
    {
        public static int port = 25565;
        public static string ipAddress = "26.92.228.180";

        public static List<MyFile> Files = new List<MyFile>();
        public static List<User> UserList = new List<User>();
        public static ConcurrentDictionary<string, List<User>> ChatList = new ConcurrentDictionary<string, List<User>>();
        public static Socket mainSocket;
        public static bool ServerWork = true;

        public delegate void UserEvent(string Name);

        public static event UserEvent UserConnected = (Username) =>
        {
            Console.WriteLine($"User {Username} connected.");
            SendAllUserMessage($"[Сервер] {Username} подключился к чату");
            PrepareUserList();
        };

        public static event UserEvent UserDisconnected = (Username) =>
        {
            Console.WriteLine($"User {Username} disconnected.");
            SendAllUserMessage($"[Сервер] {Username} отключился от чата");;
            PrepareUserList();
        };

        public static void Start()
        {
            try
            {
                IPAddress iP = IPAddress.Parse(ipAddress);
                IPEndPoint endPoint = new IPEndPoint(iP, port);
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                mainSocket.Bind(endPoint);
                mainSocket.Listen(100);
                Console.WriteLine("Сервер запущен");

                while (ServerWork)
                {
                    Socket handle = mainSocket.Accept();
                    Console.WriteLine($"Новое подключение: {handle.RemoteEndPoint}");
                    new User(handle);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        public static void AddUser(User user)
        {
            UserList.Add(user);
            UserConnected(user.userName);
        }

        public static void SendUserMessage(User user, string message)
        {
            user.Send($"#{Types.SETNAME}|SUCCESS");
        }

        public static void DeleteUser(User user)
        {
            UserList.Remove(user);
            user.EndUser();
            UserDisconnected(user.userName);
        }

        public static void PrepareUserList() 
        {
            string message = "";
            foreach (User user in UserList)
                message += user.userName + ",";
            SendAllUserUsersList(message);
        }

        //Отправить всем пользователям список пользователей
        public static void SendAllUserUsersList(string message)
        {
            string resultMessage = $"#{Types.USERLIST}|{message}";
            foreach (User user in UserList)
                user.Send(resultMessage);
        }

        //Отправить всем пользователям сообщение от пользователя
        public static void SendAllUserMessage(string message)
        {
            foreach (User user in UserList)
                user.Send($"#{Types.MESSAGE}|{message}");
        }

        public static string AddChat()
        {
            string id = ChatList.Count().ToString();
            ChatList.TryAdd(id, new List<User>());
            return id;
        }

        //Отправить пользователям команду создать чат
        public static void SendUsersCreateChat(string[] splitUsers)
        {
            string id = AddChat();
            List<User> userList = new List<User>(); 
            string command = $"#{Types.CHATCREATE}|{id}";
            foreach (User user in UserList)
            {
                if (splitUsers.Contains(user.userName))
                {
                    userList.Add(user);
                    user.Send(command);
                }
            }
            ChatList[id] = userList;
        }

        public static MyFile GetFileByID(int ID)
        {
            int countFiles = Files.Count;
            for (int i = 0; i < countFiles; i++)
            {
                if (Files[i].ID == ID)
                    return Files[i];
            }
            return new MyFile() { ID = 0 };
        }

        public static void SendIntentionFileUsers(MyFile file, List<User> Users)
        {
            string command = $"#{Types.SETFILETO}|{file.ID}|{file.FileName}|{file.From}|{file.FileSize}";
            foreach (User user in Users)
            {
                if (user.userName != file.From)
                    user.Send(command);
            }
        }

        public static void SendIntentionFileToChat(string chatID, MyFile file)
        {
            List<User> ChatUsers = ChatList[chatID];
            if(ChatUsers != null)
                SendIntentionFileUsers(file, ChatUsers);
        }


        //Отправить сообщение в созданный чат
        public static void SendMessageToChat(string chatID, string message)
        {
            List<User> ChatUsers = ChatList[chatID];
            if(ChatUsers != null)
            {
                string command = $"#{Types.PRIVATEMESSAGE}|{chatID}|{message}";
                foreach (User user in ChatUsers)
                    user.Send(command);
            }
        }
    }
}
