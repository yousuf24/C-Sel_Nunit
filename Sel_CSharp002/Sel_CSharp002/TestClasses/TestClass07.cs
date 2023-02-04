using NUnit.Framework;
using OpenQA.Selenium;
using Sel_CSharp002.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002
{   [TestFixture]
    class TestClass07 : BrowserUtility
    {
        IWebDriver driver;
        [Test, Category("UAT"), Author("MohsinKhan786"), Order(0)]

        public void Mohsin14()
        {
            try
            {
                
                driver =GetChromeInstance(driver);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2000);
                driver.FindElement(By.PartialLinkText("//*[@id='abc']")).Click();
                
                //driver.FindElement(By.LinkText("")).Click();
                
                
            }
            catch (Exception e)
            {
                var pathSS = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode-ws1\Sel_CSharp002\SS";
                ITakesScreenshot ts=driver as ITakesScreenshot; //explicit Typecast
                Screenshot ss=ts.GetScreenshot();//getScreenShot Method
                ss.SaveAsFile(pathSS+"cut001.jpeg", ScreenshotImageFormat.Jpeg);
                Console.WriteLine(e.StackTrace);
                
                throw;
            }
            finally
            {
                if(driver!=null)driver.Quit();
            }
            


        }
    }
}
