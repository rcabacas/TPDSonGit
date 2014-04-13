using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace TPDSSimulator
{
    //transfer this function to the node itself
    //pointless to separate this function
    class Sensor
    {
        Queue dataSource = new Queue(); //this is where all the data is stored before being "sensed" or queued by a node

        /// <summary>
        /// This initializes the data source for the node
        /// </summary>
        public void GenerateSource()
        {
            Random r1 = new Random();
            Random r2 = new Random();
            Message messageToQueue = new Message();
           
            while (SensorField.SensorFieldDataCount() != 0)
            {
                messageToQueue = (Message)SensorField.DequeueFromSensorField();
                dataSource.Enqueue(messageToQueue);
                Thread.Sleep(10);
            }
            
            //Console.WriteLine("Total Messages: {0}", dataSource.Count);
        }

        /// <summary>
        /// Returns the number of messages in queue
        /// </summary>
        public int DataSourceCount
        {
            get { return dataSource.Count; }
        }

        /// <summary>
        /// Prints all queue items
        /// </summary>
        public void OutputQueueItems()
        {
            foreach (Message item in dataSource)
            {
                Console.WriteLine("{0} -- {1} -- {2}", 
                    item.MessageID, 
                    item.MessageType, 
                    item.MessageContent);
            }
        }
    }
}
