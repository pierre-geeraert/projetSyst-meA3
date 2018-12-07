using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Salle2.model
{
    class ConnectionBDD
    {
        // Connection's configuration:
        private static string connectionString = @"Data Source=geeraert.eu;Initial Catalog=projet1;User ID=projet;Password=1234";
        private static ConnectionBDD singleton;
        private static SqlConnection sqlConnection;

        public ConnectionBDD()
        {
            co();
        }

        public static SqlConnection SqlConnetionFactory
        {
            get { return sqlConnection; }
        }
        
        public static ConnectionBDD Singleton
        {
            get
            {
                if (singleton == null)
                    singleton = new ConnectionBDD();

                sqlConnection = new SqlConnection(connectionString);
                return singleton;
            }
        }

        public ConnectionBDD co()
        {
            return singleton;
        }

        public void selecQqch()
        {
            try
            {
               sqlConnection.Open();

                // Création d'une commande SQL en fonction de l'objet connection
                SqlCommand cmd = sqlConnection.CreateCommand();

                // Requête SQL
                cmd.CommandText = "select x from place";

                // Exécution de la commande SQL
                cmd.ExecuteNonQuery();

                // Fermeture de la connexion
                sqlConnection.Close();
            }
            catch
            {

            }
            Console.WriteLine("");
        }
    }
}
