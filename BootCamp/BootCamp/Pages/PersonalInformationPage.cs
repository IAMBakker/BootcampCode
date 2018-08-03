using BootCamp.Pages.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    public class PersonalInformationPage : TestShopPage
    {
        By firstNameField = By.CssSelector("input#firstname");
        By lastNameField = By.CssSelector("input#lastname");
        By oldPasswordField = By.CssSelector("input#old_passwd");
        By submitButton = By.CssSelector("div#center_column * button[name='submitIdentity']");

        public PersonalInformationPage(IWebDriver driver) : base(driver)
        {
        }

        public PersonalInformationPage UpdateFirstName(String firstName)
        {
            IWebElement firstNameInput = driver.FindElement(firstNameField);
            firstNameInput.Clear();
            firstNameInput.SendKeys(firstName);
            return this;
        }

        public PersonalInformationPage UpdateLastName(String lastName)
        {
            IWebElement lastNameInput = driver.FindElement(lastNameField);
            lastNameInput.Clear();
            lastNameInput.SendKeys(lastName);
            return this;
        }

        public PersonalInformationPage FillPassword(String password)
        {
            driver.FindElement(oldPasswordField).SendKeys(password);
            return this;
        }

        public MyAccountPage SubmitPersonalInformation()
        {
            driver.FindElement(submitButton).Click();
            return new MyAccountPage(driver);
        }
    }
}
