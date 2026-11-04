using System;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;

namespace DanmarksRadioUnitTest
{
    public class UnitTest1 : IDisposable
    {
        private readonly IWebDriver _driver;

        public UnitTest1()
        {
            //string driverDirectory = @"C:\webDriver";
            _driver = new ChromeDriver(/*driverDirectory*/);

            Thread.Sleep(2000);
        }

        [Fact]
        public void AddRecord_ShowsInTable()
        {
            string url = "file:///c%3A/Users/johnb/Downloads/DanmarksRadioFrontend-main/DanmarksRadioFrontend/frontend/index.html";
            _driver.Navigate().GoToUrl(url);

            Thread.Sleep(2000);

            _driver.FindElement(
                By.CssSelector("input[placeholder='Title']")
            ).SendKeys("Test Song");

            _driver.FindElement(
                By.CssSelector("input[placeholder='Artist']")
            ).SendKeys("Test Artist");

            _driver.FindElement(
                By.XPath("//button[normalize-space(.)='Add Record']")
            ).Click();

            Thread.Sleep(2000);

            _driver.FindElement(
                By.XPath("//button[normalize-space(.)='Get All Records']")
            ).Click();

            Thread.Sleep(5000);

            Assert.Contains("Test Song",
                _driver.FindElement(By.TagName("tbody")).Text);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }
    }
}