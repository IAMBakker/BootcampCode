using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.Test.Base.Browser
{
    public static class BrowserFactoryBasic
    {
        private static IWebDriver driver;

        public static IWebDriver InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    driver = new FirefoxDriver();
                    break;

                case "IE":
                    driver = new InternetExplorerDriver();
                    break;

                case "Chrome":
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("ignore-certificate-errors");
                    options.AddArguments("start-maximized");
                    options.AddArguments("disable-infobars");
                    driver = new ChromeDriver(options);
                    break;
            }

            return driver;
        }
    }
}
