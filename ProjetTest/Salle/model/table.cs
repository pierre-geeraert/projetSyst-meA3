using System;
using System.Collections.Generic;
using System.Text;

namespace Salle.model
{
    public class Table
    {
        int tableX;
        int tableY;
        public Table()
        {
            enumTableClient client = enumTableClient.vide;
            enumTableProprete proprete = enumTableProprete.propre;
            tableX = 0;
            tableY = 0;
        }

        public int getTableX()
        {
            return tableX;
        }

        public int getTableY()
        {
            return tableY;
        }
    }
}
