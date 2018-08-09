using BootCamp.Pages.Base;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BootCamp.Pages
{
    public class SearchResultsPage : TestShopPage
    {

        private By productName = By.CssSelector("a.product-name");
        private By productTile = By.CssSelector("div.product-container");

        public SearchResultsPage(IWebDriver driver)
            : base(driver)
        {
        }

        public ProductPage SelectProductWithName(String name)
        {
            
            foreach(IWebElement productTile in getProductTiles())
            {
                if (productTile.FindElement(productName).Text.Equals(name))
                {
                    productTile.Click();
                    break;
                }
            }

            return new ProductPage(driver);
        }

        internal IList getProductTiles()
        {
            return driver.FindElements(productTile);
        }
    }
}