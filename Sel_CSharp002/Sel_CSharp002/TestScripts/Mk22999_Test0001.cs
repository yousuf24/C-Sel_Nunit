using NUnit.Framework;
using Sel_CSharp002.BaseClass;
using Sel_CSharp002.TestData.AzureAppConfig;
using Sel_CSharp002.TestData.AzureKeyVaults;

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





        }

        private void SFLoginAsSalesUser()
        {
            _seleniumHelper.OpenUrl(AppConfigData.salesforceUrl);
            string UID=KeyValutsData.sftestServiceManagerUserName;
            string Pwd = KeyValutsData.sftestServiceManagerPassword;
            System.Console.WriteLine($"UID: {UID} | Password: {Pwd}");
            
        }
    }
}
