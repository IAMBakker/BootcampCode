using BootCamp.Pages.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    public class LoginPage : TestShopPage
    {

        private By loginEmailField = By.CssSelector("input#email");
        private By loginPasswordField = By.CssSelector("input#passwd");
        private By loginSubmitButton = By.CssSelector("button#SubmitLogin");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public MyAccountPage LoginSuccesfully(String username, String password)
        {
            driver.FindElement(loginEmailField).SendKeys(username);
            driver.FindElement(loginPasswordField).SendKeys(password);
            driver.FindElement(loginSubmitButton).Click();

            Assert.AreEqual("MY ACCOUNT", GetPageTitle());

            return new MyAccountPage(driver);
        }
    }
}
