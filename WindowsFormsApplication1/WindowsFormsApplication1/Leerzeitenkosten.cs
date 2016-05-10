using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    class Leerzeitenkosten //idletimecosts
    {
        public String workplace { set; get; }
        public String id { set; get; } 
        public String setupevents { set; get; }
        public String idletime { set; get; } 
        public String wageidletimecosts { set; get; }
        public String wagecosts { set; get; }
        public String machineidletimecosts { set; get; }

        public Leerzeitenkosten() { }

        public Leerzeitenkosten(String workplace, String id, String setupevents, String idletime,
            String wageidletimecosts, String wagecosts, String machineidletimecosts)
        {
            this.workplace = workplace;
            this.id = id;
            this.setupevents = setupevents;
            this.idletime = idletime;
            this.wageidletimecosts = wageidletimecosts;
            this.wagecosts = wagecosts;
            this.machineidletimecosts = machineidletimecosts;
                }


    }
}
