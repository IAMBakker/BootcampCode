using System;
using BootCamp.Test.API.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;

namespace BootCamp.Test.API
{
    [TestClass]
    public class VerstappenResults2016StatusOkTest : APIScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            var request = new RestRequest("/2016/drivers/max_verstappen/results.json", Method.GET);

            IRestResponse response = client.Execute(request);

            Assert.IsTrue(response.IsSuccessful);
        }
    }
}
