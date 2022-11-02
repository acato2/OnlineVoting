using System;
using System.Collections.Generic;
using System.Linq;

public class Glasanje
{
	List<Kandidat> nezavisniKandidati;
	List<Stranka> stranke;
    List<Glasac> glasaci;
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
    public void dodajGlasaca(Glasac glasac)
    {
        glasaci.Add(glasac);
    }
    public void izvrsiGlasanjeZaNezavisnog(Glasac glasac)
    {
        
        glasac.GlasajZaNezavisnog();
    }
    public Glasac DodajGlasaca(string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
    {
        Glasac glasac = new Glasac(ime, prezime, adresa, datum_rodenja, br_licne, jmbg);
       glasaci.Add(glasac);
        return glasac;
    }
    public void PrikaziGlasace() //Ispisuje listu glasaca, samo ime, prezime i Id, ostalo je zabranjeno u postavci
    {
        int brojac = 1;
        foreach(Glasac x in glasaci)
        {
            Console.WriteLine(brojac.ToString() + ". " + x.getIme() + " " + x.getPrezime() + " " + x.getId() + "\n");
            brojac++;
     
        }
    }

   public void GlasajZaNezavisnog(int odabirKandidata)
    {
        nezavisniKandidati.ElementAt(odabirKandidata - 1).dodajGlas();
    }

    public List<Kandidat> DajNezavisne()
    {
        throw new NotImplementedException();
    }

    public List<Stranka> DajStranke()
    {
        return stranke;
    }
}
