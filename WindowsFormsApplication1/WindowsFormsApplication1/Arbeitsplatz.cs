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
        public String shift { get; set; }
        public String overtime { get; set; }
        public String set_up_time { get; set; }
        public int process_time { set; get; }
        public int total_process_time
        {
            get { return getBearbeitungszeit() ; }
            set { total_process_time = value; }
        }

        public int getBearbeitungszeit()
        {
            return process_time +Convert.ToInt32(set_up_time) + Convert.ToInt32(kapvor);
        }


        public String kapvor { get; set; }
        public String rustzeitvor { get; set; }
    }

}
