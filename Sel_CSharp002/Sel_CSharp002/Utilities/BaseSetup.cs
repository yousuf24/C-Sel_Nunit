using NUnit.Framework;
using Sel_CSharp002.BaseClass;
using NUnit.Framework.Interfaces;
using System;
using System.IO;

namespace Sel_CSharp002.Utilities
{
    class BaseSetup:BaseSetUpCore
    {
        [SetUp]
        public void Before()
        {
            InitializeNormalBrowser();
            //InitializeHeadlessBrowser();
        }

        [TearDown]
        public void After()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Console.WriteLine("Driver resolution: " + _driver.Manage().Window.Size) ;
                Console.WriteLine("Current URL: "+_seleniumHelper.GetCurrentURL());
                CaptureSnapShot();
            }
            _seleniumHelper.DisposeDriverAlone();
            _driver = null;
            _seleniumHelper = null;
        }

        public void CaptureSnapShot()
        {
            string testName = TestContext.CurrentContext.Test.Name;
            var FilePath=AppDomain.CurrentDomain.BaseDirectory + "Reports\\Snapshots\\";
            if (!Directory.Exists(FilePath))
            {
                DirectoryInfo di = Directory.CreateDirectory(FilePath);
                Console.WriteLine($"Directory created: {FilePath}");

            }
            var FileName = FilePath + testName + ".png";
            _seleniumHelper.SaveSnapShot(FileName);
            Console.WriteLine($"Snapshot saved successfully. Full Path: {FileName}");
            TestContext.AddTestAttachment(FileName);
        }

    }
}
