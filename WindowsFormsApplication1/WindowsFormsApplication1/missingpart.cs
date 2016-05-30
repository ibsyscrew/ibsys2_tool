using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Missingpart
    {
        public String id { set; get; }
        public List<Waitinglist2> waitinglistlist;

        public Missingpart() { }
        public Missingpart(String id)
        {
            this.id = id;
        }

    }
}
