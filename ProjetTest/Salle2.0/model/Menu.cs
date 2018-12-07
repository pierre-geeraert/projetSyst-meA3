using System.Collections.Generic;

namespace Salle.model
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