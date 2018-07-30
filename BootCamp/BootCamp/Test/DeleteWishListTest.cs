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
            IList<WishList> toBeCreatedWishLists = new List<WishList>();
            toBeCreatedWishLists.Add(new WishList("Easy peasy lemon squeezy", 0, false));
            toBeCreatedWishLists.Add(new WishList("Piece of cake", 0, false));
            toBeCreatedWishLists.Add(new WishList("No Problemo", 0, false));
            toBeCreatedWishLists.Add(new WishList("No Sweat", 0, false));
            toBeCreatedWishLists.Add(new WishList("Ok maybe a little bit", 0, false));

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
            foreach(WishList list in toBeCreatedWishLists)
            {
                if (!wishlists.Contains(list))
                {
                    wishListPage.AddWishList(list);
                }
            }
            wishListPage.DeleteWishList(feelThePain);
            wishListPage.MakeWishListDefault(new WishList("Cardio Grind", 0, true));
            foreach(WishList list in toBeCreatedWishLists)
            {
                wishListPage.DeleteWishList(list);
            }
            Assert.IsFalse(wishListPage.GetMyWishLists().Contains(feelThePain),
                "The wish list was deleted, so it should no longer exist in the table.");
        }
    }
}
