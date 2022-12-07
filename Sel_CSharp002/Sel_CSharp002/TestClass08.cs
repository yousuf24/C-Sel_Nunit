using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Sel_CSharp002
{   [TestFixture]
    class TestClass08 // About extent reports
    {
        public IWebDriver driver;
        ExtentReports extent = null;
        ExtentTest test = null;
        
        [OneTimeSetUp]
        public void SetUp()
        {
            var reportpath = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode-ws1\Sel_CSharp002\Sel_CSharp002\ExtentReport";
            extent = new ExtentReports();
            var htmlReport = new ExtentHtmlReporter(reportpath+"TestClass08.html");
            extent.AttachReporter(htmlReport);

        }
        [TearDown]
        public void TearDown()
        {
            extent.Flush();
        }


        [Test]
        [Author("yosufMD","aqieb.javed1996@gmail.com")]
        public void Mohsin15()
        {
            try
            {
                test = extent.CreateTest("test0001").Info("testStart");
                
                driver = new ChromeDriver();
                test.Log(Status.Info, "ChromeDriver launched.");
                driver.Url = "https://linkedin.com";
                driver.FindElement(By.Id("email-or-phone")).SendKeys("aqieb.javed1996@gmail.com");
                driver.FindElement(By.Id("password")).SendKeys("9491701295");
                test.Log(Status.Info, "UserID and Pwd Given.");
                driver.FindElement(By.PartialLinkText("Agree & Join")).Click();
                test.Log(Status.Pass, "Test passed.");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw;
            }
            finally
            {
                if (driver != null) driver.Quit();
            }
        }
        
    }
}
