using System;
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
			pomocniKraj = kraj[i].Split(".");

			/*Provjera datum pocetak*/

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
			
			/*Provjera datum kraj*/

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

			/* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

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

	public bool ProvjeraOpisaTunning2(List<String> stranke, List<String> pocetak, List<String> kraj)
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
			pomocniKraj = kraj[i].Split(".");

			/*Provjera datum pocetak*/

			int pomocniPocetak0 = Int16.Parse(pomocniPocetak[0]);
			int pomocniPocetak1 = Int16.Parse(pomocniPocetak[1]);
			int pomocniPocetak2 = Int16.Parse(pomocniPocetak[2]);
			int trenutnaGodinaInt = Int16.Parse(trenutnaGodina);


			if (pomocniPocetak0 < 1 || pomocniPocetak0 > 31 )
			{
				return false;
			}
			if (pomocniPocetak1 < 1 || pomocniPocetak1 > 12)
			{
				return false;
			}
			if (pomocniPocetak2 < 0 || pomocniPocetak2 > trenutnaGodinaInt)
			{
				return false;
			}

			/*Provjera datum kraj*/

			if (Int16.Parse(pomocniKraj[0]) < 1 || Int16.Parse(pomocniKraj[0]) > 31)
			{
				return false;
			}
			if (Int16.Parse(pomocniKraj[1]) < 1 || Int16.Parse(pomocniKraj[1]) > 12)
			{
				return false;
			}
			if (Int16.Parse(pomocniKraj[2]) < 0 || Int16.Parse(pomocniKraj[2]) > trenutnaGodinaInt)
			{
				return false;
			}

			/* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

			if (pomocniPocetak2 > Int16.Parse(pomocniKraj[2]))
			{
				return false;
			}
			else if (pomocniPocetak2 == Int16.Parse(pomocniKraj[2]))
			{
				if (pomocniPocetak1 > Int16.Parse(pomocniKraj[1]))
				{
					return false;
				}
				else if (pomocniPocetak1 == Int16.Parse(pomocniKraj[1]))
				{
					if (pomocniPocetak0 > Int16.Parse(pomocniKraj[0]))
					{
						return false;
					}
				}
			}
		}

		return true;
	}
	public bool ProvjeraOpisaTunning3(List<String> stranke, List<String> pocetak, List<String> kraj)
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
			pomocniKraj = kraj[i].Split(".");

			/*Provjera datum pocetak*/

			int pomocniPocetak0 = Int16.Parse(pomocniPocetak[0]);
			int pomocniPocetak1 = Int16.Parse(pomocniPocetak[1]);
			int pomocniPocetak2 = Int16.Parse(pomocniPocetak[2]);
			int trenutnaGodinaInt = Int16.Parse(trenutnaGodina);


			if (pomocniPocetak0 < 1 || pomocniPocetak0 > 31)
			{
				return false;
			}
			if (pomocniPocetak1 < 1 || pomocniPocetak1 > 12)
			{
				return false;
			}
			if (pomocniPocetak2 < 0 || pomocniPocetak2 > trenutnaGodinaInt)
			{
				return false;
			}

			/*Provjera datum kraj*/

			int pomocniKraj0 = Int16.Parse(pomocniKraj[0]);
			int pomocniKraj1 = Int16.Parse(pomocniKraj[1]);
			int pomocniKraj2 = Int16.Parse(pomocniKraj[2]);

			if ( pomocniKraj0 < 1 || pomocniKraj0 > 31)
			{
				return false;
			}
			if ( pomocniKraj1 < 1 || pomocniKraj1 > 12)
			{
				return false;
			}
			if (pomocniKraj2 < 0 || pomocniKraj2 > trenutnaGodinaInt)
			{
				return false;
			}

			/* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

			if (pomocniPocetak2 > pomocniKraj2)
			{
				return false;
			}
			else if (pomocniPocetak2 == pomocniKraj2)
			{
				if (pomocniPocetak1 > pomocniKraj1)
				{
					return false;
				}
				else if (pomocniPocetak1 == pomocniKraj1)
				{
					if (pomocniPocetak0 > pomocniKraj0)
					{
						return false;
					}
				}
			}
		}

		return true;
	}

    public bool ProvjeraOpisaTunning4(List<String> stranke, List<String> pocetak, List<String> kraj)
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
        String[] pomocniPocetakA = new String[3];
        String[] pomocniKrajA = new String[3];
        String[] pomocniPocetakB = new String[3];
        String[] pomocniKrajB = new String[3];
		String[] pomocniPocetakC = new String[3];
        String[] pomocniKrajC = new String[3];
        String trenutnaGodina = DateTime.Today.ToString("yyyy");

        for (int i = 0; i < pocetak.Count()-4; i+=4)
        {
            pomocniPocetak = pocetak[i].Split(".");
            pomocniKraj = kraj[i].Split(".");

            /*Provjera datum pocetak*/

            int pomocniPocetak0 = Int16.Parse(pomocniPocetak[0]);
            int pomocniPocetak1 = Int16.Parse(pomocniPocetak[1]);
            int pomocniPocetak2 = Int16.Parse(pomocniPocetak[2]);
            int trenutnaGodinaInt = Int16.Parse(trenutnaGodina);


            if (pomocniPocetak0 < 1 || pomocniPocetak0 > 31
				|| pomocniPocetak1 < 1 || pomocniPocetak1 > 12
				|| pomocniPocetak2 < 0 || pomocniPocetak2 > trenutnaGodinaInt)
            {
                return false;
            }
            

            /*Provjera datum kraj*/

            int pomocniKraj0 = Int16.Parse(pomocniKraj[0]);
            int pomocniKraj1 = Int16.Parse(pomocniKraj[1]);
            int pomocniKraj2 = Int16.Parse(pomocniKraj[2]);

            if (pomocniKraj0 < 1 || pomocniKraj0 > 31
				|| pomocniKraj1 < 1 || pomocniKraj1 > 12
				|| pomocniKraj2 < 0 || pomocniKraj2 > trenutnaGodinaInt)
            {
                return false;
            }

            /* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

            if (pomocniPocetak2 > pomocniKraj2)
            {
                return false;
            }
            else if (pomocniPocetak2 == pomocniKraj2)
            {
                if (pomocniPocetak1 > pomocniKraj1)
                {
                    return false;
                }
                else if (pomocniPocetak1 == pomocniKraj1)
                {
                    if (pomocniPocetak0 > pomocniKraj0)
                    {
                        return false;
                    }
                }
            }

            pomocniPocetakA = pocetak[i+1].Split(".");
            pomocniKrajA = kraj[i+1].Split(".");

            /*Provjera datum pocetak*/

            int pomocniPocetak0A = Int16.Parse(pomocniPocetakA[0]);
            int pomocniPocetak1A = Int16.Parse(pomocniPocetakA[1]);
            int pomocniPocetak2A = Int16.Parse(pomocniPocetakA[2]);


            if (pomocniPocetak0A < 1 || pomocniPocetak0A > 31
                || pomocniPocetak1A < 1 || pomocniPocetak1A > 12
                || pomocniPocetak2A < 0 || pomocniPocetak2A > trenutnaGodinaInt)
            {
                return false;
            }


            /*Provjera datum kraj*/

            int pomocniKraj0A = Int16.Parse(pomocniKrajA[0]);
            int pomocniKraj1A = Int16.Parse(pomocniKrajA[1]);
            int pomocniKraj2A = Int16.Parse(pomocniKrajA[2]);

            if (pomocniKraj0A < 1 || pomocniKraj0A > 31
                || pomocniKraj1A < 1 || pomocniKraj1A> 12
                || pomocniKraj2A < 0 || pomocniKraj2A > trenutnaGodinaInt)
            {
                return false;
            }

            /* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

            if (pomocniPocetak2A > pomocniKraj2A)
            {
                return false;
            }
            else if (pomocniPocetak2A == pomocniKraj2A)
            {
                if (pomocniPocetak1A > pomocniKraj1A)
                {
                    return false;
                }
                else if (pomocniPocetak1A == pomocniKraj1A)
                {
                    if (pomocniPocetak0A > pomocniKraj0A)
                    {
                        return false;
                    }
                }
            }

            pomocniPocetakB = pocetak[i + 2].Split(".");
            pomocniKrajB = kraj[i + 2].Split(".");

            /*Provjera datum pocetak*/

            int pomocniPocetak0B = Int16.Parse(pomocniPocetakB[0]);
            int pomocniPocetak1B = Int16.Parse(pomocniPocetakB[1]);
            int pomocniPocetak2B = Int16.Parse(pomocniPocetakB[2]);


            if (pomocniPocetak0B < 1 || pomocniPocetak0B > 31
                || pomocniPocetak1B < 1 || pomocniPocetak1B > 12
                || pomocniPocetak2B < 0 || pomocniPocetak2B > trenutnaGodinaInt)
            {
                return false;
            }


            /*Provjera datum kraj*/

            int pomocniKraj0B = Int16.Parse(pomocniKrajB[0]);
            int pomocniKraj1B = Int16.Parse(pomocniKrajB[1]);
            int pomocniKraj2B = Int16.Parse(pomocniKrajB[2]);

            if (pomocniKraj0B < 1 || pomocniKraj0B > 31
                || pomocniKraj1B < 1 || pomocniKraj1B > 12
                || pomocniKraj2B < 0 || pomocniKraj2B > trenutnaGodinaInt)
            {
                return false;
            }

            /* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

            if (pomocniPocetak2B > pomocniKraj2B)
            {
                return false;
            }
            else if (pomocniPocetak2B == pomocniKraj2B)
            {
                if (pomocniPocetak1B > pomocniKraj1B)
                {
                    return false;
                }
                else if (pomocniPocetak1B == pomocniKraj1B)
                {
                    if (pomocniPocetak0B > pomocniKraj0B)
                    {
                        return false;
                    }
                }
            }

			pomocniPocetakC = pocetak[i + 3].Split(".");
            pomocniKrajC = kraj[i + 3].Split(".");

            /*Provjera datum pocetak*/

            int pomocniPocetak0C = Int16.Parse(pomocniPocetakC[0]);
            int pomocniPocetak1C = Int16.Parse(pomocniPocetakC[1]);
            int pomocniPocetak2C = Int16.Parse(pomocniPocetakC[2]);


            if (pomocniPocetak0C < 1 || pomocniPocetak0C > 31
				|| pomocniPocetak1C < 1 || pomocniPocetak1C > 12
				|| pomocniPocetak2C < 0 || pomocniPocetak2C > trenutnaGodinaInt)
            {
                return false;
            }
            

            /*Provjera datum kraj*/

            int pomocniKraj0C = Int16.Parse(pomocniKrajC[0]);
            int pomocniKraj1C = Int16.Parse(pomocniKrajC[1]);
            int pomocniKraj2C = Int16.Parse(pomocniKrajC[2]);

            if (pomocniKraj0C < 1 || pomocniKraj0C > 31
				|| pomocniKraj1C < 1 || pomocniKraj1C > 12
				|| pomocniKraj2C < 0 || pomocniKraj2C > trenutnaGodinaInt)
            {
                return false;
            }

            /* Slučaj 5: Datum početka ne može biti poslije datuma kraja članstva */

            if (pomocniPocetak2C > pomocniKraj2C)
            {
                return false;
            }
            else if (pomocniPocetak2C == pomocniKraj2C)
            {
                if (pomocniPocetak1C > pomocniKraj1C)
                {
                    return false;
                }
                else if (pomocniPocetak1C == pomocniKraj1C)
                {
                    if (pomocniPocetak0C > pomocniKraj0C)
                    {
                        return false;
                    }
                }
            }

           
        }
		




        return true;
    }



	/* Posljednji Code Tuning */
	public bool ProvjeraOpisaTunning5(List<String> stranke, List<String> pocetak, List<String> kraj)
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

		
		String trenutnaGodina = DateTime.Today.ToString("yyyy");
		int trenutnaGodinaInt = Int16.Parse(trenutnaGodina);
		int provjeraGodine = 0;

		DateTime datumPocetka1 = new DateTime();
		DateTime datumKraja1 = new DateTime();

		DateTime datumPocetka2 = new DateTime();
		DateTime datumKraja2 = new DateTime();

		DateTime datumPocetka3 = new DateTime();
		DateTime datumKraja3 = new DateTime();

		DateTime datumPocetka4 = new DateTime();
		DateTime datumKraja4 = new DateTime();

		for (int i = 0; i < pocetak.Count() - 4; i += 4)
		{
			/* Negativnost datuma ili izlazak iz opsega datuma, provjerava već klasa DateTime, koja baca izuzetak. */

			/*===================PRVA===================*/

			datumPocetka1 = DateTime.Parse(pocetak[i]);
			datumKraja1 = DateTime.Parse(kraj[i]);

			provjeraGodine = Int16.Parse(datumPocetka1.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			provjeraGodine = Int16.Parse(datumKraja1.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			if (datumPocetka1 > datumKraja1) return false;


			/*===================DRUGA===================*/

			datumPocetka2 = DateTime.Parse(pocetak[i + 1]);
			datumKraja2 = DateTime.Parse(kraj[i + 1]);

			provjeraGodine = Int16.Parse(datumPocetka2.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			provjeraGodine = Int16.Parse(datumKraja2.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			if (datumPocetka2 > datumKraja2) return false;


			/*===================TREĆA===================*/

			datumPocetka3 = DateTime.Parse(pocetak[i + 2]);
			datumKraja3 = DateTime.Parse(kraj[i + 2]);

			provjeraGodine = Int16.Parse(datumPocetka3.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			provjeraGodine = Int16.Parse(datumKraja3.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			if (datumPocetka3 > datumKraja3) return false;

			/*===================ČETVRTA===================*/

			datumPocetka4 = DateTime.Parse(pocetak[i + 3]);
			datumKraja4 = DateTime.Parse(kraj[i + 3]);

			provjeraGodine = Int16.Parse(datumPocetka4.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			provjeraGodine = Int16.Parse(datumKraja4.ToString("yyyy"));

			if (provjeraGodine > trenutnaGodinaInt)
			{
				return false;
			}

			if (datumPocetka4 > datumKraja4) return false;

		}

		return true;
    }

}

