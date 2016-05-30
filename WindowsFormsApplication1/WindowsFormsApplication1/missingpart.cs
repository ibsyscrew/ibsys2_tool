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
        public List<waitinglist> waitinglistlist { set; get};

        Missingpart() { }
        Missingpart(String id)
        {
            this.id = id;
        }

    }
}
