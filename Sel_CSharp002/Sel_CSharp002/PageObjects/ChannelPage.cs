using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SeleniumExtras.PageObjects;

namespace Sel_CSharp002.PageObjects
{
    class ChannelPage
    {
        IWebDriver driver;
        public ChannelPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How=How.Id,Using ="")]
        public IWebElement ChannelText { get; set; }

        public String Validate()
        {
            String text = ChannelText.Text;
            Assert.AreEqual(text, "Bakkappa N");
            Assert.IsTrue(text.Equals("Bakkappa N"));
            return text;
        }
    }
}
