using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

/* kandidat moze biti i glasac - funkcionalnost 4 - Adna Ćato */
public class Kandidat : Glasac, IComparable
{
	string ime, prezime, id;
	int broj_glasova;
	private String opis;
	
	public Kandidat(string ime, string prezime, string id)
    {
	

		if (ValidateName(ime) == false)
		{
			throw new Exception("Nevalidni podaci");
		}
        else
        {
			this.ime = ime;
        }

		if (ValidateName(prezime) == false)
		{
			throw new Exception("Nevalidni podaci");
		}
		else
		{
			this.prezime = prezime;
		}
		BrojGlasova = 0;
		this.id = id;
    }
	public string Ime
	{
		get
		{
			return ime;
		}

		set
		{
			ime = value;
		}
	}
	public string Prezime
	{
		get
		{
			return prezime;
		}

		set
		{
			prezime = value;
		}
	}
	public int BrojGlasova
	{
		get
		{
			return broj_glasova;
		}

		set
		{
			broj_glasova = value;
		}
	}
	public string Id
	{
		get
		{
			return id;
		}

		set
		{
			id = value;
		}
	}

	public string Opis
	{
		get
		{
			return opis;
		}

		set
		{
			opis = value;
		}
	}


    public void DodajGlas()
	{
		broj_glasova++;
	}

	public static bool ValidateName(string name)
	{
		return name.All(Char.IsLetter);
	}

	int IComparable.CompareTo(object obj)
    {
        Kandidat c = (Kandidat)obj;
        if (this.broj_glasova > c.broj_glasova)
            return -1;

        if (this.broj_glasova < c.broj_glasova)
            return 1;

        else
            return 0;
    }

	/* Implementaciju Funkcionalnosti br. 2 radila je Anida Nezović. */

	private bool ProvjeraOpisa()
    {
		bool validno = true;

		/* Slučaj 1: Opis ne počinje onako kako je dato u tekstu zadaće */
		/* Slučaj 2: Opis je prazan string */
		/* Slučaj 3: Opis sadrži samo početak datog primjera */

		String pocetak = "Kandidat je bio član stranke";
		if(!opis.Contains(pocetak) || String.IsNullOrEmpty(opis) || opis.Equals(pocetak))
        {
			validno = false;
        }

		return validno;
    }

	
	private bool ProvjeraOpisa(List<String> stranke, List<String> pocetak, List<String> kraj)
	{

		/* Slučaj 1: Veličine listi moraju biti jednake broju ponavljanja stringa 'član stranke' */

		string regex = @"\bčlan stranke\b";
		int brojPonavljanja = Regex.Matches(opis, regex).Count;

		if(stranke.Count != brojPonavljanja || pocetak.Count != brojPonavljanja || kraj.Count != brojPonavljanja)
        {
			return false;
		}

		/* Slučaj 2: Nazivi stranaka mogu biti samo slova (ne smiju adržavati brojeve niti znakove) */

		foreach (String naziv in stranke)
        {
			if(!naziv.All(Char.IsLetter))
            {
				return false;
            }
        }

		/* Slučaj 3: Datumi smiju biti samo brojevi te tačke između dana, mjeseca i godine */

		foreach (String datum in pocetak)
		{
			if (datum.Any(Char.IsLetter))
			{
				return false;
			}
		}
		foreach (String datum in kraj)
		{
			if (datum.Any(Char.IsLetter))
			{
				return false;
			}
		}

		/* Slučaj 4: Provjera ispravnosti dana, mjeseca i godine */
		/* Pretpostavljamo da se datum unosi kao 1.1.2000. */

		String[] pomocniPocetak = new String[3];
		String[] pomocniKraj = new String[3];

		for (int i = 0; i < pocetak.Count(); i++)
        {
			pomocniPocetak = pocetak[i].Split(".");

			int dan = Int16.Parse(pomocniPocetak[0]);
			int mjesec = Int16.Parse(pomocniPocetak[1]);
			int godina = Int16.Parse(pomocniPocetak[2]);
			if (!provjeraDatuma(dan, mjesec, godina)) return false;

		}

		for (int i = 0; i < kraj.Count(); i++)
		{
			pomocniKraj = kraj[i].Split(".");

			int dan = Int16.Parse(pomocniKraj[0]);
			int mjesec = Int16.Parse(pomocniKraj[1]);
			int godina = Int16.Parse(pomocniKraj[2]);
			if (!provjeraDatuma(dan, mjesec, godina)) return false;

		}

		/* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

		for (int i= 0; i < pocetak.Count(); i++)
		{
			pomocniPocetak = pocetak[i].Split(".");
			pomocniKraj = kraj[i].Split(".");

			/* Pretvaramo datum pocetka i datum kraja u broj, a onda gledamo da li je broj pocetka veci od broja kraja. */

			String joinPocetak = pomocniPocetak[0] + pomocniPocetak[1] + pomocniPocetak[2];
			String joinKraj = pomocniKraj[0] + pomocniKraj[1] + pomocniKraj[2];

			if (Int32.Parse(joinPocetak) > Int32.Parse(joinKraj)) return false;

		}

		return true;
	}

	private bool provjeraDatuma(int dan, int mjesec, int godina)
    {
		String trenutnaGodina = DateTime.Today.ToString("yyyy");
		int trenGod=Int16.Parse(trenutnaGodina);

		if (dan<1 || dan>31) return false;
		if (mjesec<1 || mjesec>12) return false;
		if (godina<0 || godina> trenGod) return false;

		return true;
	}
	public String PrikazPrethodnogClanstva()
    {
		String prikaz = "";

		if (ProvjeraOpisa())
        {
			bool stranka = false;
			bool odDatum = false;
			bool doDatum = false;

			List<String> stranke = new List<String>();
			List<String> pocetak = new List<String>();
			List<String> kraj = new List<String>();

			foreach (String podatak in opis.Split(" "))
			{
				if (podatak == "Kandidat" || podatak == "je" || podatak == "član") continue;

				if (podatak == "stranke") stranka = true;
				if (podatak == "od") odDatum = true;
				if (podatak == "do") doDatum = true;


				if (stranka && podatak != "stranke" && podatak != "od")
				{
					stranke.Add(podatak);
					stranka = false;
				}
				if (odDatum && podatak != "od" && podatak != "do")
				{
					pocetak.Add(podatak);
					odDatum = false;
				}
				if (doDatum && podatak != "do")
				{
					kraj.Add(podatak);
					doDatum = false;
				}
			}

			for (int i = 0; i < kraj.Count(); i++)
			{
				if (kraj[i][kraj[i].Length - 1] == ',')
				{
					kraj[i] = kraj[i].Remove(kraj[i].Length - 1, 1);
				}
			}

			if(ProvjeraOpisa(stranke, pocetak, kraj))
            {
				for (int i = 0; i < stranke.Count(); i++)
				{
					prikaz += "Stranka: " + stranke[i] + ", Članstvo od: " + pocetak[i] + ", Članstvo do: " + kraj[i] + "\n";
				}
			}
			else
            {
				prikaz = "Greška u unosu detaljnih informacija o kandidatu!";
			}
		}
		else
        {
			prikaz = "Greška u unosu detaljnih informacija o kandidatu!";

		}

		return prikaz;
	}
}
