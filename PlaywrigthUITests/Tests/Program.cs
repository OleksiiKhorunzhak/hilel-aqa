using Microsoft.Playwright;


namespace PlaywrigthUITests.Tests;

public class Program
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
        await page.GetByPlaceholder("Full Name").FillAsync("John");
        await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
    }
}