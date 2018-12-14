using System;
using System.Collections.Generic;

namespace Salle2.model
{
    public class maitreRang
    {
        public int maitreRangX;
        public int maitreRangY;
        private logWrite log = new logWrite();

        public Table Table
        {
            get => default(Table);
            set
            {
            }
        }

        public (int, int) Place(int group)
        {
            maitreHotel mh = new maitreHotel();
            mh = maitreHotel.GetInstance();
            return mh.tableLibre(group);
        }
    }
}