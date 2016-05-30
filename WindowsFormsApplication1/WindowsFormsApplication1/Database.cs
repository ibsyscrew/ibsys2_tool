using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    static class Database
    {
        public static List<Futureinwardstockmovement> zukunftigeEingänge;
        public static List<Warehousestock> lager;
        public static List<Inwardstockmovement> bestellungen;
        public static List<Idletimecosts> strafkosten;
        public static List<Waitinglistworkstations> workstationswaitinglist;
        public static List<Missingpart> waitingliststock;
        public static List<Workplace> ordersinwork;
        public static List<Order> orders;
        public static List<Order2> cycletimes;

        public static List<NeueBestellung> neuebestellungen;
    }
}
