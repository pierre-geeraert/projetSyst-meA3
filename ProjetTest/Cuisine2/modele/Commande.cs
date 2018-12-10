using System;
using System.Collections.Generic;

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
    }
}