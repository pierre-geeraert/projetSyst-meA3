using System;

namespace Salle.model
{
    public class Serveur
    {

        int serveurX = 0;
        int serveurY = 0;

        public (int, int) marcherTableCoord(model.Table table)
        {
            (serveurX, serveurY) = table.getTableCoord();
            return (serveurX, serveurY);
        }
    }
}