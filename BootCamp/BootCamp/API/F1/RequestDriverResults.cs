using Microsoft.VisualStudio.TestTools.UnitTesting;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.API.F1
{
    public class RequestDriverResults
    {
        private RestClient client;

        public RequestDriverResults()
        {
            client = new RestClient("http://ergast.com/api/f1");
        }

        public IRestResponse GetDriverResultsPerYear(int year, String driverName)
        {
            var request = new RestRequest("/"+ year  
                +"/drivers/" + driverName + "/results.json", Method.GET);

            return client.Execute(request);
        }

        public IRestResponse GetRaceResultsPerYearPerRace(int year, String raceName)
        {
            var request = new RestRequest("/" + year
                + "/" + raceName + "/results.json", Method.GET);
            IRestResponse response = client.Execute(request);
            Assert.IsTrue(response.IsSuccessful);

            return response;
        }
    }
}
