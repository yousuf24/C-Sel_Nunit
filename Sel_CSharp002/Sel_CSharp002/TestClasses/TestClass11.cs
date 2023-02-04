using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Sel_CSharp002.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestClasses
{   [TestFixture]
    class TestClass11
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new FirefoxDriver();
            driver.Url = "https://www.seleniumeasy.com/test/basic-first-form-demo.html";
        }
        [Test]
        public void LoginTest()
        {
            HomePage hp = new HomePage(driver); 
        }
    }
}
