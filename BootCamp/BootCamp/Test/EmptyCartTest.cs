using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections;
using BootCamp.Pages;

namespace BootCamp.Test
{
    [TestClass]
    public class EmptyCartTest : TestShopScenario
    {
        
        [TestMethod]
        public void TestMethod1()
        {
            HomePage homePage = new HomePage(driver);
            if(homePage.Header.GetCartWidget()
                .getEmptyCartElement().Displayed)
            {
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

                homePage.LeftColumn.getTagsBlock()
                    .FindElement(By.CssSelector("a[title='More about apple']")).Click();

                new ProductPage(driver)
                    .AddProductToCart("MacBook")
                    .handleShoppingCart();

                cartItemAmount = homePage.Header.GetCartWidget().GetCartItemAmount();
                Assert.AreEqual(cartItemAmount, "2",
                    "Shopping cart should be filled with two products.");
            }
            homePage.Header.GetCartWidget().HoverShoppingCartWidget().RemoveAllItems();

            Assert.IsTrue(homePage.Header.GetCartWidget().getEmptyCartElement().Displayed,
                "The Cart should display (empty), so this element should exist");
        }
    }
}
