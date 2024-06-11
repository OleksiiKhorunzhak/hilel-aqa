using Microsoft.Playwright;

namespace PlaywrigthUITests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class UITestFixture
    {
        public IPage Page { get; private set; }
        private IBrowser browser;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, // Set to false to run the browser in non-headless mode
                Channel = "chrome",
                Args = new List<string> { "--start-maximized", "--window-position=0,0", /*"--window-size=1920,1080"*/ }
            });
            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize { Width = 1900, Height = 970 },
                // Alternatively, you can fetch the actual screen size dynamically.
                // However, in Playwright, the viewport size setting is more reliable.
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
