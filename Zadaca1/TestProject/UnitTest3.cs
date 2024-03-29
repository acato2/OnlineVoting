﻿using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace TestProject
{
    /*Unit testove za funkcionalnost 3 je pisala Semina Muratović*/
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestIspisiUkupanBrojGlasova()
        {
            Glasac glasac = new Glasac("Semina", "Muratovic", "Podigmanska 10", new DateTime(2001, 06, 07), "159E716", "0706001175009");
            Glasanje g = new Glasanje();
            Stranka s1 = new Stranka("SDA", new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    }, 0);
            Kandidat k = s1.Kandidati[0]; //nezavisni kanidat

            g.Nezavisni = new List<Kandidat>() { k };
            g.Stranke = new List<Stranka>() { s1 };

            List<int> lista = new List<int>() { 1 };

            g.GlasajZaKandidateStranke(s1, lista);
            s1.DodajGlas();
            glasac.Glasaj(1, lista);

            StringAssert.StartsWith(g.ispisiUkupanBrojGlasova(1, s1.Kandidati.Count), "\nUkupan broj glasova je: 1");
            StringAssert.Contains(g.ispisiUkupanBrojGlasova(1, s1.Kandidati.Count), "Ukupan broj glasova u postotcima je: 33.33333333333333%");
        }

        [TestMethod]
        public void TestRezultatiMandata()
        {
            Glasac glasac = new Glasac("Semina", "Muratovic", "Podigmanska 10", new DateTime(2001, 06, 07), "159E716", "0706001175009");
            Glasanje g = new Glasanje();
            Stranka s1 = new Stranka("SDA", new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    }, 0);
            Kandidat k = s1.Kandidati[0]; //nezavisni kanidat

            g.Nezavisni = new List<Kandidat>() { k };
            g.Stranke = new List<Stranka>() { s1 };

            List<int> lista = new List<int>() { 1 };

            g.GlasajZaKandidateStranke(s1, lista);
            s1.DodajGlas();
            glasac.Glasaj(1, lista);

            StringAssert.Contains(g.RezultatiMandata(), "Bakir Izetbegović");

        }
        [TestMethod]
        public void TestRezultatiMandata2()
        {
            Glasac glasac = new Glasac("Semina", "Muratovic", "Podigmanska 10", new DateTime(2001, 06, 07), "159E716", "0706001175009");
            Glasanje g = new Glasanje();
            Kandidat k = new Kandidat("Goran", "Milošević", "1"); //nezavisni kanidat

            g.Nezavisni = new List<Kandidat>() { k };

            List<int> lista = new List<int>() { 1 };
            g.GlasajZaNezavisnog(1);
            glasac.Glasaj(1, lista);
            StringAssert.Contains(g.RezultatiMandata(), "Goran Milošević");

        }


        #region Inline Testovi

        static IEnumerable<object[]> Stranke
        {
            get
            {
                return new[]
                {
                 new object[] { "SDA",300}

                };
            }
        }


        [TestMethod]
        [DynamicData("Stranke")]
        public void Test1(string naziv, int broj_glasova)
        {
            Glasanje g = new Glasanje();
            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Bakir", "Izetbegović", "1"));
            lista.Add(new Kandidat("Šemsudin", "Dedić", "2"));
            lista.Add(new Kandidat("Sabina", "Hotić", "3"));
            Stranka stranka = new Stranka(naziv, broj_glasova);
            stranka.Kandidati = lista;
            String ispis = "";
            ispis = "\nUkupan broj glasova je: " + broj_glasova + "\n";
            ispis += "Ukupan broj glasova u postotcima je: " + (broj_glasova / (double)lista.Count) * 100 + "%";
            Assert.AreEqual(ispis, g.ispisiUkupanBrojGlasova(broj_glasova, lista.Count));
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
            using (var reader = new StreamReader("podaci3.csv"))
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

            Glasanje g = new Glasanje();
            List<Kandidat> lista = new List<Kandidat>();
            lista.Add(new Kandidat("Bakir", "Izetbegović", "1"));
            lista.Add(new Kandidat("Šemsudin", "Dedić", "2"));
            lista.Add(new Kandidat("Sabina", "Hotić", "3"));
            Stranka stranka = new Stranka(naziv, Int32.Parse(broj_glasova));
            stranka.Kandidati = lista;
            String ispis = "";
            ispis = "\nUkupan broj glasova je: " + Int32.Parse(broj_glasova) + "\n";
            ispis += "Ukupan broj glasova u postotcima je: " + (Int32.Parse(broj_glasova) / (double)lista.Count) * 100 + "%";
            Assert.AreEqual(ispis, g.ispisiUkupanBrojGlasova(Int32.Parse(broj_glasova), lista.Count));
        }

        #endregion



    }
}






