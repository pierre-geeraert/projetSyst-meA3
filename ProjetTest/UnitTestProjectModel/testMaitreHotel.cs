using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Salle.model;

namespace UnitTestProjectModel
{
    [TestClass]
    public class testMaitreHotel
    {
        [TestMethod]
        public void singleton()
        {
            maitreHotel mh = new maitreHotel();
            mh = maitreHotel.GetInstance();

            maitreHotel mh2 = new maitreHotel();
            mh2 = maitreHotel.GetInstance();

            
            Assert.AreEqual(mh, mh2);

        }
    }
}
