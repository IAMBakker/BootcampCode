using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public class TestShopPage
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        public TestShopHeader Header { get; }
        public TestShopFooter Footer { get; }
        public TestShopLeftColumn LeftColumn { get; }
        public TestShopRightColumn RightColumn { get; }

        private By PageTitleHeader = By.CssSelector("h1.page-heading");
        private By AlertMessage = By.CssSelector(".alert");

        public TestShopPage(IWebDriver driver)
        {
            this.driver = driver;
            Header = TestShopHeader.Instance;
            Footer = TestShopFooter.Instance;
            LeftColumn = TestShopLeftColumn.Instance;
            RightColumn = TestShopRightColumn.Instance;
            ShareWebDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        private void ShareWebDriver()
        {
            Header.SetDriver(driver);
            Footer.SetDriver(driver);
            LeftColumn.SetDriver(driver);
            RightColumn.SetDriver(driver);
        }

        public String GetPageTitle()
        {
            return driver.FindElement(PageTitleHeader).Text;
        }

        public String GetAlertMessageText()
        {
            return driver.FindElement(AlertMessage).Text;
        }

        public bool GetAlertMessageSuccess()
        {
            bool success;
            String alertMessageClass = driver.FindElement(AlertMessage).GetAttribute("class");

            if (alertMessageClass.Contains("alert-success"))
            {
                success = true;
            } else if (alertMessageClass.Contains("alert-danger"))
            {
                success = false;
            } else
            {
                throw new Exception("Unable to identify alert message.\n" +
                    "Class values of alert message are: {" + alertMessageClass +
                    "}");
            };
            return success;
                
        }
    }
}
