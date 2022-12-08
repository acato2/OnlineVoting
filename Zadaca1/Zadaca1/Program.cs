using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

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
              "6. Trenutni mandati\n" +
              "7. Poništi glasanje glasaču\n" + 
              "8. Izlaz iz programa"

              );
            int unos;
            while (true)
            {
                unos = Convert.ToInt32(Console.ReadLine());

                if (unos == 1)
                {
                    Glasac g=new Glasac();
                    //Dodat unos podataka (ime, prezime, itd.)
                    Console.WriteLine("Unesite Ime: ");
                    while (true)
                    {
                        try {
                            g.Ime = Console.ReadLine();
                            break;
                        }catch(Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Pokušajte ponovo!");
                            continue;
                        }
                    }

                    Console.WriteLine("Unesite prezime: ");
                    while (true)
                    {
                        try
                        {
                            g.Prezime = Console.ReadLine();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Pokušajte ponovo!");
                            continue;
                        }
                    }

                    Console.WriteLine("Unesite adresu stanovanja: ");
                    string adresa = Console.ReadLine();
                    g.Adresa = adresa;

                    Console.WriteLine("Unesite datum rodjenja u formatu MM/dd/yyyy: ");

                    while (true)
                    {
                        try
                        {
                            g.DatumRodjenja = Convert.ToDateTime(Console.ReadLine());
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Pokušajte ponovo!");
                            continue;
                        }
                    }

                    Console.WriteLine("Unesite broj licne karte: ");

                    while (true)
                    {
                        try
                        {
                            g.BrojLicne = Console.ReadLine();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Pokušajte ponovo!");
                            continue;
                        }
                    }

                    Console.WriteLine("Unesite JMBG: ");

                    while (true)
                    {
                        try
                        {
                            g.Jmbg = Console.ReadLine();
                            break;
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            Console.WriteLine("Pokušajte ponovo!");
                            continue;
                        }
                    }
                    try
                    {
                        g.Id = g.generisi_id();
                    }catch(Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    
                    glasanje.DodajGlasaca(g);

                    Console.WriteLine("");
                    Console.WriteLine("ID unesenog glasaca je: ");
                    g.PrikaziGlasaca();
                    Console.WriteLine("");
                }
                else if (unos == 2)
                {

                    Console.WriteLine("Unesite vas Id:");
                    string id = Console.ReadLine();

                    //Ovdje treba napraviti provjeru da li postoji glasac na listi sa tim Id-ijem i da li je vec glasao
                    //, ako ima nastavlja se sa glasanjem
                    Glasac trenutniGlasac = glasanje.GetGlasac(id);
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
                    else
                    {
                        Console.WriteLine("");
                        IspisKandidataIStranaka(glasanje);
                        IspisNezavisnihKandidata(glasanje);// ispisuje sve stranke i kandidate 
                        Console.WriteLine("Odaberite redni broj stranke za koju želite glasati ili listu neovisnih kandidata:");
                        int brStranka = IspisStranaka(glasanje); /*Ispis stranaka za odabir po rednom broju, 
                                                  u ovoj ce se metodi prikazati i opcija nezavisni kandidati
                                                  ,vraca broj stranaka da bi se nezavisni kandidati stavili na opciju brStranaka+1*/
                        Console.WriteLine((brStranka + 1).ToString() + ". " + "Neovisni kandidati");

                        int odabirStranke = Convert.ToInt32(Console.ReadLine()); //upisuje se broj stranke
                        if (odabirStranke == brStranka + 1) //slucaj da su odabrani nezavisni kandidati
                        {
                            Console.WriteLine("");
                            Console.WriteLine("Odabrali ste glasanje za nezavisnog kandidata");
                            IspisNezavisnihKandidata(glasanje);//ispisuje Nezavisne clanove sa rednim brojevima
                            int odabirKandidata = Convert.ToInt32(Console.ReadLine()); // Upis odabira kandidata (za pocetak se moze izabrati samo jedan, kasnije cemo prosirit funkcionalnost)
                            glasanje.GlasajZaNezavisnog(odabirKandidata);//izvrsava se glasanje
                            trenutniGlasac.Glasaj(-1,new List<int>(), odabirKandidata);
                        }
                        else//odabrana stranka
                        {
                            Stranka odabranaStranka = glasanje.Stranke.ElementAt(odabirStranke - 1);

                            if (odabranaStranka.Kandidati.Count == 0)
                                Console.WriteLine("Odabrana stranka nema kandidata");
                            else
                            {
                                List<int> odabiriKandidata = new List<int>() { };
                                string odabirKandidata = "";

                                Console.WriteLine("Odaberite redne brojeve kandidata stranke "
                                + "za kojeg želite glasati ili 0 ako hoćete samo za stranku\n"
                                + "Na primjer, odabir 1. i 2. kandidata mora biti u formi: '1/2' ");
                                Console.WriteLine("");
                                IspisKandidata(odabranaStranka.Kandidati);
                                odabirKandidata = Console.ReadLine();

                                odabiriKandidata = odabirKandidata.Split("/").Distinct().ToList().
                                                                 Select(int.Parse).ToList();

                                if (odabirKandidata == "0" && odabiriKandidata.Count == 1)
                                {
                                    odabranaStranka.DodajGlas(); //glas samo stranci
                                    trenutniGlasac.Glasaj(odabirStranke,new List<int>());

                                }

                                else if (odabiriKandidata.Count != 0)
                                {
                                    if (odabiriKandidata.Contains(0))
                                        odabiriKandidata.Remove(0);
                                    glasanje.GlasajZaKandidateStranke(odabranaStranka, odabiriKandidata); //glas i stranci i kandidatima
                                    odabranaStranka.DodajGlas();
                                    trenutniGlasac.Glasaj(odabirStranke, odabiriKandidata);

                                }
                            }
                        }

                    }
                }

                else if (unos == 3)
                {
                    glasanje.RezultatiGlasanja();
                }
                else if (unos == 4)
                {
                    Console.WriteLine("Trenutna izlaznost na izborima je " + glasanje.DajTrenutnuIzlaznost() + ".");
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
                else if (unos == 6)
                {
                    Console.WriteLine(glasanje.RezultatiMandata());
                    
                }
                else if (unos == 7)
                {
                    Console.WriteLine("\nUnesite identifikacioni broj glasača: ");
                    string unos_id = Console.ReadLine();
                    Console.WriteLine("\nUnesite tajnu šifru za ponistavanje glasanja: ");
                    for(int i = 0; i < 3; i++)
                    {
                        string unos_sifre = Console.ReadLine();
                        if(unos_sifre.Equals("VVS20222023"))
                        {
                            break;
                        }
                        else if(!unos_sifre.Equals("VVS20222023") && i==0)
                        {
                            Console.WriteLine("Pogrešna šifra, imate još 2 pokušaja: ");
                        }
                        else if(!unos_sifre.Equals("VVS20222023") && i==1)
                        {
                            Console.WriteLine("Pogrešna šifra, imate još 1 pokušaj: ");
                        }
                        else
                        {
                            Console.WriteLine("Šifra pogrešno unesena 3 puta, prekid programa");
                            System.Threading.Thread.Sleep(3000);
                            return;
                        }
                    }
                    PonistiGlasanje(glasanje, unos_id);
                    

                }
                else if (unos == 8)
                {
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine("Izabrerite jednu od opcija:\n" +
                "1. Unos novog glasača\n" +
                "2. Glasanje\n" +
                "3. Rezultati izbora\n" +
                "4. Izlaznost izbora\n" +
                "5. Izlistaj glasače\n" +
                "6. Trenutni mandati\n" +
                "7. Poništi glasanje glasaču\n" + 
                "8. Izlaz iz programa"
              );
            }

        }

        
        private static  void PonistiGlasanje(Glasanje glasanje, string glasac_id)
        {
            bool ponisteno = false;
            foreach(Glasac x in glasanje.Glasaci)
            {
                if (x.Id.Equals(glasac_id) && x.Glasao)
                {
                    ponisteno = true;
                    if(x.Glas_stranci != -1)
                    {
                        glasanje.Stranke.ElementAt(x.Glas_stranci-1).BrojGlasova--;
                        
                         if(x.Glas_kadnidatima.Count != 0)
                         {
                                foreach(int i in x.Glas_kadnidatima)
                                {
                                    glasanje.Stranke.ElementAt(x.Glas_stranci-1).Kandidati.ElementAt(i-1).BrojGlasova--;
                                }
                         }   
                         x.Glas_stranci = -1;
                        x.Glas_kadnidatima = new List<int>();
                    }
                    if(x.Glas_nezavisnom != -1)
                    {
                        glasanje.Nezavisni.ElementAt(x.Glas_nezavisnom-1).BrojGlasova--;
                        x.Glas_nezavisnom = -1;
                    }
                   
                    Console.WriteLine("Glasanje uspješno poništeno glasaču sa ID-ijem " + glasac_id);
                    x.Glasao = false;
                    break;
                    

                }
            }
            if (!ponisteno)
            {
                Console.WriteLine("Glasac sa datim ID-ijem nije glasao ili ne postoji.");
            }
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
            List<Kandidat> nezavisni = glasanje.Nezavisni;

            Console.WriteLine("Nezavisni kandidati su: ");
            int i = 1;
            foreach (Kandidat k in nezavisni)
            {
                Console.WriteLine(i.ToString() + ". " + k.Ime + " " + k.Prezime);
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
                s.IspisiKandidate();
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
                    new Glasac("Semina","Muratovic","Podigmanska 10",new DateTime(2001,06,07),"159E716","0706001175009"),
                    new Glasac("Adna","Cato","Mrakusa 70",new DateTime(2001,04,11),"159K716","1104001175009"),
                    new Glasac("Filip", "Maric", "Komari bb", new DateTime(2000,04,29), "259E716", "2904000760097"),
                    new Glasac("Harry","Potter","Glencoe",new DateTime(1995,05,07),"157E716","0705995175329"),
                    new Glasac("Luke","Skywalker","Naboo",new DateTime(1990,11,11),"149E716","1111990175000")

            };
            return glasaci;

        }
       
    }
}
