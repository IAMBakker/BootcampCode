using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public sealed class TestShopFooter
    {
        private static readonly Lazy<TestShopFooter> lazy =
            new Lazy<TestShopFooter>(() => new TestShopFooter());
        public static TestShopFooter Instance { get { return lazy.Value; } }

        private IWebDriver driver;
        private TestShopFooter()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            if(driver == null)
            {
                driver = value;
            }
        }
    }
}
