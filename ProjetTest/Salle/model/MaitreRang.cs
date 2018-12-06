using System;
using System.Collections.Generic;

namespace Salle.model
{
    public class maitreRang
    {
        public int maitreRangX;
        public int maitreRangY;

        public (int, int) Place(int group)
        {
            List<Table> vide = new List<Table>();
            vide.Add(new Table(1, 2, 4));
            vide.Add(new Table(1, 3, 8));

            // ajouter à chaque entré dans la table vide
            foreach(Table element in vide)
            {
                if (group <= 4 && element.place <= 4)
                {
                    maitreRangX = element.tableX;
                    maitreRangY = element.tableY;
                }else if(group <= 8 && group > 4 && element.place > 4 && element.place <= 8)
                {
                    maitreRangX = element.tableX;
                    maitreRangY = element.tableY;
                }
            }
            return (maitreRangX, maitreRangY);
        }
    }
}