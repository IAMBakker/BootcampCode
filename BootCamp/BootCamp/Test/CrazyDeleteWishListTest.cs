using System;
using BootCamp.Model;
using BootCamp.Pages;
using BootCamp.Test.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BootCamp.Test
{
    [TestClass]
    public class CrazyDeleteWishListTest : TestShopScenario
    {
        [TestMethod]
        public void TestMethod1()
        {
            FillableWishList suffering = new FillableWishList("Suffering", false);
            suffering.addProduct(new Product("iPod shuffle"));
            suffering.addProduct(new Product("Ledger Nano S"));

            WishListsPage wishListPage = new HomePage(driver)
                .Header.ClickLogin()
                .LoginSuccesfully("ico.bakker+292@gmail.com", "test123")
                .ClickMyWishLists();

            wishListPage.DeleteWishList("Suffering");
            wishListPage.AddWishList(suffering);
            wishListPage.DeleteWishList(suffering);

            Assert.IsFalse(wishListPage.GetMyWishLists().asList().Contains(suffering), 
                "Your suffering wish list was deleted..." +
                " It should not be in this list of lists.");
        }
    }
}
