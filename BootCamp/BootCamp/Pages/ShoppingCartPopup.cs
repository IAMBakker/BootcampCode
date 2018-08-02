using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    public class ShoppingCartPopup
    {
        private IWebDriver driver;

        public ShoppingCartPopup(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void handleShoppingCart()
        {
            IWebElement cartPopup = driver.FindElement(By.CssSelector("div#layer_cart"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            By continueShoppingLocator = By.CssSelector("span[title='Continue shopping']");

            wait.Until(ExpectedConditions.ElementToBeClickable(continueShoppingLocator));

            cartPopup.FindElement(continueShoppingLocator).Click();

        }
    }
}
