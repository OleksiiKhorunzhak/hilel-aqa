using Microsoft.Playwright;
using System;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    [Description("Verify Buttons on buttons page")]
    class ButtonsTests
    {
        [Test]
        [Description("Verify Buttons on buttons page")]
        public async Task ClickButtonTest()
        {
            // Background
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            //Given I go to DemoQa Elements page 
            await page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            await page.GetByRole(AriaRole.Button, new() { NameString = "Click Me" }).ClickAsync();
            // Then  I see "You have done a dynamic click" text.
            var isVisible = await page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.IsTrue(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.IsFalse(isNotVisible, "The element with text 'You have done a double click' should NOT be visible after clicking the button.");
        }

        [Test]
        public async Task DoubleClickButtonTest()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            //Given I go to DemoQA Elements page 
            await page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I double click the 'Double Click Me' button
            await page.GetByRole(AriaRole.Button, new() { NameString = "Double Click Me" }).DblClickAsync();
            // Then I see "You have done a double click" text.
            var isVisible = await page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.IsTrue(isVisible, "The element with text 'You have done a double click' should be visible after clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.IsFalse(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");
        }

        [Test]
        public async Task RigthClickButtonTest()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();
            var page = await context.NewPageAsync();
            //Given I go to DemoQA Elements page 
            await page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I Rigth click the 'Right Click Me' button
            await page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            // Then I see "You have done a right click" text.
            var isVisible = await page.GetByText("You have done a right click").IsVisibleAsync();
            Assert.IsTrue(isVisible, "The element with text 'You have done a double click' should be visible after Rigth clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.IsFalse(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after Rigth clicking the button.");
        }
    }
}