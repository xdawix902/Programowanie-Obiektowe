using L12;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1Tests
{
    [TestFixture]
    class CzłonekZespołuTests
    {
        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekRowny()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "", 12);

            Assert.AreEqual(0,a.CompareTo(b));
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekWiekszy()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 14);
            CzłonekZespołu b = new CzłonekZespołu("", "", 12);

            Assert.Greater(a.CompareTo(b), 0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespolu_WiekMniejszy()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 10);
            CzłonekZespołu b = new CzłonekZespołu("", "", 12);

            Assert.Less(a.CompareTo(b), 0);
        }

        [Test]
        public void TestPorowananiaDwochCzlonkowZespolu_RoznyWiek()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "", 15);
            CzłonekZespołu b = new CzłonekZespołu("", "", 20);

            Assert.AreNotEqual(0, a.CompareTo(b));
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RowneNazwiska()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "Fistaszek", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "Fistaszek", 15);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.AreEqual(0, comparer.Compare(a, b));
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_PierwszeNazwiskoMniejsze()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "Fist", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "Fistaszek", 15);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.Less(comparer.Compare(a, b), 0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_DrugieNazwiskoMniejsze()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "Fistaszek", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "Fist", 15);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.Greater(comparer.Compare(a, b), 0);
        }

        [Test]
        public void TestPorownaniaDwochCzlonkowZespoluPoNazwisku_RozneNazwiska()
        {
            CzłonekZespołu a = new CzłonekZespołu("", "Daes", 12);
            CzłonekZespołu b = new CzłonekZespołu("", "Fist", 15);
            CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer comparer = new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer();

            Assert.AreNotEqual(0, comparer.Compare(a, b));
        }

        [Test]
        public void TestToString_PoprawnyFormat()
        {
            CzłonekZespołu osoba = new CzłonekZespołu("Kuba", "Kowalski", 14);
            Assert.AreEqual("Kuba Kowalski 14", osoba.ToString());
        }

        [Test]
        public void TestTworzeniaObiektuCzlonkaZespolu_ZPoprawnymiDanymi()
        {
            CzłonekZespołu osoba = new CzłonekZespołu("Adrian", "Kowalski", 29);
            Assert.NotNull(osoba);
        }

        [Test]
        public void TestTworzeniaObiektuCzlonkaZespolu_ZNiepoprawnymiDanymi()
        {
            TestDelegate brakImienia = () => new CzłonekZespołu(null, "Eee", 12);
            Assert.Throws<ArgumentException>(brakImienia);

            TestDelegate brakNazwiska = () => new CzłonekZespołu("Tomek", null, 12);
            Assert.Throws<ArgumentException>(brakNazwiska);

            TestDelegate ujemnyWiek = () => new CzłonekZespołu("Tomek", "Eee", -5);
            Assert.Throws<ArgumentOutOfRangeException>(ujemnyWiek);
        }

    }
}
