using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.BaseClass
{
    public class PreRequisite
    {
        public IWebDriver driver;
        [OneTimeSetUp]
        public void oneTimeSetUp()
        {   //For LinkedIn
            /*driver = new ChromeDriver();// You can also provide .exe path in param but its optional
            driver.Url = "https://www.linkedin.com/";// ir diver.Navigate().goToURL(""); driver.Navigate().refresh();//.back();forward();*/
            //http://www.uitestingplayground.com/
            //For LinkedIn diff method
            
            String driverPath = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode-ws1\Sel_CSharp002\packages\Selenium.WebDriver.ChromeDriver.108.0.5359.7100\driver\win32";
            driver = new ChromeDriver(driverPath);
            //driver.Navigate().GoToUrl("https://www.linkedin.com/");
            driver.Url="https://www.youtube.com/";
            driver.Manage().Window.Maximize();
           
            

        }

        [OneTimeTearDown]
        public void tearDown()
        {
            driver.Quit();
            //driver.Close();
        }

    }
}
