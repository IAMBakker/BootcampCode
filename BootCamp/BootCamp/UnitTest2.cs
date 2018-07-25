using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BootCamp
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://techblog.polteq.com/testshop/index.php");

            driver.FindElement(By.CssSelector("a.login")).Click();
            driver.FindElement(By.CssSelector("input#email")).SendKeys("ico.bakker+123@gmail.com");
            driver.FindElement(By.CssSelector("input#passwd")).SendKeys("test123");
            driver.FindElement(By.CssSelector("button#SubmitLogin")).Click();

            IWebElement pageTitle = driver.FindElement(By.CssSelector("h1.page-heading"));

            Assert.AreEqual("MY ACCOUNT", pageTitle.Text);
        }
    }
}
