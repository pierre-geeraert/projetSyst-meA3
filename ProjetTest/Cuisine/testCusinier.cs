using System;
using Cuisine2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cuisine
{
    [TestClass]
    public class testCuisiner
    {
        [TestMethod]
        public void platTest()
        {
            chefCusinier chef = new chefCusinier();
            Commande commande = new Commande();

            commande.ajoutCommande("pates");

            int expectedResult = 50;

            //Assert.AreEqual(expectedResult, chef.tempsPlat(commande.liste[0]));
        }
    }
}
