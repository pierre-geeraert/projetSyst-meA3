using System;
using System.Collections.Generic;

namespace Salle.model
{
    public class maitreHotel
    {
        public (int , int) tableLibre(int taille)
        {
            int libreX;
            int libreY;
            Table table = new Table();
            if (table.getLibre(taille))
            {
                List<Table> vide = new List<Table>();
                vide.Add(new Table(1, 2, 4));
                vide.Add(new Table(1, 3, 8));

                // ajouter à chaque entré dans la table vide
                foreach (Table element in vide)
                {
                    if (taille <= 4 && element.place <= 4)
                    {
                        libreX = element.tableX;
                        libreY = element.tableY;
                    }
                    else if (taille <= 8 && taille > 4 && element.place > 4 && element.place <= 8)
                    {
                        libreX = element.tableX;
                        libreY = element.tableY;
                    }
                }
            }
            return (1, 2);
        }
    }
}