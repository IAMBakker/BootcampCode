using BootCamp.Model;
using BootCamp.Pages.Base;
using BootCamp.Pages.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        private By submitNewWishListButton = By.CssSelector("form#form_wishlist button#submitWishlist");
        private By wishListsTable = By.CssSelector("div#block-history tbody");
        private By rowLocator = By.CssSelector("tr[id*=wishlist]");
        private static By nameCell = By.CssSelector("td[style='width:200px;']");
        private static By amountOfItemsCell = By.CssSelector("td.align_center");
        private static By defaultCheckboxCell = By.CssSelector("td.wishlist_default i");
        private static By deleteCell = By.CssSelector("td.wishlist_delete > a");
        private static By defaultWishListLocator = By.CssSelector("p.is_wish_list_default");

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
            driver.FindElement(newWishListNameField).SendKeys(wishList.Name);
            driver.FindElement(submitNewWishListButton).Click();
            if (wishList.IsDefault)
            {
                MakeWishListDefault(wishList);
            }
        }

        public void AddWishList(FillableWishList wishList)
        {
            AddWishList((WishList)wishList);
            new AddProductsHelper(driver)
                .AddProducts(wishList);
        }

        public void DeleteWishList(WishList wishListToDelete)
        {
            IList<WishListRow> wishListRows = GetWishListRows();
            int amountOfWishLists = wishListRows.Count;
            Console.WriteLine("To be deleted wish list: " + wishListToDelete.Name);
            foreach(WishListRow wishList in wishListRows)
            {
                if (wishList.WishListObject.Equals(wishListToDelete))
                {
                    wishList.DeleteWishList();
                    break;
                }
            }
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                Console.WriteLine(alert.Text);
                alert.Accept();

            } catch (NoAlertPresentException e)
            {
                throw new Exception("Unable to Delete Wish List, specified wish list did not exist:\n" + e);
            }
            wait.Until<bool>((p) => WishListsSizeUpdated(amountOfWishLists));
        }

        public void DeleteWishList(String wishListName)
        {
            IList<WishListRow> wishListRows = GetWishListRows();
            int amountOfWishLists = wishListRows.Count;
            Console.WriteLine("To be deleted wish list: " + wishListName);
            foreach (WishListRow wishList in wishListRows)
            {
                if (wishList.WishListObject.Name.Equals(wishListName))
                {
                    wishList.DeleteWishList();
                    IAlert alert = driver.SwitchTo().Alert();
                    Console.WriteLine(alert.Text);
                    alert.Accept();
                    wait.Until<bool>((p) => WishListsSizeUpdated(amountOfWishLists));
                    break;
                }
            }
        }

        public void MakeWishListDefault(WishList wishListToMakeDefault)
        {
            IList<WishListRow> wishListRows = GetWishListRows();
            IList<WishList> wishLists = GetMyWishLists();

            foreach(WishListRow wishList in wishListRows)
            {
                if (wishList.WishListObject.EqualsIgnoreIsDefault(wishListToMakeDefault))
                {
                    wishList.MakeWishListDefault();
                    break;
                }
            }
            wait.Until<bool>((p) => DefaultWishListsUpdated(wishLists));
        }

        private bool DefaultWishListsUpdated(IList<WishList> wishLists)
        {
            bool isUpdated = false;
            if (!wishLists.Equals(GetMyWishLists()))
            {
                isUpdated = true;
            }
            return isUpdated;
        }

        private bool WishListsSizeUpdated(int wishListSize)
        {
            bool isUpdated = false;
            if (driver.FindElements(rowLocator).Count < wishListSize)
            {
                isUpdated = true;
            }
            return isUpdated;
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
            private String wishListName;
            private int wishListItems;
            public IWebElement ThisWishListRow { get; set; }
            public IWebElement DefaultCell { get; set; }
            public IWebElement DeleteCell { get; set; }

            public WishListRow(IWebElement row)
            {
                ThisWishListRow = row;
                wishListName = row.FindElement(nameCell).Text;
                wishListItems = Int32.Parse(row.FindElement(amountOfItemsCell).Text);
                DefaultCell = row.FindElement(defaultCheckboxCell);
                DeleteCell = row.FindElement(deleteCell);
                WishListObject = new WishList(wishListName,
                    wishListItems,
                    doesWishListDefaultElementExist());
            }
            public void DeleteWishList()
            {
                DeleteCell.Click();
            }
            public void MakeWishListDefault()
            {
                DefaultCell.Click();
            }
            public bool doesWishListDefaultElementExist()
            {
                bool elementExists = false;
                try
                {
                    ThisWishListRow.FindElement(defaultWishListLocator);
                    elementExists = true;
                } catch (NoSuchElementException e)
                {
                    //Console.WriteLine(wishListName + " is not the default wishlist");
                }
                return elementExists;
            }
        }
    }
}
