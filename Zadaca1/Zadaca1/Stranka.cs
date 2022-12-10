using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class Stranka : IComparable
{
	string naziv;
	List<Kandidat> kandidati;
	int broj_glasova;
	int ukupan_brojGlasova_kandidata = 0;

	// dodana lista kandidata koji su u rukovodstvu - funkcionalnost 4 - Adna Ćato */
	List<Kandidat> rukovodstvo;


	public Stranka(string naziv, List<Kandidat> kandidati, int broj_glasova)
	{
		if (!ValidateName(naziv)) throw new Exception("Naziv stranke nije validan!");

		//Kandidati se validiraju u klasi Kandidat

		this.naziv = naziv;
		this.kandidati = kandidati;
		this.broj_glasova = broj_glasova;
		this.rukovodstvo = new List<Kandidat>();


	}

	public Stranka(string naziv, List<Kandidat> kandidati, List<Kandidat> rukovodstvo)
	{
		if (!ValidateName(naziv)) throw new Exception("Naziv stranke nije validan!");

		this.naziv = naziv;
		this.kandidati = kandidati;
		this.rukovodstvo = rukovodstvo;
	}
	public Stranka(string naziv,int broj_glasova)
	{
		if (!ValidateName(naziv)) throw new Exception("Naziv stranke nije validan!");

		this.naziv = naziv;
		this.broj_glasova = broj_glasova;
		
	}

	public Stranka(string naziv, List<Kandidat> kandidati, List<Kandidat> rukovodstvo,int broj_glasova)
	{
		if (!ValidateName(naziv)) throw new Exception("Naziv stranke nije validan!");

		this.naziv = naziv;
		this.kandidati = kandidati;
		this.rukovodstvo = rukovodstvo;
		this.broj_glasova = broj_glasova;
	}

	public static bool ValidateName(string name)
	{
		return name.All(Char.IsLetter);
	}

	public void IspisiKandidate()
	{
		int i = 1;
		//ispisuje kandidate sa rednim brojevima od 1 do n
		foreach (Kandidat kandidat in kandidati)
		{
			Console.WriteLine(i + ". " + kandidat.Ime + " " + kandidat.Prezime);
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
	public int Ukupan_BrojGlasova_Kandidata
	{
		get
		{
			return ukupan_brojGlasova_kandidata;
		}

		set
		{
			ukupan_brojGlasova_kandidata = value;
		}
	}
	public List<Kandidat> Rukovodstvo {
		get
		{
			return rukovodstvo;
		}

		set
		{
			rukovodstvo = value;
		}
	}

	/* Ispis rezultata o rukovodstvu - funkcionalnost 4 - Adna Ćato */
	public string RezultatiRukovodstva()
	{
		string ispis = "";
		ispis = ispis + "Naziv stranke: " + naziv;
		int ukupnoGlasova = 0;
		foreach (Kandidat k in rukovodstvo)
		{
			ukupnoGlasova += k.BrojGlasova;
		}
		ispis = ispis + "\nUkupan broj glasova: " + ukupnoGlasova + "\nKandidati: ";
		foreach (Kandidat k in rukovodstvo)
		{
			ispis = ispis + "\nIdentifikacioni broj: " + k.Id;
		}
		return ispis;
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
