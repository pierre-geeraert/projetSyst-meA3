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
            string connectionString = baseDataSet.GetConnectionString();
            baseDataSet bdd = new baseDataSet();
            List<int> listTableX = bdd.getTable(connectionString);

            foreach (int element in listTableX)
            {
                //Console.WriteLine(element);
            }

            
            int libreX = 0;
            int libreY = 0;
            
            Table table = new Table();
            if (table.getLibre(taille))
            {
                List<Table> vide = new List<Table>();
                Table useTable = new Table();


                foreach (int element in listTableX)
                {
                    vide.Add(new Table(element, element, 4));
                }

                if (taille <= 4)
                {
                    useTable = vide.Find(x => x.place <= 4) ;
                    libreX = useTable.tableX;
                    libreY = useTable.tableY;
                    table.client = enumTableClient.prise;
                    table.proprete = enumTableProprete.sale;
                }
                else if (taille <= 8 && taille > 4)
                {
                    useTable = vide.Find(x => x.place <= 8 && taille > 4);
                    libreX = useTable.tableX;
                    libreY = useTable.tableY;
                    table.client = enumTableClient.prise;
                    table.proprete = enumTableProprete.sale;
                }
                else
                {
                    useTable = vide.Find(x => x.place > 8);
                    libreX = useTable.tableX;
                    libreY = useTable.tableY;
                    table.client = enumTableClient.prise;
                    table.proprete = enumTableProprete.sale;
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