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
    public class ContactUsPage : TestShopPage
    {
        private By SubjectDropdown = By.CssSelector("select#id_contact");
        private By EmailTextField = By.CssSelector("input#email");
        private By ReferenceTextField = By.CssSelector("input#id_order");
        private By MessageTextArea = By.CssSelector("textarea#message");
        private By SubmitButton = By.CssSelector("button#submitMessage");
       
        public ContactUsPage(IWebDriver driver)
            :base(driver)
        {
        }

        public ContactUsPage FillContactForm(String subject, String email, String reference, String message)
        {
            new SelectElement(driver.FindElement(SubjectDropdown)).SelectByText(subject);
            IWebElement emailTextField = driver.FindElement(EmailTextField);
            emailTextField.Clear();
            emailTextField.SendKeys(email);
            IWebElement referenceField = driver.FindElement(ReferenceTextField);
            referenceField.Clear();
            referenceField.SendKeys(reference);
            IWebElement textArea = driver.FindElement(MessageTextArea);
            textArea.Clear();
            textArea.SendKeys(message);
            return this;
        }

        public ContactUsPage SubmitContactForm()
        {
            driver.FindElement(SubmitButton).Click();
            return this;
        }

        public bool GetEmailValidation()
        {
            return driver.FindElement(EmailTextField)
                .FindElement(By.XPath("..")).GetAttribute("class")
                .Contains("form-ok");
        }
    }
}
