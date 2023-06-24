using OpenQA.Selenium;
using Sel_CSharp002.BaseClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.PageObjects.LoginPage
{
    public class SFLoginPage
    {
        private SeleniumHelper _seleniumHelper;
        #region Constructor
        public SFLoginPage(SeleniumHelper _sh)
        {
            _seleniumHelper = _sh;
            
        }
        #endregion

        #region pageElements
        By tbUserName = By.Id("username");
        By tbpassword = By.Id("password");
        By btnLogin = By.XPath("//input[@type='submit']");
        By btnRememberMe = By.XPath("//*[@id='rememberUn']");
        By btnAzureADO = By.XPath("//button[contains(.,'Azure AD SSO')]");
        By tbEmail = By.XPath("//input[@type='email']");

        
        By btnSignIn = By.XPath("input[@type='submit' and @value='Sign in']");


        #endregion

        #region pageActions
        public void OpenSFUrl(string Url)
        {
            _seleniumHelper.OpenUrl(Url);
            MethodBase _methodB = MethodBase.GetCurrentMethod();
            Console.WriteLine($"executed {_methodB.ReflectedType.Name}.{_methodB.Name}");
        }
        public void EnterCredentialsAndClickLogin(string U,string P)
        {
            _seleniumHelper.WaitForPageToLoad();
            _seleniumHelper.WaitTillVisible(tbUserName);
            _seleniumHelper.TextEnter(tbUserName, U);
            _seleniumHelper.TextEnter(tbpassword, P);
            _seleniumHelper.Click(btnLogin);
        }
        public void CheckedRememberMe()
        {
            _seleniumHelper.WaitTillClickable(btnRememberMe);
            _seleniumHelper.Click(btnRememberMe);
        }
        public void ClickOnAzureADOBtn()
        {
            _seleniumHelper.WaitTillClickable(btnAzureADO);
            _seleniumHelper.Click(btnAzureADO);
        }
        #endregion
    }
}

