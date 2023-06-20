using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
        public bool TextEnter(By Ele, string txt,int TimeOut=60)
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
        public bool SelectContains(By Ele, String Optiontxt)
        {
            bool IsSelected = false;
            try
            {
                SelectElement drpdown = new SelectElement(LoadWebElement(Ele));
                WaitTillOptionsLoaded(Ele,10);

                string txt = drpdown.Options.AsEnumerable().Where(x => x.Text.Contains(Optiontxt)).Select(x => x.Text).First();
                drpdown.SelectByText(txt);
                IsSelected = true;

            }
            catch (Exception)
            {

                throw;
            }
            return IsSelected;
        }
        public bool SelectByIndex(IWebElement Wele,int index)
        {
            bool IsSelected = false;
            try
            {
                SelectElement drp = new SelectElement(Wele);
                WaitTillOptionsLoaded(Wele,10);
                drp.SelectByIndex(index);
                IsSelected = true;
            }
            catch (Exception)
            {

                throw;
            }return IsSelected;
        }
        public bool SelectByIndex(By Ele, int index)
        {
            bool IsSelected = false;
            try
            {
                SelectElement drp = new SelectElement(LoadWebElement(Ele));
                WaitTillOptionsLoaded(LoadWebElement(Ele), 10);
                drp.SelectByIndex(index);
                IsSelected = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsSelected;
        }
        public string SelectedOption(By Ele)
        {
            string str = string.Empty;
            try
            {
                SelectElement se = new SelectElement(LoadWebElement(Ele));
                str=se.SelectedOption.Text;
            }
            catch (Exception)
            {

                throw;
            }return str;
        }
        public void DeselectAll(By Ele)
        {
            try
            {
                SelectElement se = new SelectElement(LoadWebElement(Ele));
                WaitTillOptionsLoaded(LoadWebElement(Ele), 10);
                se.DeselectAll();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public List<String> GetAllOptionsText(By Ele)
        {
            List<String> strOptions = new List<String>();
            try
            {
                SelectElement drp = new SelectElement(LoadWebElement(Ele));
                strOptions=drp.Options.Select(x => x.Text).ToList();
            }
            catch (Exception)
            {

                throw;
            }return strOptions;
        }
        #endregion

        #region Verification functions
        public bool VerifyElemExists(IWebElement Wele,bool IsExpected)
        {
            bool Status = false;
            try
            {
                if(IsExpected)
                    Status =ElementDisplayed(Wele); 
                
            }
            catch (Exception)
            {

                throw;
            }return Status;
        }
        public bool VerifyElemExists(By Ele, bool IsExpected)
        {
            bool Status = false;
            try
            {
                if (IsExpected)
                    Status = ElementDisplayed(LoadWebElement(Ele));

            }
            catch (Exception)
            {

                throw;
            }
            return Status;
        }
        public bool VerifyAllOptionExistInDropDown(By Ele,List<String> strOptions)
        {
            bool Status = false;
            try
            {
                SelectElement se = new SelectElement(LoadWebElement(Ele));
                List<String> Actual=se.Options.Select(x => x.Text).Distinct().ToList();
                if (strOptions.Count == se.Options.Count)
                {
                    foreach(string Option in strOptions)
                    {
                       Status= Actual.Any(x => x.Trim().Contains(Option));
                        if (!Status) break;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }return Status;
        }
        public bool VerifyAllOptionExistInDropDown(IWebElement Wele, List<String> strOptions)
        {
            bool Status = false;
            try
            {
                SelectElement se = new SelectElement(Wele);
                if (strOptions.Count == se.Options.Count)
                {
                    foreach (string Option in strOptions)
                    {
                        VerifyValueExistsinDrpDown(Wele, Option);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return Status;
        }

        public bool VerifyValueExistsinDrpDown(By Ele,string strToSearch)
        {
            bool IsExist = false;
            try
            {
                SelectElement se = new SelectElement(LoadWebElement(Ele));
                if (se != null)
                {
                    List<String> strOptionsActual=se.Options.Select(x => x.Text).ToList();
                    strOptionsActual = strOptionsActual.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();
                    strToSearch=strToSearch.Trim();
                    IsExist = (strOptionsActual.Any(x => x.Trim().Contains(strToSearch)));
                }

            }
            catch (Exception)
            {

                throw;
            }return IsExist;
        }
        public bool VerifyValueExistsinDrpDown(IWebElement Wele, string strToSearch)
        {
            bool IsExist = false;
            try
            {
                SelectElement se = new SelectElement(Wele);
                if (se != null)
                {
                    List<String> strOptionsActual = se.Options.Select(x => x.Text).ToList();
                    strOptionsActual = strOptionsActual.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();
                    strToSearch = strToSearch.Trim();
                    IsExist = (strOptionsActual.Any(x => x.Trim().Contains(strToSearch)));
                }

            }
            catch (Exception)
            {

                throw;
            }
            return IsExist;
        }
        #endregion

        #region Attribute functions
        public string GetElementAttributeValue(IWebElement W,string strAtt)
        {
            string str = string.Empty;
            try
            {
                if(W!=null)
                    str=W.GetAttribute(strAtt);

            }
            catch (Exception)
            {

                throw;
            }return str;
    
        }
        public string GetElementAttributeValue(By W, string strAtt)
        {
            string str = string.Empty;
            try
            {
                if (W != null)
                    str = LoadWebElement(W).GetAttribute(strAtt);

            }
            catch (Exception)
            {

                throw;
            }
            return str;

        }
        public void SetAttribute(IWebElement Wele,string strAttrName,string strValue)
        {
            var jsExec = (IJavaScriptExecutor)Driver;
            jsExec.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", Wele, strAttrName, strValue);
        }
        public void SetAttribute(By Ele, string strAttrName, string strValue)
        {
            var jsExec = (IJavaScriptExecutor)Driver;
            jsExec.ExecuteScript("arguments[0].setAttribute(arguments[1],arguments[2])", Ele, strAttrName, strValue);
        }
        public void RemoveAttribute(IWebElement Ele, string strAttrName, string strValue)
        {
            var jsExec = (IJavaScriptExecutor)Driver;
            jsExec.ExecuteScript("arguments[0].removeAttribute(arguments[1])", Ele, strAttrName);
        }
        public void RemoveAttribute(By Ele, string strAttrName, string strValue)
        {
            var jsExec = (IJavaScriptExecutor)Driver;
            jsExec.ExecuteScript("arguments[0].removeAttribute(arguments[1])", Ele, strAttrName);
        }
        #endregion












        #region Wait Functions
        public bool WaitTillExists(How how, string loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(LoadElementBy(how, loc)));

            }
            catch (Exception)
            {

                throw;
            }return St;
        }
        public bool WaitTillExists(By E, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(E));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillPresenceOf(How how, string loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(LoadElementBy(how, loc)));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillPresenceOf(By loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(loc));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillVisible(How how, string loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(LoadElementBy(how, loc)));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillVisible(By loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(loc));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillClickable(How how, string loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementToBeClickable(LoadElementBy(how, loc)));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillClickable(By loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementToBeClickable(loc));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillClickable(IWebElement loc, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementToBeClickable(loc));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillText(IWebElement loc,string strEx, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.TextToBePresentInElement(loc,strEx));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillText(By loc, string strEx, int TimeOut = 60)
        {
            bool St = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.TextToBePresentInElementLocated(loc, strEx));

            }
            catch (Exception)
            {

                throw;
            }
            return St;
        }
        public bool WaitTillOptionsLoaded(IWebElement Wele,int TimeOut,int MinOptionCount=0)
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
        public bool WaitTillOptionsLoaded(By Ele, int TimeOut, int MinOptionCount = 0)
        {
            bool IsLoaded = false;
            try
            {
                SelectElement drp = new SelectElement(LoadWebElement(Ele));
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
            }
            return IsLoaded;

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
        public bool ElementDisplayed(IWebElement Wele,bool IsExpected=true)
        {
            bool Status = false;
            try
            {
                if (Wele != null)
                {
                    if (Wele.Displayed && IsExpected) Status = true;
                    else if (!Wele.Displayed && !IsExpected) Status = true;
                    else if (Wele.Displayed && !IsExpected) Status = false;
                    else if (!Wele.Displayed && IsExpected) Status = false;
                }
                else
                {
                    if (IsExpected) Status = false;
                    else if (!IsExpected) Status = true;
                }

            }
            catch (Exception)
            {

                throw;
            }return Status;

        }
        public bool ElementDisplayed(By Ele, bool IsExpected = true)
        {
            bool Status = false;
            try
            {
                IWebElement Wele=LoadWebElement(Ele);
                    if (Wele.Displayed && IsExpected) Status = true;
                    else if (!Wele.Displayed && !IsExpected) Status = true;
                    else if (Wele.Displayed && !IsExpected) Status = false;
                    else if (!Wele.Displayed && IsExpected) Status = false;
                
                

            }
            catch (Exception)
            {

                throw;
            }
            return Status;

        }
        public bool ElementDisplayed(How how,string locator, bool IsExpected = true)
        {
            bool Status = false;
            try
            {
                IWebElement Wele = LoadWebElement(how,locator);
                if (Wele.Displayed && IsExpected) Status = true;
                else if (!Wele.Displayed && !IsExpected) Status = true;
                else if (Wele.Displayed && !IsExpected) Status = false;
                else if (!Wele.Displayed && IsExpected) Status = false;



            }
            catch (Exception)
            {

                throw;
            }
            return Status;

        }
        public bool WaitTillTextBoxNotEmpty(IWebElement W,int Timeout = 60)
        {
            bool S = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timeout));
                wait.Until < Boolean>(d =>
                {
                    try
                    {
                        return GetElementAttributeValue(W, "value").Length != 0;
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
            }return S;
        }
        public bool WaitTillTextBoxNotEmpty(By W, int Timeout = 60)
        {
            bool S = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(Timeout));
                wait.Until<Boolean>(d =>
                {
                    try
                    {
                        return GetElementAttributeValue(W, "value").Length != 0;
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
            return S;
        }
        #endregion

        #region Extract textFromUI
        public string GetElementText(How how,string Loc, int TimeOut = 60)
        {
            string str = string.Empty;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                By Ele = LoadElementBy(how,Loc);
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                str = LoadWebElement(Ele).Text;
                str = string.IsNullOrEmpty(str) ? GetElementAttributeValue(Ele, "innerText") : str;
                str = string.IsNullOrEmpty(str) ? GetElementAttributeValue(Ele, "value") : str;

            }
            catch (Exception)
            {

                throw;
            }
            return str;
        }
        public string GetElementText(By Ele,int TimeOut = 60)
        {
            string str = string.Empty;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                str=LoadWebElement(Ele).Text;
                str = string.IsNullOrEmpty(str) ? GetElementAttributeValue(Ele, "innerText") : str;
                str = string.IsNullOrEmpty(str) ? GetElementAttributeValue(Ele, "value") : str;

            }
            catch (Exception)
            {

                throw;
            }return str;
        }
        public string ExtractCellValueFromTable(By Ele,int r,int c)
        {
            string str = string.Empty;
            try
            {
                if (Ele != null)
                {
                    IList<IWebElement> tblRows=LoadCollectionOfWebElements(Ele, By.TagName("tr"));
                    str=tblRows.ElementAt(r).FindElements(By.TagName("td"))[c-1].Text;
                }
            }
            catch (Exception)
            {

                throw;
            }return str;
        }
        public string ExtractCellValueFromTable(IWebElement Ele, int r, int c)
        {
            string str = string.Empty;
            try
            {
                if (Ele != null)
                {
                    IList<IWebElement> tblRows = LoadCollectionOfWebElements(Ele, By.TagName("tr"));
                    str = tblRows.ElementAt(r).FindElements(By.TagName("td"))[c - 1].Text;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return str;
        }
        #endregion

        #region Field Justification
        public bool IsFieldRequired(IWebElement Wele,bool NeedToFill)
        {
            if (NeedToFill)
                return IsMandtoryFieldiLr(Wele);
            else
                return ElementDisplayed(Wele) ? true:false;
        }
        public bool IsMandtoryFieldiLr(By Ele)
        {
            bool IsR = false;
            try
            {
                IWebElement Wele=LoadWebElement(Ele);
                IsR = ElementDisplayed(Wele) ? Wele.GetAttribute("class").Contains("input-validation-error") : false;

            }
            catch (Exception)
            {

                throw;
            }return IsR;
        }
        public bool IsMandtoryFieldiLr(IWebElement Wele)
        {
            bool IsR = false;
            try
            {
                
                IsR = ElementDisplayed(Wele) ? Wele.GetAttribute("class").Contains("input-validation-error") : false;

            }
            catch (Exception)
            {

                throw;
            }
            return IsR;
        }
        public bool IsTextbox(By Ele)
        {
            bool IsTb = false;
            try
            {
                IWebElement Wele=LoadWebElement(Ele);
                IsTb=Wele != null ? Wele.TagName.Equals("input", StringComparison.OrdinalIgnoreCase) : false;

            }
            catch (Exception)
            {

                throw;
            }return IsTb;
        }
        public bool IsDateField(By Ele)
        {
            bool IsTb = false;
            try
            {
                IWebElement Wele = LoadWebElement(Ele);
                IsTb = Wele != null ? Wele.GetAttribute("class").Contains("date") : false;

            }
            catch (Exception)
            {

                throw;
            }
            return IsTb;
        }

        #endregion

        #region Extra
        public bool UploadDocuments(By Ele,string strPath,int TimeOut=60)
        {
            bool IsStatus = true;
            try
            {
                LoadWebElement(Ele).SendKeys(strPath);
                IsStatus = true;
            }
            catch (Exception)
            {

                throw;
            }return IsStatus;
        }
        public bool WaitForUrlContains(string str,int TimeOut=60)
        {
            bool IsStatus = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.UrlContains(str));
                IsStatus = true;
            }
            catch (Exception)
            {

                throw;
            }return IsStatus;
        }
        public bool WaitForUrlMatchesRegex(string str, int TimeOut=60)
        {
            bool IsStatus = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.UrlMatches(str));
                IsStatus = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsStatus;
        }
        public bool OpenUrl(string strUrl)
        {
            try
            {
                Driver.Navigate().GoToUrl(strUrl);
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void SwitchToLatestTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.Last());
        }
        public void SwitchToFirstTab()
        {
            Driver.SwitchTo().Window(Driver.WindowHandles.First());
        }
        public bool SwitchFrame(int index)
        {
            bool IsTrue = false;
            try
            {
                Driver.SwitchTo().Frame(index);
                IsTrue = true;
            }
            catch (Exception)
            {

                throw;
            }return IsTrue;
        }
        public bool SwitchFrame(By Ele)
        {
            bool IsTrue = false;
            try
            {
                WaitTillVisible(Ele);
                Driver.SwitchTo().Frame(LoadWebElement(Ele));
                IsTrue = true;
            }
            catch (Exception)
            {

                throw;
            }
            return IsTrue;

        }
        public bool SwitchToDefaultFrame()
        {
            try
            {
                Driver.SwitchTo().DefaultContent();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
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
        public bool JavaExecutor(string script,string param)
        {
            bool Success = false;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript(script,param);
                Success = true;

            }
            catch (Exception)
            {

                throw;
            }
            return Success;
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
        public IWebElement JavaExecutorshadowDom(string strJQuery)
        {
            IWebElement Wele = null;
            try
            {
                var js=((IJavaScriptExecutor)Driver);
                Wele=(IWebElement)js.ExecuteScript("return" + strJQuery);
            }
            catch (Exception)
            {

                throw;
            }return Wele;
        }
        public bool JavaExecutor(string strScript,IWebElement Wele)
        {
            bool S = true;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript(strScript, Wele);S = true;
            }
            catch (Exception)
            {

                throw;
            }return S;
        }
        public bool JavaExecutor(string strScript, By Wele)
        {
            bool S = true;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript(strScript, Wele); S = true;
            }
            catch (Exception)
            {

                throw;
            }
            return S;
        }
        public bool JavaExecutor(string strScript, By Wele,string txt)
        {
            bool S = true;
            try
            {
                ((IJavaScriptExecutor)Driver).ExecuteScript(strScript, Wele,txt); S = true;
            }
            catch (Exception)
            {

                throw;
            }
            return S;
        }
        public void DisposeDriverAlone()
        {
            try
            {
                Driver.Close();
                Driver.Dispose();
                Driver.Quit();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public bool OpenInANewTab(IWebElement Wele)
        {
            bool Is = false;
            try
            {
                Actions _actions=InitializeActions();
                _actions.KeyDown(Keys.Control).Click(Wele).KeyUp(Keys.Control).Build().Perform();
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        public bool OpenInANewTab(By Ele)
        {
            bool Is = false;
            try
            {
                Actions _actions = InitializeActions();
                _actions.KeyDown(Keys.Control).Click(LoadWebElement(Ele)).KeyUp(Keys.Control).Build().Perform();
            }
            catch (Exception)
            {

                throw;
            }
            return Is;
        }
        public void OpenNewTab()
        {
            try
            {
                JavaExecutor("window.open()");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public String GetCurrentURL()
        {
            string str = string.Empty;
            try
            {
                str = Driver.Url;

            }
            catch (Exception)
            {

                throw;
            }return str;
        }
        public void SetCurrentDate(By Ele)
        {
            WaitTillVisible(Ele);
            TextEnter(Ele, DateTime.Now.ToString("MM/dd/yyyy"));

        }

        #endregion

        #region Mouse Actions
        public void RightClick(IWebElement Wele)
        {
            Actions _actions=InitializeActions();
            _actions.MoveToElement(Wele).ContextClick().Build().Perform();
        }
        public void RightClick(By Wele)
        {
            Actions _actions = InitializeActions();
            _actions.MoveToElement(LoadWebElement(Wele)).ContextClick().Build().Perform();
        }
        #endregion

        #region Window functions
        public void MaximizeWindow()
        {
            Driver.Manage().Window.Maximize();
        }
        public bool SwitchWindow(string window)
        {
            bool Is = false;
            try
            {
                if (!Driver.Title.Equals(window))
                {
                    foreach (var handle in Driver.WindowHandles)
                    {
                        IWebDriver popup = Driver.SwitchTo().Window(handle);
                        if (popup.Title.Trim().Equals(window))
                        {
                            Is = true;
                            break;

                        }
                            
                    }
                    {

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }return Is;

        }
        public bool CloseWindowByTitle(string strTitle)
        {
            bool Is = false;
            try
            {
                
                
                    foreach (var handle in Driver.WindowHandles)
                    {
                        IWebDriver popup = Driver.SwitchTo().Window(handle);
                        if (popup.Title.Trim().Equals(strTitle))
                        {
                            Is = true;
                            Driver.Close();
                            break;

                        }

                    }
                    {

                    }
               
            }
            catch (Exception)
            {

                throw;
            }
            return Is;
        }
        public void CloseChildWindow(string ParentWindow)
        {
            try
            {
                if (SwitchWindow(ParentWindow))
                {
                    foreach (var handle in Driver.WindowHandles)
                    {
                        SwitchWindow(handle);
                        if (!Driver.Title.Trim().Equals(ParentWindow))
                        {
                            Driver.Close();

                        }
                    }
                    {

                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        #endregion

        #region AlertFunctions
        public string AcceptAlertAndGetItsText()
        {
            string str = String.Empty;
            try
            {
                IAlert alert = Driver.SwitchTo().Alert();
                str=alert.Text;
                alert.Accept();
            }
            catch (Exception)
            {

                throw;
            }return str;
        }
        #endregion

        #region Mouse Hover
        public bool MouseOverOnElement(By Ele,int TimeOut = 60)
        {
            bool Is = false;
            Actions _actions=InitializeActions();
            try
            {
                WaitForPageToLoad();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                IWebElement W=LoadWebElement(Ele);
                _actions.MoveToElement(W).Build().Perform();
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }return Is;

        }
        public bool MouseOverOnElementAndClickSubElement(By Ele,By Ele2, int TimeOut = 60)
        {
            bool Is = false;
            Actions _actions = InitializeActions();
            try
            {
                WaitForPageToLoad();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                IWebElement W = LoadWebElement(Ele);
                _actions.MoveToElement(W).Perform();

                WaitForPageToLoad();
                wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele2));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele2));
                wait.Until(ExpectedConditions.ElementToBeClickable(Ele2));
                W = LoadWebElement(Ele2);
                _actions.MoveToElement(W);
                _actions.Click().Build().Perform();
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }
            return Is;

        }
        public bool MouseOverOnElementAndClick(By Ele, By Ele2, int TimeOut = 60)
        {
            bool Is = false;
            Actions _actions = InitializeActions();
            try
            {
                WaitForPageToLoad();
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Ele));
                wait.Until(ExpectedConditions.ElementIsVisible(Ele));
                wait.Until(ExpectedConditions.ElementToBeClickable(Ele));
                IWebElement W = LoadWebElement(Ele);
                _actions.MoveToElement(W);
                _actions.Click().Build().Perform();
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }
            return Is;

        }
        #endregion

        #region SnapShot
        public bool SaveSnapShot(string strPath)
        {
            bool Is = false;
            try
            {
                ((ITakesScreenshot)Driver).GetScreenshot().SaveAsFile(strPath,ScreenshotImageFormat.Png);
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        #endregion

        #region Scrolling
        public bool MovePopupScrollBasedOnElement(IWebElement Wele)
        {
            bool Is = false;
            try
            {
                JavaExecutor("arguments[0].scrollIntoView();", Wele);
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        public bool MovePopupScrollBasedOnElement(By Wele,int TimeOut=60)
        {
            bool Is = false;
            try
            {
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(TimeOut));
                wait.Until(ExpectedConditions.ElementExists(Wele));
                JavaExecutor("arguments[0].scrollIntoView();", LoadWebElement(Wele));
            }
            catch (Exception)
            {

                throw;
            }
            return Is;
        }
        public bool ScrollTillPixel(int pixel)
        {
            bool Is = false;
            try
            {
                WaitForPageToLoad();
                JavaExecutor($"window.scrollTo(0,{pixel});");
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        public bool ScrollTillBottom()
        {
            bool Is = false;
            try
            {
                JavaExecutor("window.scrollTo(0,document.body.scrollHeight-150)");
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        public bool HorizontalScrolling(By Ele,int pixel = 250)
        {
            bool Is = false;
            try
            {
                JavaExecutor("window.scrollTo(0,document.body.scrollHeight)");
                JavaExecutor($"arguments[0].scrollLeft+={pixel}", LoadWebElement(Ele));
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        #endregion

        #region KeyBoard Actions
        public bool PressArrDownKey(By Ele)
        {
            bool Is = false;
            try
            {
                LoadWebElement(Ele).SendKeys(Keys.ArrowDown);
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }return Is;
        }
        public bool PressArrUpKey(By Ele)
        {
            bool Is = false;
            try
            {
                LoadWebElement(Ele).SendKeys(Keys.ArrowUp);
                Is = true;
            }
            catch (Exception)
            {

                throw;
            }
            return Is;
        }
        #endregion

    }
}

