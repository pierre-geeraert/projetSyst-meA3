using System;
using System.Collections.Generic;

namespace Salle2.model
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