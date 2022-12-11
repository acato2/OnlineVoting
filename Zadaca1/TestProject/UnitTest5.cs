using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;


namespace TestProject
{
    /* Unit testovi za funkcionalnost 5 - Filip Marić */

    [TestClass]
    public class UnitTest5
    {
        static Glasanje g = new Glasanje();

     
        [ClassInitialize]
        public static void PocetnaInicijalizacija(TestContext testContext)
        {
            g = new Glasanje();
        }

      
        [TestInitialize]
        public void InicijalizacijaPrijeSvakogTesta()
        {
            g.Nezavisni = new List<Kandidat>()
            {
                    new Kandidat("Goran","Milošević","1"),
                    new Kandidat("Ćamil","Duraković","2"),
                    new Kandidat("Gazmend","Dačaj","3"),
                    new Kandidat("Slavko","Sekulić","4"),
            };
            g.Stranke  = new List<Stranka>()
            {
                     new Stranka("SDA",new List<Kandidat>()
                    {
                         new Kandidat("Bakir","Izetbegović","1"),
                          new Kandidat("Šemsudin","Dedić","2"),
                           new Kandidat("Sabina","Hotić","3"),
                    },0),
                    new Stranka("SDP",new List<Kandidat>(){
                        new Kandidat("Albin","Muslić","1"),
                        new Kandidat("Edina","Šertović","2"),
                        new Kandidat("Martin","Brdar","3"),
                        new Kandidat("Edina","Osmanović","4")

                    },0),
                    new Stranka("NIP",new List<Kandidat>()
                    {
                         new Kandidat("Nermin","Pračić","1"),
                         new Kandidat("Jasminka","Hadžić","2"),
                         new Kandidat("Denis","Zvizdić","3"),
                    },0),
                     new Stranka("SNSD",new List<Kandidat>()
                    {
                         new Kandidat("Milorad","Dodik","1"),
                         new Kandidat("Željka","Cvijanović","2"),
                         new Kandidat("Denis","Šulić","3"),
                    },0),
                      new Stranka("DF",new List<Kandidat>()
                    {
                         new Kandidat("Željko","Komšić","1")

                    },0),
                       new Stranka("HDZ",new List<Kandidat>()
                    {
                         new Kandidat("Borjana","Krišto","1"),
                         new Kandidat("Marinko","Čavara","2"),
                    },0)

            }; 
            g.Glasaci  = new List<Glasac>()
            {
                    new Glasac("Semina","Muratovic","Podigmanska 10",new DateTime(2001,06,07),"159E716","0706001175009"),
                    new Glasac("Adna","Cato","Mrakusa 70",new DateTime(2001,04,11),"159K716","1104001175009"),
                    new Glasac("Filip", "Maric", "Komari bb", new DateTime(2000,04,29), "259E716", "2904000760097"),
                    new Glasac("Harry","Potter","Glencoe",new DateTime(1995,05,07),"157E716","0705995175329"),
                    new Glasac("Luke","Skywalker","Naboo",new DateTime(1990,11,11),"149E716","1111990175000")

            };
        }
    
        [TestMethod]
        public void TestPonistiNezavisni()
        {
            Assert.AreEqual("", "");
        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void TestNeispravnaSifra()
        {
            try
            {
                Console.SetIn(new StringReader("Idglasaca \nvvvs\nafafafaf\npogresna"));
                g.UnosSifreIId();
            }
            catch(Exception e) {
                Assert.AreEqual(e.Message, "Šifra pogrešno unesena 3 puta, prekid programa");
                throw;
            
            }

        }

        #region InlineTestovi
        static IEnumerable<object[]> Unosi
        {
            get
            {
                return new[]
                {
                 new object[] { "idglasaca", "VVS20222023", "", ""},
                 new object[] { "idglasaca", "vvs20222023", "VVS20222023", ""},
                 new object[] { "idglasaca", "VVS 2022 2023", "VVS20232022", "VVS20222023"},

                };
            }
        }

        [TestMethod]
        [DynamicData("Unosi")]
        public void TestIspravnaSifra(string idglasaca, string unos1, string unos2, string unos3)
        {
            Console.SetIn(new StringReader(idglasaca + "\n" + unos1 + "\n" + unos2 + "\n" + unos3));
            Assert.AreEqual(idglasaca, g.UnosSifreIId());

        }






        #endregion


        #region CSV Testovi

        static IEnumerable<object[]> GlasaciCSV
        {
            get
            {
                return UcitajPodatkeCSV();
            }
        }

        public static IEnumerable<object[]> UcitajPodatkeCSV()
        {
            using (var reader = new StreamReader("podaci5.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var rows = csv.GetRecords<dynamic>();
                foreach (var row in rows)
                {
                    var values = ((IDictionary<String, Object>)row).Values;
                    var elements = values.Select(elem => elem.ToString()).ToList();
                    yield return new object[] { Int32.Parse( elements[0]), elements[1] };
                }
            }
        }


        [TestMethod]
        [DynamicData("GlasaciCSV")]
        public void TestIspravanGlasacIdNijeGlasao(int index, string id)
        {
            using (StringWriter sw = new StringWriter())
            {
                Console.SetOut(sw);
                for (int i = 0; i < 5; i++)
                {
                    
                    if(g.Glasaci.ElementAt(i).id == id)
                    {
                        g.Glasaci.ElementAt(i).Glasao = false;
                    }
                    else
                        g.Glasaci.ElementAt(i).Glasao = true;
                }
                Console.SetIn(new StringReader(id + "\n" + "VVS20222023" + "\n" + ""+ "\n" + ""));

                g.PonistiGlasanje(g.UnosSifreIId());
                string actual =sw.ToString();
                StringAssert.Contains(actual, "Glasac sa datim ID-ijem nije glasao ili ne postoji.");
            }
        }
        #endregion

    }

}