using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BootCamp.Test.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections;

namespace BootCamp
{
    [TestClass]
    public class EmptyCartTest : TestShopScenario
    {
        
        [TestMethod]
        public void TestMethod1()
        {

            IWebElement emptyCartElement = driver.FindElement(By.CssSelector("span.ajax_cart_no_product"));
            if (emptyCartElement.Displayed)
            {
                IWebElement tagsBlock = driver.FindElement(By.CssSelector("div#tags_block_left"));
                tagsBlock.FindElement(By.CssSelector("a[title='More about ipod']")).Click();

                driver.FindElement(By.CssSelector("a.product-name[title='iPod shuffle']")).Click();

                driver.FindElement(By.CssSelector("p#add_to_cart > button[type='submit']")).Click();

                IWebElement cartPopup = driver.FindElement(By.CssSelector("div#layer_cart"));

                By continueShoppingLocator = By.CssSelector("span[title='Continue shopping']");

                wait.Until(ExpectedConditions.ElementToBeClickable(continueShoppingLocator));

                cartPopup.FindElement(continueShoppingLocator).Click();

                Assert.AreEqual(driver.FindElement(By.CssSelector("span.ajax_cart_quantity")).Text, "1",
                    "Shopping cart should be filled with a product.");


                //should be a new method
                tagsBlock = driver.FindElement(By.CssSelector("div#tags_block_left"));
                tagsBlock.FindElement(By.CssSelector("a[title='More about apple']")).Click();

                driver.FindElement(By.CssSelector("a.product-name[title='MacBook']")).Click();

                driver.FindElement(By.CssSelector("p#add_to_cart > button[type='submit']")).Click();

                cartPopup = driver.FindElement(By.CssSelector("div#layer_cart"));

                continueShoppingLocator = By.CssSelector("span[title='Continue shopping']");

                wait.Until(ExpectedConditions.ElementToBeClickable(continueShoppingLocator));

                cartPopup.FindElement(continueShoppingLocator).Click();

                Assert.AreEqual(driver.FindElement(By.CssSelector("span.ajax_cart_quantity")).Text, "2",
                    "Shopping cart should be filled with a product.");
            }
            IWebElement shoppingCartDropdown = driver.FindElement(By.CssSelector("a[title='View my shopping cart']"));
            new Actions(driver).MoveToElement(shoppingCartDropdown).Build().Perform();
            By removeLinkLocator = By.CssSelector("span.remove_link > a.ajax_cart_block_remove_link");

            IWebElement shoppingCartSummary = driver.FindElement(By.CssSelector("[class='cart_block block exclusive']"));
            wait.Until<bool>((d) => shoppingCartSummary.GetAttribute("style").Equals("display: block;"));

            IList removeLinks = driver.FindElements(removeLinkLocator);

            Console.WriteLine(removeLinks.Count);
            foreach(IWebElement link in removeLinks)
            {
                link.Click();
            }
            wait.Until<bool>((d) => shoppingCartSummary.GetAttribute("style").Equals("display: none;"));

            Assert.IsTrue(driver.FindElement(By.CssSelector("span.ajax_cart_no_product")).Displayed,
                "The Cart should display (empty), so this element should exist");
        }
    }
}
