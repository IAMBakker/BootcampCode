using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BootCamp.Test.Base;
using BootCamp.Test;
using BootCamp.Pages.Base;

namespace BootCamp.Test
{
    [TestClass]
    public class LoginTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            String pageTitle = new HomePage(driver)
                .Header.ClickLogin()
                .LoginSuccesfully("ico.bakker+123@gmail.com", "test123")
                .GetPageTitle();

            Assert.AreEqual("MY ACCOUNT", pageTitle);
        }
    }
}
