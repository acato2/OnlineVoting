using System;

public class Kandidat
{
	string ime, prezime, id;
	int broj_glasova;
	bool nezavisan;
	

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
