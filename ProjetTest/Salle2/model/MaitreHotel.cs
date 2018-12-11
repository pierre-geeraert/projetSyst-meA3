using System;
using System.Collections.Generic;

namespace Salle2.model
{
    public class maitreHotel
    {
        private int _observerState;
        private Client _subject;
        private string _name;

        private static maitreHotel instance = null;

        private static readonly object mylock = new object();
        
        public maitreHotel()
        {

        }

        /// <summary>
        /// Check if one table is availaible for customers
        /// </summary>
        /// <param name="taille"></param>
        public (int , int) tableLibre(int taille)
        {
            int libreX = 0;
            int libreY = 0;
            Table table = new Table();
            if (table.getLibre(taille))
            {
                List<Table> vide = new List<Table>();
                vide.Add(new Table(1, 2, 4));
                vide.Add(new Table(1, 3, 8));

                // ajouter à chaque entré dans la table vide
                foreach (Table element in vide)
                {
                    if (taille <= 4 && element.place <= 4)
                    {
                        libreX = element.tableX;
                        libreY = element.tableY;
                        table.client = enumTableClient.prise;
                        table.proprete = enumTableProprete.sale;
                    }
                    else if (taille <= 8 && taille > 4 && element.place > 4 && element.place <= 8)
                    {
                        libreX = element.tableX;
                        libreY = element.tableY;
                    }
                }
            }
            return (libreX, libreY);
        }

        /// <summary>
        /// DP Singleton
        /// </summary>
        public static maitreHotel GetInstance()
        {
            lock ((mylock))
            {
                if (instance == null)
                {
                    instance = new maitreHotel();
                }
                return instance;
            }
        }

        public void Update(int nbr)
        {
            Console.WriteLine("Le maitre d'hotel à capté des clients. Ils sont {0}", nbr);
            Console.WriteLine("Vous serez placer à la table {0}", tableLibre(nbr));
        }
    }
}