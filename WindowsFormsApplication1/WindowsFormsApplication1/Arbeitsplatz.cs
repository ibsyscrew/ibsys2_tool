using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Arbeitsplatz
    {
        public String station { get; set; }
        public String schicht { get; set; }
        public String ueberstunden { get; set; }
        public String rustzeit { get; set; }
        public int bearbeitungszeit { set; get; }
        public int gesamtzeit
        {
            get { return getBearbeitungszeit() ; }
            set { gesamtzeit = value; }
        }

        public int getBearbeitungszeit()
        {
            return bearbeitungszeit +Convert.ToInt32(rustzeit) + Convert.ToInt32(kapvor);
        }


        public String kapvor { get; set; }
        public String rustzeitvor { get; set; }
    }

}
