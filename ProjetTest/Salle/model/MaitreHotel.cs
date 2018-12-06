using System;

namespace Salle.model
{
    public class maitreHotel
    {
        public void tableLibre(int taille)
        {
           Table table = new Table();
           return table.getLibre(taille);
        }
    }
}