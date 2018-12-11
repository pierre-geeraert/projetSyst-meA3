using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Salle2.model
{
    class baseDataSet
    {

        public static void ConnectToData(string connectionString)
        {
            
        }

        static public string GetConnectionString()
        {
            // To avoid storing the connection string in your code, 
            // you can retrieve it from a configuration file.
            return "Data Source=geeraert.eu;Initial Catalog=projet1;User ID=projet;Password=1234";
        }

        public List<int> getTable(string connectionString)
        {
            List<int> tableX = new List<int>();
            //Create a SqlConnection to the Northwind database.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                //Create a SqlDataAdapter for the PLace table.
                SqlDataAdapter adapter = new SqlDataAdapter();

                // A table mapping names the DataTable.
                adapter.TableMappings.Add("Place", "Recette");

                // Open the connection.
                connection.Open();
                //Console.WriteLine("The SqlConnection is open.");

                // Create a SqlCommand to retrieve Suppliers data.
                SqlCommand command = new SqlCommand("dbo.table_coord_all_x", connection);
                command.CommandType = CommandType.Text;

                // Set the SqlDataAdapter's SelectCommand.
                adapter.SelectCommand = command;

                // Fill the DataSet.
                DataSet dataSet = new DataSet("Table");
                adapter.Fill(dataSet);

                // Close the connection.
                connection.Close();
                //Console.WriteLine("The SqlConnection is closed.");

                foreach (DataRow row in dataSet.Tables[0].Rows)
                {
                    tableX.Add((int)row["X"]);
                }

                return tableX;
            }
        }

        public void setTable(string connectionString)
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

                // Set the SqlDataAdapter's SelectCommand.
                //adapter.SelectCommand = command;

                // Fill the DataSet.
                //DataSet dataSet = new DataSet("Table");
                //adapter.Fill(dataSet);

                // Close the connection.
                connection.Close();
                //Console.WriteLine("The SqlConnection is closed.");
            }
        }
    }
}