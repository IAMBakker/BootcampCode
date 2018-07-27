using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BootCamp
{
    [TestClass]
    public class CreateAccountTest : TestShopScenario
    {

        [TestMethod]
        public void TestMethod1()
        {
            driver.FindElement(By.CssSelector("a.login")).Click();
            UserAccount newUser = new UserAccount.Builder("Ico", "Bakker")
                .withEmail("ico.bakker+" + new Random().Next(100, 999) + "@gmail.com")
                .withPassword("test123")
                .withBirthDate(26, 7, 1987)
                .signUpToNewsLetter()
                .wantsSpecialOffers()
                .build();
            CreateNewUserAccount(newUser);

            bool succesfullyCreated = DoesAlertAccountSuccesfullyCreatedExist();
            Assert.IsTrue(succesfullyCreated, "We should see an alert message that has class: alert-success");
        }

        private bool DoesAlertAccountSuccesfullyCreatedExist()
        {
            bool alertExists = false;
            try
            {
                driver.FindElement(By.CssSelector("p[class='alert alert-success']"));
                alertExists = true;
            } catch (NoSuchElementException e)
            {
                Console.WriteLine(e);
            }
            return alertExists;
        }

        private void CreateNewUserAccount(UserAccount user)
        {
            driver.FindElement(By.CssSelector("input#email_create")).SendKeys(user.email);
            driver.FindElement(By.CssSelector("button#SubmitCreate")).Click();

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
        }

        public class UserAccount
        {
            public String email { get; set; }
            public int gender { get; set; }
            public String firstName { get; set; }
            public String lastName { get; set; }
            public String password { get; set; }
            public String birthDay { get; set; }
            public String birthMonth { get; set; }
            public String birthYear { get; set; }
            public bool newsLetter { get; set; }
            public bool specialOffers { get; set; }

            public UserAccount()
            {
            }

            public UserAccount(String email, int gender, String firstName, String lastName, String password,
                String birthDay, String birthMonth, String birthYear, bool newsLetter, bool specialOffers)
            {
                this.email = email;
                this.gender = gender;
                this.firstName = firstName;
                this.lastName = lastName;
                this.password = password;
                this.birthDay = birthDay;
                this.birthMonth = birthMonth;
                this.birthYear = birthYear;
                this.newsLetter = newsLetter;
                this.specialOffers = specialOffers;
            }
            public class Builder
            {
                private String email;
                private int gender;
                private String firstName;
                private String lastName;
                private String password;
                private String birthDay;
                private String birthMonth;
                private String birthYear;
                private bool newsLetter;
                private bool specialOffers;
                public Builder(String firstName, String lastName)
                {
                    this.firstName = firstName;
                    this.lastName = lastName;
                }
                public Builder withEmail(String email)
                {
                    this.email = email;
                    return this;
                }
                public Builder withBirthDate(int day, int month, int year)
                {
                    this.birthDay = day.ToString();
                    this.birthMonth = month.ToString();
                    this.birthYear = year.ToString();
                    return this;
                }
                public Builder withPassword(String password)
                {
                    this.password = password;
                    return this;
                }
                public Builder signUpToNewsLetter()
                {
                    this.newsLetter = true;
                    return this;
                }
                public Builder wantsSpecialOffers()
                {
                    this.specialOffers = true;
                    return this;
                }
                public UserAccount build()
                {
                    return new UserAccount(email, gender, firstName, lastName, password,
                        birthDay, birthMonth, birthYear, newsLetter, specialOffers);
                }
            }
        }
    }
}
