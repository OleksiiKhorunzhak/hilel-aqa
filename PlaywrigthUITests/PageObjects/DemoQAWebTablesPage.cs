using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQAWebTablesPage
    {
        private IPage _page;
        private string WebTablePageUrl = "https://demoqa.com/webtables";

        public DemoQAWebTablesPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToDemoQaWebTablesPage()
        {
            await _page.GotoAsync(WebTablePageUrl);
        }

        public async Task CheckTableVisible()
        {
            await _page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
        }

       
    }
}
