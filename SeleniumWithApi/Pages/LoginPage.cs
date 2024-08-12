using OpenQA.Selenium;

namespace SeleniumWithApi.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameField = By.XPath("//*[@placeholder='Email']");
        private readonly By _passwordField = By.XPath("//*[@placeholder='Password']");
        private readonly By _loginButton = By.XPath("//*[@type='submit']");
        public LoginPage(IWebDriver driver) : base(driver)
        { }

        public void EnterUsername(string username)
        {
            EnterText(_usernameField, username);
        }

        public void EnterPassword(string password)
        {
            EnterText(_passwordField, password);
        }

        public void ClickLogin()
        {
            ClickElement(_loginButton);
        }
    }
    
}
