using System;
using BootCamp.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootCamp
{
    [TestClass]
    public class ObjectOrientedTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Auto auto = new Auto();
            auto.Color = "Green";
            auto.Brand = "Tesla";
            auto.AmountOfWheels = 4;

            Auto auto2 = new Auto("Green", 4, "Tesla", new Auto.Motor("V1", 20, 600));

            Assert.AreEqual(auto, auto2, "Created using constructor and using setters should be the same object.");
        }

        [TestMethod]
        public void TestMethod2()
        {
            Auto auto = new Auto("Green", 4, "Tesla", new Auto.Motor("V12", 300, 1200));

            auto.PrintAuto();
        }
    }
}
