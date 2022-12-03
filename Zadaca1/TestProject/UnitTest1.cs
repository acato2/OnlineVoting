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
                g.Ime = "Naida-nozic";
                g.Ime = "---nn";
                g.Ime = "n-n";
                g.Ime = "-AdnaCato-Prezime";
                g.Ime = "nn";
                g.Ime = "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn";
                Assert.AreEqual(g.Ime, "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn");

        }
        [TestMethod]
        public void PraznoINullPrezimeTest()
        {
            Glasac g = new Glasac();
            Exception ex = Assert.ThrowsException<Exception>(() => g.Prezime = "");
            Assert.AreEqual(ex.Message, "Prezime ne smije biti prazno!");
            Exception ex1 = Assert.ThrowsException<Exception>(() => g.Prezime = null);
            Assert.AreEqual(ex1.Message, "Prezime ne smije biti prazno!");
        }
        [TestMethod]
        public void NevalidnaDuzinaPrezimenaTest()
        {
            Glasac g = new Glasac();
            Exception ex = Assert.ThrowsException<Exception>(() => g.Prezime = "n");
            Exception ex1 = Assert.ThrowsException<Exception>(() => g.Prezime = "N-");
            Exception ex2 = Assert.ThrowsException<Exception>(() => g.Prezime = "NNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNg");
            Assert.AreEqual(ex.Message, "Pogrešan format prezimena!");
            Assert.AreEqual(ex1.Message, "Pogrešan format prezimena!");
        }
        [TestMethod]
        public void NevalidniKarakteriUPrezimenu()
        {
            Glasac g = new Glasac();
            Assert.ThrowsException<Exception>(() => g.Prezime = "5KK");
            Assert.ThrowsException<Exception>(() => g.Prezime = "*-NAIDA");
            Assert.ThrowsException<Exception>(() => g.Prezime = "naida-nozic-+-");
            Assert.ThrowsException<Exception>(() => g.Prezime = "nai noz");
            Assert.ThrowsException<Exception>(() => g.Prezime = "n\nnn");
            Assert.ThrowsException<Exception>(() => g.Prezime = "--");
            Assert.ThrowsException<Exception>(() => g.Prezime = "---");
            Assert.ThrowsException<Exception>(() => g.Prezime = "nnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnnn-");
        }
        [TestMethod]

        public void ValidniKarakteriUPrezimenu()
        {
            Glasac g = new Glasac();
                g.Prezime = "Naida-nozic";
                g.Prezime = "---nnn";
                g.Prezime = "n-nn";
                g.Prezime = "-AdnaCato-Prezime";
                g.Prezime = "nnn";
                g.Prezime = "gggggggggg-gggggggggg-gggggggggg-gggggggggg-gggggggggg";
                Assert.AreEqual(g.Prezime, "gggggggggg-gggggggggg-gggggggggg-gggggggggg-gggggggggg");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void NijePunoljetanGlasacTest()
        {
            try
            {
                Glasac g = new Glasac();
                g.DatumRodjenja = new DateTime(2005, 06, 07);}
            catch(Exception ex)
            {
                Assert.AreEqual(ex.Message, "Glasac mora biti punoljetan");
                throw;}}

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void DatumUBuducnostiTest()
        {
            try
            {
                Glasac g = new Glasac();
                g.DatumRodjenja = new DateTime(2023, 06, 07); }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Datum ne moze biti u buducnosti!");
                throw;}}

        [TestMethod]
        public void IspravanDatumTest()
        {
            Glasac g = new Glasac();
                g.DatumRodjenja = new DateTime(2001, 06, 07);
                g.DatumRodjenja = new DateTime(2004, 12, 03);
                Assert.IsTrue(DateTime.Compare(g.DatumRodjenja, new DateTime(2004, 12, 03))==0);
        }
        [TestMethod]
        public void NevalidnaDuzinaLicneKarteTest()
        {
            Glasac g=new Glasac();
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "123456");
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "12345678");
        }
        [TestMethod]
        public void NevalidniFormatLicneKarteTest()
        {
            Glasac g = new Glasac();
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "99AA887");
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "996A888");
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "996a8887");
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "991k883");
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "");
            Assert.ThrowsException<Exception>(() => g.BrojLicne = null);
            Assert.ThrowsException<Exception>(() => g.BrojLicne = "001-187");
        }
        [TestMethod]
        public void ValidniFormatLicneKarteTest()
        {
                Glasac g = new Glasac();
                g.BrojLicne = "123K456";
                g.BrojLicne = "000E000";
                Assert.AreEqual(g.BrojLicne, "000E000");
        }
        [TestMethod]
        public void NevalidnaDuzinaMaticnogBrojaTest()
        {
            Glasac g=new Glasac();
            Assert.ThrowsException<Exception>(() => g.Jmbg="");
            Assert.ThrowsException<Exception>(() => g.Jmbg = "123");
            Assert.ThrowsException<Exception>(() => g.Jmbg = "12345678912344");
        }
        [TestMethod]
        public void NevalidanFormatMaticnogBroja()
        {
            Glasac g=new Glasac();
            Assert.ThrowsException<Exception>(() => g.Jmbg="g123456789123");
            g.DatumRodjenja = new DateTime(2001, 1, 1);
            Assert.ThrowsException<Exception>(() => g.Jmbg = "0101000239812");
            g.DatumRodjenja = new DateTime(2001, 7, 18);
            Assert.ThrowsException<Exception>(() => g.Jmbg = "0011001237899");
            Assert.ThrowsException<Exception>(() => g.Jmbg = "01010012-7899");
            Assert.ThrowsException<Exception>(() => g.Jmbg = "010100123789A");
        }
        [TestMethod]
        public void ValidniMaticniBrojevi()
        {
                Glasac g = new Glasac();
                g.DatumRodjenja = new DateTime(2001, 1, 1);
                g.Jmbg = "0101001899999";
                g.DatumRodjenja = new DateTime(2000, 7, 18);
                g.Jmbg = "1807000999999";
                Assert.AreEqual(g.Jmbg, "1807000999999");
        }
        [TestMethod]
        public void NevalidnaAdresa()
        {
            Glasac g = new Glasac();
            Exception ex=Assert.ThrowsException<Exception>(() => g.Adresa = "");
            Exception ex1 = Assert.ThrowsException<Exception>(() => g.Adresa = null);
            Exception ex2 = Assert.ThrowsException<Exception>(() => g.Adresa = "h");
            Assert.AreEqual(ex.Message, "Adresa ne moze biti prazna!");
            Assert.AreEqual(ex1.Message, "Adresa ne moze biti prazna!");
            Assert.AreEqual(ex2.Message, "Adresa mora biti duza od 2 karaktera!");
            g.Adresa = "Validna adresa";
            Assert.AreEqual(g.Adresa, "Validna adresa");
        }
        [TestMethod]
        public void IdTest()
        {
            Glasac g = new Glasac("Nn", "nozic", "ob", new DateTime(2001, 07, 18), "123E123", "1807001999999");
            Assert.ThrowsException<Exception>(() => g.Id = "Nnnoob181219");
            Assert.ThrowsException<Exception>(() => g.Id = "Nnnoob182218");
            Assert.ThrowsException<Exception>(() => g.Id = "Nnnoob81218");
            Assert.ThrowsException<Exception>(() => g.Id = "NnnoOb181218");
            Assert.ThrowsException<Exception>(() => g.Id = "Nnn+ob181218");
            Assert.ThrowsException<Exception>(() => g.Id = "nnnoob181218");
            g = new Glasac("Nn", "nozic", "ob", new DateTime(2001, 07, 8), "123E123", "0807001999999");
            Assert.AreEqual(g.Id, "Nnnoob081208");
        }
    }
}
