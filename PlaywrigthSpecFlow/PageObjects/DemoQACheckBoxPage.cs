using Microsoft.Playwright;

namespace PlaywrigthSpecFlow.PageObjects
{
    internal class DemoQACheckBoxPage
    {
        private readonly IPage page;
        private readonly string CheckBoxPageUrl = "https://demoqa.com/checkbox";

        public DemoQACheckBoxPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToDemoQaChecboxPage()
        {
            await page.GotoAsync(CheckBoxPageUrl);
        }

        public async Task CheckHomeCheckbox()
        {
            await page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
        }

        public async Task CheckCheckbox(string branch)
        {
            await page.Locator("label").Filter(new() { HasTextString = branch }).GetByRole(AriaRole.Img).First.ClickAsync();
        }

        public async Task OpenHome()
        {
            await page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task VerifyHomeChecked()
        {
            await Assertions.Expect(page.Locator("#tree-node path").Nth(3)).ToBeCheckedAsync();
        }

        public async Task<bool> VerifyCheckboxChecked(string branch)
        {
            // Locate `span` element containing the branch title
            var spanElement = page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}'))");
            // Locate the checkbox in `span` element
            var checkboxLocator = spanElement.Locator(".rct-icon-check");
            // Check if the checkbox is visible
            var checkboxVisible = await checkboxLocator.IsVisibleAsync();
            return checkboxVisible;
        }
    }
}
