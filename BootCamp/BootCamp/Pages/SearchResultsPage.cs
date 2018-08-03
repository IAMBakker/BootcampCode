using BootCamp.Pages.Base;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;

namespace BootCamp.Pages
{
    public class SearchResultsPage : TestShopPage
    {

        private By productName = By.CssSelector("a.product-name");

        public SearchResultsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public ProductPage SelectProductWithName(String name)
        {
            IList<IWebElement> products = driver.FindElements(productName);
            foreach(IWebElement productTile in products)
            {
                if (productTile.Text.Equals(name))
                {
                    productTile.Click();
                    break;
                }
            }

            return new ProductPage(driver);
        }
    }
}