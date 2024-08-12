using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumWithApi.Pages
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        public BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // Common method for waiting for an element to be visible
        protected IWebElement WaitForElementToBeVisible(By locator)
        {
            return Wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
        }

        // Common method for clicking an element
        protected void ClickElement(By locator)
        {
            WaitForElementToBeVisible(locator).Click();
        }

        // Common method for entering text
        protected void EnterText(By locator, string text)
        {
            var element = WaitForElementToBeVisible(locator);
            element.Clear();
            element.SendKeys(text);
        }

        // Common method to navigate to a specific URL
        public void NavigateTo(string url)
        {
            Driver.Navigate().GoToUrl(url);
        }

        // Common method to get the current page title
        public string GetPageTitle()
        {
            return Driver.Title;
        }

        // Common method for taking a screenshot
        public void TakeScreenshot(string filePath)
        {
            Screenshot screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
            screenshot.SaveAsFile(filePath);
        }
    }
}
