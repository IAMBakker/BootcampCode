using BootCamp.Test;
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
        private By UserNameLocator = By.CssSelector("div.header_user_info");
        private By HomeButtonLocator = By.CssSelector("div#block_top_menu * a[title='Home']");
        private By LogOutButton = By.CssSelector("a.logout");
        private By SearchQueryField = By.CssSelector("input#search_query_top");
        private By SubmitSearchButton = By.CssSelector("button[name=submit_search]");

        private TestShopHeader()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            driver = value;
        }

        public String GetLoggedInUserName()
        {
            return driver.FindElement(UserNameLocator).Text;
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

        public HomePage ClickHomeButton()
        {
            driver.FindElement(HomeButtonLocator).Click();
            return new HomePage(driver);
        }

        public LoginPage ClickSignOut()
        {
            driver.FindElement(LogOutButton).Click();
            return new LoginPage(driver);
        }

        public bool UserNameFieldExists()
        {
            bool elementExists = false;
            try
            {
                IWebElement accountName = driver.FindElement(UserNameLocator).FindElement(By.CssSelector("a.account"));
                elementExists = true;
            }
            catch (NoSuchElementException e)
            {
                Console.Write(e);
            }
            return elementExists;
        }

        public SearchResultsPage SearchForText(String name)
        {
            driver.FindElement(SearchQueryField).SendKeys(name);
            driver.FindElement(SubmitSearchButton).Click();
            return new SearchResultsPage(driver);
        }

    }
}
