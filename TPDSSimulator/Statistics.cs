using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class Statistics
    {
        private static int droppedP1Messages;
        private static int droppedP2Messages;
        private static int droppedP3Messages;
        private static int droppedP4Messages;
        private static int droppedP5Messages;

        private static int receivedP1Messages;
        private static int receivedP2Messages;
        private static int receivedP3Messages;
        private static int receivedP4Messages;
        private static int receivedP5Messages;

        private static int totalP1Messages;
        private static int totalP2Messages;
        private static int totalP3Messages;
        private static int totalP4Messages;
        private static int totalP5Messages;

        private static int queuedP1Messages;
        private static int queuedP2Messages;
        private static int queuedP3Messages;
        private static int queuedP4Messages;
        private static int queuedP5Messages;

        private static int totalDroppedMessages;
        private static int totalSentMessages;
        private static int queuedMessages;
        private static int unqueuedMessages;

        #region dropped pn messages
        public static int DroppedP1Messages
        {
            get { return droppedP1Messages; }
            set { droppedP1Messages = value; }
        }

        public static int DroppedP2Messages
        {
            get { return droppedP2Messages; }
            set { droppedP2Messages = value; }
        }

        public static int DroppedP3Messages
        {
            get { return droppedP3Messages; }
            set { droppedP3Messages = value; }
        }

        public static int DroppedP4Messages
        {
            get { return droppedP4Messages; }
            set { droppedP4Messages = value; }
        }

        public static int DroppedP5Messages
        {
            get { return droppedP5Messages; }
            set { droppedP5Messages = value; }
        }
        #endregion

        #region received pn messages
        public static int ReceivedP1Messages
        {
            get { return receivedP1Messages; }
            set { receivedP1Messages = value; }
        }

        public static int ReceivedP2Messages
        {
            get { return receivedP2Messages; }
            set { receivedP2Messages = value; }
        }

        public static int ReceivedP3Messages
        {
            get { return receivedP3Messages; }
            set { receivedP3Messages = value; }
        }

        public static int ReceivedP4Messages
        {
            get { return receivedP4Messages; }
            set { receivedP4Messages = value; }
        }

        public static int ReceivedP5Messages
        {
            get { return receivedP5Messages; }
            set { receivedP5Messages = value; }
        }
        #endregion

        #region total pn messages
        public static int TotalP1Messages
        {
            get { return totalP1Messages; }
            set { totalP1Messages = value; }
        }

        public static int TotalP2Messages
        {
            get { return totalP2Messages; }
            set { totalP2Messages = value; }
        }

        public static int TotalP3Messages
        {
            get { return totalP3Messages; }
            set { totalP3Messages = value; }
        }

        public static int TotalP4Messages
        {
            get { return totalP4Messages; }
            set { totalP4Messages = value; }
        }

        public static int TotalP5Messages
        {
            get { return totalP5Messages; }
            set { totalP5Messages = value; }
        }
        #endregion

        #region queued pn messages
        public static int QueuedP1Messages
        {
            get { return queuedP1Messages; }
            set { queuedP1Messages = value; }
        }

        public static int QueuedP2Messages
        {
            get { return queuedP2Messages; }
            set { queuedP2Messages = value; }
        }

        public static int QueuedP3Messages
        {
            get { return queuedP3Messages; }
            set { queuedP3Messages = value; }
        }

        public static int QueuedP4Messages
        {
            get { return queuedP4Messages; }
            set { queuedP4Messages = value; }
        }

        public static int QueuedP5Messages
        {
            get { return queuedP5Messages; }
            set { queuedP5Messages = value; }
        }
        #endregion

        public static int TotalDroppedMessages
        {
            get { 
                return droppedP1Messages 
                    + droppedP2Messages
                    + droppedP3Messages
                    + droppedP4Messages
                    + droppedP5Messages; 
            }
        }

        public static int TotalSentMessages
        {
            get
            {
                return receivedP1Messages
                    + receivedP2Messages
                    + receivedP3Messages
                    + receivedP4Messages
                    + receivedP5Messages; 
            }
        }

        public static int TotalQueuedMessages
        {
            get
            {
                return queuedP1Messages
                    + queuedP2Messages
                    + queuedP3Messages
                    + queuedP4Messages
                    + queuedP5Messages;
            }
        }
    }
}
