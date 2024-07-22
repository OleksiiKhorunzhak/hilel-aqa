using Microsoft.Playwright;

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

        public async Task GetColorChange(string expectedColor)
        {
            var colorElement = Page.Locator("#colorChange");
            var color = await colorElement.EvaluateAsync<string>("element => getComputedStyle(element).color");

            Assert.That(color, Is.EqualTo(expectedColor));
        }

        public async Task ShoudBeEnabledAfter5sec()
        {
            var button = Page.Locator("#enableAfter");
            await Assertions.Expect(button).ToBeDisabledAsync();
           
            await Task.Delay(5000);
            await Assertions.Expect(button).ToBeEnabledAsync();
        }

        public async Task ShouldBeVisibleAfter5sec()
        {
            var button = Page.Locator("#visibleAfter");
            //var button = Page.GetByRole(AriaRole.Button, new() { Name = "Visible After 5 Seconds" });
            await Assertions.Expect(button).ToBeHiddenAsync();

            await Assertions.Expect(button).ToBeEnabledAsync();
        }
    }
}