using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace SeleniumCSharp
{
    [TestFixture]
    class SeleniumCSharpTutorial04
    {
        private static IEnumerable<TestCaseData> DataDrivenLoginTesting
        {
            get
            {
                yield return new TestCaseData("https://facebook.com/", "id", "email");
                yield return new TestCaseData("https://poczta.interia.pl/logowanie/", "id", "email");
                yield return new TestCaseData("https://e.wsei.edu.pl/login/index.php/", "id", "username");
            }
        }

        [Test]
        [Author("Dawid", "dawid.malarz@microsoft.wsei.edu.pl")]
        [Description("Login field Verify")]
        [TestCaseSource("DataDrivenLoginTesting")]
        public void TestLoginFields(string urlName, string IdName, string IdValue)
        {
            IWebDriver driver = null;
            try
            {
                driver = new ChromeDriver();
                //driver.Manage().Window.Maximize();
                driver.Url = urlName;

                var path = $".//*[@{IdName}='{IdValue}']";
                IWebElement loginTextField = driver.FindElement(By.XPath(path));

                loginTextField.SendKeys("Selenium C#");
                driver.Quit();
            }
            catch (Exception e)
            {
                // If it fails take a screen shot  

                ITakesScreenshot ts = driver as ITakesScreenshot;
                Screenshot screenshot = ts.GetScreenshot();

                var path = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
                string fullPath = Path.GetFullPath(Path.Combine(path, @"..\..\Screenshots\Screenshot1.jpeg"));

                screenshot.SaveAsFile(fullPath, ScreenshotImageFormat.Jpeg);

                Console.WriteLine(e.StackTrace);

                throw;
            }
            finally
            {
                if (driver != null)
                {
                    driver.Quit();
                }
            }
        }
    }
}
