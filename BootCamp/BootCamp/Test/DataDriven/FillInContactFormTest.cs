using System;
using BootCamp.Pages;
using BootCamp.Pages.Base;
using BootCamp.Test.Base;
using NUnit.Framework;

namespace BootCamp.Test.DataDriven
{
    [TestFixture("Chrome")]
    [TestFixture("Firefox")]
    [TestFixture("Chrome")]
    public class FillInContactFormTest : DrivenTestShopScenario
    {
        public FillInContactFormTest(string browser) : base(browser)
        {
        }
        //[Values("Chrome", "Firefox")]
        //String browser
        [Test]
        public void TestMethod1()
        {
            ContactUsPage page = new HomePage(driver)
                .Header.ClickContactUs()
                .FillContactForm("Customer service", "bootcamper@feelthepain.com", "43211234", "Ipod defect while lifting, \nneed new one");
            String pageTitle = page.GetPageTitle();
            String alertMessage = page.GetAlertMessageText();

            Assert.AreEqual("CUSTOMER SERVICE - CONTACT US", pageTitle);
            Assert.AreEqual("Your message has been successfully sent to our team.", alertMessage);
        }
    }
}
