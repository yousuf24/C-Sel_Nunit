using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.PageObjects
{
    class HomePage
    {
        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public IWebDriver Driver { get; }
        public IWebElement Link => Driver.FindElement(By.Id(""));
        public IWebElement Details => Driver.FindElement(By.LinkText(""));

        //public void LinkClick()
        //{
        //    Link.Click();
        //}
        //Above piece of code is same as
        public void LinkClick() => Link.Click();
        public bool DetailsValidation() => Details.Displayed;
    }
}
