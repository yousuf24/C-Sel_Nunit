using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
