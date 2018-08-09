using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using System.Collections;
using OpenQA.Selenium.Support.UI;
using BootCamp.Pages;

namespace BootCamp.Test
{
    [TestClass]
    public class ValidateSupplierProductTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            IList productTiles = new HomePage(driver)
                .LeftColumn.clickSupplierSelect()
                .appleStore()
                .getProductTiles();

            IList productNames = new ArrayList();
            foreach(IWebElement productTile in productTiles)
            {
                productNames.Add(productTile.FindElement(By.CssSelector("a.product-name")).Text);
            }
            Assert.IsTrue(productNames.Contains("MacBook Air"), "Supplier AppleStore should have MacBook Air as a search result on this page.");
        }
    }
}
