using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtrybutDefaultValue
{
    //[Obsolete("use something else")] // odkomentuj - ostrzeżenie kompilatora
    //[Obsolete("use something else", true)] // odkomentuj - błąd kompilacji
    public class TestowanieAtrybutu
    {
        [DefaultDayofWeekAttribute(2024, 05, 06)]        
        public string DzienTygodnia { get; set; }
    }
}
