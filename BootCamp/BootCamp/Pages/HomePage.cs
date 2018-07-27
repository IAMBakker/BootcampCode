using BootCamp.Pages;
using OpenQA.Selenium;

namespace BootCamp.Test
{
    internal class HomePage
    {
        private IWebDriver driver;
        private HeaderPage header;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            header = new HeaderPage(driver);
        }

        public HeaderPage GetHeaderPage()
        {
            return header;
        }
    }
}