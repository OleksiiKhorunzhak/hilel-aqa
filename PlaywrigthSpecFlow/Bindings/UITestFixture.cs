using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrigthSpecFlow.Bindings
{
    [Parallelizable(ParallelScope.Self)]
    //[TestFixture]
    [Binding]
    internal class UITestFixture
    {
        public static IPage? page { get; private set; }
        private static IBrowser? browser;

        //[SetUp]
        [BeforeFeature(Order = 1)]
        public static async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to false to run the browser in non-headless mode
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1890,  // Set the width to a common fullscreen width
                    Height = 945 // Set the height to a common fullscreen height
                }
            });

            page = await context.NewPageAsync();
        }

        [AfterFeature]
        public static async Task Teardown()
        {
            if (page != null)
            {
                await page.CloseAsync();
            }

            if (browser != null)
            {
                await browser.CloseAsync();
            }
        }
    }
}
