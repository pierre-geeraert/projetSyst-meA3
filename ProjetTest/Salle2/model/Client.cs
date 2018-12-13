using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

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
        private logWrite log = new logWrite();

        public Client()
        {
            clientX = 50;
            clientY = 150;
            group = rnd.Next(1,10);
        }

        public void parler()
        {
            Notify();
            log.Write("Passé dans client parler");
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
            log.Write("Client passe une commande");
            return (starter[choixstarter].Name, dish[choixDish].Name, dessert[choixdessert].Name);
        }

        public (int, int) placement()
        {
            maitreRang mr = new maitreRang();
            (clientX, clientY) = mr.Place(group);
            log.Write("Client passsé" + (clientX, clientY));
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
            log.Write("Client paye" + total);
            return total;
        }

        public string SubjectState
        {
            get { return _subjectState; }
            set { _subjectState = value; }
        }


        public void Attach()
        {
            maitreHotel mh = new maitreHotel();
            mh = maitreHotel.GetInstance();
            _observers.Add(mh);
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