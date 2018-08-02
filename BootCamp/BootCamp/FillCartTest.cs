using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using BootCamp.Test.Base;
using OpenQA.Selenium.Support.UI;
using BootCamp.Pages;

namespace BootCamp
{
    [TestClass]
    public class FillCartTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            HomePage homePage = new HomePage(driver);
            Assert.IsTrue(homePage.Header.GetCartWidget()
                .getEmptyCartElement().Displayed,
                "Empty Cart Element should be displayed");

            homePage.LeftColumn.getTagsBlock()
                .FindElement(By.CssSelector("a[title='More about ipod']")).Click();

            new ProductPage(driver)
                .AddProductToCart("iPod shuffle")
                .handleShoppingCart();

            String cartItemAmount = homePage.Header.GetCartWidget().GetCartItemAmount();
            Assert.AreEqual(cartItemAmount, "1", 
                "Shopping cart should be filled with a product.");
        }
    }
}
