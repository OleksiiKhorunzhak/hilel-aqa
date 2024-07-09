using Microsoft.Playwright;
using TechTalk.SpecFlow;
using PlaywrightSpecFlow.PageObjects;
using PlaywrigthSpecFlow.Bindings;

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

		[Then(@"I see Email ""(.*)"" in a table")]
		public async Task ThenISeeEmail(string email) =>
			await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = email, Exact = true })).ToBeVisibleAsync();

		[Then(@"I see Age ""(.*)"" in a table")]
		public async Task ThenISeeAge(string age) =>
			await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = age, Exact = true })).ToBeVisibleAsync();

		[Then(@"I see Salary ""(.*)"" in a table")]
		public async Task ThenISeeSalary(string salary) =>
			await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = salary, Exact = true })).ToBeVisibleAsync();

		[Then(@"I see Department ""(.*)"" in a table")]
		public async Task ThenISeeDepartment(string department) =>
			await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = department, Exact = true })).ToBeVisibleAsync();

		[When(@"I set Email ""(.*)"" in a table")]
        public async Task ThenISetEmail(string email) =>
            await DemoQAWebTablesPage.IFillEmail(email);

		[When(@"I set Age (.*) in a table")]
		public async Task WhenISetAgeInATable(int p0) =>
			await DemoQAWebTablesPage.IFillAge(p0);

        [When(@"I set Salary (.*) in a table")]
        public async Task WhenISetSalaryInATable(int p0) =>
            await DemoQAWebTablesPage.IFillSalary(p0);

        [When(@"I set Department (.*) in a table")]
        public async Task WhenISetDepartmentQAInATable(string department) =>
            await DemoQAWebTablesPage.IFillDepartment(department);

        [When(@"I click Submit button")]
        public async Task WhenIClickSubmitButton() =>
            await DemoQAWebTablesPage.IClickSubmitButton();

	}
}