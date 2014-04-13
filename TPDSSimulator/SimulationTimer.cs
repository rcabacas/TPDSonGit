using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TPDSSimulator
{
    class SimulationTimer
    {
        static Timer _timer;
        public static int tCount = 0;
        public static void TStart()
        {
            _timer = new Timer(100);
            _timer.Elapsed += new ElapsedEventHandler(_timer_Elapsed);
            _timer.Start();
        }

        public static void TStop()
        {
            _timer.Stop();
        }

        private static void _timer_Elapsed(object sender, EventArgs e)
        {
            tCount++;
        }
    }
}
