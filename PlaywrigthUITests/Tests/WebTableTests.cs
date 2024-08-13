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
            await DemoQAWebTablesPage.VerifyPopupVisible(true);
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        [Test]
        public async Task VerifyTableVisible2()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible(true);
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        //TODO: automate test cases
        //Check any mandatory field
        [Test]
        [Description("Verify mandatory fields")]
        public async Task VerifyDepartmentIsMandatoryField()
        {
            //Arrange
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.OpenAddPopup();
            await DemoQAWebTablesPage.VerifyPopupVisible(true);
            //Act
            await DemoQAWebTablesPage.FillFirstName("John");
            await DemoQAWebTablesPage.FillLastName("Doe");
            await DemoQAWebTablesPage.FillEmail("jon@doe.com");
            await DemoQAWebTablesPage.FillAge("33");
            await DemoQAWebTablesPage.FillSalary("555");
            await DemoQAWebTablesPage.FillDepartment("");
            await DemoQAWebTablesPage.ClickSubmit();
            //Assert
            Assert.That(await DemoQAWebTablesPage.VerifyPopupVisible(false), "The 'Add' popup is still visible.");
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
            //Act
            await DemoQAWebTablesPage.FillFirstName(firstName);
            await DemoQAWebTablesPage.FillLastName(lastName);
            await DemoQAWebTablesPage.FillEmail(email);
            await DemoQAWebTablesPage.FillAge(age);
            await DemoQAWebTablesPage.FillSalary(salary);
            await DemoQAWebTablesPage.FillDepartment(department);
            await DemoQAWebTablesPage.ClickSubmit();
            //Assert
            Assert.That(await DemoQAWebTablesPage.VerifyPopupVisible(false), "The 'Add' popup is still visible.");
            var rowAdded = await DemoQAWebTablesPage.FindRowInTable(firstName, lastName, email, age, salary, department);
            Assert.That(rowAdded, Is.True, "The row was not found in the table.");
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
            var modifiedRow = await DemoQAWebTablesPage.FindRowInTable(firstName, lastName, email, age, salary, department);
            Assert.That(modifiedRow, Is.True, "The modified row was not found in the table.");
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
            await DemoQAWebTablesPage.VerifyPopupVisible(false);
            //Act
            await DemoQAWebTablesPage.ClickDeleteButton(email);
            //Assert
            var removedRow = await DemoQAWebTablesPage.FindRowInTable(firstName, lastName, email, age, salary, department);
            Assert.That(removedRow, Is.False, "The row was found in the table.");
        }
        
        [Test]
        [Description("Delete row and verify row deleted")]
        [TestCase("Alden", "Cantrell", "alden@example.com", "45", "12000", "Compliance")]
        [TestCase("Kierra", "Gentry", "kierra@example.com", "29", "2000", "Legal")]
        [TestCase("Cierra", "Vega", "cierra@example.com", "39", "10000", "Insurance")]
        public async Task DeleteRow(string firstName, string lastName, string email, string age, string salary,
            string department)
        {
            //Arrange
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.FindRowInTable(firstName, lastName, email, age, salary, department);
            //Act
            await DemoQAWebTablesPage.ClickDeleteButton(email);
            //Assert
            var removedRow = await DemoQAWebTablesPage.FindRowInTable(firstName, lastName, email, age, salary, department);
            Assert.That(removedRow, Is.False, "The row was found in the table.");
        }
    }
}
