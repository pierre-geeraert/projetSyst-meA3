using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Graphique_Salle.Model
{
    public class maitreRang
    {
        public int maitreRangX;
        public int maitreRangY;

        public (int, int) Place(int group)
        {
            maitreHotel mh = new maitreHotel();
            mh = maitreHotel.GetInstance();
            return mh.tableLibre(group);
        }
    }
}
