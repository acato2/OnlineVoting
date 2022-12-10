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
    public Glasac DodajGlasaca(Glasac glasac)
    {
        glasaci.Add(glasac);
        return glasac;
    }
    public void PrikaziGlasace()
    {
        int brojac = 1;
        Console.WriteLine("Rb Ime             Prezime         ID Kod        Glasao/la");
        glasaci.Sort();
        foreach (Glasac x in glasaci)
        {
            String glasao = "";
            if (x.Glasao)
                glasao = "+";
            Console.WriteLine(brojac.ToString().PadLeft(2, ' ') + ". " + x.ime.PadRight(15, ' ') +
                " " + x.prezime.PadRight(15, ' ') + " " + x.id + " " + glasao);
            brojac++;

        }
    }
    public Glasac DodajGlasaca(string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
    {
        Glasac glasac = new Glasac(ime, prezime, adresa, datum_rodenja, br_licne, jmbg);
        glasaci.Add(glasac);
        return glasac;
    }

    public void IzvrsiGlasanjeZaNezavisnog(Glasac glasac, int odabirKandidata)
    {

        GlasajZaNezavisnog(odabirKandidata);
    }
    public void GlasajZaNezavisnog(int odabirKandidata)
    {
        nezavisniKandidati.ElementAt(odabirKandidata - 1).DodajGlas();

    }

    public void IzvrsiGlasanjeZaStranku(Glasac glasac, int odabirStranke)
    {

        GlasajZaStranku(odabirStranke);
    }
    public Stranka GlasajZaStranku(int odabirStranke)
    {
        Stranka stranka = stranke.ElementAt(odabirStranke - 1);
        stranka.DodajGlas();
        return stranka;
    }
    public void GlasajZaKandidateStranke(Stranka stranka, List<int> odabiriKandidata)
    {
        List<Kandidat> kandidati = stranka.Kandidati;
        foreach (int i in odabiriKandidata)
        {
            kandidati.ElementAt((int)i - 1).DodajGlas();
        }
        stranka.Ukupan_BrojGlasova_Kandidata++;
    }
    public Glasac GetGlasac(string id)
    {
        Glasac glasac = Glasaci.Find(g => g.id.Equals(id));
        if (glasac != null) return glasac;
        return null;
    }
    public void RezultatiGlasanja()
    {
        List<Stranka> st = new List<Stranka>(stranke);
        st.Sort();
        int i = 1;
        Console.WriteLine("\n Rezultati glasanja za stranke:");
        Console.WriteLine("Br Stranka  Broj Glasova");
        foreach (Stranka s in st)
        {
            Console.WriteLine(i.ToString().PadLeft(2, ' ') + ". " + s.Naziv.PadRight(9, ' ') + s.BrojGlasova.ToString());
            i++;
        }
        List<Kandidat> nk = new List<Kandidat>(nezavisniKandidati);
        foreach (Kandidat k in nk)
        {
            Console.WriteLine(i.ToString().PadLeft(2, ' ') + ". " + (k.Ime + " " + k.Prezime).PadRight(20, ' ') + k.BrojGlasova.ToString());
            i++;
        }

        Console.WriteLine("Rezultati izbora po strankama: ");
        i = 1;
        int brojacGlasova = 0;
        int brojacKandidata = 0;
        foreach (Stranka s in st)
        {
            Console.WriteLine(i.ToString() + ". " + s.Naziv);
            List<Kandidat> ka = new List<Kandidat>(s.Kandidati);
            ka.Sort();
            Console.WriteLine("Br Kandidat       Broj Glasova");
            int j = 1;
            foreach (Kandidat k in ka)
            {
                Console.WriteLine(j.ToString() + ". " + (k.Ime + " " + k.Prezime).PadRight(20, ' ') + k.BrojGlasova.ToString());
                brojacGlasova += k.BrojGlasova;
                j++;
                brojacKandidata++;
            }
            i++;
            Console.WriteLine(ispisiUkupanBrojGlasova(brojacGlasova, brojacKandidata));
            brojacGlasova = 0;
            brojacKandidata = 0;
            Console.WriteLine("------------------------");
        }
    }

    public string ispisiUkupanBrojGlasova(int brojacGlasova,int brojacKandidata)
    {
        String ispis = "";
        ispis = "\nUkupan broj glasova je: " + brojacGlasova +"\n";
        ispis += "Ukupan broj glasova u postotcima je: " + (brojacGlasova / (double)brojacKandidata) * 100 + "%";
        return ispis;
    }

    public string RezultatiMandata()
    {
        string ispis = "";
        int brojac = 0;

        //Prvo, mandati stranke ili nezavisnog kandidata

        ispis = "Stranke i nezavisni kandidati sa trenutnim mandatom:\n";
        foreach (Stranka s in DajStrankeSaMandatima())
        {
            brojac++;
            ispis += brojac + ". " + s.Naziv;

        }
        foreach (Kandidat k in DajKandidateSaMandatima())
        {
            brojac++;
            ispis += brojac + k.Ime + " " + k.Prezime;
        }

        brojac = 0;
        //Drugo, kandidati koji imaju mandat unutar neke stranke

        ispis += "\nKandidati koji su trenutno osvojili mandat stranke:\n";
        foreach (KeyValuePair<Kandidat, Stranka> m in DajKandidateSaMandatimaUnutarStranke())
        {
            
            brojac++;
            ispis += brojac + ". " + m.Key.Ime + " " + m.Key.Prezime + ", " + m.Value.Naziv;
            ispis += "\nUkupan broj glasova je: " + m.Key.BrojGlasova + "\n";
            ispis += "Ukupan broj glasova glasova u postotcima je: " + (m.Key.BrojGlasova / (double)m.Value.Ukupan_BrojGlasova_Kandidata) * 100 + "%\n";
        }
        return ispis;
    }
    public String DajTrenutnuIzlaznost()
    {
        int oniKojiSuGlasali = 0;
        foreach (Glasac g in glasaci)
        {
            if (g.Glasao) oniKojiSuGlasali++;
        }
        return Math.Round(((oniKojiSuGlasali / (double)glasaci.Count)) * 100, 3) + "%";
    }
    private int DajUkupanBrojGlasova()
    {
        return Stranke.Sum(s => s.BrojGlasova) + Nezavisni.Sum(k => k.BrojGlasova);
    }
    public List<Stranka> DajStrankeSaMandatima()
    {
        List<Stranka> mandati = new List<Stranka>();

        foreach (Stranka x in stranke)
        {
            double vrijednost = x.BrojGlasova / (double)DajUkupanBrojGlasova();
            if (vrijednost > 0.02 || Math.Abs(vrijednost - 0.02) < 0.00000000001)
            {
                mandati.Add(x);
            }
        }

        return mandati;
    }

    public List<Kandidat> DajKandidateSaMandatima()
    {
        List<Kandidat> mandati = new List<Kandidat>();

        foreach (Kandidat x in nezavisniKandidati)
        {
            double vrijednost = x.BrojGlasova / (double)DajUkupanBrojGlasova();
            if (vrijednost > 0.02 || Math.Abs(vrijednost - 0.02) < 0.00000000001)
            {
                mandati.Add(x);
            }
        }

        return mandati;
    }
    public Dictionary<Kandidat, Stranka> DajKandidateSaMandatimaUnutarStranke()
    {
        Dictionary<Kandidat, Stranka> mandati = new Dictionary<Kandidat, Stranka>();

        foreach (Stranka s in stranke)
        {
            foreach (Kandidat k in s.Kandidati)
            {
                double vrijednost = k.BrojGlasova / (double)s.BrojGlasova;
                if (vrijednost > 0.2 || Math.Abs(vrijednost - 0.2) < 0.00000000001)
                {
                    mandati.Add(k, s);
                }
            }
        }
        return mandati;
    }
}
