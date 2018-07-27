using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;

namespace BootCamp
{
    [TestClass]
    public class AdjustPersonalinfoTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            driver.FindElement(By.CssSelector("a.login")).Click();
            driver.FindElement(By.CssSelector("input#email")).SendKeys("ico.bakker+123@gmail.com");
            driver.FindElement(By.CssSelector("input#passwd")).SendKeys("test123");
            driver.FindElement(By.CssSelector("button#SubmitLogin")).Click();

            IWebElement pageTitle = driver.FindElement(By.CssSelector("h1.page-heading"));

            Assert.AreEqual("MY ACCOUNT", pageTitle.Text);

            driver.FindElement(By.CssSelector("a[title='Information']")).Click();
            IWebElement loggedInUser = driver.FindElement(By.CssSelector("div.header_user_info"));
            if (loggedInUser.Text.Equals("Ico bakker"))
            {
                updateFirstAndLastName("Jan", "MetDePet");
                Assert.AreEqual("Jan MetDePet", driver.FindElement(By.CssSelector("div.header_user_info")).Text,
                    "We changed username to Jan MetDePet, so we expect this to show in the header");
            } else
            {
                updateFirstAndLastName("Ico", "bakker");
                Assert.AreEqual("Ico bakker", driver.FindElement(By.CssSelector("div.header_user_info")).Text,
                    "We changed username to Ico bakker, so we expect this to show in the header");
            }

        }

        private void updateFirstAndLastName(String firstName, String lastName)
        {
            Console.WriteLine("Updating name to: " + firstName + " " + lastName);
            IWebElement firstNameInput = driver.FindElement(By.CssSelector("input#firstname"));
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);

            IWebElement lastNameInput = driver.FindElement(By.CssSelector("input#lastname"));
            lastNameInput.Clear();
            lastNameInput.SendKeys(lastName);

            driver.FindElement(By.CssSelector("input#old_passwd")).SendKeys("test123");

            driver.FindElement(By.CssSelector("div#center_column * button[name='submitIdentity']")).Click();
        }
    }
}
