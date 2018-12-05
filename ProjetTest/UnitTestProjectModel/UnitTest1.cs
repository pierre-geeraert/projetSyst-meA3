using Microsoft.VisualStudio.TestTools.UnitTesting;
using Salle.model;

namespace TDD
{
    [TestClass]
    public class serveurTest
    {
        [TestMethod]
        public void accesTableX()
        {
            Table table = new Table();
            Serveur serveur = new Serveur();

            int expectedResult = 0;
            int actualResult = serveur.marcherTableX(table);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void accesTableY()
        {
            Table table = new Table();
            Serveur serveur = new Serveur();

            int expectedResult = 0;
            int actualResult = serveur.marcherTableY(table);

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
