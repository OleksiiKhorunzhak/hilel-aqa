using Microsoft.Playwright;
using System.Drawing;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQADynamicPropertiesPage
    {
        private IPage Page;
        private string DynamicPropertiesPageUrl = "https://demoqa.com/dynamic-properties";

        public DemoQADynamicPropertiesPage(IPage page)
        {
            this.Page = page;
        }

        public async Task GoToDemoQaDynamicPropertiesPage()
        {
            await Page.GotoAsync(DynamicPropertiesPageUrl);
        }

        public async Task GetColorChangeColor(string expectedColor)
        {
            var colorElement = Page.Locator("#colorChange");
            var color = await colorElement.EvaluateAsync<string>("element => getComputedStyle(element).color");

            Assert.That(color, Is.EqualTo(expectedColor));
        }
    }
}
