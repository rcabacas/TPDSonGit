using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class EnergyHarvester
    {
        static Object locker = new Object();

        /// <summary>
        /// Harvests energy.
        /// </summary>
        public static void HarvestEnergy(int second)
        {
            double harvestedEnergy = 0;
            bool solarActive = SimulationSettings.SolarEnergy;

            CheckHarvesterActivity(second);

            if (SimulationSettings.SolarEnergy)
            {
                harvestedEnergy += HarvestSolar();
                if (SimulationSettings.ConsoleView)
                {
                    Console.WriteLine("Solar harvester active");
                }
            }
            else
            {
                if (SimulationSettings.ConsoleView)
                {
                    Console.WriteLine("Solar harvester inactive");
                }
            }
            if (SimulationSettings.WindEnergy)
            {
                harvestedEnergy += HarvestWind();
                Console.WriteLine("Wind harvester active");
            }
            else
            {
                if (SimulationSettings.ConsoleView)
                {
                    Console.WriteLine("Wind harvester inactive");
                }
            }
            if (SimulationSettings.PiezoEnergy)
            {
                harvestedEnergy += HarvestPiezo();
                Console.WriteLine("Mechanical harvester active");
            }
            else
            {
                if (SimulationSettings.ConsoleView)
                {
                    Console.WriteLine("Mechanical harvester inactive");
                }
            }
            if (SimulationSettings.HeatEnergy)
            {
                harvestedEnergy += HarvestHeat();
                Console.WriteLine("Heat harvester active");
            }
            else
            {
                if (SimulationSettings.ConsoleView)
                {
                    Console.WriteLine("Heat harvester inactive");
                }
            }

            lock(locker)
            {
                Supercapacitor.TotalEnergy += harvestedEnergy;
            }

            harvestedEnergy = 0;
        }

        private static void CheckHarvesterActivity(int second)
        {
            if (second >= SimulationSettings.SolarInactiveStart
                || second <= SimulationSettings.SolarInactiveEnd)
            {
                SimulationSettings.SolarEnergy = false;
            }
            else
            {
                SimulationSettings.SolarEnergy = true;
            }

            if (second >= SimulationSettings.WindInactiveStart
                || second <= SimulationSettings.WindInactiveEnd)
            {
                SimulationSettings.WindEnergy = false;
            }
            else
            {
                SimulationSettings.WindEnergy = true;
            }

            if (second >= SimulationSettings.PiezoInactiveStart
                || second <= SimulationSettings.PiezoInactiveEnd)
            {
                SimulationSettings.PiezoEnergy= false;
            }
            else
            {
                SimulationSettings.PiezoEnergy = true;
            }

            if (second >= SimulationSettings.HeatInactiveStart
                || second <= SimulationSettings.HeatInactiveEnd)
            {
                SimulationSettings.HeatEnergy = false;
            }
            else
            {
                SimulationSettings.HeatEnergy = true;
            }
        }

        private static double HarvestSolar()
        {
            Random randomObject = new Random(SimulationTimer.tCount);
            //return GenerateRandomDouble(randomObject, 0.000022, 0.000032);
            return GenerateRandomDouble(randomObject, 0.0, 0.000032);
        }

        private static double HarvestWind()
        {
            Random randomObject = new Random(SimulationTimer.tCount);
            //return GenerateRandomDouble(randomObject, 0.000022, 0.000032);
            return GenerateRandomDouble(randomObject, 0.0, 0.000032);
        }

        private static double HarvestPiezo()
        {
            Random randomObject = new Random(SimulationTimer.tCount);
            //return GenerateRandomDouble(randomObject, 0.0039, 0.0049);
            return GenerateRandomDouble(randomObject, 0.0, 0.0049);
        }

        private static double HarvestHeat()
        {
            Random randomObject = new Random(SimulationTimer.tCount);
            //return GenerateRandomDouble(randomObject, 0.00049, 0.00059);
            return GenerateRandomDouble(randomObject, 0.0, 0.00059);
        }

        private static double GenerateRandomDouble(Random ro, double min, double max)
        {
            return ro.NextDouble() * (max - min) + min;
        }
        
    }
}
