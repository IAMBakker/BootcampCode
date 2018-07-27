using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    class ContactUsPage
    {
        private IWebDriver driver;
        private By SubjectDropdown = By.CssSelector("select#id_contact");
        private By EmailTextField = By.CssSelector("input#email");
        private By ReferenceTextField = By.CssSelector("input#id_order");
        private By MessageTextArea = By.CssSelector("textarea#message");
        private By SubmitButton = By.CssSelector("button#submitMessage");
        private By PageTitleHeader = By.CssSelector("h1.page-heading");
        private By AlertMessage = By.CssSelector("p.alert");

        public ContactUsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ContactUsPage FillContactForm(String subject, String email, String reference, String message)
        {
            new SelectElement(driver.FindElement(SubjectDropdown)).SelectByText(subject);
            IWebElement emailTextField = driver.FindElement(EmailTextField);
            emailTextField.Clear();
            emailTextField.SendKeys(email);
            driver.FindElement(ReferenceTextField).SendKeys(reference);
            driver.FindElement(MessageTextArea).SendKeys(message);
            driver.FindElement(SubmitButton).Click();
            return this;
        }

        public String GetPageTitle()
        {
            return driver.FindElement(PageTitleHeader).Text;
        }

        public String GetAlertMessageText()
        {
            return driver.FindElement(AlertMessage).Text;
        }
    }
}
