using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle;
using Salle.model;

namespace TDD
{
    [TestClass]
    public class serveurTest
    {
        [TestMethod]
        public void accesTable0()
        {
            Table table = new Table();
            Serveur serveur = new Serveur();

            (int, int) expectedResult = (0, 0);
            (int, int) actualResult = serveur.marcherTableCoord(table);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void accesTableCoord()
        {
            Table table = new Table(25, 25, 4);
            Serveur serveur = new Serveur();

            (int, int) expectedResult = (25, 25);
            (int, int) actualResult = serveur.marcherTableCoord(table);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void debarasserTable()
        {
            Table table = new Table(25, 25, 4);
            Serveur serveur = new Serveur();
            table.proprete = enumTableProprete.sale;

            int expectedResult = 1;
            int actualResult = serveur.debarasse(table);

            Assert.AreEqual(expectedResult, actualResult);
        }


    }
}
