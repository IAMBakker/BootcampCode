using System;
using BootCamp.API.F1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BootCamp.Test.API
{
    [TestClass]
    public class AbstractDriverYearResultTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            IRestResponse response = new RequestDriverResults()
            .GetDriverResultsPerYear(2016, "max_verstappen");

            Assert.IsTrue(response.IsSuccessful);

            String driverID = JObject.Parse(response.Content)["MRData"]["RaceTable"]["driverId"].ToString();

            Assert.AreEqual("max_verstappen", driverID);
        }
    }
}
