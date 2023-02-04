using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Sel_CSharp002.Utilities
{
    public class BrowserUtility
    {
        public IWebDriver GetChromeInstance(IWebDriver driver)
        {
            driver = new ChromeDriver();
            driver.Url = "https://facebook.com";
            driver.Manage().Window.Maximize();
            return driver;

        }

    }
}
