using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DanmarksRadioUnitTest
{
    public class UnitTest1 : IDisposable
    {
        private static readonly string DriverDirectory = "C:\\WebDriver";
        // Download drivers to your driver folder.
        // Driver version must match your browser version.
        // http://chromedriver.chromium.org/downloads
        private static IWebDriver _driver;

        public UnitTest1()
        {
            //string driverDirectory = @"C:\WebDriver";
            _driver = new ChromeDriver(DriverDirectory);
        }

        [Fact]
        public void Test1()
        {
            _driver.Navigate().GoToUrl("file:///C:/Users/nadia/Documents/Programmering/Programmering3/JavaScript/DanmarksRadioFront/index.html");

            Assert.Equal("Danmarks Radio", _driver.Title);

            IWebElement buttonElement = _driver.FindElement(By.Id("getAllButton"));
            buttonElement.Click();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement recordList = wait.Until(d => d.FindElement(By.Id("recordlist")));
            Assert.Contains("Bohemian Rhapsody", recordList.Text);

            ReadOnlyCollection<IWebElement> listElements = recordList.FindElements(By.TagName("li"));
            Assert.Equal(4, listElements.Count);
            Assert.Contains("Bohemian Rhapsody", listElements[0].Text);

            _driver.FindElement(By.Id("addTitleInput")).SendKeys("Audio");
            _driver.FindElement(By.Id("addArtistInput")).SendKeys("LSD");
            _driver.FindElement(By.Id("addYearInput")).SendKeys("2018");
            _driver.FindElement(By.Id("addButton")).Click();

            wait.Until(d => d.FindElement(By.Id("recordlist")).Text.Contains("Audio"));

            ReadOnlyCollection<IWebElement> updatedElements = _driver.FindElements(By.TagName("li"));
            Assert.Equal(5, updatedElements.Count);

            Thread.Sleep(2000);
        }

        public void Dispose()
        {
            _driver.Dispose();
        }

    }
}