using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Test.DataDriven
{
    public class BrowserList : ValueSourceAttribute
    {
        public static IEnumerable Browsers;

        public BrowserList()
            : base(typeof(BrowserList), "Browsers")
        {
            Browsers = GetBrowserFromConfig();
        }

        private static IEnumerable GetBrowserFromConfig()
        {
            var settings = File.ReadAllText(@"C:\Users\Gebruiker\git-projects\BootcampCode\BootCamp\BootCamp\Test\DataDriven\testParameters.json");
            var config = (JObject)JsonConvert.DeserializeObject(settings);
            var seleniumSettings = config["Selenium"];
            var browsers = (JArray)seleniumSettings["BrowsersToTest"];

            return browsers.ToObject<string[]>();
        }
    }
}
