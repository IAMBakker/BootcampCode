using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public sealed class TestShopRightColumn
    {
        private static readonly Lazy<TestShopRightColumn> lazy =
            new Lazy<TestShopRightColumn>(() => new TestShopRightColumn());
        public static TestShopRightColumn Instance { get { return lazy.Value; } }

        private IWebDriver driver;
        private By myWishListsButton = By.CssSelector("a[title='My wishlists']");

        private TestShopRightColumn()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            driver = value;
        }

        public WishListsPage ClickMyWishLists()
        {
            driver.FindElement(myWishListsButton).Click();
            return new WishListsPage(driver);
        }
    }

}
