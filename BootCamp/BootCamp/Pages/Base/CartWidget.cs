using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public class CartWidget
    {
        private IWebDriver driver;
        private static WebDriverWait wait;
        private By emptyCartElement = By.CssSelector("span.ajax_cart_no_product");

        public CartWidget(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
        }

        public IWebElement getEmptyCartElement()
        {
            return driver.FindElement(emptyCartElement);
        }
        public String GetCartItemAmount()
        {
            return driver.FindElement(By.CssSelector("span.ajax_cart_quantity")).Text;
        }
        public CartWidgetOptions HoverShoppingCartWidget()
        {
            IWebElement shoppingCartDropdown = driver.FindElement(By.CssSelector("a[title='View my shopping cart']"));
            new Actions(driver).MoveToElement(shoppingCartDropdown).Build().Perform();

            IWebElement shoppingCartSummary = driver.FindElement(By.CssSelector("[class='cart_block block exclusive']"));
            wait.Until<bool>((d) => shoppingCartSummary.GetAttribute("style").Equals("display: block;"));
            return new CartWidgetOptions(shoppingCartSummary);
        }

        public class CartWidgetOptions
        {
            private IWebElement shoppingCartSummary;
            private By removeLinkLocator = By.CssSelector("span.remove_link > a.ajax_cart_block_remove_link");
            public CartWidgetOptions(IWebElement shoppingCartSummary)
            {
                this.shoppingCartSummary = shoppingCartSummary;
            }
            public void RemoveAllItems()
            {
                IList removeLinks = shoppingCartSummary.FindElements(removeLinkLocator);

                Console.WriteLine(removeLinks.Count);
                foreach (IWebElement link in removeLinks)
                {
                    link.Click();
                }
                wait.Until<bool>((d) => shoppingCartSummary.GetAttribute("style").Equals("display: none;"));

            }
        }

    }
}
