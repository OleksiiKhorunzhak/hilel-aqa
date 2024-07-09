using Microsoft.Playwright;
using TechTalk.SpecFlow;
using PlaywrightSpecFlow.PageObjects;
using PlaywrigthSpecFlow.Bindings;

namespace PlaywrigthSpecFlow.Features.WebTable
{
    [Binding]
    internal sealed class WebTableSteps : UITestFixture
    {
        public static DemoQAWebTablesPage _WebTablesPage;

        [BeforeFeature("@WebPageLogin")]
        public static async Task FirstBeforeScenario()
        {
            _WebTablesPage = new DemoQAWebTablesPage(page);
        }

        [Given(@"I am on DemoQA WebTable Page")]
        public async Task WhenIOpenWebTablePage() => await _WebTablesPage.GoToDemoQaWebTablesPage();

        [When(@"I see the WebTable")]
        public async Task WhenISeeTheWebTable() => await _WebTablesPage.VerifyTableVisible();

        [When(@"I click Add Button")]
        public async Task WhenIKlickAddButton() => await _WebTablesPage.IClickAddButton();

        [When(@"I set FirstName to ""(.*)""")]
        public async Task WhenISetFirstName(string firstName) =>
           await _WebTablesPage.IFillFirstName(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public async Task WhenISetLastName(string lastName) =>
             await _WebTablesPage.IFillLastName(lastName);

        [Then(@"I see FirstName ""(.*)"" in a table")]
        public async Task ThenISeeFirstName(string firstName) =>
            await Assertions.Expect(page.GetByRole(AriaRole.Gridcell, new() { Name = firstName, Exact = true })).ToBeVisibleAsync();

        [When(@"I set Email ""(.*)"" in a table")]
        public async Task ThenISetEmail(string email)
        {
            await page.GetByPlaceholder("name@example.com").FillAsync(email);
            await page.GetByPlaceholder("name@example.com").PressAsync("Enter");
        }

        [Then(@"I see LastName ""(.*)"" in a table")]
        public async Task ThenISeeLastName(string lastName) =>
          await Assertions.Expect(page.GetByRole(AriaRole.Gridcell, new() { Name = lastName, Exact = true })).ToBeVisibleAsync();
    }
}