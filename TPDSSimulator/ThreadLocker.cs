using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPDSSimulator
{
    class ThreadLocker
    {
        static Barrier _barrier = new Barrier(SimulationSettings.NodeCount+1);

        public static Barrier Bar
        {
            get { return _barrier; }
            set { _barrier = value; }
        }
    }
}
