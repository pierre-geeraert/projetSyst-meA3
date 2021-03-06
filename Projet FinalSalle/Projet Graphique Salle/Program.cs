﻿using Projet_Graphique_Salle.Model;
using System;
using System.Diagnostics;
using System.Threading;

namespace Projet_Graphique_Salle
{
    /// <summary>
    /// The main class.
    /// </summary>
    public static Client cli;
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
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

            Thread threadServeur;
            threadServeur = new Thread(new ThreadStart(newThreadServeur));

            // Lancement des threads
            threadMh.Start();
            threadClient.Start();
            threadMr.Start();
            threadServeur.Start();

            using (var game = new SalleVue())
                game.Run();
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
                cli.parler(); //maitre va lui dire ou il va etre
                cli.placement(); //amitre de rang va l'accompagenr a la table choisie avant
                Console.WriteLine(cli.clientX);
                Console.WriteLine(cli.clientY);
                AsynchronousClient.StartClient(cli.commande(menu).Item1 + "<EOF>");
                cli.payer(menu);
                threadSuper();
            }
        }

        public static void newThreadMh()
        {
            // Tant que le thread n'est pas tué, on travaille
            while (Thread.CurrentThread.IsAlive)
            {
                maitreHotel mh = new maitreHotel();
                mh = maitreHotel.GetInstance();
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

        public static void newThreadServeur()
        {
            while (Thread.CurrentThread.IsAlive)
            {
                Serveur serveur = new Serveur();
                //serveur.debarasse();
            }
        }

        public static void threadSuper()
        {
            ProcessThreadCollection threads = Process.GetCurrentProcess().Threads;
            foreach (ProcessThread pt in threads)
            {
                //Console.WriteLine("  thread:  {0}", pt.Id);
                //Console.WriteLine("    started: {0}", pt.StartTime.ToString());
                //Console.WriteLine("    CPU time: {0}", pt.TotalProcessorTime);
                //Console.WriteLine("    priority: {0}", pt.BasePriority);
                //Console.WriteLine("    thread state: {0}", pt.ThreadState.ToString());
            }
        }
    
          

        }
    }

