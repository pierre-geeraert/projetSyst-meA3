﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle2.model;
using System.Data.SqlClient;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.IO;

namespace Salle2
{
    class Program
    {

        static void Main(string[] args)
        {

            Menu menu = new Menu();
            string serveurs = logWrite.param_txt_file(1);

            Thread threadClient = new Thread(() => newThreadClient(menu));

            Thread threadMh;
            threadMh = new Thread(new ThreadStart(newThreadMh));

            Thread threadMr;
            threadMr = new Thread(new ThreadStart(newThreadMr));

            Thread threadServeur;
            threadServeur = new Thread(new ThreadStart(newThreadServeur));

            logWrite param = new logWrite();

            Console.WriteLine("Il y aura dans la simulation " + serveurs + " serveurs");


            // Lancement des threads
            threadMh.Start();
            threadClient.Start();
            threadMr.Start();
            threadServeur.Start();
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
                cli.placement(); //maitre de rang va l'accompagenr a la table choisie avant
                Console.WriteLine(cli.clientX);
                Console.WriteLine(cli.clientY);
                AsynchronousClient.StartClient(cli.commande(menu).Item1 + " < EOF>");
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