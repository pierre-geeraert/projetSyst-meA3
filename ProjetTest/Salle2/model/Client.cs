using System;
using System.Collections.Generic;

namespace Salle2.model
{
    public class Client
    {

        Random rnd = new Random();
        public int group;
        public int clientX;
        public int clientY;
        private string _subjectState;
        private List<maitreHotel> _observers = new List<maitreHotel>();

        public Client()
        {
            clientX = 50;
            clientY = 150;
            group = rnd.Next(1,10);
        }

        public void parler()
        {
            Notify();
            //(int, int) libre = mh.tableLibre(group);
            //return libre;
        }

        public (string, string, string) commande(Menu obj)
        {
            List<(int Prix, string Name)> dish = obj.dish();
            int choixDish = rnd.Next(dish.Count);

            List<(int Prix, string Name)> starter = obj.starter();
            int choixstarter = rnd.Next(starter.Count);

            List<(int Prix, string Name)> dessert = obj.dessert();
            int choixdessert = rnd.Next(dessert.Count);

            Console.WriteLine("Je commande " + starter[choixstarter].Name + " " + dish[choixDish].Name + " " + dessert[choixdessert].Name);
            return (starter[choixstarter].Name, dish[choixDish].Name, dessert[choixdessert].Name);
        }

        public (int, int) placement()
        {
            maitreRang mr = new maitreRang();
            (clientX, clientY) = mr.Place(group);
            return mr.Place(group);
        }

        public int payer(Menu obj)
        {
            List<(int Prix, string Name)> dish = obj.dish();
            int choixDish = rnd.Next(dish.Count);

            List<(int Prix, string Name)> starter = obj.starter();
            int choixstarter = rnd.Next(starter.Count);

            List<(int Prix, string Name)> dessert = obj.dessert();
            int choixdessert = rnd.Next(dessert.Count);


            int total = starter[choixstarter].Prix + starter[choixDish].Prix + starter[choixdessert].Prix;
            Console.WriteLine("Nous payons: " + total);
            return total;
        }

        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }


        public void Attach()
        {
            _observers.Add(new maitreHotel());
        }

        public void Notify()
        {
            foreach(maitreHotel mh in _observers)
            {
                mh.Update(group);
            }
        }
    }
}