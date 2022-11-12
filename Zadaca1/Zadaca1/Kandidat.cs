using System;

public class Kandidat : IComparable
{
	string ime, prezime, id;
	int broj_glasova;
	

	public Kandidat(string ime, string prezime, string id)
    {
		Ime= ime;
		Prezime= prezime;
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
	public int Broj_glasova
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
	public Kandidat(string ime, string prezime, string id) 
	{
		this.ime = ime;
		this.prezime = prezime;
		this.id = id;
	}

	public void dodajGlas()
	{
		broj_glasova++;
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
