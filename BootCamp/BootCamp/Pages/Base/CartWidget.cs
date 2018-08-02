using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public class CartWidget
    {
        private IWebDriver driver;
        private By emptyCartElement = By.CssSelector("span.ajax_cart_no_product");
        public CartWidget(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement getEmptyCartElement()
        {
            return driver.FindElement(emptyCartElement);
        }
        public String GetCartItemAmount()
        {
            return driver.FindElement(By.CssSelector("span.ajax_cart_quantity")).Text;
        }
    }
}
