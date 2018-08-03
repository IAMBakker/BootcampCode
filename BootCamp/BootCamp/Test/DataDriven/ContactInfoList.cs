using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Test.DataDriven
{
    public class ContactInfoList : ValueSourceAttribute
    {
        public static IEnumerable ContactInfoDataSet;

        public ContactInfoList() 
            : base(typeof(ContactInfoList), "ContactInfoDataSet")
        {
            ContactInfoDataSet = GetContactInfoListFromJson();
        }

        private static IEnumerable GetContactInfoListFromJson()
        {
            var testData = File.ReadAllText(@"C:\Users\Gebruiker\git-projects\BootcampCode\BootCamp\BootCamp\Test\DataDriven\test905params.json");
            JObject testDataJson = JObject.Parse(testData);
            IList<JToken> testDataArray = testDataJson["TestData"].Children().ToList();
            IList<ContactInfo> contactInfoList = new List<ContactInfo>();
            foreach(JToken contactInfoJson in testDataArray)
            {
                ContactInfo contactInfo = contactInfoJson.ToObject<ContactInfo>();
                contactInfoList.Add(contactInfo);
            }
            return contactInfoList;
        }
    }
}
