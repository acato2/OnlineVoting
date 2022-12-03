using System;
using System.Collections;
using System.Linq;
using System.Runtime.ConstrainedExecution;

public class Glasac : IComparable
{
	public String ime;
	public String prezime;
	String adresa;
	DateTime datum_rodenja;
	String br_licne;
	String jmbg;
	public String id;
	bool glasao = false;

	public Glasac(string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
	{
		Ime = ime;
		Prezime = prezime;
		this.adresa = adresa;
		DatumRodjenja = datum_rodenja;
		BrojLicne = br_licne;
		Jmbg = jmbg;
		Id = generisi_id();
	}
	public Glasac()
    {
	}

	public string generisi_id()
    {
		if (String.IsNullOrEmpty(ime) || String.IsNullOrEmpty(prezime) || String.IsNullOrEmpty(adresa)
									 || String.IsNullOrEmpty(br_licne) || String.IsNullOrEmpty(jmbg))
			throw new Exception("Nije moguce generisati ispravan id");

		return ((ime.Length >= 2) ? ime.Substring(0, 2) : ime)
			+ ((prezime.Length >= 2) ? prezime.Substring(0, 2) : prezime)
			+ ((adresa.Length >= 2) ? adresa.Substring(0, 2) : adresa)
			+ datum_rodenja.ToString("dd/MM/yyyy").Substring(0, 2)
			+ ((br_licne.Length >= 2) ? br_licne.Substring(0, 2) : br_licne)
			+ ((jmbg.Length >= 2) ? jmbg.Substring(0, 2) : jmbg);
	}
	public void Glasaj()
	{
		if (glasao) throw new InvalidOperationException("Glasac ne moze dva puta glasati!");
		glasao = true;
	}
	public void PrikaziGlasaca()
	{
		Console.WriteLine(id);
		/*Console.WriteLine("Ime: " + Ime);
		Console.WriteLine("Prezime: " + Prezime);
		Console.WriteLine("Adresa: " + Adresa);
		Console.WriteLine("Datum: " + DatumRodjenja.Day + ":" + DatumRodjenja.Month + ":" + DatumRodjenja.Year);
		Console.WriteLine("Licna karta: " + BrojLicne);
		Console.WriteLine("JMBG: " + Jmbg);*/
	}

	public bool Glasao
	{
		get
		{
			return glasao;
		}

		set
		{
			glasao = value;
		}
	}

	public String Ime
	{
		get
		{
			return ime;
		}

		set
		{
			if(String.IsNullOrEmpty(value)) throw new Exception("Ime ne smije biti prazno!");

			int bezCrtica = value.Length-value.Count(x => x.Equals('-'));
			int samoSlova= value.Where(x => Char.IsLetter(x)).ToList().Count;
			if (bezCrtica == samoSlova && samoSlova >= 2 && samoSlova <= 40)
			{
				ime = value;
			}
			else throw new Exception("Pogrešan format imena!");
		}
	}

	public String Prezime
    {
        get
        {
			return prezime;
        }
        set
        {
			if (String.IsNullOrEmpty(value)) throw new Exception("Prezime ne smije biti prazno!");

			int bezCrtica = value.Length - value.Count(x => x.Equals('-'));
			int samoSlova = value.Where(x => Char.IsLetter(x)).ToList().Count;
			if (bezCrtica == samoSlova && samoSlova >= 3 && samoSlova <= 50) prezime = value;

			else throw new Exception("Pogrešan format prezimena!");
		}
    }

	public DateTime DatumRodjenja
    {
        get
        {
			return datum_rodenja;

		}
        set
        {
			if (DateTime.Compare(DateTime.Now, value) < 0) throw new Exception("Datum ne moze biti u buducnosti!");
			if (DateTime.Compare(value.AddYears(18),DateTime.Now)>0) throw new Exception("Glasac mora biti punoljetan");
			datum_rodenja = value;

		}
    }

	public String Adresa
    {
        get
        {
			return adresa;
        }
        set
        {
			if (String.IsNullOrEmpty(value)) throw new Exception("Adresa ne moze biti prazna!");
			if (value.Length < 2) throw new Exception("Adresa mora biti duza od 2 karaktera!");
			adresa = value;
        }
    }

	public String BrojLicne
    {
        get
        {
			return br_licne;
		}
        set
        {
			String dozvoljeni = "EJKMT";
			if (String.IsNullOrEmpty(value)) throw new Exception("Broj licne karte ne smije biti prazan!");
			if (value.Length > 7 || value.Length < 7) throw new Exception("Broj licne mora imati 7 karaktera!");
			if (value.Substring(0, 3).All(Char.IsDigit) && value.Substring(4, 3).All(Char.IsDigit) &&
				dozvoljeni.Contains(value.ElementAt(3))) br_licne = value;
			else throw new Exception("Neispravan format licne karte!");
        }
    }

	public String Jmbg
    {
        get
        {
			return jmbg;
        }
        set
        {
			if (String.IsNullOrEmpty(value)) throw new Exception("Maticni broj ne smije biti prazan!");
			if (value.Length != 13) throw new Exception("Maticni broj se mora sastojati od 13 brojeva!");
			if (!value.All(Char.IsDigit)) throw new Exception("Maticni broj se mora sastojati od brojeva!");
			int dan = int.Parse(value.Substring(0, 2));
			int mjesec=int.Parse(value.Substring(2, 2));
			int godina=int.Parse(value.Substring(4, 3));

			if(dan==datum_rodenja.Day && mjesec==datum_rodenja.Month && 
			   godina==int.Parse(datum_rodenja.Year.ToString().Substring(4-3))) jmbg = value;
			else
			throw new Exception("Neispravan format maticnog broja!");
		}
    }

	public String Id
    {
        get
        {
			return id;
        }
        set
        {
			if ( !value.Substring(0, 2).Equals(ime.Substring(0, 2)) )
				throw new Exception("Neispravan id!");
			if ( !value.Substring(2, 2).Equals(prezime.Substring(0, 2)) )
				throw new Exception("Neispravan id!");
			if ( !value.Substring(4, 2).Equals(adresa.Substring(0, 2)) )
				throw new Exception("Neispravan id!");
			if (!(value.Substring(6, 2).Equals(datum_rodenja.ToString("dd/MM/yyyy").Substring(0, 2))))
				throw new Exception("Neispravan id!");
			if ( !value.Substring(8, 2).Equals(br_licne.Substring(0, 2)) )
				throw new Exception("Neispravan id!");
			if ( !value.Substring(10, 2).Equals(jmbg.Substring(0, 2)) )
				throw new Exception("Neispravan id!");
			id = value;
        }
    }
	int IComparable.CompareTo(object obj)
	{
        Glasac c = (Glasac)obj;
        return String.Compare(this.prezime, c.prezime);
    }
}
