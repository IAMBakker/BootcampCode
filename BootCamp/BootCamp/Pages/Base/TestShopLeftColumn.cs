using OpenQA.Selenium;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public sealed class TestShopLeftColumn
    {
        private static readonly Lazy<TestShopLeftColumn> lazy =
            new Lazy<TestShopLeftColumn>(() => new TestShopLeftColumn());
        public static TestShopLeftColumn Instance { get { return lazy.Value; } }

        private static IWebDriver driver;
        private TestShopLeftColumn()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            driver = value;
        }

        public IWebElement getTagsBlock()
        {
            return driver.FindElement(By.CssSelector("div#tags_block_left"));
        }

        public SupplierOptions clickSupplierSelect()
        {
            IWebElement supplierDropdown = driver.FindElement(By.CssSelector("select[name='supplier_list']"));
            supplierDropdown.Click();
            
            return new SupplierOptions(supplierDropdown);
        }

        public class SupplierOptions
        {
            private IWebElement supplierDropdown;

            public SupplierOptions(IWebElement supplierDropdown)
            {
                this.supplierDropdown = supplierDropdown;
            }

            public SearchResultsPage appleStore()
            {
                IList suppliers = supplierDropdown.FindElements(By.CssSelector("option"));

                foreach (IWebElement supplier in suppliers)
                {
                    if (supplier.Text.Equals("AppleStore"))
                    {
                        supplier.Click();
                        break;
                    }
                }
                return new SearchResultsPage(driver);
            }
        }
    }
}
