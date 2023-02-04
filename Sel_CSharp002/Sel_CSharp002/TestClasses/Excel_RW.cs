using Microsoft.Office.Interop.Excel;
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
{
    class Excel_RW
    {
        IWebDriver driver;
        String url = "https://www.linkedin.com/login";
        String path = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode-ws1\Sel_CSharp002\Sel_CSharp002\Resources\testbook.xlsx";
        [SetUp]
        public void setUp()
        {
            driver = new ChromeDriver();
            driver.Url = url;
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

        }

        [Test]
        public void TestMethod()
        {
            Application app = null;
            Workbook wb = null;
            Worksheet ws = null;

            app = new Application();app.Visible = true;//set visibility only for this execution
            wb = app.Workbooks.Open(path);
            ws=wb.Sheets["Sheet1"];

            int rowCount = ws.UsedRange.Rows.Count;

            for(int i = 2; i < rowCount; i++)
            {
                String uid = ws.Cells[i, 1].Text;
                String pwd = ws.Cells[i, 2].Text;
                try
                {
                    Console.WriteLine(uid + pwd);
                    driver.FindElement(By.Id("username")).SendKeys(uid);
                    driver.FindElement(By.Id("password")).SendKeys(pwd);

                    driver.FindElement(By.XPath("//button[@type='submit']")).Click();


                    if (driver.Title.Contains("Feed"))
                    {
                        ws.Cells[i, 3] = "Login Successful.";
                        driver.FindElement(By.XPath("//*[@id=\"ember16\"]/span/li-icon")).Click();
                        Thread.Sleep(1000);
                        driver.FindElement(By.XPath("//div[@id='ember15']/div")).Click();////div[@id='ember15']/div[@id='ember18']
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        ws.Cells[i, 3] = "Login Failed.";
                        

                        driver.Navigate().Refresh();
                    }
                }
                catch(Exception e)
                {
                    Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
                    String dst = @"C:\Users\HI\My_Items\Job\Softwares\VisualStudioCode - ws1\Sel_CSharp002\SS\screenshot01.PNG";
                    ss.SaveAsFile(dst);
                }
                finally
                {
                    driver.Navigate().Refresh();
                }
            }


            wb.Save();
            wb.Close();
            app.Quit();
        }
        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
}
