using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Test.API.Base
{
    [TestClass]
    public class APIScenario
    {

        protected RestClient client;

        [TestInitialize]
        public void setUp()
        {
            client = new RestClient("http://ergast.com/api/f1");
        }
    }
}
