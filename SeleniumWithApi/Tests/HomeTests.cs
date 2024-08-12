using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWithApi.Pages;

namespace SeleniumWithApi.Tests
{
    [TestFixture]
    public class HomeTests
    {
        private IWebDriver _driver;
        private HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://demo.evershop.io/");

            _homePage = new HomePage(_driver);
        }

        [Test]
        public void VerifyMenMenuIsVisibleTest()
        {
            Assert.IsTrue(_homePage.IsMenMenuVisible(), "Men menu should be visible on the home page.");
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
