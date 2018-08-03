using System;
using BootCamp.Pages;
using BootCamp.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootCamp.Test
{
    [TestClass]
    public class NOK_ContactFormEmailFormatTest : TestShopScenario
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
                "nope", "4321234", "Help!");

            bool emailIsValid = contactUsPage.GetEmailValidation();

            Assert.IsFalse(emailIsValid, "Email address should not be valid");

            emailIsValid = contactUsPage.FillContactForm("Customer service",
                "yes@yesYes.girl", "3211234", "this will work")
                .GetEmailValidation();

            Assert.IsTrue(emailIsValid, "This email should show it should be valid");
        }
    }
}
