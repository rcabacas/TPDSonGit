using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class RecordStatistics
    {
        /// <summary>
        /// Records the number of messages received for each type of message
        /// </summary>
        /// <param name="messageType">Message priority number</param>
        public static void RecordReceived(int messageType)
        {
            switch (messageType)
            {
                case 1:
                    Statistics.ReceivedP1Messages += 1;
                    break;
                case 2:
                    Statistics.ReceivedP2Messages += 1;
                    break;
                case 3:
                    Statistics.ReceivedP3Messages += 1;
                    break;
                case 4:
                    Statistics.ReceivedP4Messages += 1;
                    break;
                case 5:
                    Statistics.ReceivedP5Messages += 1;
                    break;
            }
        }

        /// <summary>
        /// Records the number of dropped messages for each type of message
        /// </summary>
        /// <param name="messageType">Message priority number</param>
        public static void RecordDropped(int messageType)
        {
            switch (messageType)
            {
                case 1:
                    Statistics.DroppedP1Messages += 1;
                    break;
                case 2:
                    Statistics.DroppedP2Messages += 1;
                    break;
                case 3:
                    Statistics.DroppedP3Messages += 1;
                    break;
                case 4:
                    Statistics.DroppedP4Messages += 1;
                    break;
                case 5:
                    Statistics.DroppedP5Messages += 1;
                    break;
            }
        }

        /// <summary>
        /// Records the number of queued messages for each type of message
        /// </summary>
        /// <param name="messageType">Message priority number</param>
        public static void RecordQueued(int messageType)
        {
            switch (messageType)
            {
                case 1:
                    Statistics.QueuedP1Messages += 1;
                    break;
                case 2:
                    Statistics.QueuedP2Messages += 1;
                    break;
                case 3:
                    Statistics.QueuedP3Messages += 1;
                    break;
                case 4:
                    Statistics.QueuedP4Messages += 1;
                    break;
                case 5:
                    Statistics.QueuedP5Messages += 1;
                    break;
            }
        }

        /// <summary>
        /// Records the number of messages for each type of message
        /// </summary>
        /// <param name="messageType">Message priority number</param>
        public static void RecordMessageTypeOccurence(int messageType)
        {
            switch (messageType)
            {
                case 1:
                    Statistics.TotalP1Messages++;
                    break;
                case 2:
                    Statistics.TotalP2Messages++;
                    break;
                case 3:
                    Statistics.TotalP3Messages++;
                    break;
                case 4:
                    Statistics.TotalP4Messages++;
                    break;
                case 5:
                    Statistics.TotalP5Messages++;
                    break;
            }
        }
    }
}
