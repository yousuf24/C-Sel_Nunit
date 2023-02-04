using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002
{   [TestFixture]
    class TestCalss05
    {
        //Remember if you are not using driver.quit() then u may have ot kill the process by "taskkill /f /im chromedriver.exe"
        public IWebDriver driver;
        [Test,Order(2),Category("order01")]
        public void Mohsin08()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("aqieb.javed1996@gmail.com");
            driver.Close();
        }
        [Test,Order(2), Category("order01")]
        public void Mohsin09()
        {
            driver = new ChromeDriver();
            Assert.Ignore("Dont want this test as it in DEV");
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("aqieb.javed1996@gmail.com");
            driver.Close();
        }
        [Test, Order(1),Category("order01")]
        public void Mohsin10()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://www.facebook.com");
            driver.FindElement(By.XPath("//*[@id='email']")).SendKeys("aqieb.javed1996@gmail.com");
            driver.Close();
        }
        

    }
}
