using Microsoft.Playwright;
using TechTalk.SpecFlow;
using PlaywrightSpecFlow.PageObjects;
using PlaywrigthSpecFlow.Bindings;

namespace PlaywrigthSpecFlow.Features
{
    [Binding]
    internal sealed class WebTableSteps : UITestFixture
    {
        internal static DemoQAWebTablesPage DemoQAWebTablesPage;

        [BeforeFeature(Order = 2)]
        public static async Task FirstBeforeScenario()
        {
            DemoQAWebTablesPage = new DemoQAWebTablesPage(Page);
        }

        [Given(@"I am on DemoQA WebTable Page")]
        public async Task WhenIOpenWebTablePage() => 
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();

        [When(@"I see the WebTable")]
        public async Task WhenISeeTheWebTable() =>
            await DemoQAWebTablesPage.VerifyTableVisible();

        [When(@"I click Add Button")]
        public async Task WhenIKlickAddButton() =>
             await DemoQAWebTablesPage.IClickAddButton();


        [When(@"I set FirstName to ""(.*)""")]
        public async Task WhenISetFirstName(string firstName) =>
           await DemoQAWebTablesPage.IFillFirstName(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public async Task WhenISetLastName(string lastName) =>
             await DemoQAWebTablesPage.IFillLastName(lastName);

        [Then(@"I see FirstName ""(.*)"" in a table")]
        public async Task ThenISeeFirstName(string firstName) => 
            await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = firstName, Exact = true })).ToBeVisibleAsync();

        [Then(@"I see LastName ""(.*)"" in a table")]
        public async Task ThenISeeLastName(string lastName) =>
          await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = lastName, Exact = true })).ToBeVisibleAsync();


    }
}