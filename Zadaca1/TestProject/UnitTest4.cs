using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace TestProject
{
    /* Unit testovi za funkcionalnost 4 - Adna Ćato */
    [TestClass]
    public class UnitTest4
    {
        [TestMethod]
        public void TestPrikazaInformacijaORukovodstvu()
        {

            Stranka s1 = new Stranka("SDA", new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    }, 0);
            Kandidat k = s1.Kandidati[0]; //kandidat 1 ide u rukovodstvo
            s1.Rukovodstvo.Add(k);
            CollectionAssert.Contains(s1.Rukovodstvo, k);
            StringAssert.StartsWith(s1.RezultatiRukovodstva(), "Naziv stranke: SDA");
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Ukupan broj glasova: 0");
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Identifikacioni broj: 1");
        }

        [TestMethod]
        public void TestPrikazaInformacijaORukovodstvu2()
        {
            /* ispitujemo da li se povecava broj glasova u rukovodstvu prilikom glasanja */

            Glasac glasac = new Glasac("Semina", "Muratovic", "Podigmanska 10", new DateTime(2001, 06, 07), "159E716", "0706001175009");
            Glasanje g = new Glasanje();
            Stranka s1 = new Stranka("SDA", new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    }, 0);
            Kandidat k = s1.Kandidati[0]; //kandidat ide u rukovodstvo
            g.Nezavisni = new List<Kandidat>() { k };
            g.Stranke = new List<Stranka>() { s1 };
            List<int> lista = new List<int>() { 1 };
            g.GlasajZaKandidateStranke(s1, lista);
            s1.DodajGlas();
            glasac.Glasaj(1, lista);

            s1.Rukovodstvo.Add(k);

            CollectionAssert.Contains(s1.Rukovodstvo, k);
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Ukupan broj glasova: 1");
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Identifikacioni broj: 1");
        }

        #region InlineTestovi
        static IEnumerable<object[]> Stranke
        {
            get
            {
                return new[]
                {
                 new object[] { "SDA",305},
                 new object[] { "SDP",306},
                 new object[] { "SNSD",307}

                };
            }
        }

        [TestMethod]
        [DynamicData("Stranke")]
        public void Test1(string naziv, int broj_glasova)
        {
            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Bakir", "Izetbegović", "1"));
            lista.Add(new Kandidat("Šemsudin", "Dedić", "2"));
            lista.Add(new Kandidat("Sabina", "Hotić", "3"));

            Stranka stranka = new Stranka(naziv, broj_glasova);
            stranka.Rukovodstvo = lista;
            string rezultatPovratkaFunkcije =
                "Naziv stranke: " + naziv +
                "\nUkupan broj glasova: 0" +
                "\nKandidati: " +
                "\nIdentifikacioni broj: 1" +
                "\nIdentifikacioni broj: 2" +
                "\nIdentifikacioni broj: 3";
            Assert.AreEqual(rezultatPovratkaFunkcije, stranka.RezultatiRukovodstva());

        }

        #endregion


        #region CSV Testovi

        static IEnumerable<object[]> StrankeCSV
        {
            get
            {
                return UcitajPodatkeCSV();
            }
        }

        public static IEnumerable<object[]> UcitajPodatkeCSV()
        {
            using (var reader = new StreamReader("podaci4.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { elements[0], elements[1] };
                }
            }
        }

        [TestMethod]
        [DynamicData("StrankeCSV")]
        public void Test2(string naziv, string broj_glasova)
        {
            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Bakir", "Izetbegović", "1"));
            lista.Add(new Kandidat("Šemsudin", "Dedić", "2"));
            lista.Add(new Kandidat("Sabina", "Hotić", "3"));

            Stranka stranka = new Stranka(naziv, Int32.Parse(broj_glasova));
            stranka.Rukovodstvo = lista;
            string rezultatPovratkaFunkcije =
                "Naziv stranke: " + naziv +
                "\nUkupan broj glasova: 0" +
                "\nKandidati: " +
                "\nIdentifikacioni broj: 1" +
                "\nIdentifikacioni broj: 2" +
                "\nIdentifikacioni broj: 3";
            Assert.AreEqual(rezultatPovratkaFunkcije, stranka.RezultatiRukovodstva());

        }

        #endregion

    }

}