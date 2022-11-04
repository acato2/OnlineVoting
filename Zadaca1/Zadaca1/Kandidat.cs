using System;

public class Kandidat
{
	string ime, prezime, id;
	int broj_glasova;
	bool nezavisan;

	public Kandidat(string ime, string prezime, string id)
    {
		Ime= ime;
		Prezime= prezime;
		Broj_glasova = 0;
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
	public Kandidat(string ime, string prezime, string id, bool nezavisan) 
	{
		this.ime = ime;
		this.prezime = prezime;
		this.id = id;
		this.broj_glasova = 0;
		this.nezavisan = nezavisan;
	}

	public void dodajGlas()
	{
		broj_glasova++;
	}
}
