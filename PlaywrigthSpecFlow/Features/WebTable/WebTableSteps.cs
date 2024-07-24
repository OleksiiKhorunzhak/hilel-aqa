using Microsoft.Playwright;
using TechTalk.SpecFlow;
using PlaywrightSpecFlow.PageObjects;
using PlaywrigthSpecFlow.Bindings;
using static System.Net.Mime.MediaTypeNames;
using TechTalk.SpecFlow.Time;

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
        public async Task WhenIClickAddButton() =>
            await DemoQAWebTablesPage.IClickAddButton();
       
      
        [When(@"I click Submit Button")]
        public async Task WhenIClickSubmitButton() =>
           await DemoQAWebTablesPage.IClickSubmitButton();

      
        [When(@"I click Edit Button ""(.*)""")]
        public async Task WhenIEditRow(string editrow) =>
     await DemoQAWebTablesPage.IClickEditButton($"#edit-record-{editrow}");

        [When(@"I click Delete Button ""(.*)""")]
        public async Task WhenIDeleteRow(string deleterow) =>
           await DemoQAWebTablesPage.IClickDeleteButton($"#delete-record-{deleterow} path");
        [When(@"I set FirstName to ""(.*)""")]
        public async Task WhenISetFirstName(string firstName) =>
           await DemoQAWebTablesPage.IFillFirstName(firstName);

        [When(@"I set LastName to ""(.*)""")]
        public async Task WhenISetLastName(string lastName) =>
             await DemoQAWebTablesPage.IFillLastName(lastName);
       
        [When(@"I set Email ""(.*)""")]
        public async Task WhenISetEmail(string email) =>
            await DemoQAWebTablesPage.IFillEmail(email);

        [When(@"I set Age ""(.*)""")]
        public async Task WhenISetAge(string agevalue) =>
            await DemoQAWebTablesPage.IFillAge(agevalue);

        [When(@"I set Salary ""(.*)""")]
        public async Task WhenISetSalary(string salaryvalue) =>
            await DemoQAWebTablesPage.IFillSalary(salaryvalue);

        [When(@"I set Department ""(.*)""")]
        public async Task WhenISetDepartment(string departmentvalue) =>
            await DemoQAWebTablesPage.IFillDepartment(departmentvalue);

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
        public async Task ThenISeeAge(string agevalue) =>
           await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = agevalue, Exact = true })).ToBeVisibleAsync();

        [Then(@"I see Salary ""(.*)"" in a table")]
        public async Task ThenISeeSalary(string salaryvalue) =>
           await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = salaryvalue, Exact = true })).ToBeVisibleAsync();


        [Then(@"I see Department ""(.*)"" in a table")]
        public async Task ThenISeeDepartment(string departmentvalue) =>
           await Assertions.Expect(Page.GetByRole(AriaRole.Gridcell, new() { Name = departmentvalue, Exact = true })).ToBeVisibleAsync();
       
        [Then(@"I dont see Row ""(.*)"" in a table")]
        public async Task ThenIDontSeeRow(string deletedrow) =>
                    await DemoQAWebTablesPage.VerifyRowIsNotVisible(deletedrow);




        [AfterFeature]
        public static async Task TearDownFeature()
        {
            await Page.CloseAsync(); // Закрытие страницы после завершения всех тестов
        }
    }

}