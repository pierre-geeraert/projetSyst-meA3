using System;
using System.Collections.Generic;
using System.Linq;

namespace Cuisine2
{
    public class Commande
    {
        public List<String> liste = new List<String>();
        public Commande()
        {

        }

        public void ajoutCommande(string commmande)
        {
            liste.Add(commmande);
        }

        public string returnCommande(int number)
        {
            return "pates";
        }
    }
}