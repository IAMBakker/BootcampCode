using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using BootCamp.Test.Base;
using BootCamp.Test;
using BootCamp.Pages.Base;

namespace BootCamp.Test
{
    [TestClass]
    public class SignOutTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            bool userNameFieldExists = new HomePage(driver)
                .Header.ClickLogin()
                .LoginSuccesfully("ico.bakker+123@gmail.com", "test123")
                .Header.ClickSignOut()
                .Header.UserNameFieldExists();
            
            Assert.IsFalse(userNameFieldExists);
        }
    }
}
