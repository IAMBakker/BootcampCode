using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace BootCamp.Pages.Base
{
    public class MyAccountPage : TestShopPage
    {
        private By myWishListsTile = By.CssSelector("li.lnk_wishlist");

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public WishListsPage ClickMyWishLists()
        {
            driver.FindElement(myWishListsTile).Click();
            return new WishListsPage(driver);
        }

        
    }
}
