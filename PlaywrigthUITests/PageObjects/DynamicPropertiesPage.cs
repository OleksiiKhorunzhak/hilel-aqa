using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
    internal class DynamicPropertiesPage
    {
        private readonly IPage Page;
        private readonly string testPageUrl = "https://demoqa.com/dynamic-properties";

        public DynamicPropertiesPage(IPage page)
        {
            this.Page = page;
        }

        public async Task GoToDynamicPropertiesPage()
        {
            await Page.GotoAsync(testPageUrl);
        }

        public async Task GetColorChangeChangeColor(string expectedColor)
        {
            var colorElement = Page.Locator("#colorChange");
            var color = await colorElement.EvaluateAsync<string>("element => getComputedStyle(element).color");

            Assert.That(color, Is.EqualTo(expectedColor));
        }

        public async Task EnableAfter5sec()
        {
            var button = Page.GetByRole(AriaRole.Button, new() { Name = "Will enable 5 seconds" });
            await Assertions.Expect(button).ToBeDisabledAsync();
            //await button.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 2000 });
            await Task.Delay(5000);
            await Assertions.Expect(button).ToBeEnabledAsync();
        }

        public async Task VisibleAfter5sec()
        {
            var button = Page.GetByRole(AriaRole.Button, new() { Name = "Visible After 5 Seconds" });
            await button.ClickAsync();
            await Assertions.Expect(button).ToBeFocusedAsync();
        }
    }
}
