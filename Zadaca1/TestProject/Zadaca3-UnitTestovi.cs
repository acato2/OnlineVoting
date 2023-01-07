using CsvHelper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;

namespace TestProject
{
    /*Unit testove za funkcionalnost 1 je pisala Naida Nožić*/
    [TestClass]
    public class Zadaca3_UnitTest
    {
        static Glasac g = new Glasac("Adna", "Cato", "Mrakusa 70", new DateTime(2001, 04, 11), "159K716", "1104001175009");
       

        [TestMethod]
        public void Test1()
        {
            
            String rezultat = g.generisi_id("Filip", "Marić", "T59J062", "Komari bb", "2904005050565");
            StringAssert.Equals(rezultat, "FiMaT5Ko29");
                
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test2() {
            try
            {
                String rezultat = g.generisi_id("", "Nozic", "E5445666", "Sarajevo", "45465446544");
       
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Nije moguce generisati ispravan id");
                throw;
            }
        }

        [TestMethod]
        public void Test3()
        {
            
            String rezultat = g.generisi_id("F", "M", "T", "b", "2");
            StringAssert.Equals(rezultat, "FMTb2");

        }


        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test4()
        {
            try
            {
                String rezultat = g.generisi_id("Adna", "", "T59J062", "Sarajevo", "45465446544");

            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Nije moguce generisati ispravan id");
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test5()
        {
            try
            {
                String rezultat = g.generisi_id("Semina", "Muratovic", "", "Sarajevo", "45465446544");

            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Nije moguce generisati ispravan id");
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test6()
        {
            try
            {
                String rezultat = g.generisi_id("Anida", "Nezovic", "E5445666", "", "45465446544");
            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Nije moguce generisati ispravan id");
                throw;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test7()
        {
            try
            {
                String rezultat = g.generisi_id("Filip", "Maric", "E5445666", "Sarajevo", "");

            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Nije moguce generisati ispravan id");
                throw;
            }
        }



    }
}
