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
<<<<<<< HEAD
                Headless = false, // Set to false to run the browser in non-headless mode
				Args = new List<string> { "--start-maximized" }
			});
			var context = await browser.NewContextAsync(new BrowserNewContextOptions
			{
				ViewportSize = ViewportSize.NoViewport
			});

			Page = await context.NewPageAsync();
		}
=======
                Headless = false // Set to false to run the browser in non-headless mode
            });

            var context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,  // Set the width to a common fullscreen width
                    Height = 1080 // Set the height to a common fullscreen height
                }
            });

            Page = await context.NewPageAsync();
        }
>>>>>>> andriyMykytenkohomework20

        [OneTimeSetUp]

        [TearDown]
        public async Task Teardown()
        {
            await Page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
