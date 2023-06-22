using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumCSharp.BaseClass;

namespace SeleniumCSharp
{
    [TestFixture]
    public class TestClass : BaseTest
    {
        [Test, Category("Smoke Testing")]
        public void TestMethod1()
        {
            // Accept cookie
            IWebElement cookiesAcceptButton = driver.FindElement(By.XPath(".//*[@data-cookiebanner='accept_button']"));
            cookiesAcceptButton.Click();

            // Enter password
            IWebElement passwordField = driver.FindElement(By.XPath(".//*[@id='pass']"));
            passwordField.SendKeys("SeleniumCsharpPassword");
            Thread.Sleep(2000);

        }

        [Test, Category("Regression Testing")]
        public void TestMethod2()
        {
            IWebElement cookiesAcceptButton = driver.FindElement(By.XPath(".//*[@data-cookiebanner='accept_button']"));
            cookiesAcceptButton.Click();

            // Create account
            IWebElement newAccountButton = driver.FindElement(By.XPath(".//*[@data-testid='open-registration-form-button']"));
            newAccountButton.SendKeys(Keys.Enter);
            Thread.Sleep(2000);

            // Pick day
            IWebElement dayDropdownList = driver.FindElement(By.XPath(".//*[@id='day']"));
            SelectElement element = new SelectElement(dayDropdownList);
            element.SelectByIndex(2);
            element.SelectByValue("16");
            Thread.Sleep(2000);

        }

        [Test, Category("Smoke Testing")]
        public void TestMethod3()
        {
            // Enter email
            IWebElement emailTextField = driver.FindElement(By.XPath(".//*[@id='email']"));
            emailTextField.SendKeys("Selenium C#");
            Thread.Sleep(2000);
        }
    }
}
