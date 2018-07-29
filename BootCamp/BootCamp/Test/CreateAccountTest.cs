using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BootCamp.Model;
using BootCamp.Test;
using BootCamp.Pages.Base;

namespace BootCamp.Test
{
    [TestClass]
    public class CreateAccountTest : TestShopScenario
    {

        [TestMethod]
        public void TestMethod1()
        {
            bool succesfullyCreated = new HomePage(driver)
                .Header.ClickLogin()
                .CreateNewUserAccount(
                    new UserAccount.Builder("Ico", "Bakker")
                    .withEmail("ico.bakker+" + new Random().Next(100, 999) + "@gmail.com")
                    .withPassword("test123")
                    .withBirthDate(26, 7, 1987)
                    .signUpToNewsLetter()
                    .wantsSpecialOffers()
                    .build()
                )
                .GetAlertMessageSuccess();

            Assert.IsTrue(succesfullyCreated, "We should see an alert message that has class: alert-success");
        }
    }
}
