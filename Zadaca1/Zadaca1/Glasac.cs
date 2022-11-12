using System;
using System.Collections;
using System.Runtime.ConstrainedExecution;

public class Glasac : IComparable
{
	public String ime { get; set;}
	public String prezime { get; set;}
	String adresa { get; set;}
	DateTime datum_rodenja{ get; set;}
	String br_licne{ get; set;}
	String jmbg{ get; set;}
	public String id { get; set;}
	bool glasao = false;

	public Glasac(string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
	{
		this.ime = ime;
		this.prezime = prezime;
		this.adresa = adresa;
		this.datum_rodenja = datum_rodenja;
		this.br_licne = br_licne;
		this.jmbg = jmbg;
		this.id = generisi_id(ime, prezime, adresa, datum_rodenja, br_licne, jmbg);
	}
	public string generisi_id (string ime, string prezime, string adresa, DateTime datum_rodenja, string br_licne, string jmbg)
	{
		return ((ime.Length >= 2) ? ime.Substring(0, 2) : ime) 
			+ ((prezime.Length >=2)? prezime.Substring(0,2):prezime)
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
    int IComparable.CompareTo(object obj)
	{
        Glasac c = (Glasac)obj;
        return String.Compare(this.prezime, c.prezime);
    }
}
