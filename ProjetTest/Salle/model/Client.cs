using System;
using System.Collections.Generic;

namespace Salle.model
{
    public class Client
    {

        Random rnd = new Random();
        public int group;
        public int clientX;
        public int clientY;

        public Client()
        {
            clientX = 50;
            clientY = 150;
            group = rnd.Next(1,8);
        }

        public int parler(maitreHotel mh)
        {
            int libre = mh.tableLibre();
            return libre;
        }

        public (string, string, string) commande(Menu obj)
        {
            List<string> dish = obj.dish();
            int choixDish = rnd.Next(dish.Count);

            List<string> starter = obj.starter();
            int choixstarter = rnd.Next(starter.Count);

            List<string> dessert = obj.dessert();
            int choixdessert = rnd.Next(dessert.Count);
            return (starter[choixstarter], dish[choixDish], dessert[choixdessert]);
        }

        public (int, int) placement(maitreRang mr)
        {
            return mr.Place(group);
        }
    }
}