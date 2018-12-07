using System;
using Salle.model;

namespace Salle
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();

            for(int i = 0; i < 10; i++)
            {
                Client c = new Client();
                maitreHotel mh = new maitreHotel(c);
                maitreRang mr = new maitreRang();
                Menu menu = new Menu();

                c.Attach(mh);
                c.parler(mh);
                Console.WriteLine(c.clientX);
                Console.WriteLine(c.clientY);
                c.placement(mr);
                Console.WriteLine(c.clientX);
                Console.WriteLine(c.clientY);
                c.commande(menu);
                c.payer(menu);
                Console.WriteLine("\n");
            }
            Console.ReadKey();
        }
    }
}
