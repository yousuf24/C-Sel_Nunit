using NUnit.Framework;
using OpenQA.Selenium;
using Sel_CSharp002.Utilities;
using SeleniumExtras.PageObjects;
using System;

namespace Sel_CSharp002.TestScripts
{
    [TestFixture]
    [Parallelizable]
    class NT_InterviewMock:BaseSetup
    {
        [Test][Ignore("--")]
        public void ExecuteB2B()
        {
            By byLF = By.XPath("(//a[text()=\"Ladies' Fingers (Loose)\"]/ancestor::div[@qa='product_name']/following-sibling::div//button[text()='Add '])[last()]");
            _seleniumHelper.OpenUrl("https://www.bigbasket.com/");
            _seleniumHelper.WaitForPageToLoad();
            _seleniumHelper.WaitTillExists(byLF);
            Console.WriteLine("Ladies finger is found");
            _seleniumHelper.LoadElementBy(How.XPath,"");

        }
        [Test]
        public void ExecuteSample()
        {
            string strCardType = "", strCardNumber = "345657";
            switch (strCardNumber)
            {
                case "4[\\d]+":
                    strCardType = "Visa"; break;
                case "5[\\d]+":
                    strCardType = "Mastercard"; break;
                case "3[\\d]+":
                    strCardType = "American Express"; break;
                case "6[\\d]+":
                    strCardType = "Discover"; break;
            }
            Console.WriteLine("CardType: " + strCardType);
        }

    }
}
