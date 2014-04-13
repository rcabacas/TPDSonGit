using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPDSSimulator
{
    class TPDSModule
    {
        public static string GetPermission(int priorityNumber)
        {
            string permission = "";
            int bs = Supercapacitor.BatteryState();
            int pn = priorityNumber;

            if (bs == 1 && pn == 1)
            {
                permission = "CTS";
            }
            else if (bs == 2 && (pn == 2 || pn == 1))
            {
                permission = "CTS";
            }
            else if (bs == 3 && (pn == 3 || pn == 2 || pn == 1))
            {
                permission = "CTS";
            }
            else if (bs == 4 && (pn == 4 || pn == 3 || pn == 2 || pn == 1))
            {
                permission = "CTS";
            }
            else if (bs == 5 && (pn == 5 || pn == 4 || pn == 3 || pn == 2 || pn == 1))
            {
                permission = "CTS";
            }
            else
            {
                permission = "NAK";
            }

            return permission;
        }
    }
}
