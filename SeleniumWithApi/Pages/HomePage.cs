using OpenQA.Selenium;

namespace SeleniumWithApi.Pages
{
    public class HomePage : BasePage
    {
        private readonly By _menMenu = By.XPath("//*[@href='/men']");
        private readonly By _myAccount = By.XPath("//*[@href='/account']");

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public bool IsMenMenuVisible()
        {
            return WaitForElementToBeVisible(_menMenu).Displayed;
        }

        public void OpenMyAccount()
        {
            ClickElement(_myAccount);
        }
    }
}
