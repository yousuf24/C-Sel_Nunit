using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002.PageObjects
{
    class ResultPage
    {
        IWebDriver driver;
        public ResultPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);//to initialize all webElements ( SearchBox, SearchButton )

        }
        [FindsBy(How=How.LinkText,Using ="")]
        public IWebElement ChannelName { get; set; }

        public void toChannel()
        {
            Thread.Sleep(3000);
            ChannelName.Click();

        }
    }
}
