using BootCamp.Pages.Base;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace BootCamp.Pages
{
    public class ProductPage : TestShopPage
    {
        private By addToWishListBlock = By.CssSelector("p[class='buttons_bottom_block no-print']:not([id])");
        private By addToWishListButton = By.CssSelector("a#wishlist_button");
        private By closeProductAddedSuccesfullyPopup = By.CssSelector("a[title='Close']");
        private By wishListPopupTable = By.CssSelector("div[class='popover fade bottom in']");
        private By fancyBoxOverlay = By.CssSelector("div.fancybox-overlay");

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public ProductPage AddProductToWishList(String wishListName)
        {
            driver.FindElement(addToWishListBlock).FindElement(addToWishListButton).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div[class='popover fade bottom in']")));

            IWebElement wishList = driver.FindElement(addToWishListBlock)
                .FindElement(wishListPopupTable)
                .FindElement(By.CssSelector("tr" + "[title=" + wishListName + "]"));
            new Actions(driver).DoubleClick(wishList).Perform();

            wait.Until<bool>((p) => FancyBoxOverlayExists());
            wait.Until<bool>((p) => FancyBoxOverlayFullyDisplayed());
            driver.FindElement(fancyBoxOverlay).FindElement(closeProductAddedSuccesfullyPopup).Click();
            wait.Until<bool>((p) => !FancyBoxOverlayExists());
            return this;
        }

        private bool FancyBoxOverlayFullyDisplayed()
        {
            return driver.FindElement(fancyBoxOverlay).GetAttribute("style")
                .Equals("display: block; width: auto; height: auto;");
        }

        public bool FancyBoxOverlayExists()
        {
            bool fancyBoxExists = false;
            try
            {
                driver.FindElement(fancyBoxOverlay);
                fancyBoxExists = true;
            } catch (NoSuchElementException e)
            {

            }
            return fancyBoxExists;
        }
    }
}