using Microsoft.Playwright;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class WebTableTests : UITestFixture
    {
        private DemoQAWebTablesPage DemoQAWebTablesPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            DemoQAWebTablesPage = new DemoQAWebTablesPage(Page);
        }

        [Test]
        public async Task VerifyTableVisible()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            //await DemoQAWebTablesPage.VerifyTableRowContent();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Vega");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        [Test]
        [Description("Check that all fields are added to table when Registration Form is completed")]
        public async Task VerifyThatAllRowsAreAddedAfterFormSubmit()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();

            await DemoQAWebTablesPage.FillFirstNameField("Test");
            await DemoQAWebTablesPage.FillLastNameField("Data");
            await DemoQAWebTablesPage.FillEmailField("test@gmail.com");
            await DemoQAWebTablesPage.FillAgeField(38);
            await DemoQAWebTablesPage.FillSalaryField(10000000);
            await DemoQAWebTablesPage.FillDepartmentField("IT");
            await DemoQAWebTablesPage.ClickSubmitButton();
            await DemoQAWebTablesPage.VerifyPopupNotVisible();

            await DemoQAWebTablesPage.VerifyFirstNameIsAddedToTable("Test");
            await DemoQAWebTablesPage.VerifyNewRowIsAdded(4);
        }

        [Test]
        [Description("Check that the fields are mondatory for Registration form")]
        public async Task VerifyValidationRegistrationForm()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();

            await DemoQAWebTablesPage.ClickSubmitButton();
            await DemoQAWebTablesPage.VerifyValidationOfRegistrationForm();
            await DemoQAWebTablesPage.VerifyPopupVisible();
        }

        [Test]
        [Description("Edit row and verify row edited")]
        public async Task VerifyThatRowIsEdited()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();

            await DemoQAWebTablesPage.FillFirstNameField("Test");
            await DemoQAWebTablesPage.FillLastNameField("Data");
            await DemoQAWebTablesPage.FillEmailField("test@gmail.com");
            await DemoQAWebTablesPage.FillAgeField(38);
            await DemoQAWebTablesPage.FillSalaryField(10000000);
            await DemoQAWebTablesPage.FillDepartmentField("IT");
            await DemoQAWebTablesPage.ClickSubmitButton();

            await DemoQAWebTablesPage.ClickEditIconWithId(4);
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.FillFirstNameField("Test_2");
            await DemoQAWebTablesPage.ClickSubmitButton();

            await DemoQAWebTablesPage.VerifyFirstNameIsAddedToTable("Test_2");
            await DemoQAWebTablesPage.VerifyNewRowIsAdded(4);
        }

        [Test]
        [Description("Delete row and verify row deleted")]

        public async Task VerifyRowIsDeleted()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();

            await DemoQAWebTablesPage.FillFirstNameField("Test");
            await DemoQAWebTablesPage.FillLastNameField("Data");
            await DemoQAWebTablesPage.FillEmailField("test@gmail.com");
            await DemoQAWebTablesPage.FillAgeField(38);
            await DemoQAWebTablesPage.FillSalaryField(10000000);
            await DemoQAWebTablesPage.FillDepartmentField("IT");
            await DemoQAWebTablesPage.ClickSubmitButton();

            await DemoQAWebTablesPage.ClickDeleteIconWithId(4);
            await DemoQAWebTablesPage.VerifyNewRowIsNotVisible(4);

        }









        
        

    }
}
