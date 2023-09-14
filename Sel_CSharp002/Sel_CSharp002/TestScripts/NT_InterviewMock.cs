using NUnit.Framework;
using OpenQA.Selenium;
using Sel_CSharp002.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sel_CSharp002.TestScripts
{
    [TestFixture]
    [Parallelizable]
    class NT_InterviewMock:BaseSetup
    {
        [Test]
        public void ExecuteB2B()
        {
            By byLF = By.XPath("(//a[text()=\"Ladies' Fingers (Loose)\"]/ancestor::div[@qa='product_name']/following-sibling::div//button[text()='Add '])[last()]");
            _seleniumHelper.OpenUrl("https://www.bigbasket.com/");
            _seleniumHelper.WaitForPageToLoad();
            _seleniumHelper.WaitTillExists(byLF);
            Console.WriteLine("Ladies finger is found");

        }

    }
}
