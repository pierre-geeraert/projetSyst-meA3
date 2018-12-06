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

        public (int, int) parler(maitreHotel mh)
        {
            (int, int) libre = mh.tableLibre(group);
            return libre;
        }

        public (string, string, string) commande(Menu obj)
        {
            List<(int Prix, string Name)> dish = obj.dish();
            int choixDish = rnd.Next(dish.Count);

            List<(int Prix, string Name)> starter = obj.starter();
            int choixstarter = rnd.Next(starter.Count);

            List<(int Prix, string Name)> dessert = obj.dessert();
            int choixdessert = rnd.Next(dessert.Count);

            return (starter[choixstarter].Name, dish[choixDish].Name, dessert[choixdessert].Name);
        }

        public (int, int) placement(maitreRang mr)
        {
            return mr.Place(group);
        }

        public int payer()
        {
            throw new NotImplementedException();
        }
    }
}