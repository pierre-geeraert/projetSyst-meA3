using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Salle2.model
{
    public class maitreHotel
    {
        private int _observerState;
        private Client _subject;
        private string _name;

        private int passage = 0;

        private static maitreHotel instance = null;

        private static readonly object mylock = new object();

        public maitreHotel()
        {

        }

        /// <summary>
        /// Check if one table is availaible for customers
        /// </summary>
        /// <param name="taille"></param>
        public (int, int) tableLibre(int taille)
        {
            string connectionString = baseDataSet.GetConnectionString();
            baseDataSet bdd = new baseDataSet();
            List<Table> listTableX = bdd.getTable(connectionString);
            List<int> listTableNbr = bdd.getTableNbr(connectionString);

            int libreX = 0;
            int libreY = 0;

            Table table = new Table();
            if (table.getLibre(taille))
            {
                List<Table> vide = new List<Table>();
                Table useTable = new Table();


                vide = listTableX;

                if (taille <= 4)
                {
                    useTable = vide.Find(x => x.place <= 4);
                    libreX = useTable.tableX;
                    libreY = useTable.tableY;
                    useTable.client = enumTableClient.prise;
                    useTable.proprete = enumTableProprete.sale;
                    if(passage % 3 == 2)
                    {
                        bdd.setTable(connectionString, libreX, libreY);
                        passage++;
                    }
                    else
                    {
                        passage++;
                    }
                    
                }
                else if (taille <= 8 && taille > 4)
                {
                    useTable = vide.Find(x => x.place <= 8 && taille > 4);
                    libreX = useTable.tableX;
                    libreY = useTable.tableY;
                    useTable.client = enumTableClient.prise;
                    useTable.proprete = enumTableProprete.sale;
                    if (passage % 3 == 2)
                    {
                        bdd.setTable(connectionString, libreX, libreY);
                        passage++;
                    }
                    else
                    {
                        passage++;
                    }
                }
                else
                {
                    useTable = vide.Find(x => x.place > 7);
                    libreX = useTable.tableX;
                    libreY = useTable.tableY;
                    useTable.client = enumTableClient.prise;
                    useTable.proprete = enumTableProprete.sale;
                    if (passage % 3 == 2)
                    {
                        bdd.setTable(connectionString, libreX, libreY);
                        passage++;
                    }
                    else
                    {
                        passage++;
                    };
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

        /*public void setTable(string connectionString)
        {
            List<int> tableX = new List<int>();
            //Create a SqlConnection to the Northwind database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create a SqlDataAdapter for the PLace table.
                //SqlDataAdapter adapter = new SqlDataAdapter();

                // A table mapping names the DataTable.
                //adapter.TableMappings.Add("Place");

                // Open the connection.

                //Console.WriteLine("The SqlConnection is open.");

                // Create a SqlCommand to retrieve Suppliers data.

                connection.Open();
                SqlCommand com = new SqlCommand("dbo.Table_Sale", connection);
                com.CommandType = CommandType.StoredProcedure;
                //Ajouter les paramètres de la procèdure stockée
                com.Parameters.Add("@Tablex", SqlDbType.Int).Value = //faut recup le x;
                com.Parameters.Add("@Tabley", SqlDbType.Int).Value = //faut recup le y;
                com.ExecuteNonQuery();

            }*/
    }
}
