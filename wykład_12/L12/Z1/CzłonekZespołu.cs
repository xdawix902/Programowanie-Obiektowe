using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class CzłonekZespołu
    {
        public string Imie { get; set; }
        public string Naziwsko { get; set; }

        public CzłonekZespołu(string imie, string naziwsko)
        {
            Imie = imie;
            Naziwsko = naziwsko;
        }
    }
}
