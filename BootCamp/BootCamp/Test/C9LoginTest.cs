using System;
using BootCamp.Pages;
using BootCamp.Test.Base;
using BootCamp.Test.DataDriven;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootCamp.Test
{
    [TestClass]
    public class C9LoginTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            
            HomePage homePage = new HomePage(driver);
            if(homePage.Header.UserNameFieldExists())
            {
                homePage.Header.ClickSignOut();
            }

            String loggedInUser = homePage.Header.ClickLogin()
                .LoginSuccesfully("bootcamper@feelthepain.com", "1qazxsw2")
                .Header.GetLoggedInUserName();
            Assert.AreEqual("Seargent Slaughter", loggedInUser);
        }
    }
}
