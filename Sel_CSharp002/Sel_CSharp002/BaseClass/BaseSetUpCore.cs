using OpenQA.Selenium;
using Sel_CSharp002.FileFolderHelper;
using System;
using System.Collections.Generic;
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
            if (_driver != null)
            {
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
