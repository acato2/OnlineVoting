using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void PraznoINullImeTest()
        {
            Glasac g = new Glasac();
            Exception ex=Assert.ThrowsException<Exception>(() => g.Ime = "");
            Assert.AreEqual(ex.Message, "Ime ne smije biti prazno!");
            Exception ex1=Assert.ThrowsException<Exception>(() => g.Ime = null);
            Assert.AreEqual(ex1.Message, "Ime ne smije biti prazno!");
        }
        [TestMethod]
        public void NevalidnaDuzinaImenaTest()
        {
            Glasac g = new Glasac();
            Exception ex=Assert.ThrowsException<Exception>(() => g.Ime="n");
            Exception ex1=Assert.ThrowsException<Exception>(() => g.Ime = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaNN");
            Assert.AreEqual(ex.Message, "Pogrešan format imena!");
            Assert.AreEqual(ex1.Message, "Pogrešan format imena!");
        }
        [TestMethod]
        public void NevalidniKarakteriUImenu()
        {
            Glasac g = new Glasac();
            Assert.ThrowsException<Exception>(() => g.Ime = "5KK");
            Assert.ThrowsException<Exception>(() => g.Ime = "*-NAIDA");
            Assert.ThrowsException<Exception>(() => g.Ime = "naida-nozic-+-");
            Assert.ThrowsException<Exception>(() => g.Ime = "nai noz");
            Assert.ThrowsException<Exception>(() => g.Ime = "n\nnn");
            Assert.ThrowsException<Exception>(() => g.Ime = "--");
            Assert.ThrowsException<Exception>(() => g.Ime = "---");
        }
        [TestMethod]

        public void ValidniKarakteriUImenu()
        {
            Glasac g = new Glasac();
            Exception ex1 = null;
            try
            {
                g.Ime = "Naida-nozic";
                g.Ime = "---nn";
                g.Ime = "n-n";
                g.Ime = "-AdnaCato-Prezime";
            }catch(Exception ex)
            {
                ex1 = ex;
            }
            Assert.IsNull(ex1);
        }
    }
}
