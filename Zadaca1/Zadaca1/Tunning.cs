﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

public class Tunning
{
	//U ovoj klasi se nalaze sve verzije code tunninga obavljene nad originalnom metodom

	String opis;

	public string Opis
	{
		get
		{
			return opis;
		}

		set
		{
			opis = value;
		}
	}
	public bool ProvjeraOpisaOriginal(List<String> stranke, List<String> pocetak, List<String> kraj)
	{

		/* Slučaj 1: Veličine listi moraju biti jednake broju ponavljanja stringa 'član stranke' */

		string regex = @"\bčlan stranke\b";
		int brojPonavljanja = Regex.Matches(opis, regex).Count;

		if (stranke.Count != brojPonavljanja || pocetak.Count != brojPonavljanja || kraj.Count != brojPonavljanja)
		{
			return false;
		}

		/* Slučaj 2: Nazivi stranaka mogu biti samo slova (ne smiju adržavati brojeve niti znakove) */

		foreach (String naziv in stranke)
		{
			if (!naziv.All(Char.IsLetter))
			{
				return false;
			}
		}

		/* Slučaj 3: Datumi smiju biti samo brojevi te tačke između dana, mjeseca i godine */

		foreach (String datum in pocetak)
		{
			if (datum.Any(Char.IsLetter))
			{
				return false;
			}
		}
		foreach (String datum in kraj)
		{
			if (datum.Any(Char.IsLetter))
			{
				return false;
			}
		}

		/* Slučaj 4: Provjera ispravnosti dana, mjeseca i godine */
		/* Pretpostavljamo da se datum unosi kao 1.1.2000. */

		String[] pomocniPocetak = new String[3];
		String[] pomocniKraj = new String[3];
		String trenutnaGodina = DateTime.Today.ToString("yyyy");

		for (int i = 0; i < pocetak.Count(); i++)
		{
			pomocniPocetak = pocetak[i].Split(".");

			if (Int16.Parse(pomocniPocetak[0]) < 1 || Int16.Parse(pomocniPocetak[0]) > 31)
			{
				return false;
			}
			if (Int16.Parse(pomocniPocetak[1]) < 1 || Int16.Parse(pomocniPocetak[1]) > 12)
			{
				return false;
			}
			if (Int16.Parse(pomocniPocetak[2]) < 0 || Int16.Parse(pomocniPocetak[2]) > Int16.Parse(trenutnaGodina))
			{
				return false;
			}
		}

		for (int i = 0; i < kraj.Count(); i++)
		{
			pomocniKraj = kraj[i].Split(".");

			if (Int16.Parse(pomocniKraj[0]) < 1 || Int16.Parse(pomocniKraj[0]) > 31)
			{
				return false;
			}
			if (Int16.Parse(pomocniKraj[1]) < 1 || Int16.Parse(pomocniKraj[1]) > 12)
			{
				return false;
			}
			if (Int16.Parse(pomocniKraj[2]) < 0 || Int16.Parse(pomocniKraj[2]) > Int16.Parse(trenutnaGodina))
			{
				return false;
			}
		}

		/* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

		for (int i = 0; i < pocetak.Count(); i++)
		{
			pomocniPocetak = pocetak[i].Split(".");
			pomocniKraj = kraj[i].Split(".");

			if (Int16.Parse(pomocniPocetak[2]) > Int16.Parse(pomocniKraj[2]))
			{
				return false;
			}
			else if (Int16.Parse(pomocniPocetak[2]) == Int16.Parse(pomocniKraj[2]))
			{
				if (Int16.Parse(pomocniPocetak[1]) > Int16.Parse(pomocniKraj[1]))
				{
					return false;
				}
				else if (Int16.Parse(pomocniPocetak[1]) == Int16.Parse(pomocniKraj[1]))
				{
					if (Int16.Parse(pomocniPocetak[0]) > Int16.Parse(pomocniKraj[0]))
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	public bool ProvjeraOpisaTunning1(List<String> stranke, List<String> pocetak, List<String> kraj)
	{

		/* Slučaj 1: Veličine listi moraju biti jednake broju ponavljanja stringa 'član stranke' */

		string regex = @"\bčlan stranke\b";
		int brojPonavljanja = Regex.Matches(opis, regex).Count;

		if (stranke.Count != brojPonavljanja || pocetak.Count != brojPonavljanja || kraj.Count != brojPonavljanja)
		{
			return false;
		}

		/* Slučaj 2: Nazivi stranaka mogu biti samo slova (ne smiju adržavati brojeve niti znakove) */

		foreach (String naziv in stranke)
		{
			if (!naziv.All(Char.IsLetter))
			{
				return false;
			}
		}

		/* Slučaj 3: Datumi smiju biti samo brojevi te tačke između dana, mjeseca i godine */

		foreach (String datum in pocetak)
		{
			if (datum.Any(Char.IsLetter))
			{
				return false;
			}
		}
		foreach (String datum in kraj)
		{
			if (datum.Any(Char.IsLetter))
			{
				return false;
			}
		}

		/* Slučaj 4: Provjera ispravnosti dana, mjeseca i godine */
		/* Pretpostavljamo da se datum unosi kao 1.1.2000. */

		String[] pomocniPocetak = new String[3];
		String[] pomocniKraj = new String[3];
		String trenutnaGodina = DateTime.Today.ToString("yyyy");

		for (int i = 0; i < pocetak.Count(); i++)
		{
			pomocniPocetak = pocetak[i].Split(".");

			if (Int16.Parse(pomocniPocetak[0]) < 1 || Int16.Parse(pomocniPocetak[0]) > 31)
			{
				return false;
			}
			if (Int16.Parse(pomocniPocetak[1]) < 1 || Int16.Parse(pomocniPocetak[1]) > 12)
			{
				return false;
			}
			if (Int16.Parse(pomocniPocetak[2]) < 0 || Int16.Parse(pomocniPocetak[2]) > Int16.Parse(trenutnaGodina))
			{
				return false;
			}
		}

		for (int i = 0; i < kraj.Count(); i++)
		{
			pomocniKraj = kraj[i].Split(".");

			if (Int16.Parse(pomocniKraj[0]) < 1 || Int16.Parse(pomocniKraj[0]) > 31)
			{
				return false;
			}
			if (Int16.Parse(pomocniKraj[1]) < 1 || Int16.Parse(pomocniKraj[1]) > 12)
			{
				return false;
			}
			if (Int16.Parse(pomocniKraj[2]) < 0 || Int16.Parse(pomocniKraj[2]) > Int16.Parse(trenutnaGodina))
			{
				return false;
			}
		}

		/* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

		for (int i = 0; i < pocetak.Count(); i++)
		{
			pomocniPocetak = pocetak[i].Split(".");
			pomocniKraj = kraj[i].Split(".");

			int danPocetak=Int16.Parse(pomocniPocetak[0]);
			int danKraj=Int16.Parse(pomocniKraj[0]);

			int mjesecPocetak= Int16.Parse(pomocniPocetak[1]);
			int mjesecKraj= Int16.Parse(pomocniKraj[1]);

			int godinaPocetak= Int16.Parse(pomocniPocetak[2]);
			int godinaKraj = Int16.Parse(pomocniKraj[2]);

			if (godinaPocetak > godinaKraj)
			{
				return false;
			}
			else if (godinaPocetak == godinaKraj)
			{
				if (mjesecPocetak > mjesecKraj)
				{
					return false;
				}
				else if (mjesecPocetak == mjesecKraj)
				{
					if (danPocetak > danKraj)
					{
						return false;
					}
				}
			}
		}
		return true;
	}
}

