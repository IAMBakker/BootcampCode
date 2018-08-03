using BootCamp.Model;
using BootCamp.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    public class NewAccountPage : TestShopPage
    {
        public NewAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public MyAccountPage CreateNewUserAccount(UserAccount user)
        {
            By personIdentifierLocator = By.CssSelector("input#id_gender1");

            wait.Until(ExpectedConditions.ElementExists(personIdentifierLocator));
            driver.FindElement(personIdentifierLocator).Click();
            driver.FindElement(By.CssSelector("input#customer_firstname")).SendKeys(user.firstName);
            driver.FindElement(By.CssSelector("input#customer_lastname")).SendKeys(user.lastName);
            driver.FindElement(By.CssSelector("input#passwd")).SendKeys(user.password);
            new SelectElement(driver.FindElement(By.CssSelector("select#days"))).SelectByValue(user.birthDay);
            new SelectElement(driver.FindElement(By.CssSelector("select#months"))).SelectByValue(user.birthMonth);
            new SelectElement(driver.FindElement(By.CssSelector("select#years"))).SelectByValue(user.birthYear);
            if (user.newsLetter)
            {
                driver.FindElement(By.CssSelector("input#newsletter")).Click();
            }
            if (user.specialOffers)
            {
                driver.FindElement(By.CssSelector("input#optin")).Click();
            }
            driver.FindElement(By.CssSelector("button[name='submitAccount']")).Click();
            return new MyAccountPage(driver);
        }
    }
}
