using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
    internal class DynamicPropertiesPage(IPage page)
    {
        private readonly IPage page = page;

        //page:
        public async Task GoToURL(string testPageUrl)
        {
            await page.GotoAsync(testPageUrl);
            await page.WaitForURLAsync(testPageUrl);
        }

        public async Task IsPageH1Visible(string pageH1)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = pageH1 })).ToBeVisibleAsync();
        }


        public async Task GetColorChangeChangeColor(string expectedColor)
        {
            var colorElement = page.Locator("#colorChange");
            var color = await colorElement.EvaluateAsync<string>("element => getComputedStyle(element).color");

            Assert.That(color, Is.EqualTo(expectedColor));
        }

        public async Task EnableAfter5sec()
        {
            var button = page.GetByRole(AriaRole.Button, new() { Name = "Will enable 5 seconds" });
            await Assertions.Expect(button).ToBeDisabledAsync();
            //await button.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible, Timeout = 2000 });
            await Task.Delay(5000);
            await Assertions.Expect(button).ToBeEnabledAsync();
        }

        public async Task VisibleAfter5sec()
        {
            var button = page.GetByRole(AriaRole.Button, new() { Name = "Visible After 5 Seconds" });
            await button.ClickAsync();
            await Assertions.Expect(button).ToBeFocusedAsync();
        }
    }
}
