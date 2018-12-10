using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle2.model;
using System.Data.SqlClient;
using System.Threading;

namespace Salle2
{
    class Program
    {
        static void Main(string[] args)
        {
            string connetionString = null;
            SqlConnection cnn;
            connetionString = @"Data Source=geeraert.eu;Initial Catalog=projet1;User ID=projet;Password=1234";
            cnn = new SqlConnection(connetionString);
            try
            {
                //Si connecter à la base de données alors ce message s'affiche
                cnn.Open();
                Console.WriteLine("vous êtes connecté à la base de données ! ");
                cnn.Close();
            }
            catch (Exception ex)
            {
                //Si pas connecté ce message s'affiche
                Console.WriteLine("Vous n'êtes pas à connecter à la base de données ! " + ex.Message);
            }

            Random rnd = new Random();
            /*for (int i = 0; i < 10; i++)
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
                AsynchronousClient.StartClient(c.commande(menu).Item1 + "<EOF>");
                c.payer(menu);
                Console.WriteLine("\n");
            }*/

            Menu menu = new Menu();

            Thread threadClient = new Thread(() => newThreadClient(menu));

            Thread threadMh;
            threadMh = new Thread(new ThreadStart(newThreadMh));

            Thread threadMr;
            threadMr = new Thread(new ThreadStart(newThreadMr));

            // Lancement des threads
            threadMh.Start();
            Console.WriteLine("Mh crée");
            threadClient.Start();
            

        }


        public static void newThreadClient(Menu menu)
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                // Attente de 2000 ms
                Thread.Sleep(1000);
                // Affichage dans la console
                Client cli = new Client();
                cli.Attach();
                cli.parler();
                cli.placement();
                Console.WriteLine(cli.clientX);
                Console.WriteLine(cli.clientY);
                AsynchronousClient.StartClient(cli.commande(menu).Item1 + "<EOF>");
                cli.payer(menu);
            }
        }

        public static void newThreadMh()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                maitreHotel mh = new maitreHotel();
            }
        }

        public static void newThreadMr()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                maitreRang mr = new maitreRang();
            }
        }
    }
}