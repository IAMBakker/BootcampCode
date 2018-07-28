using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Pages.Base
{
    public sealed class TestShopRightColumn
    {
        private static readonly Lazy<TestShopRightColumn> lazy =
            new Lazy<TestShopRightColumn>(() => new TestShopRightColumn());
        public static TestShopRightColumn Instance { get { return lazy.Value; } }

        private IWebDriver driver;
        private TestShopRightColumn()
        {

        }

        public void SetDriver(IWebDriver value)
        {
            if (driver == null)
            {
                driver = value;
            }
        }
    }

}
