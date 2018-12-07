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
                Console.WriteLine("vous êtes connecté à la base de données ! ");
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
