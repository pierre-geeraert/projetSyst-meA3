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

                c.Attach(mh);
                c.parler(mh);
            }
            Console.ReadKey();
        }
    }
}
