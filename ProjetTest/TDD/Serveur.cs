using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle;
using Salle.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace TDD
{
    [TestClass]
    class serveurTest
    {
        [TestMethod]
        public void accesTableX()
        {
            Table table = new Table();
            Serveur serveur = new Serveur();

            int expectedResult = 0;
            int  actualResult = serveur.marcherTableX(table);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
