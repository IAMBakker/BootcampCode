using System;
using System.Collections.Generic;
using BootCamp.Model;
using BootCamp.Pages;
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
            WishList noPain1 = new WishList("No Pain No Gain", 1);

            WishListsPage wishListPage = new HomePage(driver)
                .Header.ClickLogin()
                .LoginSuccesfully("ico@bakker.com", "1qazxsw2")
                .ClickMyWishLists();

            IList<WishList> wishlists = wishListPage
                .GetMyWishLists();

            if (wishlists.Contains(noPain1))
            {
                wishListPage.DeleteWishList(noPain1);
            } else
            {
                wishListPage.AddWishList(noPain1);
            }
        }
    }
}
