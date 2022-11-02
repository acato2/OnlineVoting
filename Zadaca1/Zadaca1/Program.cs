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
            Console.WriteLine("Izabrerite jednu od opcija:\n" +
              "1. Unos novog glasača \n " +
              "2. Glasanje \n" +
              "3. Rezultati izbora\n" +
              "4. Izlaznost izbora"
              );
            int unos ;
            unos = Convert.ToInt32( Console.ReadLine());
            if(unos == 1)
            {
                //Dodat unos podataka (ime, prezime, itd.)
                glasanje.dodajGlasaca()//dodat argumente
            }
            else if(unos == 2)
            {
                Console.WriteLine("Unesite vas Id:");
                //Ovdje treba napraviti provjeru da li postoji glasac na listi sa tim Id-ijem i da li je vec glasao
                //, ako ima nastavlja se sa glasanjem
                IspisKandidata(glasanje); // ispisuje sve stranke i kandidate 
                Console.WriteLine("Odaberite stranku za koju želite glasati ili listu neovisnih kandidata:");
                int brStranka = IspisStranaka(glasanje); /*Ispis stranaka za odabir po rednom broju, 
                                                  u ovoj ce se metodi prikazati i opcija nezavisni kandidati
                                                  , vraca broj stranaka da bi se nezavisni kandidati stavili na opciju brStranaka+1*/
                int odabirStranke = Convert.ToInt32(Console.ReadLine()); //upisuje se broj stranke
                if(odabirStranke == brStranka + 1) //slucaj da su odabrani nezavisni kandidati
                {
                    List<Kandidat> nezavisni = glasanje.DajNezavisne();
                    IspisKandidata(nezavisni);//ispisuje Nezavisne clanove sa rednim brojevima
                    int odabirKandidata = Convert.ToInt32(Console.ReadLine()); // Upis odabira kandidata (za pocetak se moze izabrati samo jedan, kasnije cemo prosirit funkcionalnost)
                    GlasajZaNezavisnog(odabirKandidata, glasanje, nezavisni); //izvrsava se glasanje
                }
                else//odabrana stranka
                {
                    Stranka odabranaStranka = glasanje.DajStranke().ElementAt(odabirStranke - 1);
                    IspisKandidata(odabranaStranka.DajKandidate());
                    int odabirKandidata = Convert.ToInt32(Console.ReadLine());
                    if(odabirKandidata == 0)
                    {
                        GlasajZaStranku(odabranaStranka); //glas za stranku
                    }
                    else
                    {
                        GlasajZaStrankuIKandidata(odabranaStranka, odabirKandidata); //glas i stranci i kandidatima
                    }
                }
                

            }

        }

        private static void GlasajZaStranku(Stranka odabranaStranka)
        {
            odabranaStranka.DodajGlas();
        }

        private static void GlasajZaStrankuIKandidata(Stranka odabranaStranka, int odabirKandidata)
        {
            GlasajZaStranku(odabranaStranka);
            odabranaStranka.DajKandidate().ElementAt(odabirKandidata - 1).dodajGlas();
        }

        private static int IspisStranaka(Glasanje glasanje)
        {
            //Ispis imena stranaka sa rednim brojevima
            return glasanje.Stranke.Count();
        }

        private static void IspisKandidata(Glasanje glasanje)
        {
            //Ispis stranaka i kandidata
 
            IspisKandidata(glasanje.DajNezavisne();
        }

        private static void IspisKandidata(List<Kandidat> kandidati)
        {
            Console.WriteLine("");
        }

        private static void GlasajZaNezavisnog(int odabirKandidata, Glasanje glasanje, List<Kandidat> nezavisni)
        {
            glasanje.GlasajZaNezavisnog(odabirKandidata);
        }
    }
}
