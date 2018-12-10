using System;
using System.Collections.Generic;

namespace Cuisine2
{
    public class Commande
    {
        public List<String> liste = new List<String>()
        {
            "Pates",
            "Pates",
            "Pates"
        };

        public Commande()
        {

        }

        public void ajoutCommande(string commmande)
        {
            liste.Add(commmande);
        }
    }
}