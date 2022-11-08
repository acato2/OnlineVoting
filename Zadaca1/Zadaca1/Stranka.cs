using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;

public class Stranka : IComparable
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
		int i = 1;
		//ispisuje kandidate sa rednim brojevima od 1 do n
		foreach(Kandidat kandidat in kandidati)
        {
			Console.WriteLine(i.ToString()+". "+kandidat.Ime+" "+kandidat.Prezime+" broj glasova: "+kandidat.Broj_glasova);
			i++;
        }
	}


	public void DodajGlas()
	{
		broj_glasova++;
	}
	public string Naziv
	{
		get
		{
			return naziv;
		}

		set
		{
			naziv = value;
		}
	}
	public List<Kandidat> Kandidati
	{
		get
		{
			return kandidati;
		}

		set
		{
			kandidati = value;
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
    int IComparable.CompareTo(object obj)
    {
        Stranka c = (Stranka)obj;
        if (this.broj_glasova > c.broj_glasova)
            return -1;

        if (this.broj_glasova < c.broj_glasova)
            return 1;

        else
            return 0;
    }
}
