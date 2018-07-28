using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public class TestShopHeader
    {
        private static readonly Lazy<TestShopHeader> lazy =
            new Lazy<TestShopHeader>(() => new TestShopHeader());
        public static TestShopHeader Instance { get { return lazy.Value; } }

        private IWebDriver driver;
        private By ContactUsButton = By.CssSelector("div#contact-link a");
        private By LoginLocator = By.CssSelector("a.login");

        private TestShopHeader()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            if(driver == null)
            {
                driver = value;
            }
        }

        public ContactUsPage ClickContactUs()
        {
            driver.FindElement(ContactUsButton).Click();
            return new ContactUsPage(driver);
        }

        public LoginPage ClickLogin()
        {
            driver.FindElement(LoginLocator).Click();
            return new LoginPage(driver);
        }
    }
}
