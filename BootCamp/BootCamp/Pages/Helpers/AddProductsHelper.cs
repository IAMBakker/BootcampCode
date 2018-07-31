using BootCamp.Model;
using BootCamp.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Helpers
{
    public class AddProductsHelper
    {
        private HomePage homePage;

        public AddProductsHelper(IWebDriver driver)
        {
            homePage = new HomePage(driver);
        }

        public void AddProducts(FillableWishList wishList)
        {
            foreach(Product product in wishList.Products)
            {
                homePage.Header.SearchForText(product.Name)
                    .SelectProductWithName(product.Name)
                    .AddProductToWishList(wishList.Name)
                    .RightColumn.ClickMyWishLists();
            }
        }
    }
}
