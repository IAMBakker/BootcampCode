using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using BootCamp.Test;
using BootCamp.Pages;
using BootCamp.Pages.Base;

namespace BootCamp.Test
{
    [TestClass]
    public class AdjustPersonalInfoOnHomepageTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            PersonalInformationPage personalInfoPage = new HomePage(driver)
                .Header.ClickLogin()
                .LoginSuccesfully("ico.bakker+123@gmail.com", "test123")
                .Header.ClickHomeButton()
                .Footer.ClickManagePersonalInformation();
            String loggedInUser = personalInfoPage.Header.GetLoggedInUserName();
            
            if (loggedInUser.Equals("Ico bakker"))
            {
                String newUserName = personalInfoPage
                    .UpdateFirstName("Jan")
                    .UpdateLastName("MetDePet")
                    .FillPassword("test123")
                    .SubmitPersonalInformation()
                    .Header.GetLoggedInUserName();
                Assert.AreEqual("Jan MetDePet", newUserName,
                    "We changed username to Jan MetDePet, so we expect this to show in the header");
            }
            else
            {
                String newUserName = personalInfoPage
                    .UpdateFirstName("Ico")
                    .UpdateLastName("bakker")
                    .FillPassword("test123")
                    .SubmitPersonalInformation()
                    .Header.GetLoggedInUserName();
                Assert.AreEqual("Ico bakker", newUserName,
                    "We changed username to Ico bakker, so we expect this to show in the header");
            }
        }
    }
}
