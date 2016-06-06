using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class Fertigungsauftrag
    {
        public String artikel { get; set; }
        public String menge { get; set; }
        public void setMenge(String m)
        {
            menge = m;
            if (Convert.ToInt32(menge) < 0)
            {
                menge = "0";
            }
        }

        public Fertigungsauftrag() { }
    }
}
