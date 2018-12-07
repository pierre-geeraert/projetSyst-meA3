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
        private static string connectionString = @"Data Source=geeraert.eu;Initial Catalog=projet1;User ID=projet;Password=***********";
        private static ConnectionBDD singleton;
        private static SqlConnection sqlConnection;

        public ConnectionBDD()
        {

        }

        public SqlConnection SqlConnetionFactory
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
    }
}
