using System;

public class Glasac
{
	String ime { get; set; } 
	String prezime { get; set; }
	String adresa { get; set; }
	DateTime datum_rodenja { get; set; }
	String br_licne { get; set; }
	String jmbg { get; set; }
	String id { get; set; }
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
		return ime.Substring(2) + prezime.Substring(2) + adresa.Substring(2) + datum_rodenja.ToString().Substring(2)
            + br_licne.Substring(2) + jmbg.Substring(2);

    }
	public void Glasaj()
	{
		glasao = true;
	}
	
	public string getIme()
	{
		return ime;
	}
}
