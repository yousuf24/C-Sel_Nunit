using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002
{   
    [TestFixture]
    class TestClass03
    {
        public static IWebDriver driver;
        [SetUp]
        public void su()
        {
            driver = new ChromeDriver();
            
        }
        [Test, Category("UAT")]
        public void Aqg_mohsin()
        {
            driver.Navigate().GoToUrl("https://www.flipkart.com/");//http://www.uitestingplayground.com/
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);//drawback is that it applies to all the steps
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[1]/input")).SendKeys("8332811095");
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[2]/input")).SendKeys("9491701295");
            driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div/div[2]/div/form/div[4]/button")).Click();
            Thread.Sleep(3000);

            /*String toV = driver.FindElement(By.XPath("//*[@id='container']/div/div[1]/div[1]/div[2]/div[3]/div/div/div/div")).Text;
            Assert.AreEqual(toV.ToLower(), "mohammad");*/

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            //wait.Until(ExpectedConditions.ElementExists(By.LinkText("Contact Us")));            
            //Console.WriteLine("Login Successful.");

            /*driver.FindElement(By.PartialLinkText("Return Policy")).Click();
            Thread.Sleep(3000);

            IWebElement table = driver.FindElement(By.XPath("//*[@id='container']/div/div[3]/div/div/div/table[1]"));
            IReadOnlyCollection<IWebElement> t_r = table.FindElements(By.TagName("tr"));
            for(int r_i = 0; r_i < t_r.Count; r_i++)
            {
                IReadOnlyCollection<IWebElement> t_d=t_r.ElementAt(r_i).FindElements(By.TagName("td"));//use only readable collection
                for(int c_i = 0; c_i < t_d.Count; c_i++)
                {
                   Console.WriteLine( t_d.ElementAt(c_i).Text);
                }

            }*/

            //Assert.IsTrue(driver.FindElement(By.LinkText("Contact Us")).Displayed);
            /*driver.FindElement(By.XPath("//*[@id='container']/div/div[2]/div[1]/div[2]/div[3]/div/div/div/div")).Click();
            driver.FindElement(By.PartialLinkText("My Profile")).Click();*/

            /*IAlert alert=driver.SwitchTo().Alert();
            alert.Accept();
            alert.Dismiss();
            String info=alert.Text;
            alert.SendKeys("");*/

            /* IWebElement table=driver.FindElement(By.Id(""));
             IReadOnlyCollection<IWebElement> t_r = table.FindElements(By.TagName("tr"));
             for(int index = 0; index < t_r.Count; index++)
             {
                 IReadOnlyCollection<IWebElement> t_d = t_r.ElementAt(index).FindElements(By.TagName("td"));
                 if(t_d.Count==5 && t_d.ElementAt(5).Text.Contains("SOmText"))
                 {
                     t_d.ElementAt(5).Click();break;
                 }
             }

             IReadOnlyCollection<String> all =driver.WindowHandles;
             foreach(String e in all)
             {
                 driver.SwitchTo().Window(e);
                 if (driver.Title.Equals("ChotaBheem")) break;

             }

             //check if any expected element present
             Boolean result=driver.FindElement(By.Id("")).Displayed;*/

            //driver = new FirefoxDriver();




        }
        [Test,Category("Smoke")]
        public void VasantaQA()
        {
            driver.Navigate().GoToUrl("http://www.uitestingplayground.com/");

        }
        [Test, Category("Regression")]
        public void MohsinPhase2QA()
        {
            driver.Navigate().GoToUrl("http://www.facebook.com/");

        }
        [Test, Category("Regression")]
        public void VasantaPhase2QA()
        {
            driver.Navigate().GoToUrl("http://www.github.com/yousuf24/");

        }
        [TearDown]
        public void td()
        {
            driver.Close();
        }

    }
}
