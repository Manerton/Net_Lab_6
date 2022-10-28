using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Net_Lab_6
{
    public struct Types
    {
        public const string SETNAME = "SETNAME";
        public const string MESSAGE = "MESSAGE";
        public const string PRIVATEMESSAGE = "PRIVATEMESSAGE";
        public const string USERLIST = "USERLIST";
        public const string GETFILE = "GETFILE";
        public const string SETFILETO = "SETFILETO";
        public const string CHATCREATE = "CHATCREATE";
        public const string EXITSERVER = "EXITSERVER";
         
    }

    public struct MyFile
    {
        public int ID;
        public string FileName;
        public string From;
        public int FileSize;
        public byte[] fileBuffer;
    }
}
