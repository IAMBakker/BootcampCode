using System;
using BootCamp.Pages;
using BootCamp.Pages.Base;
using BootCamp.Test.Base;
using NUnit.Framework;

namespace BootCamp.Test.DataDriven
{
    [TestFixture]
    public class DataDrivenContactFormTest : NunitTestShopScenario
    {
        //[Values("Chrome", "Firefox")]
        //String browser
        
        [Test]
        public void TestMethod1([ContactInfoList] ContactInfo contactInfo)
        {
            ContactUsPage page = new HomePage(driver)
                .Header.ClickContactUs()
                .FillContactForm(contactInfo.subject,
                    contactInfo.email, contactInfo.orderID, contactInfo.message)
                .SubmitContactForm();
            String pageTitle = page.GetPageTitle();
            String alertMessage = page.GetAlertMessageText();

            Assert.AreEqual("CUSTOMER SERVICE - CONTACT US", pageTitle);
            Assert.AreEqual("Your message has been successfully sent to our team.", alertMessage);
        }
    }
}
