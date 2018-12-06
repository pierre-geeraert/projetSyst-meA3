using System;

namespace Salle.model
{
    public class maitreHotel
    {
        public int tableLibre()
        {
           Table table = new Table();
           return table.getLibre();
        }
    }
}