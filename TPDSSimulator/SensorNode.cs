using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Threading;

namespace TPDSSimulator
{
    class SensorNode
    {
        //this is where all the data is stored before being "sensed" or queued by a node
        Queue dataSource = new Queue();
        int a = 0;
        private int nodeID;
        private string permission;
        
        public void RunNode()
        {
            bool sleep = true, active = false;
            int csleep = 0, cactive = 0;
            int cycle = SimulationSettings.Interval * 60; //in minutes
            int dutyCycle = SimulationSettings.DutyCycle; //in percent
            int sleepCycle = 100 - dutyCycle; //in percent
            int timeToSleep = Convert.ToInt32(cycle * (sleepCycle * 0.01));
            int timeActive = Convert.ToInt32(cycle * (dutyCycle * 0.01));

            //node state loop
            for (int i = 0; i < SimulationSettings.SimulationTime; i++)
            {
                
                if (sleep)
                {
                    if (csleep < timeToSleep)
                    {
                        Sleep(i);
                        csleep++;
                    }
                    else
                    {
                        sleep = false;
                        csleep = 0;
                        active = true;
                    }
                }

                if (active)
                {
                    if (cactive < timeActive)
                    {
                        Active(i);
                        cactive++;
                    }
                    else
                    {
                        active = false;
                        cactive = 0;
                        sleep = true;
                    }
                }

                ThreadLocker.Bar.SignalAndWait();
                if (SimulationSettings.RealTimeView)
                    Thread.Sleep(100);
            }
        }

        public SensorNode() { }
        
        public void Sleep(int second)
        {
            //do nothing here
            Console.WriteLine("{0} NN-{1} SLEEPING", second + 1, nodeID);
            //write trace file here
        }

        public void Active(int second)
        {
            Message messageToSend;
            StubInvokeTPDS();

            if (permission == "CTS")
            {
                messageToSend = (Message)dataSource.Dequeue();
                Console.WriteLine("{0} node {1} --- SENT --- PN {2} --- ID {3}",
                    second,
                    nodeID, 
                    messageToSend.MessageType, 
                    messageToSend.MessageID);
                EnergyHarvestingNode.ReceiveMessage(nodeID, messageToSend, second);
            }
            else if (permission == "NAK")
            {
                //trace will be placed here too
                messageToSend = (Message)dataSource.Peek();
                Console.WriteLine("{0} node {1} --- HOLD --- PN {2} --- ID {3}",
                    second,
                    nodeID, 
                    messageToSend.MessageType, 
                    messageToSend.MessageID);
                a++;
                if (a == 3)
                {
                    //drop message
                    messageToSend = (Message)dataSource.Dequeue(); 
                    RecordStatistics.RecordDropped(messageToSend.MessageType);
                    Console.WriteLine("{0} node {1} --- DROP --- PN {2} --- ID {3}",
                        second,
                        nodeID, 
                        messageToSend.MessageType, 
                        messageToSend.MessageID);
                    //reset counter
                    a = 0;
                }
            }
            Console.WriteLine("{0} ACTIVE", second + 1);
        }

        private void StubInvokeTPDS()
        {
            Message msgToPeek = (Message)dataSource.Peek();
            int msgToPeekPriorityNumber = msgToPeek.MessageType;

            //a == 0 to record a message's first time to be queued
            //when a != 0, that means a message has been previously queued
            if (a == 0)
            {
                RecordStatistics.RecordQueued(msgToPeekPriorityNumber);
            }
            permission = EnergyHarvestingNode.InvokeTPDS(msgToPeekPriorityNumber);
        }

        /// <summary>
        /// This initializes the data source for the node
        /// </summary>
        public void GenerateSource()
        {
            Message messageToQueue = new Message();

            while (SensorField.SensorFieldDataCount() != 0)
            {
                messageToQueue = (Message)SensorField.DequeueFromSensorField();
                RecordStatistics.RecordMessageTypeOccurence(messageToQueue.MessageType);
                dataSource.Enqueue(messageToQueue);
                Thread.Sleep(10);
            }
        }

        public int DataSourceCount
        {
            get { return dataSource.Count; }
        }

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

        public int NodeID
        {
            get { return nodeID; }
            set { nodeID = value + 1; } 
        }
    }
}
