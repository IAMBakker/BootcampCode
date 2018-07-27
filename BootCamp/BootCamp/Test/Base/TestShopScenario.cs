using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    [TestClass]
    public class TestShopScenario
    {

        protected IWebDriver driver;
        protected WebDriverWait wait;

        [TestInitialize]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://techblog.polteq.com/testshop/index.php");

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        [TestCleanup]
        public void TearDown()
        {
            //driver.Quit();
        }
    }
}
