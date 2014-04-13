using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPDSSimulator
{
    class Program
    {
        static void Main(string[] args)
        {
            string configURL = "C:/Users/UBSYS/Documents/Dropbox/TPDSSimulator/TPDSSimulator/configuration.xml";

            Initialize(configURL);
            
            int nodes = SimulationSettings.NodeCount;
            EnergyHarvestingNode en = new EnergyHarvestingNode();
            SensorNode[] sn = new SensorNode[nodes];
            Thread[] gs = new Thread[nodes];
            Thread[] snt = new Thread[nodes];

            //initialize sensor field with n number of messages
            SensorField.InitializeSensorField(SimulationSettings.MessageCount);

            //print out configurations on screen
            if (SimulationSettings.OutputConfiguration)
                OutputConfigurations();

            Console.WriteLine("\nProceed with Simulation?");
            Console.ReadLine();

            //initialize sensor nodes
            //assign each with an ID
            for (int i = 0; i < nodes; i++)
            {
                sn[i] = new SensorNode();
                sn[i].NodeID = i;
            }

            //threads for source generation for each sensor node
            for (int j = 0; j < nodes; j++)
                gs[j] = new Thread(new ThreadStart(sn[j].GenerateSource));
            //start source generating threads
            for (int k = 0; k < nodes; k++)
                gs[k].Start();
            //join all source generating threads and proceed to next process
            for (int l = 0; l < nodes; l++)
                gs[l].Join();
            //print out number of messages held by each node
            for (int m = 0; m < nodes; m++)
                Console.WriteLine("Data source {0}: {1} messages", sn[m].NodeID, sn[m].DataSourceCount);
            //threads for each sensor node to run
            for (int o = 0; o < nodes; o++)
                snt[o] = new Thread(new ThreadStart(sn[o].RunNode));
            //thread for energy harvesting node to run
            Thread ehrun = new Thread(new ThreadStart(en.RunNode));
            //run all sensor node threads
            for (int p = 0; p < nodes; p++)
                snt[p].Start();
            //run energy harvesting node thread
            ehrun.Start();
            //join all sensor node threads when finished
            for (int q = 0; q < nodes; q++)
                snt[q].Join();
            //join ehn thread when finished
            ehrun.Join();

            //write statistics file
            Console.WriteLine("Writing Statistics...");
            Trace.WriteStatisticsTrace();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nSIMULATION ENDED!");
            Console.Beep(2000, 500);
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the configuration settings on the screen
        /// </summary>
        private static void OutputConfigurations()
        {
            //self explanatory code
            Console.Write("Simulation Time: ");
            Yellow();
            Console.Write(SimulationSettings.SimulationTime + "\n");
            Reset();

            Console.Write("Battery Capacity: ");
            Yellow();
            Console.Write(SimulationSettings.BatteryCapacity + "\n");
            Reset();

            Console.Write("Initial Energy: ");
            Yellow();
            Console.Write(SimulationSettings.InitialEnergy + "\n");
            Reset();

            Console.Write("Transmit Power: ");
            Yellow();
            Console.Write(SimulationSettings.TransmitPower + "\n");
            Reset();

            Console.Write("Receive Power: ");
            Yellow();
            Console.Write(SimulationSettings.ReceivePower + "\n");
            Reset();

            Console.Write("Sleep Power: ");
            Yellow();
            Console.Write(SimulationSettings.SleepPower + "\n");
            Reset();

            Console.Write("MCU Active Power: ");
            Yellow();
            Console.Write(SimulationSettings.MCUActivePower + "\n");
            Reset();

            Console.Write("Solar Energy: ");
            if (SimulationSettings.SolarEnergy) 
            {
                Yellow();
                Console.Write(SimulationSettings.SolarEnergy + " ");
                Console.Write("(Inactive from {0} to {1})\n",
                    SimulationSettings.SolarInactiveStart,
                    SimulationSettings.SolarInactiveEnd);
            }
            else 
            {
                Red();
                Console.Write(SimulationSettings.SolarEnergy + "\n");
            }
            Reset();

            Console.Write("Wind Energy: ");
            if (SimulationSettings.WindEnergy)
            {
                Yellow();
                Console.Write(SimulationSettings.WindEnergy + " ");
                Console.Write("(Inactive from {0} to {1})\n",
                    SimulationSettings.WindInactiveStart,
                    SimulationSettings.WindInactiveEnd);
            }
            else
            {
                Red();
                Console.Write(SimulationSettings.WindEnergy + "\n");
            }
            Reset();

            Console.Write("Piezo Energy: ");
            if (SimulationSettings.PiezoEnergy)
            {
                Yellow();
                Console.Write(SimulationSettings.PiezoEnergy + " ");
                Console.Write("(Inactive from {0} to {1})\n",
                    SimulationSettings.PiezoInactiveStart,
                    SimulationSettings.PiezoInactiveEnd);
            }
            else
            {
                Red();
                Console.Write(SimulationSettings.PiezoEnergy + "\n");
            }
            Reset();

            Console.Write("Heat Energy: ");
            if (SimulationSettings.HeatEnergy)
            {
                Yellow();
                Console.Write(SimulationSettings.HeatEnergy + " - ");
                Console.Write("(Inactive from {0} to {1})\n",
                    SimulationSettings.HeatInactiveStart,
                    SimulationSettings.HeatInactiveEnd);
            }
            else
            {
                Red();
                Console.Write(SimulationSettings.HeatEnergy + "\n");
            }
            Reset();

            Console.Write("Allow Zero Energy: ");
            if (SimulationSettings.AllowZero)
                Yellow();
            else
                Red();
            Console.Write(SimulationSettings.AllowZero + "\n");
            Reset();

            Console.Write("Interval: ");
            Yellow();
            Console.Write(SimulationSettings.Interval + "\n");
            Reset();

            Console.Write("Duty Cycle: ");
            Yellow();
            Console.Write(SimulationSettings.DutyCycle + "\n");
            Reset();

            Console.Write("Node Count: ");
            Yellow();
            Console.Write(SimulationSettings.NodeCount + "\n");
            Reset();

            Console.Write("Message Count: ");
            Yellow();
            Console.Write(SimulationSettings.MessageCount + "\n");
            Reset();

            Console.Write("Console View: ");
            Yellow();
            Console.Write(SimulationSettings.ConsoleView + "\n");
            Reset();

            Console.Write("Output Configurations: ");
            Yellow();
            Console.Write(SimulationSettings.OutputConfiguration + "\n");
            Reset();

            Console.Write("Real Time View: ");
            if (SimulationSettings.RealTimeView)
                Yellow();
            else
                Red();
            Console.Write(SimulationSettings.RealTimeView + "\n");
            Reset();

            Console.Write("Trace File: ");
            Yellow();
            Console.Write(SimulationSettings.TraceFile + "\n");
            Reset();
        }

        /// <summary>
        /// Make things yellow
        /// </summary>
        private static void Yellow()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
        }

        /// <summary>
        /// Make red stuff
        /// </summary>
        private static void Red()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        /// <summary>
        /// Reset to boring white
        /// </summary>
        private static void Reset()
        {
            Console.ResetColor();
        }

        /// <summary>
        /// Initializes the simulation parameters using the configuration file
        /// </summary>
        /// <param name="config">XML configuration file</param>
        private static void Initialize(string config)
        {
            //trace file
            SimulationSettings.TraceFile = XMLLoader.ParseSimulationConfiguration(config).traceFile;

            //nodes and messages
            SimulationSettings.NodeCount = XMLLoader.ParseSimulationConfiguration(config).nodes;
            SimulationSettings.MessageCount = XMLLoader.ParseSimulationConfiguration(config).messages;

            //simulation
            SimulationSettings.SimulationTime = XMLLoader.ParseSimulationConfiguration(config).simulationTime;
            SimulationSettings.Interval = XMLLoader.ParseSimulationConfiguration(config).interval;
            SimulationSettings.DutyCycle = XMLLoader.ParseSimulationConfiguration(config).dutyCycle;

            //energy usage
            SimulationSettings.BatteryCapacity = XMLLoader.ParseSimulationConfiguration(config).energyStorageCapacity;
            SimulationSettings.InitialEnergy = XMLLoader.ParseSimulationConfiguration(config).initialEnergy;
            SimulationSettings.TransmitPower = XMLLoader.ParseSimulationConfiguration(config).transmitEnergy;
            SimulationSettings.ReceivePower = XMLLoader.ParseSimulationConfiguration(config).receiveEnergy;
            SimulationSettings.SleepPower = XMLLoader.ParseSimulationConfiguration(config).sleepEnergy;
            SimulationSettings.MCUActivePower = XMLLoader.ParseSimulationConfiguration(config).mcuActiveEnergy;

            //console view
            SimulationSettings.ConsoleView = XMLLoader.ParseSimulationConfiguration(config).ehConsoleView;
            SimulationSettings.OutputConfiguration = XMLLoader.ParseSimulationConfiguration(config).outputConfigurations;
            SimulationSettings.RealTimeView = XMLLoader.ParseSimulationConfiguration(config).realTimeView;

            //energy harvesting
            SimulationSettings.SolarEnergy = XMLLoader.ParseSimulationConfiguration(config).solarEnergy;
            SimulationSettings.SolarInactiveStart = XMLLoader.ParseSimulationConfiguration(config).siStart;
            SimulationSettings.SolarInactiveEnd = XMLLoader.ParseSimulationConfiguration(config).siEnd;
            SimulationSettings.WindEnergy = XMLLoader.ParseSimulationConfiguration(config).windEnergy;
            SimulationSettings.WindInactiveStart = XMLLoader.ParseSimulationConfiguration(config).wiStart;
            SimulationSettings.WindInactiveEnd = XMLLoader.ParseSimulationConfiguration(config).wiEnd;
            SimulationSettings.PiezoEnergy = XMLLoader.ParseSimulationConfiguration(config).piezoEnergy;
            SimulationSettings.PiezoInactiveStart = XMLLoader.ParseSimulationConfiguration(config).piStart;
            SimulationSettings.PiezoInactiveEnd = XMLLoader.ParseSimulationConfiguration(config).piEnd;
            SimulationSettings.HeatEnergy = XMLLoader.ParseSimulationConfiguration(config).heatEnergy;
            SimulationSettings.HeatInactiveStart = XMLLoader.ParseSimulationConfiguration(config).hiStart;
            SimulationSettings.HeatInactiveEnd = XMLLoader.ParseSimulationConfiguration(config).hiEnd;
            SimulationSettings.AllowZero = XMLLoader.ParseSimulationConfiguration(config).allowZero;

            //traces
            SimulationSettings.TraceEnergyHarvesting = XMLLoader.ParseSimulationConfiguration(config).traceEnergyHarvesting;
            SimulationSettings.TraceSleep = XMLLoader.ParseSimulationConfiguration(config).traceSleep;
            SimulationSettings.TraceCTS = XMLLoader.ParseSimulationConfiguration(config).traceRTS;
            SimulationSettings.TraceRTS = XMLLoader.ParseSimulationConfiguration(config).traceCTS;
        }
    }
}
