using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TPDSSimulator
{
    class XMLLoader
    {
        /// <summary>
        /// This method loads the configuration file and sets the values for 
        /// simulation time, battery capacity and energy harvesting source.
        /// </summary>
        /// <param name="config">URL to the configuration file (XML format)</param>
        /// <returns></returns>
        public static Configurations ParseSimulationConfiguration(string config)
        {
            XDocument doc = XDocument.Load(config);
            XElement ge = doc.Element("simulationConfiguration");
            XElement cycle = ge.Element("cycle");
            XElement energy = ge.Element("energy");
            XElement cons = ge.Element("consoleOptions");
            XElement es = ge.Element("energyHarvestingSources");
            XElement trace = ge.Element("traceOptions");

            //harvester activity
            XElement si = es.Element("sInactive");
            XElement wi = es.Element("wInactive");
            XElement pi = es.Element("pInactive");
            XElement hi = es.Element("hInactive");

            var nodeProperties = new Configurations(
                Convert.ToBoolean(cons.Element("ehConsoleView").Value),
                Convert.ToBoolean(cons.Element("outputConfigurations").Value),
                Convert.ToBoolean(cons.Element("realTime").Value),
                Convert.ToBoolean(es.Element("solar").Value),
                Convert.ToInt32(si.Element("start").Value),
                Convert.ToInt32(si.Element("end").Value),
                Convert.ToBoolean(es.Element("wind").Value),
                Convert.ToInt32(wi.Element("start").Value),
                Convert.ToInt32(wi.Element("end").Value),
                Convert.ToBoolean(es.Element("piezo").Value),
                Convert.ToInt32(pi.Element("start").Value),
                Convert.ToInt32(pi.Element("end").Value),
                Convert.ToBoolean(es.Element("heat").Value),
                Convert.ToInt32(hi.Element("start").Value),
                Convert.ToInt32(hi.Element("end").Value),
                Convert.ToBoolean(es.Element("allowZero").Value),
                Convert.ToBoolean(trace.Element("traceEnergyHarvesting").Value),
                Convert.ToBoolean(trace.Element("traceSleep").Value),
                Convert.ToBoolean(trace.Element("traceRTS").Value),
                Convert.ToBoolean(trace.Element("traceCTS").Value),
                ge.Element("traceFile").Value,
                Convert.ToInt32(cycle.Element("simulationTime").Value),
                Convert.ToInt32(cycle.Element("interval").Value),
                Convert.ToInt32(cycle.Element("dutyCycle").Value),
                Convert.ToInt32(ge.Element("nodes").Value),
                Convert.ToInt32(ge.Element("messages").Value),
                Convert.ToDouble(energy.Element("energyStorageCapacity").Value),
                Convert.ToDouble(energy.Element("initialEnergy").Value),
                Convert.ToDouble(energy.Element("transmitEnergy").Value),
                Convert.ToDouble(energy.Element("receiveEnergy").Value),
                Convert.ToDouble(energy.Element("sleepEnergy").Value),
                Convert.ToDouble(energy.Element("MCUActiveEnergy").Value)
                );

            return nodeProperties;
        }
    }
}
