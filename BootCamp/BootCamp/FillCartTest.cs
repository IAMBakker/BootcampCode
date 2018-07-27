using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using BootCamp.Test.Base;
using OpenQA.Selenium.Support.UI;

namespace BootCamp
{
    [TestClass]
    public class FillCartTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {

            IWebElement emptyCartElement = driver.FindElement(By.CssSelector("span.ajax_cart_no_product"));

            Assert.IsTrue(emptyCartElement.Displayed);

            IWebElement tagsBlock = driver.FindElement(By.CssSelector("div#tags_block_left"));
            tagsBlock.FindElement(By.CssSelector("a[title='More about ipod']")).Click();

            driver.FindElement(By.CssSelector("a.product-name[title='iPod shuffle']")).Click();

            driver.FindElement(By.CssSelector("p#add_to_cart > button[type='submit']")).Click();

            IWebElement cartPopup = driver.FindElement(By.CssSelector("div#layer_cart"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            By continueShoppingLocator = By.CssSelector("span[title='Continue shopping']");

            wait.Until(ExpectedConditions.ElementToBeClickable(continueShoppingLocator));

            cartPopup.FindElement(continueShoppingLocator).Click();

            Assert.AreEqual(driver.FindElement(By.CssSelector("span.ajax_cart_quantity")).Text, "1", 
                "Shopping cart should be filled with a product.");

        }
    }
}
