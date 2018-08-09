using System;
using BootCamp.Pages;
using BootCamp.Pages.Base;
using BootCamp.Test.Base;
using NUnit.Framework;

namespace BootCamp.Test.DataDriven
{
    [TestFixture]
    public class FillInContactFormTest : DrivenTestShopScenario
    {
        [Test]
        public void TestMethod1([BrowserList] String browser)
        {
            initBrowsers(browser);
            ContactUsPage page = new HomePage(driver)
                .Header.ClickContactUs()
                .FillContactForm("Customer service", "bootcamper@feelthepain.com", "43211234", "Ipod defect while lifting, \nneed new one")
                .SubmitContactForm();
            String pageTitle = page.GetPageTitle();
            String alertMessage = page.GetAlertMessageText();

            Assert.AreEqual("CUSTOMER SERVICE - CONTACT US", pageTitle);
            Assert.AreEqual("Your message has been successfully sent to our team.", alertMessage);
        }
    }
}
