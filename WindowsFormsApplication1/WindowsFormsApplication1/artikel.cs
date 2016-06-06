using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Artikel
    {
        public String artikel { set; get; }
        public String menge { set; get; }

        public Artikel(String a, String m)
        {
            this.artikel = a;
            this.menge = m;
        }
    }
}
