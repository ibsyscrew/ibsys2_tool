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
        public static List<Workplace> ordersinworkidsgesammelt;
        public static List<Order> orders;
        public static List<Order2> cycletimes;
        public static List<Prognose> prognosen = new List<Prognose>() { new Prognose("0"), new Prognose("1"), new Prognose("2"), new Prognose("3") };
        

        public static List<NeueBestellung> neuebestellungen = new List<NeueBestellung>();
        public static List<Fertigungsauftrag> fertigungsauftraege = new List<Fertigungsauftrag>();
        public static List<Arbeitsplatz> arbeitsplaetze = new List<Arbeitsplatz>();

        public static void zusammenrechnen()
        {
            for (int i = 0; i < ordersinwork.Count; i++)
            {
                for (int j = 0; j < ordersinworkidsgesammelt.Count; j++)
                {
                    if (ordersinwork[i].item == ordersinworkidsgesammelt[j].item)
                    {
                        ordersinworkidsgesammelt[j].item = (Convert.ToInt32(ordersinworkidsgesammelt[j].amount) + Convert.ToInt32(ordersinwork[i].amount)).ToString();
                    }
                }
            }
        }

        public static void mergearbeitsplaetze()
        {
            for (int i = 0; i < arbeitsplaetze.Count; i++)
            {
                for (int j = 0; j < arbeitsplaetze.Count; j++)
                {
                    if (arbeitsplaetze[i].station == arbeitsplaetze[j].station&&arbeitsplaetze[i]!=arbeitsplaetze[j])
                    {
                        //arbeitsplaetze[i].bearbeitungszeit = arbeitsplaetze[i].bearbeitungszeit + arbeitsplaetze[j].bearbeitungszeit;
                        arbeitsplaetze.Remove(arbeitsplaetze[i]);
                    }
                }
            }
        }

    }

 
}
