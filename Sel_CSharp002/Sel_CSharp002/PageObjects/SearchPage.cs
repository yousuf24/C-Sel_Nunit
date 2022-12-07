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
    class SearchPage  //:PreRequisite
    {
        public IWebDriver driver;

        //Constructor
        public SearchPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);//to initialize all webElements ( SearchBox, SearchButton )

        }


        [FindsBy(How = How.XPath, Using = "//*[@id='search']")]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#search-icon-legacy")]
        public IWebElement SearchButton { get; set; }

        
        public ResultPage Mohsin16()
        {
            Thread.Sleep(3000);
            SearchBox.SendKeys("Selenium C# tutorials by bakkapa");
            SearchButton.Click();
            return new ResultPage(driver);


        }
    }
}
