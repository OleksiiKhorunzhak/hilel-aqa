using Microsoft.Playwright;
using System;
using TechTalk.SpecFlow;

namespace PlaywrigthSpecFlow.Bindings
{
    [Parallelizable(ParallelScope.Self)]
    //[TestFixture]
    [Binding]
    internal class UITestFixture
    {
        public static IPage? Page { get; private set; }
        private static IBrowser? browser;
        private static IBrowserContext context;

        //[SetUp]
        [BeforeFeature(Order = 1)]
        public static async Task Setup()
        {
            var playwrightDriver = await Playwright.CreateAsync();
            browser = await playwrightDriver.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false // Set to false to run the browser in non-headless mode
            });

            context = await browser.NewContextAsync(new BrowserNewContextOptions
            {
                ViewportSize = new ViewportSize
                {
                    Width = 1920,  // Set the width to a common fullscreen width
                    Height = 1080 // Set the height to a common fullscreen height
                }
			});

			await context.Tracing.StartAsync(new()
			{
				Title = $"{TestContext.CurrentContext.Test.ClassName}.{TestContext.CurrentContext.Test.Name}",
				Screenshots = true,
				Snapshots = true,
				Sources = true
			});

			Page = await context.NewPageAsync();
        }

        [AfterFeature]
        public static async Task Teardown()
        {
			var failed = TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Error
						|| TestContext.CurrentContext.Result.Outcome == NUnit.Framework.Interfaces.ResultState.Failure;

			await context.Tracing.StopAsync(new()
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
