using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace WindowsFormsApplication1
{
    class Ausstehende_Bestellungen //futureinwardstockmovement
    {
        public String orderperiod { set; get; }
        public String id { set; get; } 
        public String mode { set; get; } 
        public String article { set; get; } 
        public String amount { set; get; }

        public Ausstehende_Bestellungen() { }
        
        public Ausstehende_Bestellungen(String op,String id, String mode, String article, String amount)
        {
            this.orderperiod = op;
            this.id = id;
            this.mode = mode;
            this.article = article;
            this.amount = amount;
          }


    }
}


