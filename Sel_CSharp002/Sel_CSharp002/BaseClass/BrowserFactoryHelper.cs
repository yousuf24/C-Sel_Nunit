using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Sel_CSharp002.BaseClass
{
    public class BrowserFactoryHelper
    {
        public IWebDriver CreateDriverInstance(string Browser="",bool headless = false)
        {
            IWebDriver Driver = null;
            try
            {
                string DriverPath = (AppDomain.CurrentDomain.BaseDirectory + "Libraries\\Selenium\\").Replace("bin\\Debug\\","");
                string ExternalPath = (AppDomain.CurrentDomain.BaseDirectory + "Libraries\\External\\").Replace("bin\\Debug\\", "");
                string FileDownloadPath = AppDomain.CurrentDomain.BaseDirectory.Replace("netcoreapp3.1\\", "") + "Download\\";
                DeleteAndRecreateDirectory(FileDownloadPath);

                switch (Browser.ToUpper())
                {
                    case "FIREFOX":
                        FirefoxOptions fxOp = new FirefoxOptions();
                        fxOp.SetPreference("browser.download.showWhenStarting",false);
                        fxOp.SetPreference("browser.download.folderList", 1);
                        fxOp.SetPreference("browser.download.manager.focusWhenStarting", false);
                        fxOp.SetPreference("browser.download.useDownloadDir", true);
                        fxOp.SetPreference("browser.helperApps.alwaysAsk.force", false);
                        fxOp.SetPreference("browser.download.manager.alertOnEXEOpen", false);
                        fxOp.SetPreference("browser.download.manager.closeWhenDone", true);
                        fxOp.SetPreference("browser.download.manager.showAlertOnComplete", false);
                        fxOp.SetPreference("browser.download.manager.useWindow", false);
                        fxOp.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
                        if (headless)
                        {
                            fxOp.AddArguments(new List<String> { "--disable-extensions","--start-maximized","--disable-popup-blocking","-headless"});
                        }
                        else
                        {
                            fxOp.AddArguments(new List<String> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking" });
                        }
                        Driver = new FirefoxDriver(fxOp);
                        break;

                    case "EDGE":
                        EdgeOptions edgeOp = new EdgeOptions();
                        if (headless)
                        {
                            edgeOp.AddArguments("headless");
                        }
                        Driver = new EdgeDriver(edgeOp);
                        break;
                    default:
                        ChromeOptions co = new ChromeOptions();
                        if (headless)
                        {
                            co.AddArguments(new List<String> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking", "-headless" });
                        }
                        else
                        {
                            co.AddArguments(new List<String> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking" });
                        }
                        co.AddUserProfilePreference("credentials_enable_service",true);
                        co.AddUserProfilePreference("profile.password_manager_enabled", true);
                        co.AddUserProfilePreference("download.default_directory", @FileDownloadPath);
                        co.AcceptInsecureCertificates = true;
                        co.PageLoadStrategy = PageLoadStrategy.Normal;
                        Driver = new ChromeDriver(co);
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }return Driver;

        }

        public IWebDriver CreateDriverInstanceByWebDriverManager(string Browser = "", bool headless = false)
        {
            IWebDriver webDriver = null;
            try
            {
                string text = (AppDomain.CurrentDomain.BaseDirectory + "Libraries\\Selenium\\").Replace("bin\\Debug\\", "");
                string text2 = (AppDomain.CurrentDomain.BaseDirectory + "Libraries\\External\\").Replace("bin\\Debug\\", "");
                string text3 = AppDomain.CurrentDomain.BaseDirectory.Replace("netcoreapp3.1\\", "") + "DownLoad\\";
                DeleteAndRecreateDirectory(text3);
                DriverManager driverManager = new DriverManager();
                string text4 = Browser.ToUpper();
                string text5 = text4;
                if (!(text5 == "FIREFOX"))
                {
                    if (text5 == "EDGE")
                    {
                        EdgeConfig edgeConfig = new EdgeConfig();
                        string driverPath = driverManager.SetUpDriver(edgeConfig, edgeConfig.GetMatchingBrowserVersion());
                        EdgeDriverService service = EdgeDriverService.CreateDefaultService(driverPath);
                        EdgeOptions edgeOptions = new EdgeOptions();
                        if (headless)
                        {
                            edgeOptions.AddArgument("headless");
                        }

                        return new EdgeDriver(service, edgeOptions);
                    }

                    ChromeConfig chromeConfig = new ChromeConfig();
                    string driverPath2 = driverManager.SetUpDriver(chromeConfig, chromeConfig.GetMatchingBrowserVersion());
                    driverPath2=Regex.Replace(driverPath2, "\\\\[\\w]+\\.exe","");
                    ChromeDriverService service2 = ChromeDriverService.CreateDefaultService(driverPath2);
                    ChromeOptions chromeOptions = new ChromeOptions();
                    if (headless)
                    {
                        chromeOptions.AddArguments(new List<string> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking", "-headless" });
                    }
                    else
                    {
                        chromeOptions.AddArguments(new List<string> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking" });
                    }

                    chromeOptions.AddUserProfilePreference("credentials_enable_service", false);
                    chromeOptions.AddUserProfilePreference("profile.password_manager_enabled", false);
                    chromeOptions.AddUserProfilePreference("download.default_directory", text3);
                    chromeOptions.AcceptInsecureCertificates = true;
                    chromeOptions.PageLoadStrategy = PageLoadStrategy.Normal;
                    return new ChromeDriver(service2, chromeOptions);
                }

                FirefoxConfig config = new FirefoxConfig();
                string driverPath3 = driverManager.SetUpDriver(config);
                FirefoxDriverService service3 = FirefoxDriverService.CreateDefaultService(driverPath3);
                FirefoxOptions firefoxOptions = new FirefoxOptions();
                firefoxOptions.SetPreference("browser.download.showWhenStarting", preferenceValue: false);
                firefoxOptions.SetPreference("browser.download.folderList", 1);
                firefoxOptions.SetPreference("browser.download.manager.focusWhenStarting", preferenceValue: false);
                firefoxOptions.SetPreference("browser.download.useDownloadDir", preferenceValue: true);
                firefoxOptions.SetPreference("browser.helperApps.alwaysAsk.force", preferenceValue: false);
                firefoxOptions.SetPreference("browser.download.manager.alertOnEXEOpen", preferenceValue: false);
                firefoxOptions.SetPreference("browser.download.manager.closeWhenDone", preferenceValue: true);
                firefoxOptions.SetPreference("browser.download.manager.showAlertOnComplete", preferenceValue: false);
                firefoxOptions.SetPreference("browser.download.manager.useWindow", preferenceValue: false);
                firefoxOptions.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/octet-stream");
                if (headless)
                {
                    firefoxOptions.AddArguments(new List<string> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking", "-headless" });
                }
                else
                {
                    firefoxOptions.AddArguments(new List<string> { "--disable-extensions", "--start-maximized", "--disable-popup-blocking" });
                }

                return new FirefoxDriver(service3, firefoxOptions);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static void DeleteAndRecreateDirectory(string FileDownloadPath)
        {
            if (Directory.Exists(FileDownloadPath))
            {
                Directory.Delete(FileDownloadPath);
                Directory.CreateDirectory(FileDownloadPath);

            }
            else
            {
                Directory.CreateDirectory(FileDownloadPath);
            }
        }
    }
}
