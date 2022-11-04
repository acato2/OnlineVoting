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
    public Glasac dodajGlasaca(Glasac glasac)
    {
        glasaci.Add(glasac);
        return glasac;
    }
    public void PrikaziGlasace() //Ispisuje listu glasaca, samo ime, prezime i Id, ostalo je zabranjeno u postavci
    {
        int brojac = 1;
        foreach (Glasac x in glasaci)
        {
            Console.WriteLine(brojac.ToString() + ". " + x.getId() + "\n");
            brojac++;

        }
    }
    public Glasac DodajGlasaca(string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
    {
        Glasac glasac = new Glasac(ime, prezime, adresa, datum_rodenja, br_licne, jmbg);
        glasaci.Add(glasac);
        return glasac;
    }
    public void izvrsiGlasanjeZaNezavisnog(Glasac glasac, int odabirKandidata)
    {
        glasac.Glasaj(); //kako bi oznacili da je glasao=true
        GlasajZaNezavisnog(odabirKandidata);
    }
   public void GlasajZaNezavisnog(int odabirKandidata)
    {
        nezavisniKandidati.ElementAt(odabirKandidata - 1).dodajGlas();
    }
    public void izvrsiGlasanjeZaStranku(Glasac glasac, int odabirStranke)
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
    public List<Kandidat> DajNezavisne()
    {
        return Nezavisni;
    }

    public List<Stranka> DajStranke()
    {
        return stranke;
    }
    public Glasac getGlasac(string id)
    {
        Glasac glasac = Glasaci.Find(g => g.getId().Equals(id));
        if (glasac!=null)return glasac;
        return null;
    }
}
