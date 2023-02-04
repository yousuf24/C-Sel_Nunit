using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestClasses
{   [TestFixture]
    class TestClass09
    {
        IWebDriver driver;
       [TearDown]
        public void TD()
        {
            driver.Quit();

        }
        [Test]
        public void LaunchChrome()
        {
           driver = new ChromeDriver();
            driver.Url = "https://google.com";
        }
        [Test]
        public void LaunchMSEdge()
        {
            driver = new EdgeDriver();
            driver.Url = "https://google.com";
        }
        [Test]
        public void PlaywithText()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://www.facebook.com/");
            IWebElement txtBox = driver.FindElement(By.Id("email"));
            txtBox.SendKeys("test123@gmail.com");
            
            Console.WriteLine(txtBox.GetAttribute("name"));
            Thread.Sleep(2000);
            //IWebElement txt = driver.FindElement(By.XPath("//a[@id='u_0_0_2c']"));
            //Console.WriteLine(txt.Text);
            var ElementList=driver.FindElements(By.XPath("//*[@id=\"pageFooterChildren\"]/ul/li[3]"));
            Console.WriteLine(ElementList.Count);



        }
        [Test]
        public void HandlingWindow()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("https://google.com");
            driver.SwitchTo().NewWindow(WindowType.Window);
            Thread.Sleep(2000);
            driver.Url = "https://gmail.com";
            //Console.WriteLine(driver.CurrentWindowHandle);
            driver.SwitchTo().DefaultContent();
            var Windows=driver.WindowHandles;
            Console.WriteLine(Windows.First()+":"+Windows.Last());
        }
    }
}
