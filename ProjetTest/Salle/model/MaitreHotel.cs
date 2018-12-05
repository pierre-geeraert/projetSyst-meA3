using System;

namespace Salle.model
{
    public class MaitreHotel
    {
        public int tableLibre()
        {
           Table table = new Table();
           return table.getLibre();
        }
    }
}