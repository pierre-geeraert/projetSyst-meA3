using System.Collections.Generic;

namespace Salle.model
{
    public class Menu
    {
        public List<string> dish()
        {
            List<string> dish = new List<string>();
            dish.Add("pates");

            return dish;
        }

        public List<string> starter()
        {
            List<string> starter = new List<string>();
            starter.Add("pates");

            return starter;
        }

        public List<string> dessert()
        {
            List<string> dessert = new List<string>();
            dessert.Add("pates");

            return dessert;
        }
    }
}