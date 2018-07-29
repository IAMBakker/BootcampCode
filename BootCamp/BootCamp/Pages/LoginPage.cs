using BootCamp.Model;
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
        private By signInEmailField = By.CssSelector("input#email_create");
        private By signInSubmitButton = By.CssSelector("button#SubmitCreate");

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

        public MyAccountPage CreateNewUserAccount(UserAccount user)
        {
            driver.FindElement(signInEmailField).SendKeys(user.email);
            driver.FindElement(signInSubmitButton).Click();
            return new NewAccountPage(driver).CreateNewUserAccount(user);
        }
    }
}
