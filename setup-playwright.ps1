param (
    [Parameter(Mandatory=$true)]
    [string]$ProjectName
)

if (-not $ProjectName) {
    Write-Host "Usage: .\setup-playwright.ps1 -ProjectName <YourProjectName>"
    exit
}

Write-Host "Step 1: Create a new NUnit project with the specified name"
dotnet new nunit -n $ProjectName

Write-Host "Step 2: Change directory to the newly created project folder"
cd $ProjectName

Write-Host "Step 3: Add Microsoft.Playwright.NUnit package"
dotnet add package Microsoft.Playwright.NUnit

Write-Host "Step 4: Build the project"
dotnet build

Write-Host "Step 5: Install Playwright"
./bin/Debug/net8.0/playwright.ps1 install

Write-Host "Step 6: Replace content of UnitTest1.cs with the specified text"
$unitTestPath = "UnitTest1.cs"
$fixturePath = "UITestFixture.cs"

$unitTestContent = @"
using System.Text.RegularExpressions;
using Microsoft.Playwright;

namespace $ProjectName
{
    [Parallelizable(ParallelScope.Self)]
    [TestFixture]
    public class ExampleTest : UITestFixture
    {
        [Test]
        public async Task HasTitle()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Expect a title "to contain" a substring.
            await Assertions.Expect(Page).ToHaveTitleAsync(new Regex("Playwright"));
        }

        [Test]
        public async Task GetStartedLink()
        {
            await Page.GotoAsync("https://playwright.dev");

            // Click the get started link.
            await Page.GetByRole(AriaRole.Link, new() { Name = "Get started" }).ClickAsync();

            // Expects page to have a heading with the name of Installation.
            await Assertions.Expect(Page.GetByRole(AriaRole.Heading, new() { Name = "Installation" })).ToBeVisibleAsync();
        } 
    }
}
"@

$fixtureContent = @"
using Microsoft.Playwright;

namespace $ProjectName
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
"@

Set-Content -Path $unitTestPath -Value $unitTestContent
Set-Content -Path $fixturePath -Value $fixtureContent
