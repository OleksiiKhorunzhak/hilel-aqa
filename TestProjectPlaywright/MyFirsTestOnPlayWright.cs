using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProjectPlaywright
{
    internal class MyFirsTestOnPlayWright
    {
        [Test]
        public static async Task Main()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
            });
            var context = await browser.NewContextAsync();

            var page = await context.NewPageAsync();
            await page.GotoAsync("https://demoqa.com/");
            await page.GetByRole(AriaRole.Heading, new() { Name = "Elements" }).ClickAsync();
            await page.GetByText("Text Box").ClickAsync();
            await page.GetByPlaceholder("Full Name").ClickAsync();
            await page.GetByPlaceholder("Full Name").FillAsync("test name");
            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        }
    }
}
