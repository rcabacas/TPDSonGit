using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class Supercapacitor
    {
        private static double totalEnergy = SimulationSettings.InitialEnergy;
        private static double batteryCapacity = SimulationSettings.BatteryCapacity;
        private static double solarEnergyHarvested;
        private static double windEnergyHarvested;
        private static double piezoEnergyHarvested;
        private static double heatEnergyHarvested;
        private static Object locker = new Object();

        public static double SolarEnergy
        {
            get { return solarEnergyHarvested; }
            set { solarEnergyHarvested = value; }
        }

        public static double WindEnergy
        {
            get { return windEnergyHarvested; }
            set { windEnergyHarvested = value; }
        }

        public static double PiezoEnergy
        {
            get { return piezoEnergyHarvested; }
            set { piezoEnergyHarvested = value; }
        }

        public static double HeatEnergy
        {
            get { return heatEnergyHarvested; }
            set { heatEnergyHarvested = value; }
        }

        public static double BatteryCapacity
        {
            get { return batteryCapacity; }
            set { batteryCapacity = value; }
        }

        public static double TotalEnergy
        {
            get { return totalEnergy; }
            set { lock(locker) { totalEnergy = value; } }
        }

        /// <summary>
        /// This method determines the battery state based on the total energy left
        /// relative to the total battery capacity
        /// </summary>
        /// <returns>Integer (1-5) representing the states of the battery</returns>
        public static int BatteryState()
        {
            double batteryCapacity = BatteryCapacity;
            double bte = TotalEnergy;
            int bs = 5;

            if (bte > 0 && bte < (0.10 * batteryCapacity))
            {
                bs = 1;
            }
            else if (bte > (0.11 * batteryCapacity)
                && bte < (0.20 * batteryCapacity))
            {
                bs = 2;
            }
            else if (bte > (0.21 * batteryCapacity)
                && bte < (0.30 * batteryCapacity))
            {
                bs = 3;
            }
            else if (bte > (0.31 * batteryCapacity)
                && bte < (0.40 * batteryCapacity))
            {
                bs = 4;
            }
            else if (bte > (0.41 * batteryCapacity))
            {
                bs = 5;
            }

            //if mechanical energy harvesting is inactive, lower the state of the supercapacitor
            if (!SimulationSettings.PiezoEnergy)
            {
                if (bs == 2 || bs == 3 || bs == 4 || bs == 5)
                    bs = bs - 1;
            }

            return bs;
        }

        /// <summary>
        /// Determines if the supercapacitor has reached its maximum capacity
        /// </summary>
        /// <returns>Boolean</returns>
        public static bool SCThresholdReached()
        {
            if (totalEnergy >= batteryCapacity)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Deducts energy from the supercapacitor based on the action and the priority number
        /// </summary>
        /// <param name="action">"RCV" or "SND"</param>
        /// <param name="pn">Priority number</param>
        public static void SCUsage(string action, int pn = 0)
        {
            double energyUsage = 0;
            double rEnergy = SimulationSettings.ReceivePower;
            double tEnergy = SimulationSettings.TransmitPower;
            double sEnergy = SimulationSettings.SleepPower;
            double mEnergy = SimulationSettings.MCUActivePower;

            if (action == "RCV")
            {
                //radio usage
                if (pn == 5)
                    energyUsage += rEnergy - 0.02;
                else if (pn == 4)
                    energyUsage += rEnergy - 0.015;
                else if (pn == 3)
                    energyUsage += rEnergy - 0.01;
                else if (pn == 2)
                    energyUsage += rEnergy - 0.005;
                else if (pn == 1)
                    energyUsage += rEnergy;

                //MCU usage
                energyUsage += mEnergy;
            }

            if (action == "SND")
            {
                //radio usage
                if (pn == 5)
                    energyUsage += tEnergy - 0.02;
                else if (pn == 4)
                    energyUsage += tEnergy - 0.015;
                else if (pn == 3)
                    energyUsage += tEnergy - 0.01;
                else if (pn == 2)
                    energyUsage += tEnergy - 0.005;
                else if (pn == 1)
                    energyUsage += tEnergy;

                //MCU usage
                energyUsage += mEnergy;
            }

            if (action == "SLP")
            {
                //MCU usage
                energyUsage += sEnergy;
            }

            lock (locker)
            {
                totalEnergy -= energyUsage;
                Trace.WriteTrace(action, totalEnergy);
            }

            energyUsage = 0;
        }
        
        /// <summary>
        /// Dtermines if supercapacitor is empty
        /// </summary>
        /// <returns></returns>
        public static bool SCisEmpty()
        {
            if (totalEnergy == 0)
                return true;
            else
                return false;
        }

        public static void SCLeakage(double leak)
        {
            lock (locker)
            {
                totalEnergy -= leak;
            }
        }
    }
}
