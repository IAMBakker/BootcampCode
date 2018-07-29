using System;
using System.Collections.Generic;
using BootCamp.Model;
using BootCamp.Pages;
using BootCamp.Pages.Base;
using BootCamp.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static BootCamp.Pages.WishListsPage;

namespace BootCamp.Test
{
    [TestClass]
    public class DeleteWishListTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            WishList feelThePain = new WishList("Feel the pain", 0, true);

            WishListsPage wishListPage = new HomePage(driver)
                .Header.ClickLogin()
                .LoginSuccesfully("ico@bakker.com", "1qazxsw2")
                .ClickMyWishLists();

            IList<WishList> wishlists = wishListPage
                .GetMyWishLists();

            if (!wishlists.Contains(feelThePain))
            {
                wishListPage.AddWishList(feelThePain);
            } 
            wishListPage.DeleteWishList(feelThePain);

            Assert.IsFalse(wishListPage.GetMyWishLists().Contains(feelThePain),
                "The wish list was deleted, so it should no longer exist in the table.");
        }
    }
}
