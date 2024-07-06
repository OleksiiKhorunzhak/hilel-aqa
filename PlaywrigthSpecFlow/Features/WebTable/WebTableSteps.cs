using Microsoft.Playwright;
using TechTalk.SpecFlow;
using PlaywrightSpecFlow.PageObjects;
using PlaywrigthSpecFlow.Bindings;
using static System.Net.Mime.MediaTypeNames;
using System.Runtime.CompilerServices;

namespace PlaywrigthSpecFlow.Features.WebTable
{
    [Binding]
    internal sealed class WebTableSteps : UITestFixture
    {
        internal static DemoQAWebTablesPage DemoQAWebTablesPage;

        [BeforeFeature("@WebPageLogin")]
        public static async Task FirstBeforeScenario()
        {
            DemoQAWebTablesPage = new DemoQAWebTablesPage(Page);
        }

        [Given(@"I am on DemoQA WebTable Page")]
        public async Task WhenIOpenWebTablePage() => await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();

        [When(@"I see the WebTable")]
        public async Task WhenISeeTheWebTable() => await DemoQAWebTablesPage.VerifyTableVisible();

        [When(@"I click Add Button")]
        public async Task WhenIKlickAddButton() => await DemoQAWebTablesPage.IClickAddButton();

        [When(@"I click Submit Button")]
        public async Task WhenIClickSubmitButton() => await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        [When(@"I set FirstName to ""(.*)""")]
        public async Task WhenISetFirstName(string firstName) =>
           await DemoQAWebTablesPage.IFillFirstName(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public async Task WhenISetLastName(string lastName) =>
             await DemoQAWebTablesPage.IFillLastName(lastName);

        [Then(@"I see FirstName ""(.*)"" in a table")]
        public async Task ThenISeeFirstName(string firstName) =>
            await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = $"{firstName}", Exact = true })).ToBeVisibleAsync();

        [When(@"I set Email ""(.*)""")]
        public async Task ThenISetEmail(string email)
        {
            await Page.GetByPlaceholder("name@example.com").FillAsync(email);
            await Page.GetByPlaceholder("name@example.com").PressAsync("Enter");
        }

        [When(@"I set Age ""(.*)""")]
        public async Task ThenISetAge(int age)
        {
            await Page.GetByPlaceholder("Age").FillAsync(age.ToString());
        }

        [When(@"I set Salary ""(.*)""")]
        public async Task ThenISetSalary(int salary)
        {
            await Page.GetByPlaceholder("Salary").FillAsync(salary.ToString());
        }

        [When(@"I set Department ""(.*)""")]
        public async Task ThenISetDepartment(string department)
        {
            await Page.GetByPlaceholder("Department").FillAsync(department);
        }

        [Then(@"I see LastName ""(.*)"" in a table")]
        public async Task ThenISeeLastName(string lastName) =>
          await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = lastName, Exact = true })).ToBeVisibleAsync();

        [When(@"I click Edite button ""(.*)""")]
        public async Task ThenIClickOnEditButton(int id)
        {
            string idString = id.ToString();

            await Page.Locator($"#edit-record-{idString} path").ClickAsync();
        }

        [When(@"I click Delete button ""(.*)""")]
        public async Task ClickDeleteIconWithId(int id)
        {
            string idString = id.ToString();
            await Page.Locator($"#delete-record-{idString} path").ClickAsync();
        }

        [Then(@"I do not see deleted Row ""(.*)"" in a table")]
        public async Task VerifyNewRowIsNotVisible(int id)
        {
            string idString = id.ToString();
            var deletedRowLocator = Page.Locator($"#delete-record-{idString}");
            await Assertions.Expect(deletedRowLocator).Not.ToBeVisibleAsync();
        }

        [Then(@"I see new Row added ""(.*)"" in a table")]
          public async Task VerifyNewRowIsAdded(int id)
        {
            await Page.Locator($"rt-tr -padRow -even-{id} path").IsVisibleAsync();
        }
    }

}
