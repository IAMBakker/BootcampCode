using System;
using BootCamp.Test.API.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace BootCamp.Test.API
{
    [TestClass]
    public class VerstappenResults2016DriverIdTest : APIScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            var request = new RestRequest("/2016/drivers/max_verstappen/results.json", Method.GET);

            IRestResponse response = client.Execute(request);

            String driverID = JObject.Parse(response.Content)["MRData"]["RaceTable"]["driverId"].ToString();
            Assert.AreEqual("max_verstappen", driverID, "Driver ID parsed from JSON should be max_verstappen");
        }
    }
}
