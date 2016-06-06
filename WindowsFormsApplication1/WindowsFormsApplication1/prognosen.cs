using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    
    class Prognose
    {
        public string name { get; set; }
        public  List<Artikel> sellwish = new List<Artikel>() { new Artikel("1", "0"), new Artikel("2", "0"), new Artikel("3", "0") } ;

        public Prognose(string n)
        {
            this.name = n;
        }
    }
}
