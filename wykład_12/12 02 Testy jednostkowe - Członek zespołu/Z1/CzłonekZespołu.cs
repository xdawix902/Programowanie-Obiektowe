using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public class CzłonekZespołu
    {
        public string firstName;
        string familyName;
        int age;
        public CzłonekZespołu(string firstName, string familyName, int age)
        {
            this.firstName = firstName;
            this.familyName = familyName;
            this.age = age;
        }
        public string FamilyName
        {
            get { return familyName; }
            set { familyName = value; }
        }
    }
}
