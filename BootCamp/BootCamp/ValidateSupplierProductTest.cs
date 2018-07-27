using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using System.Collections;
using OpenQA.Selenium.Support.UI;

namespace BootCamp
{
    [TestClass]
    public class ValidateSupplierProductTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebElement supplierDropdown = driver.FindElement(By.CssSelector("select[name='supplier_list']"));
            supplierDropdown.Click();
            IList suppliers = supplierDropdown.FindElements(By.CssSelector("option"));

            foreach(IWebElement supplier in suppliers)
            {
                if(supplier.Text.Equals("AppleStore"))
                {
                    supplier.Click();
                    break;
                }
            }

            IList productTiles = driver.FindElements(By.CssSelector("div.product-container"));
            IList productNames = new ArrayList();
            foreach(IWebElement productTile in productTiles)
            {
                productNames.Add(productTile.FindElement(By.CssSelector("a.product-name")).Text);
            }
            Assert.IsTrue(productNames.Contains("MacBook Air"), "Supplier AppleStore should have MacBook Air as a search result on this page.");
        }
    }
}
