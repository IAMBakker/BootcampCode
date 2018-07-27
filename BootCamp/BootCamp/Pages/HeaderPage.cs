using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    class HeaderPage
    {
        private IWebDriver driver;

        private By ContactUsButton = By.CssSelector("div#contact-link a");

        public HeaderPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ContactUsPage ClickContactUs()
        {
            driver.FindElement(ContactUsButton).Click();
            return new ContactUsPage(driver);
        }
    }
}
