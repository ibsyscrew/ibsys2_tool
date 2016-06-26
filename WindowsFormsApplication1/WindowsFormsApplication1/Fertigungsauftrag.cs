using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Fertigungsauftrag
    {
        public String id { get; set; }
        public String amount { get; set; }
        public void setMenge(String m)
        {
            amount = m;
            if (m != "")
            {
                if (Convert.ToInt32(amount) < 0)
                {
                    amount = "";
                }
            }
            else
            {
                amount = "0";
            }
        }

        public Fertigungsauftrag() { }
    }
}
