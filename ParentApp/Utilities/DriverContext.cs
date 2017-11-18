using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace ParentApp.Utilities
{
    public class DriverContext
    {
        private static IWebDriver _driver;
        private BrowserType browserType;

        public enum BrowserType
        {
            Chrome,
            Firefox,
            IE
        }

        public DriverContext(BrowserType browserType)
        {
            string webDriverDirectory = System.IO.Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Drivers";

            switch (browserType)
            {
                case BrowserType.Chrome:
                    ChromeOptions options = new ChromeOptions();
                    options.AddArguments("--test-type");
                    options.AddArguments("--start-maximized");
                    _driver = new ChromeDriver(webDriverDirectory, options);
                    break;

                case BrowserType.Firefox:
                    _driver = new FirefoxDriver();
                    break;

                case BrowserType.IE:
                    InternetExplorerOptions ieOptions = new InternetExplorerOptions();
                    ieOptions.IgnoreZoomLevel = true;
                    _driver = new InternetExplorerDriver(webDriverDirectory, ieOptions);
                    break;

                default:
                    break;
            }
        }

        public static IWebDriver Driver
        {
            get
            {
                return _driver;
            }
            set
            {
                _driver = value;
            }
        }
    }
}