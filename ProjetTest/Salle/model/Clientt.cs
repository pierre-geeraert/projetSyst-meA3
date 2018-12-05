using System;

namespace Salle
{
    public class Clientt
    {
    }
}

namespace Salle.model
{
    public class Clientt
    {
        public int parlerTest()
        {
            int libre = MaitreHotel.tableLibre();
            return libre;
        }
    }
}