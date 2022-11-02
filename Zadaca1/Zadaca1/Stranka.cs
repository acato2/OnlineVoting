using System;
using System.Collections.Generic;

public class Stranka
{
	string naziv;
	List<Kandidat> kandidati;
	int broj_glasova;

	public Stranka(string naziv, List<Kandidat> kandidati, int broj_glasova)
	{
		this.naziv = naziv;
		this.kandidati = kandidati;
		this.broj_glasova = broj_glasova;
	}

	public void ispisiKandidate()
	{
		//ispisuje kandidate sa rednim brojevima od 1 do n
	}

	public List<Kandidat> DajKandidate()
	{
		return kandidati;
	}

	public void DodajGlas()
	{
		broj_glasova++;
	}
}
