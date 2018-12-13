using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Graphique_Salle.Model
{
    public class Serveur
    {

        int serveurX = 0;
        int serveurY = 0;
        int debarasseTable = 0;

        public (int, int) marcherTableCoord(Table table)
        {
            (serveurX, serveurY) = table.getTableCoord();
            return (serveurX, serveurY);
        }

        public int debarasse(Table table)
        {
            if (table.proprete == enumTableProprete.sale)
            {
                debarasseTable = 1;
            }
            return debarasseTable;
        }
    }
}
