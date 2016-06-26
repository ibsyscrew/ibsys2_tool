using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Artikel
    {
        public String id { set; get; }
        public String amount { set; get; }

        public Artikel(String a, String m)
        {
            this.id = a;
            this.amount = m;
        }
    }
}
