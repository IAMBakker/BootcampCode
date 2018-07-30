using OpenQA.Selenium;
using System;
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

        private IWebDriver driver;
        private TestShopLeftColumn()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            driver = value;
        }
    }
}
