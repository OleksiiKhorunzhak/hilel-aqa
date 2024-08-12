using OpenQA.Selenium;

namespace SeleniumWithApi.Pages
{
    public class MyAccountPage : BasePage
    {
        private readonly By _header = By.XPath("//h1");

        public MyAccountPage(IWebDriver driver) : base(driver)
        {
        }

        public string GetHeaderText()
        {
            return WaitForElementToBeVisible(_header).Text;
        }

    }
}
