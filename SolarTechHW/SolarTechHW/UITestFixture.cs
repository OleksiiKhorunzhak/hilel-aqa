using Microsoft.Playwright;

namespace UiTestFixture
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    internal class UITestFixture
    {
        public static IBrowserContext Context { get; private set; }
        public IPage Page { get; private set; }
        private IBrowser browser;

        [SetUp]
        public async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to false to run the browser in non-headless mode
            });

            Context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,  // Set the width to a common fullscreen width
                    Height = 1080 // Set the height to a common fullscreen height
                }
            });
            await Context.Tracing.StartAsync(new()
            {
                Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
                Screenshots = true,
                Snapshots = true,
                Sources = true
            });
            Page = await Context.NewPageAsync();

        }

        [TearDown]
        public async Task Teardown()
        {
           

            var failed = TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Error
            || TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Failure;

            await Context.Tracing.StopAsync(new()
            {
                Path = failed ? Path.Combine(
                    TestContext.CurrentContext.WorkDirectory,
                    "playwright-traces",
                    $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}.zip"
                ) : null,
            });
            await Page.CloseAsync();
            await browser.CloseAsync();
        }
    }
}
