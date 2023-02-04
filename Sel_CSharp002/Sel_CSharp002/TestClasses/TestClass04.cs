using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Sel_CSharp002.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002
{   [TestFixture]
    class TestClass04
    {
        IWebDriver driver;
        [Test,Category("UAT"),Category("Module01")]
        public void Mohsin03()
        {
            var obj = new BrowserUtility();//create object and store in var . var is supported in C#
            driver=obj.GetChromeInstance(driver);
            driver.FindElement(By.PartialLinkText("Create New")).Click();
            SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
            month.SelectByText("Jul");
            

        }

        [Test, Category("UAT"), Category("Module01")]
        public void Mohsin04()
        {
            var obj = new BrowserUtility();//create object and store in var . var is supported in C#
            driver = obj.GetChromeInstance(driver);
            driver.FindElement(By.PartialLinkText("Create New")).Click();
            SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
            month.SelectByText("Aug");

        }

        [Test, Category("UAT"), Category("Module01")]
        public void Mohsin05()
        {
            var obj = new BrowserUtility();//create object and store in var . var is supported in C#
            driver = obj.GetChromeInstance(driver);
            driver.FindElement(By.PartialLinkText("Create New")).Click();
            SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
            month.SelectByText("Sep");

        }

        [Test, Category("UAT"), Category("Module01")]
        public void Mohsin06()
        {
            var obj = new BrowserUtility();//create object and store in var . var is supported in C#
            driver = obj.GetChromeInstance(driver);
            driver.FindElement(By.PartialLinkText("Create New")).Click();
            SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
            month.SelectByText("Oct");

        }
        [TearDown]
        public void td()
        {
            driver.Close();
        }
    }
}
