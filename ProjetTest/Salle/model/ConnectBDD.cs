using System;
using System.Data.SqlCient;

class Connection
{
    // Connection's configuration:
    private static string connectionString = @"Data Source=geeraert.eu;Initial Catalog=projet1;User ID=projet;Password=***********";
    private static Connection singleton;
    private static SqlConnection sqlConnection;

    public SqlConnection SqlConnetionFactory
    {
        get { return sqlConnection; }
    }

    private Connection() { }

    public static Connection Singleton
    {
        get
        {
            if (singleton == null)
                singleton = new Connection();

            sqlConnection = new SqlConnection(connectionString);
            return singleton;
        }
    }

}
