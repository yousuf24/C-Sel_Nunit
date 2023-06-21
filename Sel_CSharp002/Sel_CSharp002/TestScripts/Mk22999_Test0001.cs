using NUnit.Framework;
using Sel_CSharp002.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using Sel_CSharp002.PageObjects;

namespace Sel_CSharp002.TestScripts
{   [TestFixture]
    class Mk22999_Test0001:BaseSetUpCore //BrowserUtility
    {
        [SetUp]
        public void Bm()
        {
            InitializeNormalBrowser();
        }
        [TearDown]
        public void Am()
        {
            _seleniumHelper.DisposeDriverAlone();
            _seleniumHelper = null;
        }
       [Test]
        public void Mohsin16_test()
        {
            /*SearchPage Searchpageobj = new SearchPage(driver);
            var resultPageObj= Searchpageobj.Mohsin16();
            resultPageObj.toChannel();*/


        }
    }
}
