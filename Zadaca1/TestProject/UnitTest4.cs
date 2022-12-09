using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using CsvHelper;


namespace TestProject
{
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
            Kandidat k = new Kandidat("Bakir", "Izetbegović", "1");
            s1.Rukovodstvo.Add(k);
            StringAssert.StartsWith(s1.RezultatiRukovodstva(), "Naziv stranke: SDA");
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Ukupan broj glasova: 0");
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Identifikacioni broj");
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
        public void Test1(string naziv,int broj_glasova)
        {
            List<Kandidat>lista = new List<Kandidat>();
            lista.Add(new Kandidat("Bakir", "Izetbegović", "1"));
            lista.Add(new Kandidat("Šemsudin", "Dedić", "2"));
            lista.Add(new Kandidat("Sabina", "Hotić", "3"));
           
            Stranka stranka = new Stranka(naziv,broj_glasova);
            stranka.Rukovodstvo = lista;
            string rezultatPovratkaFunkcije =
                "Naziv stranke: " + naziv +
                "\nUkupan broj glasova: 0" +
                "\nKandidati: " +
                "\nIdentifikacioni broj: 1" +
                "\nIdentifikacioni broj: 2" +
                "\nIdentifikacioni broj: 3" ;
            Assert.AreEqual(rezultatPovratkaFunkcije, stranka.RezultatiRukovodstva());

        }

        #endregion


    }

}