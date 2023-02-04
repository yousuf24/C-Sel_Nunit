using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Sel_CSharp002.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002
{   [TestFixture]
    class TestClass06
    {
        IWebDriver driver;
       // [Test,Category("UAT"),Author("MohsinKhan786"),Order(0)]
      
        //public void Mohsin11()
        //{
        //    Assert.Ignore("not the latest");
        //    var obj = new BrowserUtility();//create object and store in var . var is supported in C#
        //    driver=obj.GetChromeInstance(driver);
        //    driver.FindElement(By.PartialLinkText("Create New")).Click();
        //    Thread.Sleep(3000);
        //    //SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
        //    //month.SelectByText("Jul");
        //    //Console.WriteLine("Mohsin Khan is in Automation Quality group and is on the way to SME");
            

        //}
        [Test]
        [TestCaseSource("Dp")]
        public void Mohsin13(String url)
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);



        }

        public static IList Dp()
        {
            ArrayList list = new ArrayList();
            list.Add("https://www.facebook.com");
            list.Add("https://www.linkedin.com");
            list.Add("https://www.youtube.com");
            return list;
        }
        [TearDown]
        public void Td()
        {
            driver.Close();
        }
        //[Test, Category("UAT"),Author("VasantaTestEngineer"),Order(1)]
        //public void Mohsin12()
        //{
        //    var obj = new BrowserUtility();//create object and store in var . var is supported in C#
        //    driver = obj.GetChromeInstance(driver);
        //    driver.FindElement(By.PartialLinkText("Create New")).Click();
        //    SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
        //    month.SelectByText("Aug");
        //    Console.WriteLine("Dalli is QE engineer got her new job through linkedIn");


        //}

        //[Test, Category("UAT"),Author("YousufJavaScript"),Order(2)]
        //public void Mohsin13()
        //{
        //    var obj = new BrowserUtility();//create object and store in var . var is supported in C#
        //    driver = obj.GetChromeInstance(driver);
        //    driver.FindElement(By.PartialLinkText("Create New")).Click();
        //    SelectElement month = new SelectElement(driver.FindElement(By.XPath("//*[@id='month']")));
        //    month.SelectByText("Sep");
        //    Console.WriteLine("Yousuf as Automation Test Engineer");


        //}


    }
}
