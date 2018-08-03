using BootCamp.Test.Base.Browser;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Test.Base
{
    [TestFixture]
    public class NunitTestShopScenario
    {

        protected IWebDriver driver;
        protected WebDriverWait wait;

        [SetUp]
        public void SetUp()
        {
            driver = BrowserFactoryBasic.InitBrowser(BrowserType.CHROME);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://techblog.polteq.com/testshop/index.php");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Close();
            driver.Quit();
        }
    }
}
