using System;
using System.Threading;

namespace Cuisine2
{
    public class chefCusinier
    {
        private masterChef chef = new masterChef();

        public chefCusinier()
        {

        }

        public int tempsPlat()
        {
            string actuel = chef.gererCommande();
            Console.WriteLine(actuel);
            int time = 500;
            Thread.Sleep(time);
            return time;
        }
    }
}