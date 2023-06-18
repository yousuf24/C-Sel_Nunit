using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sel_CSharp002.BaseClass
{
    public class SeleniumHelper
    {
        #region Variable Declaration
        public IWebDriver Driver;
        public Actions _actions;

        #endregion

        #region Constructor
        public SeleniumHelper(IWebDriver driver)
        {
            this.Driver = driver;
        }
        #endregion

        #region Element Loader
        public bool IsElementPresent(By by)
        {
            try
            {
                Driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
        public By LoadElementBy(How how, string Locator)
        {
            By Ele = null;
            try
            {
                switch (how)
                {
                    case How.Id: Ele = By.Id(Locator); break;
                    case How.Name: Ele = By.Name(Locator); break;
                    case How.ClassName: Ele = By.ClassName(Locator); break;
                    case How.CssSelector: Ele = By.CssSelector(Locator); break;
                    case How.LinkText: Ele = By.LinkText(Locator); break;
                    case How.PartialLinkText: Ele = By.PartialLinkText(Locator); break;
                    case How.TagName: Ele = By.TagName(Locator); break;
                    case How.XPath: Ele = By.XPath(Locator); break;

                }

            } catch (Exception ex)
            {
                throw ex;
            } return Ele;
        }
        public IWebElement LoadWebElement(How how, String Locator)
        {
            IWebElement We = null;
            try
            {
                By Ele = LoadElementBy(how, Locator);
                We = Driver.FindElement(Ele);

            } catch (Exception ex)
            {
                throw ex;
            }
            return We;
        }
        public IWebElement LoadWebElement(IWebElement We, By locator)
        {
            IWebElement WE = null;
            try
            {
                WE = We.FindElement(locator);


            } catch (Exception ex)
            {
                AlertAccept();
                throw ex;
            } return WE;
        }
        public IWebElement LoadWebElement(By Locator)
        {
            IWebElement We = null;
            try
            {
                We = Driver.FindElement(Locator);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            return We;
        }
        public IList<IWebElement> LoadCollectionOfWebElements(How how, String Locator)
        {
            IList<IWebElement> Welements = null;
            try
            {
                Welements = Driver.FindElements(LoadElementBy(how, Locator));
            }
            catch (Exception e)
            {
                throw e;
            } return Welements;
        }
        public IList<IWebElement> LoadCollectionOfWebElements(By Locator)
        {
            IList<IWebElement> Welements = null;
            try
            {
                Welements = Driver.FindElements(Locator);
            }
            catch (Exception e)
            {
                throw e;
            }
            return Welements;
        }
        public IList<IWebElement> LoadCollectionOfWebElements(By Parent, By Child)
        {
            IList<IWebElement> Welements = null;
            try
            {
                IWebElement We = Driver.FindElement(Parent);
                if (We != null)
                {
                    Welements = We.FindElements(Child);
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return Welements;
        }
        public IList<IWebElement> LoadCollectionOfWebElements(IWebElement We, By Locator)
        {
            IList<IWebElement> Welements = null;
            try
            {

                Welements = We.FindElements(Locator);

            }
            catch (Exception e)
            {
                throw e;
            }
            return Welements;
        }
        public void PageRefresh()
        {
            Driver.Navigate().Refresh();
        }
        public void GoToPreviousPage()
        {
            Driver.Navigate().Back();
        }
        public void GoToForwardPage()
        {
            Driver.Navigate().Forward();
        }

        #endregion

        #region ClickFunctions
        public bool Click(IWebElement We)
        {
            try
            {
                We.Click();
                return true;
            }
            catch (Exception e) { return false; throw e; }
        }
        public bool Click(By ele, int timeOut = 60)
        {
            bool IsClicked = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeOut));
                wait.Until(ExpectedConditions.ElementExists(ele));
                wait.Until(ExpectedConditions.ElementIsVisible(ele));
                wait.Until(ExpectedConditions.ElementToBeClickable(ele));
                Driver.FindElement(ele).Click();
                IsClicked = true;

            }
            catch (Exception e)
            {
                throw e;
            }
            return IsClicked;
        }
        public bool ClickWithOutWait(By ele)
        {
            bool IsClicked = false;
            try
            {
                Driver.FindElement(ele).Click();
                IsClicked= true;
            }
            catch (Exception)
            {

                throw;
            }return IsClicked;
        }
        public bool DoubleClick(By Ele,int TimeOut)
        {
            bool IsClicked = false;
            try
            {
                WaitForPageToLoad();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                wait.Until(ExpectedConditions.ElementToBeClickable(Ele));

                Actions _actions = new Actions(Driver);
                _actions.ContextClick(Driver.FindElement(Ele)).Build().Perform();                
                IsClicked = true;

            }
            catch (Exception)
            {

                throw;
            }return IsClicked;
        }
        public Actions InitializeActions()
        {
            return new Actions(Driver);
        }

        [Obsolete("Use normal Click()",true)]
        public bool ClickAfterVisible(By Ele)
        {
            bool IsClicked = false;
            try
            {
                
            }
            catch (Exception)
            {

                throw;
            }return IsClicked;
        }
        public bool ClickByEnter(By Ele)
        {
            bool IsClicked = false;
            try
            {
                IWebElement Wele=Driver.FindElement(Ele);
                Wele.SendKeys(Keys.Enter);
                IsClicked = true;

            }
            catch (Exception)
            {

                throw;
            }return IsClicked;
        }
        public bool Click(How how,String locator)
        {
            bool IsClicked = false;
            try
            {
                IWebElement Wele = LoadWebElement(how, locator);
                Wele.Click();
                IsClicked = true;

            }
            catch (Exception)
            {

                throw;
            }
            return IsClicked;
        }
        public bool ClickByJsExecutor(How how, String locator)
        {
            bool IsClicked = false;
            try
            {
                switch (how)
                {
                    case How.Id: JavaExecutor($"document.getElementById('{locator}').click()");break;
                    case How.ClassName: JavaExecutor($"document.getElementsByClassName('{locator}')[0].click()"); break;
                    case How.Name: JavaExecutor($"document.getElementsByName('{locator}')[0].click()"); break;
                    case How.TagName: JavaExecutor($"document.getElementsByTagName('{locator}')[0].click()"); break;
                    case How.CssSelector: JavaExecutor($"document.querySelector('{locator}')[0].click()"); break;
                    case How.XPath: JavaExecutor($"document.getElementsByXPath('{locator}')[0].click()"); break;
                }
                IsClicked = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsClicked;
        }
        public bool ClickbyJsExecutor(IWebElement Wele)
        {
            bool IsClicked = false;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", Wele);
                IsClicked = true;
            }
            catch (Exception)
            {

                throw;
            }return IsClicked;
        }
        public bool ClickbyJsExecutor(By Ele)
        {
            bool IsClicked = false;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click()", Ele);
                IsClicked = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsClicked;
        }
        #endregion

        #region TextEnter functions
        public bool TextEnter(IWebElement Wele,string txt)
        {
            bool IsEntered = false;
            try
            {
                Wele.Clear();
                Wele.SendKeys(txt);
                IsEntered = true;

            }
            catch (Exception)
            {
                throw;
            }return IsEntered;
        }
        public bool TextEnter(By Ele, string txt,int TimeOut)
        {
            bool IsEntered = false;
            try
            {
                WebDriverWait wait=new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                IWebElement Wele=LoadWebElement(Ele);
                Wele.Clear();
                Wele.SendKeys(txt);
                IsEntered = true;

            }
            catch (Exception)
            {
                throw;
            }
            return IsEntered;
        }
        public bool TextEnter(How how,string Locator, string txt)
        {
            bool IsEntered = false;
            try
            {
                IWebElement Wele = LoadWebElement(how, Locator);
                Wele.Clear();
                Wele.SendKeys(txt);
                IsEntered = true;

            }
            catch (Exception)
            {
                throw;
            }
            return IsEntered;
        }
        #endregion

        #region Radio Button and CheckBox Functions
        //ToDo:
        #endregion

        #region DropDown Select
        public bool SelectContains(IWebElement Wele,String Optiontxt)
        {
            bool IsSelected = false;
            try
            {
                SelectElement drpdown = new SelectElement(Wele);

                string txt= drpdown.Options.AsEnumerable().Where(x => x.Text.Contains(Optiontxt)).Select(x => x.Text).First();
                drpdown.SelectByText(txt);
                IsSelected = true;

            }
            catch (Exception)
            {

                throw;
            }return IsSelected;
        }
        //ToResume

        #endregion












        #region Wait Functions
       public bool WaitTillOptionsLoaded(IWebElement Wele,int TimeOut,int MinOptionCount)
        {
            bool IsLoaded = false;
            try
            {
                SelectElement drp = new SelectElement(Wele);
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(d => {
                    try
                    {
                        return drp.Options.Count > MinOptionCount;
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                });

            }
            catch (Exception)
            {

                throw;
            }return IsLoaded;

        }
        public bool WaitTillVisible(By Ele,int TimeOut = 60)
        {
            bool IsVisible = false;
            try
            {
                WaitForPageToLoad();
                WebDriverWait wait=new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                IsVisible = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsVisible;
        }
        public bool WaitTillNotVisible(By Ele, int TimeOut = 60)
        {
            bool IsVisible = false;
            try
            {
                WaitForPageToLoad();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.InvisibilityOfElementLocated(Ele));
                IsVisible = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsVisible;
        }

        public bool WaitForPageToLoad(int TimeOut = 60)
        {
            bool IsLoaded = true;
            do
            {
                try
                {
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                        wait.Until<Boolean>(d => {
                            try
                            {
                                return ((IJavaScriptExecutor)Driver).ExecuteScript("return document.readyState").ToString().Equals("complete");
                            }
                            catch (Exception)
                            {
                                return false;
                            }
                        });
                }
                catch (Exception)
                {

                    throw;
                }

            } while (!IsLoaded);
            return IsLoaded;
        }
        #endregion

        #region Extra
        public bool JavaExecutor(string script)
        {
            bool Success = false;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript(script);
                Success = true;

            }
            catch (Exception)
            {

                throw;
            }return Success;
        }
        public void AlertAccept()
            {
                try
                {
                    Thread.Sleep(5000);
                    IAlert alert = Driver.SwitchTo().Alert();
                    alert.Accept();
                } catch (Exception e)
                {
                    throw e;
                }
            }
        #endregion
        
        
        
    }
}
