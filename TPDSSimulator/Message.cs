using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class Message
    {
        public int MessageID;
        public int MessageType;
        public string MessageContent;

        public Message() { }

        public Message (int msgID, int msgType, string msgContent)
        {
            this.MessageID = msgID;
            this.MessageType = msgType;
            this.MessageContent = msgContent;
        }
    }
}
