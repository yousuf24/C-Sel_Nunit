using OpenQA.Selenium;
using Sel_CSharp002.FileFolderHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.BaseClass
{
    public class BaseSetUpCore
    {
        public IWebDriver _driver;
        public SeleniumHelper _seleniumHelper;
        public FileHelper _fileHelper;
        public PdfHelper _pdfHelper;

        public void InitializeNormalBrowser(string browser = "")
        {
            if (_driver == null)
            {
                BrowserFactoryHelper browFac = new BrowserFactoryHelper();
                _driver=browFac.CreateDriverInstance(browser);
                _driver.Manage().Window.Size = new Size(1366, 768);
                _seleniumHelper = new SeleniumHelper(_driver);
                _fileHelper = new FileHelper();
                _pdfHelper = new PdfHelper();
            }
        }
        public void InitializeNormalBrowserByWDManager(string browser = "")
        {
            if (_driver == null)
            {
                BrowserFactoryHelper browFac = new BrowserFactoryHelper();
                _driver = browFac.CreateDriverInstanceByWebDriverManager(browser);
                _driver.Manage().Window.Size = new Size(1366, 768);
                _seleniumHelper = new SeleniumHelper(_driver);
                _fileHelper = new FileHelper();
                _pdfHelper = new PdfHelper();
            }
        }
        public void InitializeHeadlessBrowser(string browser = "")
        {
            if (_driver == null)
            {
                BrowserFactoryHelper browFac = new BrowserFactoryHelper();
                browFac.CreateDriverInstance(browser,true);
                _driver.Manage().Window.Size = new Size(1366, 768);
                _seleniumHelper = new SeleniumHelper(_driver);
                _fileHelper = new FileHelper();
                _pdfHelper = new PdfHelper();
            }
        }
        public void DisposeDriver()
        {
            _driver = null;
        }
    }
}
