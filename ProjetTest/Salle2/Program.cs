using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle2.model;
using System.Data.SqlClient;

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
                // Création d'une commande SQL en fonction de l'objet connection
                SqlCommand command = new SqlCommand("Select x from [Place] where type=8", cnn);
                command.Parameters.AddWithValue("@zip", "india");
                
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}", reader["x"]));
                    }
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                //Si pas connecté ce message s'affiche
                Console.WriteLine("Vous n'êtes pas à connecter à la base de données ! " + ex.Message);
            }
            Console.Read();
        }
    }
}
