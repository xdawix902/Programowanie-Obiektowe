using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1.Tests
{
    public class CzłonekZespołuTests
    {
        [Test]
        public void CzłonekZespołuTestCreateInstance()
        {
            CzłonekZespołu JohnBonham = new CzłonekZespołu("John", "Bonham", 32);
            // Testujemy czy powstał obiekt założonego typu
            Assert.IsTrue(typeof(CzłonekZespołu).IsInstanceOfType(JohnBonham));
        }

        [Test]
        public void CzłonekZepołuTestFirstNameField()
        {
            CzłonekZespołu JohnDoe = new CzłonekZespołu("John", "Doe", 100);
            // Testujemy, czy pole publiczne ma określoną wartość
            // Można IsTrue(), można AreEqual()
            Assert.IsTrue(JohnDoe.firstName == "John");
        }

        [Test]
        public void CzłonekZepołuTestFamilyNameGet()
        {
            CzłonekZespołu JohnDoe = new CzłonekZespołu("John", "Doe", 100);
            // Testujemy, czy właściwość pobiera określoną wartość
            // Można IsTrue(), można AreEqual()
            Assert.AreEqual(JohnDoe.FamilyName,"Doe");
        }
    }
}
