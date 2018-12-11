using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cuisine2
{
    class masterChef
    {
        private int i = 0;

        public masterChef()
        {

        }

        public string gererCommande()
        {
            Commande commande = new Commande();
            return commande.returnCommande(i);
        }
    }
}
