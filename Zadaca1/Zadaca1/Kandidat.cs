using System;
using System.Linq;

public class Kandidat : Glasac, IComparable
{
	string ime, prezime, id;
	int broj_glasova;
	



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
}
