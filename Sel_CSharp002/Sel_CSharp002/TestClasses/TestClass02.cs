using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace Sel_CSharp002
{       [TestFixture]
       class TestClass02
    {   public IWebDriver driver;

        [SetUp]
        public void setUp()
        {
            Console.WriteLine("insideSetUp");
            string path = @"C:\Users\HI\My_Items\Job\Softwares\Jar Files\Browser Drivers\chromedriver.exe";
            driver = new ChromeDriver(path);
            
            driver.Navigate().GoToUrl("https://eviltester.github.io/supportclasses/");
            driver.Manage().Window.Maximize();
            //http://www.uitestingplayground.com/ ; 
            //https://www.toolsqa.com/iframe-practice-page
            //https://www.seleniumeasy.com/test/basic-first-form-demo.html
            //https://my.asos.com/identity/register
            //https://eviltester.github.io/supportclasses/
            
        }

        [Test]
        public void vasanthaTest()
        {
            //String path = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode-ws1\Sel_CSharp002\packages\Selenium.WebDriver.IEDriver.4.6.0\driver";
            //driver = new InternetExplorerDriver(path);
           
            //Console.WriteLine(driver.PageSource);
            Thread.Sleep(2000);

            //Console.WriteLine(driver.FindElement(By.XPath("//div[contains(text(),'Internet')]")).GetCssValue("<>"));
            //Console.WriteLine(driver.FindElement(By.XPath("//div[contains(text(),'Internet')]")).GetAttribute("id"));
            //Console.WriteLine(driver.FindElement(By.XPath("//div[contains(text(),'Internet')]")).Displayed);//Enabled ; Selected; Text;

            //SelectElement dd = new SelectElement(driver.FindElement(By.Id("")));
            //dd.SelectByText("");

            //driver.FindElement(By.CssSelector("input.<classname>[<attribute>='']"));
            //driver.FindElement(By.Xpath()); *[@attribute='' AND @attribute2='']/ul/li[3]/a   or *[contains(text(),'')]  or  *[contains(@attribute,'')]

            String ti = driver.Title;
            Console.WriteLine(ti);
            Assert.AreEqual(ti, "Internet Speed Test | Fast.com");//.Null() ; .IsTrue(); .AreNotEqual()
            

        }
        [TearDown]
        public void tearDown()
        {
            driver.Close();
        }
    }
}
