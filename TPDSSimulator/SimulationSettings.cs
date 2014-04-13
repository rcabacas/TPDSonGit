using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class SimulationSettings
    {
        private static int simulationTime;
        private static int interval;
        private static int dutycycle;
        private static int nodeCount;
        private static int messageCount;
        private static double batteryCapacity;
        private static double initialEnergy;
        private static double transmitPower;
        private static double receivePower;
        private static double sleepPower;
        private static double mcuActivePower;
        private static bool solarEnergy;
        private static int solarInactiveStart;
        private static int solarInactiveEnd;
        private static bool windEnergy;
        private static int windInactiveStart;
        private static int windInactiveEnd;
        private static bool piezoEnergy;
        private static int piezoInactiveStart;
        private static int piezoInactiveEnd;
        private static bool heatEnergy;
        private static int heatInactiveStart;
        private static int heatInactiveEnd;
        private static bool allowZero;
        private static bool traceEnergyHarvesting;
        private static bool traceSleep;
        private static bool traceRTS;
        private static bool traceCTS;
        private static string tracefile;
        private static bool consoleview;
        private static bool outputConfigurations;
        private static bool realTimeView;

        public static int SimulationTime {
            get { return simulationTime; }
            set { simulationTime = value; }
        }

        public static int Interval {
            get { return interval; }
            set { interval = value; }
        }

        public static int DutyCycle {
            get { return dutycycle; }
            set { dutycycle = value; }
        }

        public static int NodeCount {
            get { return nodeCount; }
            set { nodeCount = value; }
        }

        public static int MessageCount {
            get { return messageCount; }
            set { messageCount = value; }
        }

        public static double BatteryCapacity {
            get { return batteryCapacity; }
            set { batteryCapacity = value; }
        }

        public static double InitialEnergy {
            get { return initialEnergy; }
            set { initialEnergy = value; }
        }

        public static double TransmitPower {
            get { return transmitPower; }
            set { transmitPower = value; }
        }

        public static double ReceivePower {
            get { return receivePower; }
            set { receivePower = value; }
        }

        public static double SleepPower {
            get { return sleepPower; }
            set { sleepPower = value; }
        }

        public static double MCUActivePower {
            get { return mcuActivePower; }
            set { mcuActivePower = value; }
        }

        public static bool SolarEnergy {
            get { return solarEnergy; }
            set { solarEnergy = value; }
        }

        public static int SolarInactiveStart {
            get { return solarInactiveStart; }
            set { solarInactiveStart = value; }
        }

        public static int SolarInactiveEnd
        {
            get { return solarInactiveEnd; }
            set { solarInactiveEnd = value; }
        }

        public static bool WindEnergy
        {
            get { return windEnergy; }
            set { windEnergy = value; }
        }

        public static int WindInactiveStart
        {
            get { return windInactiveStart; }
            set { windInactiveStart = value; }
        }

        public static int WindInactiveEnd
        {
            get { return windInactiveEnd; }
            set { windInactiveEnd = value; }
        }

        public static bool PiezoEnergy
        {
            get { return piezoEnergy; }
            set { piezoEnergy = value; }
        }

        public static int PiezoInactiveStart
        {
            get { return piezoInactiveStart; }
            set { piezoInactiveStart = value; }
        }

        public static int PiezoInactiveEnd
        {
            get { return piezoInactiveEnd; }
            set { piezoInactiveEnd = value; }
        }

        public static bool HeatEnergy
        {
            get { return heatEnergy; }
            set { heatEnergy = value; }
        }

        public static int HeatInactiveStart
        {
            get { return heatInactiveStart; }
            set { heatInactiveStart = value; }
        }

        public static int HeatInactiveEnd
        {
            get { return heatInactiveEnd; }
            set { heatInactiveEnd = value; }
        }

        public static bool AllowZero
        {
            get { return allowZero; }
            set { allowZero = value; }
        }

        public static bool TraceEnergyHarvesting
        {
            get { return traceEnergyHarvesting; }
            set { traceEnergyHarvesting = value; }
        }

        public static bool TraceSleep
        {
            get { return traceSleep; }
            set { traceSleep = value; }
        }

        public static bool TraceRTS
        {
            get { return traceRTS; }
            set { traceRTS = value; }
        }

        public static bool TraceCTS
        {
            get { return traceCTS; }
            set { traceCTS = value; }
        }

        public static string TraceFile
        {
            get { return tracefile; }
            set { tracefile = value; }
        }

        public static bool ConsoleView
        {
            get { return consoleview; }
            set { consoleview = value; }
        }

        public static bool OutputConfiguration
        {
            get { return outputConfigurations; }
            set { outputConfigurations = value; }
        }

        public static bool RealTimeView
        {
            get { return realTimeView; }
            set { realTimeView = value; }
        }
        
    }
}
