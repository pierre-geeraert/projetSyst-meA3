using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Salle2.model;

namespace Salle2
{
    class Program
    {
        static void Main(string[] args)
        {
            ConnectionBDD co = new ConnectionBDD();
            co.SqlConnetionFactory();
        }
    }
}
