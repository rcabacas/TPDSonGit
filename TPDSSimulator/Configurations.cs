using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    struct Configurations
    {
        public readonly int simulationTime;
        public readonly int interval;
        public readonly int dutyCycle;
        public readonly int nodes;
        public readonly int messages;

        public readonly double energyStorageCapacity;
        public readonly double initialEnergy;
        public readonly double transmitEnergy;
        public readonly double receiveEnergy;
        public readonly double sleepEnergy;
        public readonly double mcuActiveEnergy;

        public readonly bool ehConsoleView;
        public readonly bool outputConfigurations;
        public readonly bool realTimeView;
        public readonly string traceFile;
        public readonly bool solarEnergy;
        public readonly int siStart; //solar inactive start
        public readonly int siEnd; //solar inactive end
        public readonly bool windEnergy;
        public readonly int wiStart; //wind inactive start
        public readonly int wiEnd; //wind inactive end
        public readonly bool piezoEnergy;
        public readonly int piStart; //piezo inactive start
        public readonly int piEnd; //piezo inactive end
        public readonly bool heatEnergy;
        public readonly int hiStart; //heat inactive start
        public readonly int hiEnd; //heat inactive end
        public readonly bool allowZero;
        public readonly bool traceEnergyHarvesting;
        public readonly bool traceSleep;
        public readonly bool traceRTS;
        public readonly bool traceCTS;
        
        /// <summary>
        /// Initializes the configuration from the XML file
        /// </summary>
        /// <param name="console">Option to view activity on console window</param>
        /// <param name="config">Option to view configuration settings on console window</param>
        /// <param name="rt">Switch real time view</param>
        /// <param name="solar">Switch solar energy</param>
        /// <param name="sis">Solar inactive start time</param>
        /// <param name="sie">Solar inactive end time</param>
        /// <param name="wind">Switch wind energy</param>
        /// <param name="wis">Wind inactive start time</param>
        /// <param name="wie">Wind inactive end time</param>
        /// <param name="piezo">Switch piezo energy</param>
        /// <param name="pis">Piezo inactive start time</param>
        /// <param name="pie">Piezo inactive end time</param>
        /// <param name="heat">Switch heat energy</param>
        /// <param name="his">Heat inactive start time</param>
        /// <param name="hie">Heat inactive end time</param>
        /// <param name="az">Allow zero energy</param>
        /// <param name="teh">Trace energy harvesting</param>
        /// <param name="ts">Trace sleep</param>
        /// <param name="trts">Trace RTS</param>
        /// <param name="tcts">Trace CTS</param>
        /// <param name="trace">Trace file name</param>
        /// <param name="st">Simulation time in seconds</param>
        /// <param name="interval">Node activity interval</param>
        /// <param name="dc">Node duty cycle</param>
        /// <param name="nn">Number of nodes to simulate</param>
        /// <param name="msgs">Number of messages to send</param>
        /// <param name="esc">Node energy storage capacity</param>
        /// <param name="ie">Node initial energy</param>
        /// <param name="te">Energy usage during transmission</param>
        /// <param name="re">Energy usage during receive</param>
        /// <param name="se">Energy usage during sleep</param>
        /// <param name="mcue">Energy spent by MCU during active state</param>
        public Configurations(
            bool console, bool config, bool rt, 
            bool solar, int sis, int sie,
            bool wind, int wis, int wie,
            bool piezo, int pis, int pie,
            bool heat, int his, int hie,
            bool az, bool teh,
            bool ts, bool trts,
            bool tcts,
            string trace,
            int st, int interval, int dc,
            int nn, int msgs,
            double esc, double ie,
            double te, double re,
            double se, double mcue
            )
        {
            //strings
            this.traceFile = trace;

            //boolean
            this.ehConsoleView = console;
            this.outputConfigurations = config;
            this.realTimeView = rt;
            this.solarEnergy = solar;
            this.windEnergy = wind;
            this.piezoEnergy = piezo;
            this.heatEnergy = heat;
            this.allowZero = az;
            this.traceEnergyHarvesting = teh;
            this.traceSleep = ts;
            this.traceRTS = trts;
            this.traceCTS = tcts;

            //integers
            this.simulationTime = st;
            this.interval = interval;
            this.dutyCycle = dc;
            this.nodes = nn;
            this.messages = msgs;
            this.siStart = sis;
            this.siEnd = sie;
            this.wiStart = wis;
            this.wiEnd = wie;
            this.piStart = pis;
            this.piEnd = pie;
            this.hiStart = his;
            this.hiEnd = hie;

            //doubles
            this.energyStorageCapacity = esc;
            this.initialEnergy = ie;
            this.transmitEnergy = te;
            this.receiveEnergy = re;
            this.sleepEnergy = se;
            this.mcuActiveEnergy = mcue;
        }
    }
}
