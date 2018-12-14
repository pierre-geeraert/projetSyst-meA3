using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Graphique_Salle.Model
{
    public class Menu
    {
        public List<(int Prix, string Name)> starter()
        {
            var starter = new List<(int Prix, string Name)>
            {
                (1, "pates")
            };

            return starter;
        }

        public List<(int Prix, string Name)> dish()
        {
            var dish = new List<(int Prix, string Name)>
            {
                (1, "pates")
            };

            return dish;
        }

        public List<(int Prix, string Name)> dessert()
        {
            var dessert = new List<(int Prix, string Name)>
            {
                (1, "pates")
            };

            return dessert;
        }
    }
}
