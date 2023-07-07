using NUnit.Framework;
using OpenQA.Selenium;
using Sel_CSharp002.BaseClass;
using Sel_CSharp002.PageObjects.LoginPage;
using Sel_CSharp002.TestData.AzureAppConfig;
using Sel_CSharp002.TestData.AzureKeyVaults;
using SeleniumExtras.PageObjects;

namespace Sel_CSharp002.TestScripts
{
    [TestFixture]
    [Parallelizable]
    class Mk22999_Test0001 : BaseSetUpCore //BrowserUtility
    {
        [SetUp]
        public void Bm()
        {
            InitializeNormalBrowser();
            //InitializeHeadlessBrowser();
        }
        [TearDown]
        public void Am()
        {
            _seleniumHelper.DisposeDriverAlone();
            _seleniumHelper = null;
        }
        [Test]
        [Category("Mohsin dope")]
        public void Mohsin16_test()
        {
            /*SearchPage Searchpageobj = new SearchPage(driver);
            var resultPageObj= Searchpageobj.Mohsin16();
            resultPageObj.toChannel();*/
            SFLoginAsSalesUser();
            System.Console.WriteLine("Logged into SF!");




        }

        private void SFLoginAsSalesUser()
        {
            SFLoginPage _sfLoginPage = new SFLoginPage(_seleniumHelper);
            _sfLoginPage.OpenSFUrl(AppConfigData.salesforceUrl);
            _sfLoginPage.CheckedRememberMe();
            _sfLoginPage.EnterCredentialsAndClickLogin(KeyValutsData.sftestServiceManagerUserName,KeyValutsData.sftestServiceManagerPassword );



        }
    }
}
