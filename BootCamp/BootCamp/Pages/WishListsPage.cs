using BootCamp.Model;
using BootCamp.Pages.Base;
using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages
{
    public class WishListsPage : TestShopPage
    {
        private By newWishListNameField = By.CssSelector("form#form_wishlist input#name");
        private By submitNewWishListButton = By.CssSelector("for#form_wishlist button#submitWishlist");
        private By wishListsTable = By.CssSelector("div#block-history tbody");
        private By rowLocator = By.CssSelector("tr[id*=wishlist]");
        private static By nameCell = By.CssSelector("td[style='width: 200px;']");
        private static By amountOfItemsCell = By.CssSelector("td.align_center");
        private static By defaultCheckboxCell = By.CssSelector("td.wishlist_default > p > i");
        private static By deleteCell = By.CssSelector("td.wishlist_delete > a");

        public WishListsPage(IWebDriver driver) : base(driver)
        {
        }

        public IList<WishList> GetMyWishLists()
        {
            IList<WishList> wishlists = new List<WishList>();
            IList rows = driver.FindElements(rowLocator);
            foreach(IWebElement row in rows)
            {
                wishlists.Add(new WishListRow(row).WishListObject);
            }

            return wishlists;
        }

        public void AddWishList(WishList wishList)
        {

        }

        public void DeleteWishList(WishList wishListToDelete)
        {
            IList<WishListRow> wishLists = GetWishListRows();

            foreach(WishListRow wishList in wishLists)
            {
                if (wishList.WishListObject.Equals(wishListToDelete))
                {
                    wishList.DeleteWishList();
                    break;
                }
            }
        }

        private IList<WishListRow> GetWishListRows()
        {
            IList<WishListRow> wishListRows = new List<WishListRow>();
            IList rows = driver.FindElements(rowLocator);
            foreach (IWebElement row in rows)
            {
                wishListRows.Add(new WishListRow(row));
            }
            return wishListRows;
        }

        public class WishListRow
        {
            public WishList WishListObject { get; set; }
            public IWebElement DefaultCell { get; set; }
            public IWebElement DeleteCell { get; set; }

            public WishListRow(IWebElement row)
            {
                WishListObject = new WishList(row.FindElement(nameCell).Text,
                    Int32.Parse(row.FindElement(amountOfItemsCell).Text));
                DefaultCell = row.FindElement(defaultCheckboxCell);
                DeleteCell = row.FindElement(deleteCell);
            }
            public void DeleteWishList()
            {
                DeleteCell.Click();
            }
            public void MakeWishListDefault()
            {
                DefaultCell.Click();
            }
        }
    }
}
