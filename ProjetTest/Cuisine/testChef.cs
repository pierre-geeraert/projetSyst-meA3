using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cuisine2;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cuisine
{
    class testChef
    {
        [TestMethod]
        public void distibCommande()
        {
            chefCusinier chef = new chefCusinier();
            chefCusinier chef2 = new chefCusinier();
            //masterChef chef = new masterChef();
            Commande commande = new Commande();

            commande.ajoutCommande("pates");

            int expectedResult = 50;

            Assert.AreEqual(expectedResult, chef.tempsPlat(commande.liste[0]));
        }
    }
}
