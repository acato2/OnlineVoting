using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    [TestClass]
    public class TuningTests
    {
        [TestMethod]
        public void TestTunning1()
        {
            Tunning tunning = new Tunning();
            tunning.Opis = "Kandidat je bio ";
            List<String> stranke = new List<String>();
            List<String> pocetak = new List<String>();
            List<String> kraj = new List<String>();

            for(int i = 0; i < 10000; i++)
            {
                stranke.Add("LLL");
                pocetak.Add("18.10.2001.");
                kraj.Add("18.12.2001.");
                tunning.Opis += "član stranke LLL od 18.10.2001. do 18.12.2001., ";
            }

            //sada posljednji datum nece valjati i zbog toga ce metoda vratiti false
            tunning.Opis += "član stranke SDA od 11.10.2005. do 11.11.2005., " +
                "član stranke SDP od 22.10.2005. do 22.11.2005., " +
                "član stranke SNSD od 11.11.2009. do 11.10.2009., ";

            stranke.Add("SDA"); stranke.Add("SDP"); stranke.Add("SNSD");
            pocetak.Add("11.10.2005."); pocetak.Add("22.10.2005."); pocetak.Add("11.11.2009.");
            kraj.Add("11.11.2005."); kraj.Add("22.11.2005."); kraj.Add("11.10.2009.");

            for (int i = 0; i < 1000; i++)
            {
                stranke.Add("LLL");
                pocetak.Add("18.10.2001.");
                kraj.Add("18.12.2001.");
                tunning.Opis += "član stranke LLL od 18.10.2001. do 18.12.2001., ";
            }

            int x = 0;



            for (int j = 0; j <= 5000; j++)
            {
                //tunning.ProvjeraOpisaOriginal(stranke, pocetak, kraj);
                tunning.ProvjeraOpisaTunning1(stranke, pocetak, kraj);
            }

            int y = 0;
            Assert.IsTrue(true);
        }
    }
}
