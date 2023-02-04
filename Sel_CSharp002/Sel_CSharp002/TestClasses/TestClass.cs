// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using OpenQA.Selenium;
using Sel_CSharp002.BaseClass;
using System.Threading;
using System;

namespace Sel_CSharp002
{
    [TestFixture]
    public class TestClass : PreRequisite
    {
        [SetUp]
        public void setUp() {
            // before Each
            Console.WriteLine("BeforeEach");
        }
        [Test]
        public void TestMethod()
        {
            driver.FindElement(By.Id("session_key")).SendKeys("aqieb.javed1996@gmail.com");
            driver.FindElement(By.Id("session_password")).SendKeys("aqieb*MD*9");
            Console.WriteLine(driver.Title);
            //.Text will give yo inner text

            /*Sometimes browser instances are stacked up in RAM which cause trouble
             * String command="/C taskkill /f /im chromedriver.exe&exit";
             * Diagnostics.Process.Start("cmd.exe",command); /C following strng is command /f force /im image <processname> exit to close command prompt
             */

        }
        [Test]
        public void mohsinClick()
        {
            driver.FindElement(By.LinkText("Sign in")).Click();
            Thread.Sleep(3000);
        }
        [TearDown]
        public void afterEach()
        {
            Console.WriteLine("AfterEach");
        }
    }
}
