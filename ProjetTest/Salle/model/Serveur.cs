using System;

namespace Salle.model
{
    public class Serveur
    {

        int serveurX = 0;
        int serveurY = 0;

        public int marcherTableX(model.Table table)
        {
            serveurX = table.getTableX();
            return serveurX;
        }

        public int marcherTableY(model.Table table)
        {
            serveurY = table.getTableY();
            return serveurX;
        }
    }
}