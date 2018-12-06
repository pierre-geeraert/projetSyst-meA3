using System;
using System.Collections.Generic;
using System.Text;

namespace Salle.model
{
    public class Table
    {
        public int tableX;
        public int tableY;
        public int place;
        public bool ok;

       
        public Table()
        {
            enumTableClient client = enumTableClient.vide;
            enumTableProprete proprete = enumTableProprete.propre;
            tableX = 0;
            tableY = 0;
        }

        public bool getLibre(int group)
        {
            if(place <= group)
            {
                ok = true;
            }
            else
            {
                ok = false;
            }
            return ok;
        }

        public Table(int x, int y, int _place)
        {
            enumTableClient client = enumTableClient.vide;
            enumTableProprete proprete = enumTableProprete.propre;
            tableX = x;
            tableY = y;
            place = _place;
        }

        public (int, int) getTableCoord()
        {
            return (tableX , tableY);
        }
    }
}
