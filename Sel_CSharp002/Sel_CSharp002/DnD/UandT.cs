using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002
{   [TestFixture]
    class UandT
    { public IWebDriver driver;
        [Test]
        public void mohsin07()
        {
            //driver = new FirefoxDriver();
            //var Path = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode-ws1\Sel_CSharp002\packages\Selenium.InternetExplorer.WebDriver.3.150.1\driver";
            driver = new ChromeDriver();
            driver.Url = "https://www.youtube.com"; //"https://www.linkedin.com/";
            Thread.Sleep(3000);
            driver.FindElement(By.XPath("//*[@id=\"search\"]")).SendKeys("c# selenium by Bakkappa N");
            
            driver.FindElement(By.CssSelector("#search-icon-legacy")).Click();

           //SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
            //Console.WriteLine(month.SelectedOption.Text);
           // month.SelectByText("Jul");
            driver.Close();
        }

    }
}

//VBA scripting
