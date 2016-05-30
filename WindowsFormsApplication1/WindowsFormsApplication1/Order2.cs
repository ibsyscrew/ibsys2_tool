using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Order2
    {
        public String id { set; get; }
        public String period { set; get; }
        public String starttime { set; get; }
        public String finishtime { set; get; }
        public String cycletimemin { set; get; }
        public String cycletimefactor { set; get; }

        public Order2()
        {
        }

        public Order2(String id, String period, String starttime, String finishtime, String cycletimemin, String cycletimefactor)
        {
            this.id = id;
            this.period = period;
            this.starttime = starttime;
            this.finishtime = finishtime;
            this.cycletimemin = cycletimemin;
            this.cycletimefactor = cycletimefactor;
        }
    }
}
