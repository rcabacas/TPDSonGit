using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TPDSSimulator
{
    class Trace
    {
        //creates a new lock object
        static Object thisLock = new Object();
        static DateTime dt = DateTime.Now;
        static string fileName = SimulationSettings.TraceFile
            + "-" + dt.Month.ToString()
            + "-" + dt.Day.ToString()
            + "-" + dt.Year.ToString()
            + "-" + dt.Hour.ToString()
            + "-" + dt.Minute.ToString()
            + "-" + dt.Second.ToString()
            + ".txt";

        static string statisticsFileName = SimulationSettings.TraceFile
            + "-" + dt.Month.ToString()
            + "-" + dt.Day.ToString()
            + "-" + dt.Year.ToString()
            + "-" + dt.Hour.ToString()
            + "-" + dt.Minute.ToString()
            + "-" + dt.Second.ToString()
            + "STATISTICS.txt";

        /// <summary>
        /// Writes traces for every node activity
        /// </summary>
        /// <param name="state"></param>
        /// <param name="energy"></param>
        public static void WriteTrace(string state, double energy)
        {
            string output = state + "--" + energy.ToString();
            File.AppendAllText(fileName, output);
            File.AppendAllText(fileName, "\r\n");
        }

        /// <summary>
        /// Writes the statistics trace file
        /// Writes the configurations and simulation statistics
        /// </summary>
        public static void WriteStatisticsTrace()
        {
            //self explanatory code
            #region configuration
            string nodeCount =
                "Sensor Nodes: " +
                SimulationSettings.NodeCount + " sensors\n";
            File.AppendAllText(statisticsFileName, nodeCount);
            File.AppendAllText(statisticsFileName, "\r\n");

            string messageCount =
                "Messages: " +
                SimulationSettings.SimulationTime + " messages\n";
            File.AppendAllText(statisticsFileName, messageCount);
            File.AppendAllText(statisticsFileName, "\r\n");

            string simulationTime = 
                "Simulation Time: " + 
                SimulationSettings.SimulationTime + " seconds\n";
            File.AppendAllText(statisticsFileName, simulationTime);
            File.AppendAllText(statisticsFileName, "\r\n");

            string min;
            if (SimulationSettings.Interval > 1)
                min = " minutes";
            else
                min = " minute";

            string interval =
                "Interval: " +
                SimulationSettings.Interval + min + "\n";
            File.AppendAllText(statisticsFileName, interval);
            File.AppendAllText(statisticsFileName, "\r\n");

            string dutyCycle =
                "Duty Cycle: " +
                SimulationSettings.DutyCycle + " percent\n";
            File.AppendAllText(statisticsFileName, dutyCycle);
            File.AppendAllText(statisticsFileName, "\r\n");

            string batteryCapacity =
                "Battery Capacity: " +
                SimulationSettings.BatteryCapacity + " joules\n";
            File.AppendAllText(statisticsFileName, batteryCapacity);
            File.AppendAllText(statisticsFileName, "\r\n");

            string initialEnergy =
                "Initial Energy: " +
                SimulationSettings.InitialEnergy + " joules\n";
            File.AppendAllText(statisticsFileName, initialEnergy);
            File.AppendAllText(statisticsFileName, "\r\n");

            string finalEnergy =
                "Final Energy: " +
                Supercapacitor.TotalEnergy + " joules\n";
            File.AppendAllText(statisticsFileName, finalEnergy);
            File.AppendAllText(statisticsFileName, "\r\n");

            string transmitPower =
                "Transmit Power Consumption: " +
                SimulationSettings.TransmitPower + " watts\n";
            File.AppendAllText(statisticsFileName, transmitPower);
            File.AppendAllText(statisticsFileName, "\r\n");

            string receivePower =
                "Receive Power Consumption: " +
                SimulationSettings.ReceivePower + " watts\n";
            File.AppendAllText(statisticsFileName, receivePower);
            File.AppendAllText(statisticsFileName, "\r\n");

            string sleepPower =
                "Sleep Power Consumption: " +
                SimulationSettings.SleepPower + " watts\n";
            File.AppendAllText(statisticsFileName, sleepPower);
            File.AppendAllText(statisticsFileName, "\r\n");

            string mcuActivePower =
                "MCU Power Consumption: " +
                SimulationSettings.MCUActivePower + " watts\n";
            File.AppendAllText(statisticsFileName, mcuActivePower);
            File.AppendAllText(statisticsFileName, "\r\n");

            string solarEnergy =
                "Solar Energy: " +
                SimulationSettings.SolarEnergy.ToString() + "\n";
            File.AppendAllText(statisticsFileName, solarEnergy);
            File.AppendAllText(statisticsFileName, "\r\n");

            string windEnergy =
                "Wind Energy: " +
                SimulationSettings.WindEnergy.ToString() + "\n";
            File.AppendAllText(statisticsFileName, windEnergy);
            File.AppendAllText(statisticsFileName, "\r\n");

            string piezoEnergy =
                "Mechanical Energy: " +
                SimulationSettings.PiezoEnergy.ToString() + "\n";
            File.AppendAllText(statisticsFileName, piezoEnergy);
            File.AppendAllText(statisticsFileName, "\r\n");

            string heatEnergy =
                "Heat Energy: " +
                SimulationSettings.HeatEnergy.ToString() + "\n";
            File.AppendAllText(statisticsFileName, heatEnergy);
            File.AppendAllText(statisticsFileName, "\r\n");

            string allowZero =
                "Zero Energy: " +
                SimulationSettings.AllowZero.ToString() + "\n";
            File.AppendAllText(statisticsFileName, allowZero);
            File.AppendAllText(statisticsFileName, "\r\n");
            #endregion

            #region statistics
            string receivedP1MessagesString = 
                "Queued PN1 Messages: " + Statistics.QueuedP1Messages.ToString() + " -- " +
                "Dropped PN1 Messages: " + Statistics.DroppedP1Messages.ToString() + " -- " +
                "Received PN1 Messages: " + Statistics.ReceivedP1Messages.ToString();
            File.AppendAllText(statisticsFileName, receivedP1MessagesString);
            File.AppendAllText(statisticsFileName, "\r\n");

            string receivedP2MessagesString =
                "Queued PN2 Messages: " + Statistics.QueuedP2Messages.ToString() + " -- " +
                "Dropped PN2 Messages: " + Statistics.DroppedP2Messages.ToString() + " -- " +
                "Received PN2 Messages: " + Statistics.ReceivedP2Messages.ToString();
            File.AppendAllText(statisticsFileName, receivedP2MessagesString);
            File.AppendAllText(statisticsFileName, "\r\n");

            string receivedP3MessagesString =
                "Queued PN3 Messages: " + Statistics.QueuedP3Messages.ToString() + " -- " +
                "Dropped PN3 Messages: " + Statistics.DroppedP3Messages.ToString() + " -- " +
                "Received PN3 Messages: " + Statistics.ReceivedP3Messages.ToString();
            File.AppendAllText(statisticsFileName, receivedP3MessagesString);
            File.AppendAllText(statisticsFileName, "\r\n");

            string receivedP4MessagesString =
                "Queued PN4 Messages: " + Statistics.QueuedP4Messages.ToString() + " -- " +
                "Dropped PN4 Messages: " + Statistics.DroppedP4Messages.ToString() + " -- " +
                "Received PN4 Messages: " + Statistics.ReceivedP4Messages.ToString();
            File.AppendAllText(statisticsFileName, receivedP4MessagesString);
            File.AppendAllText(statisticsFileName, "\r\n");

            string receivedP5MessagesString =
                "Queued PN5 Messages: " + Statistics.QueuedP5Messages.ToString() + " -- " +
                "Dropped PN5 Messages: " + Statistics.DroppedP5Messages.ToString() + " -- " +
                "Received PN5 Messages: " + Statistics.ReceivedP5Messages.ToString();
            File.AppendAllText(statisticsFileName, receivedP5MessagesString);
            File.AppendAllText(statisticsFileName, "\r\n");

            File.AppendAllText(statisticsFileName,
                "Total Queued: " + Statistics.TotalQueuedMessages);
            File.AppendAllText(statisticsFileName, "\r\n");

            File.AppendAllText(statisticsFileName,
                "Total Sent: " + Statistics.TotalSentMessages);
            File.AppendAllText(statisticsFileName, "\r\n");

            File.AppendAllText(statisticsFileName,
                "Total Dropped: " + Statistics.TotalDroppedMessages);
            File.AppendAllText(statisticsFileName, "\r\n");
            #endregion
        }

    }
}
