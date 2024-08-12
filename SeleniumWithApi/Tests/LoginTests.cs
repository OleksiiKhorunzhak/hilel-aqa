using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumWithApi.Helpers;
using SeleniumWithApi.Pages;
using System.Text;

namespace SeleniumWithApi.Tests
{
    [TestFixture]
    public class LoginTests
    {
        private IWebDriver _driver;
        private LoginPage _loginPage;
        private HomePage _homePage;
        private MyAccountPage _myAccountPage;
        private RestApiHelper _apiHelper;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://demo.evershop.io/account/login");

            _loginPage = new LoginPage(_driver);
            _homePage = new HomePage(_driver);
            _myAccountPage = new MyAccountPage(_driver);

            _apiHelper = new RestApiHelper();
        }

        [Test]
        public async Task LoginViaUI()
        {
            
            _loginPage.EnterUsername("apitestuser001@qqadczxzf.qwe");
            _loginPage.EnterPassword("apitestuser001");
            _loginPage.ClickLogin();
            _homePage.OpenMyAccount();
            
            var pageTitle = _myAccountPage.GetHeaderText();

            Assert.That(pageTitle, Is.EqualTo("My Account"));
        }
        
        [Test]
        public async Task LoginViaAPI()
        {
            // Example of sending a POST request
            var content = new StringContent("{\"email\":\"apitestuser001@qqadczxzf.qwe\", \"password\":\"apitestuser001\"}", Encoding.UTF8, "application/json");
            var response = await _apiHelper.SendPostRequestAsync("https://demo.evershop.io/customer/login", content);

            // Reading Set-Cookie header from the response
            var setCookieHeader = _apiHelper.GetSetCookieHeader(response);

            Assert.IsNotNull(setCookieHeader, "Set-Cookie header should not be null.");

            // Set cookies in the browser
            _apiHelper.SetCookiesInBrowser(_driver, new Uri("https://demo.evershop.io"));

            // Navigate to a URL
            _driver.Navigate().GoToUrl("https://demo.evershop.io");

            _homePage.OpenMyAccount();
            
            var pageTitle = _myAccountPage.GetHeaderText();

            Assert.That(pageTitle, Is.EqualTo("My Account"));
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
