using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Zadaca1
{
    internal class Izbori
    {
        static void Main(string[] args)
        {

            Glasanje glasanje = new Glasanje();

            //INICIJALIZIRAT CU TESTNE PODATKE
            glasanje.Nezavisni = TestniNezavisniKandidati();
            glasanje.Stranke = TestneStranke();
            glasanje.Glasaci = TestniGlasaci();
            //

            Console.WriteLine("Izabrerite jednu od opcija:\n" +
              "1. Unos novog glasača\n" +
              "2. Glasanje\n" +
              "3. Rezultati izbora\n" +
              "4. Izlaznost izbora\n" +
                "5. Izlistaj glasače\n" +
              "6. Izlaz iz programa"

              );
            int unos;
            while (true) {
                unos = Convert.ToInt32(Console.ReadLine());
                if (unos == 6) break;

                if (unos == 1)
                {
                    //Dodat unos podataka (ime, prezime, itd.)
                    Console.WriteLine("Unesite Ime: ");
                    string ime = Console.ReadLine();
                    Console.WriteLine("Unesite prezime: ");
                    string prezime = Console.ReadLine();
                    Console.WriteLine("Unesite adresu stanovanja: ");
                    string adresa = Console.ReadLine();
                    Console.WriteLine("Unesite datum rodjenja u formatu MM/dd/yyyy: ");
                    DateTime datum = Convert.ToDateTime(Console.ReadLine());
                    Console.WriteLine("Unesite broj licne karte: ");
                    string licnaKarta = Console.ReadLine();
                    Console.WriteLine("Unesite JMBG: ");
                    string jmbg = Console.ReadLine();

                    Glasac g = new Glasac(ime, prezime, adresa, datum, licnaKarta, jmbg);
                    glasanje.dodajGlasaca(g);

                    Console.WriteLine("");
                    Console.WriteLine("ID unesenog glasaca je: ");
                    g.PrikaziGlasaca();
                    Console.WriteLine("");
                }
                else if (unos == 2)
                {
                    /*U toku ispisa Stranaka,Kandidata i Nezavisnih kandidata prikazujem broj glasova
                     Ovo koristim dok ne implementiramo oficijelni prikaz rezultata glasanja*/
                    Console.WriteLine("Unesite vas Id:");
                    string id = Console.ReadLine();

                    //Ovdje treba napraviti provjeru da li postoji glasac na listi sa tim Id-ijem i da li je vec glasao
                    //, ako ima nastavlja se sa glasanjem
                    Glasac trenutniGlasac = glasanje.getGlasac(id);
                    if (trenutniGlasac == null)
                    {
                        Console.WriteLine("Ne postoji glasac sa tim id-em");
                        Console.WriteLine("");

                    }
                    else if (trenutniGlasac.Glasao == true)
                    {
                        Console.WriteLine("Glasac sa datim id-om je već glasao!");
                        Console.WriteLine("");
                    }
                    else {
                        Console.WriteLine("");
                        IspisKandidataIStranaka(glasanje); // ispisuje sve stranke i kandidate 
                        Console.WriteLine("Odaberite redni broj stranke za koju želite glasati ili listu neovisnih kandidata:");
                        int brStranka = IspisStranaka(glasanje); /*Ispis stranaka za odabir po rednom broju, 
                                                  u ovoj ce se metodi prikazati i opcija nezavisni kandidati
                                                  ,vraca broj stranaka da bi se nezavisni kandidati stavili na opciju brStranaka+1*/
                        Console.WriteLine((brStranka + 1).ToString() + ". " + "Neovisni kandidati");

                        int odabirStranke = Convert.ToInt32(Console.ReadLine()); //upisuje se broj stranke
                        if (odabirStranke == brStranka + 1) //slucaj da su odabrani nezavisni kandidati
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Odabrali ste glasanje za neovisnog kandidata");
                            IspisNezavisnihKandidata(glasanje);//ispisuje Nezavisne clanove sa rednim brojevima
                            int odabirKandidata = Convert.ToInt32(Console.ReadLine()); // Upis odabira kandidata (za pocetak se moze izabrati samo jedan, kasnije cemo prosirit funkcionalnost)
                            GlasajZaNezavisnog(trenutniGlasac, odabirKandidata, glasanje); //izvrsava se glasanje
                        }
                        else//odabrana stranka
                        {
                            GlasajZaStranku(trenutniGlasac, odabirStranke, glasanje);
                            Stranka odabranaStranka = glasanje.DajStranke().ElementAt(odabirStranke - 1);

                            if (odabranaStranka.Kandidati.Count == 0)
                                Console.WriteLine("Odabrana stranka nema kandidata");
                            else
                            {
                                List<int> odabiriKandidata = new List<int>() { };
                                string odabirKandidata = "";

                                Console.WriteLine("Odaberite redne brojeve kandidata stranke "
                                + "za kojeg želite glasati ili 0 za završetak\n"
                                + "Na primjer, odabir 1. i 2. kandidata mora biti u formi: '1/2' ");
                                Console.WriteLine("");
                                IspisKandidata(odabranaStranka.Kandidati);
                                odabirKandidata = Console.ReadLine();

                                odabiriKandidata = odabirKandidata.Split("/").Distinct().ToList().
                                                                 Select(int.Parse).ToList();
                                if (odabirKandidata == "0") break;

                                if (odabiriKandidata.Count != 0)
                                {
                                    GlasajZaKandidata(odabranaStranka, odabiriKandidata, glasanje); //glas i stranci i kandidatima
                                }
                            }
                        }

                    }
                }
                else if (unos == 5)
                {
                    if (glasanje.Glasaci.Count == 0)
                    {
                        Console.WriteLine("Nema glasača");
                    }
                    else
                    {
                        Console.WriteLine("Lista glasača:\n");
                        glasanje.PrikaziGlasace();
                    }


                }
                Console.WriteLine("");
                Console.WriteLine("Izabrerite jednu od opcija:\n" +
              "1. Unos novog glasača\n" +
              "2. Glasanje\n" +
              "3. Rezultati izbora\n" +
              "4. Izlaznost izbora\n" +
               "5. Izlistaj glasače\n" +
              "6. Izlaz iz programa"
              );
            }

        }

        private static void GlasajZaStranku(Stranka odabranaStranka)
        {
            odabranaStranka.DodajGlas();
        }

        private static void GlasajZaStrankuIKandidata(Stranka odabranaStranka, int odabirKandidata)
        {
            GlasajZaStranku(odabranaStranka);
            odabranaStranka.Kandidati.ElementAt(odabirKandidata - 1).dodajGlas();
        }

        private static int IspisStranaka(Glasanje glasanje)
        {
            List<Stranka> stranke = glasanje.Stranke;
            int i = 1;
            foreach (Stranka stranka in stranke)
            {
                Console.WriteLine(i.ToString() + ". " + stranka.Naziv);
                i++;
            }
            //Ispis imena stranaka sa rednim brojevima
            return glasanje.Stranke.Count();
        }

        private static void IspisNezavisnihKandidata(Glasanje glasanje)
        {
            //Ispis nezavisnih kandidata
            List<Kandidat> nezavisni = glasanje.DajNezavisne();

            Console.WriteLine("Nezavisni kandidati su: ");
            int i = 1;
            foreach (Kandidat k in nezavisni)
            {
                Console.WriteLine(i.ToString() + ". " + k.Ime + " " + k.Prezime + " Broj glasova: " + k.Broj_glasova);
                i++;
            }
        }
        private static void IspisKandidataIStranaka(Glasanje glasanje)
        {
            //Ispis stranaka i njihovih kandidata
            List<Stranka> stranke = glasanje.Stranke;

            Console.WriteLine("Lista stranki: ");
            int i = 1;
            foreach (Stranka s in stranke)
            {
                Console.WriteLine("---------");
                Console.WriteLine("Stranka " + i.ToString() + ": " + s.Naziv);
                s.ispisiKandidate();
                Console.WriteLine(" ");
                i++;
            }
        }

        private static void IspisKandidata(List<Kandidat> kandidati)
        {
            Console.WriteLine("Kandidati stranke su: ");
            int i = 1;
            foreach (Kandidat k in kandidati)
            {
                Console.WriteLine(i.ToString() + ". " + k.Ime + " " + k.Prezime);
                i++;
            }
        }

        private static void GlasajZaStranku(Glasac glasac, int odabirStranke, Glasanje glasanje)
        {
            glasanje.izvrsiGlasanjeZaStranku(glasac, odabirStranke);
        }
        private static void GlasajZaKandidata(Stranka stranka, List<int> odabraniKandidati, Glasanje glasanje)
        {
            glasanje.GlasajZaKandidateStranke(stranka, odabraniKandidati);
        }
        private static void GlasajZaNezavisnog(Glasac glasac, int odabirKandidata, Glasanje glasanje)
        {
            glasanje.izvrsiGlasanjeZaNezavisnog(glasac, odabirKandidata);
        }

        private static List<Kandidat> TestniNezavisniKandidati()
        {
            List<Kandidat> nezavisni = new List<Kandidat>()
            {
                    new Kandidat("Goran","Milošević","1"),
                    new Kandidat("Ćamil","Duraković","2"),
                    new Kandidat("Gazmend","Dačaj","3"),
                    new Kandidat("Slavko","Sekulić","4"),
            };

            return nezavisni;
        }
        private static List<Stranka> TestneStranke()
        {
            List<Stranka> stranke = new List<Stranka>()
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

            return stranke;
        }
        private static List<Glasac> TestniGlasaci()
        {
            List<Glasac> glasaci = new List<Glasac>()
            {
                new Glasac("Semina","Muratovic","Podigmanska 10",new DateTime(2001,06,07),"15987169","0706001175009"),
                 new Glasac("Adna","Cato","Mrakusa 70",new DateTime(2001,04,11),"15987169","0706001175009"),
                 new Glasac("Filip", "Maric", "Komari bb", new DateTime(2000,04,29), "5628795df", "290400176009")

            };
            return glasaci;

        }
    }
}
