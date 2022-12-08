using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

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
                    },0);
            Kandidat k = new Kandidat("Bakir", "Izetbegović","1");
            s1.Rukovodstvo.Add(k);
            StringAssert.StartsWith(s1.RezultatiRukovodstva(), "Naziv stranke: SDA");
            StringAssert.Contains(s1.RezultatiRukovodstva(), "Identifikacioni broj");
        }

    }
}
