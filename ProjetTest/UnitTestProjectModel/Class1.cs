using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Salle.model;

namespace UnitTestProjectModel
{
    [TestClass]
    public class Client
    {
        [TestMethod]
        public void ParlerTest()
        {
            MaitreHotel mh = new MaitreHotel();
            Clientt cli = new Clientt();


            int expectedResult = 1;
            int actualResult = cli.parlerTest();

            Assert.AreEqual(expectedResult, actualResult);

        }


    }
}
