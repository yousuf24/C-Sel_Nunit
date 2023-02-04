using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestClasses
{   [TestFixture]
    class TestClass10
    {
        IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Url = "https://my.asos.com/identity/register";
            
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
        [Test]
        public void tcs()
        {
            var TandC = driver.FindElement(By.Id("terms-and-conditions"));
            TandC.Click();
            IReadOnlyCollection<String> allW = driver.WindowHandles;
            foreach (String each in allW)
            {
                driver.SwitchTo().Window(each);
                Console.WriteLine(driver.Title);
                if (driver.Title.Equals("Terms & Conditions | ASOS")) break;
                
            }
            //driver.FindElement(By.XPath("//*[@id=\"chrome - app - container\"]/section/article/h1"));
            Thread.Sleep(3000);
            Assert.That(driver.FindElement(By.XPath("//*[@id=\"chrome - app - container\"]/section/article/h1")).Displayed, Is.True);


        }
    }
}
