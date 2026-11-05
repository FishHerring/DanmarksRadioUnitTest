
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using System.Threading;

namespace DanmarksRadioUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void TestAddRecord()
        {
            using IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("file:///c%3A/Users/johnb/Downloads/DanmarksRadioFrontend-main/DanmarksRadioFrontend/frontend/index.html");

            Thread.Sleep(2000);

            // Click Get All Records
            driver.FindElement(By.Id("getAllButton")).Click();

            Thread.Sleep(2000);

            // Check that there are 4 records
            Assert.Equal(4,
                driver.FindElements(By.CssSelector("#recordlist li")).Count);

            // Add a new record
            driver.FindElement(By.Id("addTitleInput")).SendKeys("XUnitTest");
            driver.FindElement(By.Id("addArtistInput")).SendKeys("Test Artist");
            driver.FindElement(By.Id("addPublicationYearInput")).SendKeys("2018");
            driver.FindElement(By.Id("addDurationInput")).SendKeys("180");

            // Click Add
            driver.FindElement(By.Id("addButton")).Click();

            Thread.Sleep(2000);

            // Check that there are now 5 records
            Assert.Equal(5,
                driver.FindElements(By.CssSelector("#recordlist li")).Count);

            // Check that XUnitTest was added
            Assert.Contains("XUnitTest",
                driver.FindElement(By.Id("recordlist")).Text);
        }
    }
}
