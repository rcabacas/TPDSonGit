using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace TPDSSimulator
{
    class SensorField
    {
        static Queue dataSensed = new Queue();
        private static Object locker = new Object();

        public static void InitializeSensorField(int dataCount)
        {
            Random r = new Random();
            int messageType;
            string messageContent;

            for (int i = 0; i < dataCount; i++)
            {
                messageType = r.Next(1, 6);
                if (messageType == 1)
                    messageContent = "Priority 1";
                else if (messageType == 2)
                    messageContent = "Priority 2";
                else if (messageType == 3)
                    messageContent = "Priority 3";
                else if (messageType == 4)
                    messageContent = "Priority 4";
                else
                    messageContent = "Priority 5";

                Message msg = new Message(i, messageType, messageContent);
                dataSensed.Enqueue(msg);
            }
            Console.WriteLine("Sensor field initialized!\n");
            //Thread.Sleep(1000);
            //OutputSensorFieldData();
        }

        //for testing purposes only
        public static void OutputSensorFieldData()
        {
            foreach (Message item in dataSensed)
            {
                Console.WriteLine("{0} -- {1} -- {2}", 
                    item.MessageID, 
                    item.MessageType, 
                    item.MessageContent);
            }
        }
                             
        public static int SensorFieldDataCount()
        {
            return dataSensed.Count;
        }

        public static Message DequeueFromSensorField()
        {
            Message dq = new Message();

            lock (locker)
            {
                dq = (Message)dataSensed.Dequeue();
            }

            return dq;
        }
    }
}
