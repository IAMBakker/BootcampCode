using System;
using BootCamp.Pages;
using BootCamp.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootCamp.Test
{
    [TestClass]
    public class NOK_FillInContactFormTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomePage homePage = new HomePage(driver);
            if (homePage.Header.UserNameFieldExists())
            {
                homePage.Header.ClickSignOut();
            }
            ContactUsPage contactUsPage = homePage.Header
                .ClickContactUs()
                .FillContactForm("Customer service",
                "nope", "4321234", "Help!")
                .SubmitContactForm();

            bool alertMessageSucces = contactUsPage 
                .GetAlertMessageSuccess();

            Assert.IsFalse(alertMessageSucces, "Should be false, since we havent " +
                "filled a correct email address.");
            Assert.IsTrue(contactUsPage.GetAlertMessageText().Contains("Invalid email address"));
        }
    }
}
