using System;
using System.Collections.Generic;
using System.Linq;

public class Glasanje
{
	List<Kandidat> nezavisniKandidati;
	List<Stranka> stranke;
    List<Glasac> glasaci;

    public Glasanje()
    {
        Nezavisni = new List<Kandidat>();
        Stranke = new List<Stranka>();
        Glasaci = new List<Glasac>();
    }
    public List<Kandidat> Nezavisni
    {
        get
        {
            return nezavisniKandidati;
        }

        set
        {
            nezavisniKandidati = value;
        }
    }
    /*Funkcije dajNezavisne() i DajStranke() nisu potrebne jer imamo već definisane gettere Nezavisni i Stranke
     - Feedback request je namijenjen Adni Ćato*/
    public List<Stranka> Stranke
    {
        get
        {
            return stranke;
        }

        set
        {
            stranke = value;
        }
    }
    public List<Glasac> Glasaci
    {
        get
        {
            return glasaci;
        }

        set
        {
            glasaci = value;
        }
    }
    //Imenovanje Funkcija velikim slovom
    public Glasac DodajGlasaca(Glasac glasac)
    {
        glasaci.Add(glasac);
        return glasac;
    }
    public void PrikaziGlasace() //Ispisuje listu glasaca, samo ime, prezime i Id, ostalo je zabranjeno u postavci
    {
        int brojac = 1;
        //glasaci.Sort(delegate (Glasac x, Glasac y) { return x.getPrezime().CompareTo(y.getPrezime(); });
        Console.WriteLine("Rb Ime             Prezime         ID Kod        Glasao/la");
        glasaci.Sort();
        foreach (Glasac x in glasaci)
        {
            String glasao = "";
            if (x.Glasao)
                glasao = "+";
            Console.WriteLine(brojac.ToString().PadLeft(2, ' ') + ". " +x.ime.PadRight(15, ' ') +
                " "+ x.prezime.PadRight(15, ' ') + " "+ x.id + " " + glasao);
            brojac++;
            
        }
    }
    public Glasac DodajGlasaca(string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
    {
        Glasac glasac = new Glasac(ime, prezime, adresa, datum_rodenja, br_licne, jmbg);
        glasaci.Add(glasac);
        return glasac;
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    public void IzvrsiGlasanjeZaNezavisnog(Glasac glasac, int odabirKandidata)
    {
        glasac.Glasaj(); //kako bi oznacili da je glasao=true
        GlasajZaNezavisnog(odabirKandidata);
    }
   public void GlasajZaNezavisnog(int odabirKandidata)
    {
        nezavisniKandidati.ElementAt(odabirKandidata - 1).dodajGlas();
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    public void IzvrsiGlasanjeZaStranku(Glasac glasac, int odabirStranke)
    {
        glasac.Glasaj(); //kako bi oznacili da je glasao=true
        GlasajZaStranku(odabirStranke);
    }
    public Stranka GlasajZaStranku(int odabirStranke)
    {
        //prvo glasa za stranku te onda za pojedinacne kandidate stranke ukoliko zeli
        Stranka stranka = stranke.ElementAt(odabirStranke - 1);
        stranka.DodajGlas();
        return stranka;
    }
    public void GlasajZaKandidateStranke(Stranka stranka,List<int>odabiriKandidata)
    {
        List<Kandidat> kandidati = stranka.Kandidati;
        foreach(int i in odabiriKandidata)
        {
            kandidati.ElementAt((int)i-1).dodajGlas();
        }
    }
    //Kako bi se držali jednog stila imenovanja funkcija, predlažem
    //da ova metoda počinje velikim slovom (GetGlasac).
    public Glasac GetGlasac(string id)
    {
        Glasac glasac = Glasaci.Find(g => g.id.Equals(id));
        if (glasac!=null)return glasac;
        return null;
    }
    public void RezultatiGlasanja()
    {
        List<Stranka> st = new List<Stranka> (stranke);
        st.Sort();
        int i = 1;
        Console.WriteLine("\n Rezultati glasanja za stranke:");
        Console.WriteLine("Br Stranka  Broj Glasova");
        foreach(Stranka s in st)
        {
            Console.WriteLine(i.ToString().PadLeft(2, ' ') + ". " + s.Naziv.PadRight(9, ' ') + s.Broj_glasova.ToString());
            i++;
        }
        List<Kandidat> nk = new List<Kandidat>(nezavisniKandidati);
        foreach (Kandidat k in nk)
        {
            Console.WriteLine(i.ToString().PadLeft(2, ' ') + ". " + (k.Ime + " " + k.Prezime).PadRight(20, ' ') + k.Broj_glasova.ToString());
            i++;
        }

        Console.WriteLine("Rezultati izbora po strankama: ");
        i = 1;
        foreach (Stranka s in st)
        {
            Console.WriteLine(i.ToString() + ". " + s.Naziv);
            List<Kandidat> ka = new List<Kandidat>(s.Kandidati);
            ka.Sort();
            Console.WriteLine("Br Kandidat       Broj Glasova");
            int j = 1;
            foreach (Kandidat k in ka)
            {
                Console.WriteLine(j.ToString() + ". " + (k.Ime + " " + k.Prezime).PadRight(20, ' ') + k.Broj_glasova.ToString());
                j++;
            }
            i++;
            Console.WriteLine("------------------------");
        }
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    public String DajTrenutnuIzlaznost()
    {
        int oniKojiSuGlasali = 0;
        foreach(Glasac g in glasaci)
        {
            if(g.Glasao) oniKojiSuGlasali++;
        }
        return Math.Round(((oniKojiSuGlasali / (double)glasaci.Count)) * 100, 3) + "%"; 
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    private int DajUkupanBrojGlasova()
    {
        /* Nema potrebe implementirati for petlje kada već postoji gotova bibliotečna funkcija koja može sumu 
         izračunati u jednoj liniji koda.
         - Feedback request je namijenjen Anidi Nezović*/
        return Stranke.Sum(s => s.Broj_glasova) + Nezavisni.Sum(k => k.Broj_glasova);
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    public List<Stranka> DajStrankeSaMandatima()
    {
        List<Stranka> mandati = new List<Stranka>();
        
        foreach (Stranka x in stranke)
        {
            if (x.Broj_glasova / (double)DajUkupanBrojGlasova() >= 0.02)
            {
                mandati.Add(x);
            }
        }

        return mandati;
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    public List<Kandidat> DajKandidateSaMandatima()
    {
        List<Kandidat> mandati = new List<Kandidat>();

        foreach (Kandidat x in nezavisniKandidati)
        {
            if (x.Broj_glasova / (double)DajUkupanBrojGlasova() >= 0.02)
            {
                mandati.Add(x);
            }
        }
        
        return mandati;
    }

    //Primjena jednog stila imenovanja metoda - nazivi pocinju velikim slovima
    public Dictionary<Kandidat,Stranka> DajKandidateSaMandatimaUnutarStranke()
    {
        Dictionary<Kandidat,Stranka> mandati = new Dictionary<Kandidat ,Stranka>();

        foreach (Stranka s in stranke)
        {
            foreach(Kandidat k in s.Kandidati)
            {
                if (k.Broj_glasova / (double)s.Broj_glasova >= 0.2)
                {  
                    mandati.Add(k, s);
                }
            }
        }
        return mandati;
    }
}
