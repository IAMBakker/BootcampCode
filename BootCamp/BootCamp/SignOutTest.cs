using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using BootCamp.Test.Base;

namespace BootCamp
{
    [TestClass]
    public class SignOutTest : TestShopScenario
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

            driver.FindElement(By.CssSelector("a.logout")).Click();

            bool elementExists = false;
            try
            {
                IWebElement accountName = driver.FindElement(By.CssSelector("a.account"));
                elementExists = true;
            } catch(NoSuchElementException e)
            {
                Console.Write(e);
            }
            Assert.IsFalse(elementExists);
        }
    }
}
