using System;
using System.Collections.Generic;

namespace Cuisine2
{
    public class Commande
    {
<<<<<<< HEAD
        public List<String> liste = new List<String>();
=======
        public List<String> liste = new List<String>()
        {
            "Pates",
            "Pates",
            "Pates"
        };

>>>>>>> master
        public Commande()
        {

        }

        public void ajoutCommande(string commmande)
        {
            liste.Add(commmande);
        }
    }
}