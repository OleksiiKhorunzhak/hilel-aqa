using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    public class UITestFixture
    {
        public IPage Page { get; private set; }
        private IBrowser browser;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,
                    Height = 1080
                }
            });

            Page = await context.NewPageAsync();
        }

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
