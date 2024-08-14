using Microsoft.Playwright;
using PlaywrigthUITests;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class WebTableTests : UITestFixture
    {
        private DemoQaWebTablesPage DemoQAWebTablesPage;

        [SetUp]
        public void SetupDemoQaPage()
        {
            DemoQAWebTablesPage = new DemoQaWebTablesPage(Page);
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
        public async Task VerifyTableVisible2()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        //TODO: automate test cases
        //Check any mandatory field
        [Test]
        [Description("Verify Department is mandatory field")]
        public async Task VerifyDepartmentIsMandatoryField()
        {
            //Arrange
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.OpenAddPopup();
            await DemoQAWebTablesPage.RegistrationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            //Act
            await DemoQAWebTablesPage.FillFirstName("John");
            await DemoQAWebTablesPage.FillLastName("Doe");
            await DemoQAWebTablesPage.FillEmail("jon@doe.com");
            await DemoQAWebTablesPage.FillAge("33");
            await DemoQAWebTablesPage.FillSalary("555");
            await DemoQAWebTablesPage.FillDepartment("");
            await DemoQAWebTablesPage.ClickSubmit();
            //Assert
            await Assertions.Expect(DemoQAWebTablesPage.FirstNameField).ToHaveCSSAsync("border-color", "rgb(40, 167, 69)");
            await Assertions.Expect(DemoQAWebTablesPage.LastNameField).ToHaveCSSAsync("border-color", "rgb(40, 167, 69)");
            await Assertions.Expect(DemoQAWebTablesPage.EmailField).ToHaveCSSAsync("border-color", "rgb(40, 167, 69)");
            await Assertions.Expect(DemoQAWebTablesPage.AgeField).ToHaveCSSAsync("border-color", "rgb(40, 167, 69)");
            await Assertions.Expect(DemoQAWebTablesPage.SalaryField).ToHaveCSSAsync("border-color", "rgb(40, 167, 69)");
            await Assertions.Expect(DemoQAWebTablesPage.DepartmentField).ToHaveCSSAsync("border-color", "rgb(220, 53, 69)");
        }

        //Add new row and verify row added
        [Test]
        [Description("Add new row and verify row added")]
        [TestCase("John", "Doe", "30", "jon@doe.com", "10000", "IT")]
        public async Task AddNewRow(string firstName,string lastName, string age, string email, string salary, string department)
        {
            //Arrange
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.OpenAddPopup();
            await DemoQAWebTablesPage.RegistrationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            //Act
            await DemoQAWebTablesPage.FillFirstName(firstName);
            await DemoQAWebTablesPage.FillLastName(lastName);
            await DemoQAWebTablesPage.FillEmail(email);
            await DemoQAWebTablesPage.FillAge(age);
            await DemoQAWebTablesPage.FillSalary(salary);
            await DemoQAWebTablesPage.FillDepartment(department);
            await DemoQAWebTablesPage.ClickSubmit();
            await DemoQAWebTablesPage.RegistrationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            //Assert
            var rowContent = await DemoQAWebTablesPage.FindRowContentByEmail(email);
            Assert.That(rowContent, Is.Not.Null.And.Not.Empty, "The row was not found in the table.");
            string expectedContent = $"{firstName}{lastName}{age}{email}{salary}{department}";
            Assert.That(rowContent, Is.EqualTo(expectedContent), $"Row does not contain expected content. Current content: {rowContent}, Expected content: {expectedContent}");
        }
        
        //Edit row and verify row edited
        [Test]
        [Description("Edit row and verify row edited")]
        [TestCase("cierra@example.com","John", "Doe", "jon@doe.com", "30", "10000", "IT")]
        [TestCase("alden@example.com","John", "Doe", "jon@doe.com", "30", "10000", "IT")]
        [TestCase("kierra@example.com","John", "Doe", "jon@doe.com", "30", "10000", "IT")]
        public async Task EditRow(string emailToFind, string firstName, string lastName, string email, string age, string salary,
            string department)
        {
            //Arrange
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            //Act
            await DemoQAWebTablesPage.ClickEditButton(emailToFind);
            await DemoQAWebTablesPage.RegistrationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            await DemoQAWebTablesPage.FillFirstName(firstName);
            await DemoQAWebTablesPage.FillLastName(lastName);
            await DemoQAWebTablesPage.FillEmail(email);
            await DemoQAWebTablesPage.FillAge(age);
            await DemoQAWebTablesPage.FillSalary(salary);
            await DemoQAWebTablesPage.FillDepartment(department);
            await DemoQAWebTablesPage.ClickSubmit();
            await DemoQAWebTablesPage.RegistrationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            //Assert
            var rowContent = await DemoQAWebTablesPage.FindRowContentByEmail(email);
            Assert.That(rowContent, Is.Not.Null.And.Not.Empty, "The row was not found in the table.");
            string expectedContent = $"{firstName}{lastName}{age}{email}{salary}{department}";
            Assert.That(rowContent, Is.EqualTo(expectedContent), $"The row was not edited. Current content: {rowContent}, Expected content: {expectedContent}");
        }
        
        //Delete row and verify row deleted
        [Test]
        [Description("Add and Delete row and verify row deleted")]
        [TestCase("John", "Doe", "jon@doe.com", "30", "10000", "IT")]
        public async Task AddAndDeleteRow(string firstName, string lastName, string email, string age, string salary,
            string department)
        {
            //Arrange
            await AddNewRow(firstName, lastName, age, email, salary, department);
            await DemoQAWebTablesPage.RegistrationPopup.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            //Act
            await DemoQAWebTablesPage.ClickDeleteButton(email);
            //Assert
            var rowContent = await DemoQAWebTablesPage.FindRowContentByEmail(email);
            Assert.That(rowContent, Is.Null.Or.Empty, "The row was found in the table.");
        }
        
        [Test]
        [Description("Delete row and verify row deleted")]
        [TestCase("alden@example.com")]
        [TestCase("kierra@example.com")]
        [TestCase("cierra@example.com")]
        //[TestCase("jon@doe.com")] //Expected to fail, email is not present in the table
        public async Task DeleteRow(string email)
        {
            //Arrange
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            //Act
            await DemoQAWebTablesPage.ClickDeleteButton(email);
            //Assert
            var rowContent = await DemoQAWebTablesPage.FindRowContentByEmail(email);
            Assert.That(rowContent, Is.Null.Or.Empty, "The row was found in the table.");
        }
    }
}
