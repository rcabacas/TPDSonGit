using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPDSSimulator
{
    class EnergyHarvestingNode
    {
        private static int[] PriorityNumbersToCompare = new int[SimulationSettings.NodeCount];
        
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
                        cactive= 0;
                        sleep = true;
                    }
                }

                ThreadLocker.Bar.SignalAndWait();
                if (SimulationSettings.RealTimeView)
                    Thread.Sleep(100);
            }
        }

        public EnergyHarvestingNode()
        {
            for (int i = 0; i < SimulationSettings.NodeCount; i++)
            {
                PriorityNumbersToCompare[i] = new int();
            }
        }

        public void Sleep(int second)
        {
            Supercapacitor.SCUsage("SLP");
            EnergyHarvester.HarvestEnergy(second);
            //Console.WriteLine("{0} EHN SLEEPING", second + 1);
        }

        public void Active(int second)
        {
            //Console.WriteLine("{0} EHN ACTIVE", second + 1);
        }

        public static string InvokeTPDS(int priorityNumber)
        {
            string permission;
            permission = TPDSModule.GetPermission(priorityNumber);
            return permission;
        }

        public static void ReceiveMessage(int nodeID, Message rm, int second)
        {
            Message receivedMessage;
            receivedMessage = rm;
            Supercapacitor.SCUsage("RCV", receivedMessage.MessageType);
            Console.WriteLine("{0} node {1} --- RCV --- PN {2} --- ID {3}",
                second,
                nodeID,
                receivedMessage.MessageType,
                receivedMessage.MessageID);
            RecordStatistics.RecordReceived(receivedMessage.MessageType);
            Supercapacitor.SCUsage("SND", receivedMessage.MessageType);
        }
    }
}
