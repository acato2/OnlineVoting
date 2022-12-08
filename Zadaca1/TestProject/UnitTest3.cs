using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void ispisiUkupanBrojGlasova()
        {
            Glasac glasac = new Glasac("Semina", "Muratovic", "Podigmanska 10", new DateTime(2001, 06, 07), "159E716", "0706001175009");
            Glasanje g = new Glasanje();
            Stranka s1 = new Stranka("SDA", new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    }, 0);
            Kandidat k = new Kandidat("Bakir", "Izetbegović", "1");
            List<int> lista = new List<int>(1);
            g.GlasajZaKandidateStranke(s1, lista);
            s1.DodajGlas();
            glasac.Glasaj(1, lista);
            StringAssert.StartsWith(g.ispisiUkupanBrojGlasova(1,s1.Kandidati.Count), "\nUkupan broj glasova je: 1");
            StringAssert.Contains(g.ispisiUkupanBrojGlasova(1, s1.Kandidati.Count), "Ukupan broj glasova u postotcima je: 33.33333333333333%");
        }

        [TestMethod]
        public void DajKandidateSaMandatima()
        {
            Glasac glasac = new Glasac("Semina", "Muratovic", "Podigmanska 10", new DateTime(2001, 06, 07), "159E716", "0706001175009");
            Glasanje g = new Glasanje();
            Stranka s1 = new Stranka("SDA", new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    }, 0);
            Kandidat k = new Kandidat("Bakir", "Izetbegović", "1"); //nezavisni kanidat

            g.Nezavisni = new List<Kandidat>() {k};
            g.Stranke = new List<Stranka>() {s1};

            List<int> lista = new List<int>() {1};

            g.GlasajZaKandidateStranke(s1, lista);
            s1.DodajGlas();
            glasac.Glasaj(1, lista);
            StringAssert.Contains(g.RezultatiMandata(), "Bakir Izetbegović");

        }



    }
}
