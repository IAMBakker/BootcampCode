using BootCamp.Pages;
using BootCamp.Pages.Base;
using OpenQA.Selenium;

namespace BootCamp.Pages
{
    public class HomePage : TestShopPage
    {

        public HomePage(IWebDriver driver)
            :base(driver)
        {
            this.driver = driver;
        }
    }
}