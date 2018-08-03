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

        public WishListOptions GetMyWishLists()
        {
            return new WishListOptions(driver.FindElements(rowLocator));
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
            IDictionary<WishList, IWebElement> wishLists = GetMyWishLists().asDictionary();
            int amountOfWishLists = wishLists.Count;
            Console.WriteLine("To be deleted wish list: " + wishListToDelete.Name);
            foreach(KeyValuePair<WishList, IWebElement> wishList in wishLists){
                if (wishList.Key.Equals(wishListToDelete))
                {
                    DeleteRow(wishList.Value);
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
            IDictionary<WishList, IWebElement> wishLists = GetMyWishLists().asDictionary();
            int amountOfWishLists = wishLists.Count;
            Console.WriteLine("To be deleted wish list: " + wishListName);
            foreach (KeyValuePair<WishList, IWebElement> wishList in wishLists)
            {
                if (wishList.Key.Name.Equals(wishListName))
                {
                    DeleteRow(wishList.Value);
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
            WishListOptions options = GetMyWishLists();
            IDictionary<WishList, IWebElement> wishListDictionary = options.asDictionary();
            IList<WishList> wishLists = options.asList();

            foreach (KeyValuePair<WishList, IWebElement> wishList in wishListDictionary)
            {
                if (wishList.Key.EqualsIgnoreIsDefault(wishListToMakeDefault))
                {
                    MakeRowDefaultWishList(wishList.Value);
                    break;
                }
            }
            wait.Until<bool>((p) => DefaultWishListsUpdated(wishLists));
        }

        private bool DefaultWishListsUpdated(IList<WishList> wishLists)
        {
            bool isUpdated = false;
            if (!wishLists.Equals(GetMyWishLists().asList()))
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

        public void DeleteRow(IWebElement row)
        {
            row.FindElement(deleteCell).Click();
        }

        public void MakeRowDefaultWishList(IWebElement row)
        {
            row.FindElement(defaultCheckboxCell).Click();
        }

        public class WishListOptions
        {
            private IList<WishListRow> rowWrappers = new List<WishListRow>();

            public WishListOptions(IList<IWebElement> rows)
            {
                foreach(IWebElement row in rows)
                {
                    rowWrappers.Add(new WishListRow(row));
                }
            }

            public IList<WishList> asList()
            {
                IList<WishList> wishLists = new List<WishList>();
                foreach(WishListRow row in rowWrappers)
                {
                    wishLists.Add(row.WishListObject);
                }
                return wishLists;
            }

            public IDictionary<WishList, IWebElement> asDictionary()
            {
                IDictionary<WishList, IWebElement > wishLists = new Dictionary<WishList, IWebElement>();
                foreach(WishListRow row in rowWrappers)
                {
                    wishLists[row.WishListObject] = row.ThisWishListRow;
                }
                return wishLists;
            }
        }

        public class WishListRow
        {
            public WishList WishListObject { get; set; }
            private String wishListName;
            private int wishListItems;
            public IWebElement ThisWishListRow { get; set; }

            public WishListRow(IWebElement row)
            {
                ThisWishListRow = row;
                wishListName = row.FindElement(nameCell).Text;
                wishListItems = Int32.Parse(row.FindElement(amountOfItemsCell).Text);
                WishListObject = new WishList(wishListName,
                    wishListItems,
                    doesWishListDefaultElementExist());
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
