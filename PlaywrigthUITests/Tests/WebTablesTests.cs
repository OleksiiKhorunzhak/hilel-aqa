using Microsoft.Playwright;
using Newtonsoft.Json.Linq;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlaywrigthUITests.Tests
{
	internal class WebTablesTests : UITestFixture
	{
		private DemoQAWebTablesPage _webTablesPage;

		[Category("pipeline")]
		[SetUp]
		public void SetupCheckBoxPage()
		{
			_webTablesPage = new DemoQAWebTablesPage(Page);
		}

		[Test]
		[Description("Verify table column headers on the page by names")]
		public async Task CheckHeaderColumnNames()
		{
			await _webTablesPage.GoToWebTablesPage();

			List<string> columnNames = new List<string> { "First Name", "Last Name", "Age", "Email", "Salary" };

			foreach (string name in columnNames)
			{
				var result = _webTablesPage.CheckHeaderNameVisibility(name);
				Assert.That(result.Result == true, $"Header column {name} not exist in the table");
			}
		}

		[Test]
		[Description("Verify table cell contains expected value")]
		public async Task CheckTableCellValue()
		{
			await _webTablesPage.GoToWebTablesPage();
			
			var expected_value = "Cierra";
			var result = await _webTablesPage.CheckTableCellValueExists("Cierra");

			Assert.That(result == true, $"Expected cell value {expected_value} is not exist in the table");
		}

		[Test]
		[Description("Verify table row contains expected values - name, surname etc.")]
		public async Task CheckTableRowValues()
		{
			await _webTablesPage.GoToWebTablesPage();

			List<string> row_data = new List<string> { "Alden", "Cantrell", "45", "alden@example.com", "12000", "Compliance" };
			
			var row_number = 2;
			foreach (string value in row_data)
			{
				var result = _webTablesPage.CheckTableCellValueByRow(row_number, value);
				Assert.That(result.Result == true, $"Cell with value {value} not exist in table row {row_number}");
			}
		}

		[Test]
		[Description("Verify User can add valid data and check added row in a table")]
		public async Task CheckAddTableRowValidData()
		{
			await _webTablesPage.GoToWebTablesPage();

			var name = "autotestName";
			var last_name = "autotestLastName";
			var age = "42";
			var email = "autotest@test.com";
			var salary = "13000";
			var department = "autotestDepartment";

			var empty_row_index = await _webTablesPage.GetFirstEmptyRowIndex();
			
			await _webTablesPage.ClickAddButton();

			await _webTablesPage.CheckRegistrationFormIsVisible();
			await _webTablesPage.InputFirstNameField(name);
			await _webTablesPage.InputLastNameField(last_name);
			await _webTablesPage.InputAgeField(age);
			await _webTablesPage.InputEmailField(email);
			await _webTablesPage.InputSalaryField(salary);
			await _webTablesPage.InputDepartmentField(department);
			await _webTablesPage.ClickSubmitButton();
			
			await _webTablesPage.CheckRegistrationFormIsNotVisible();

			var row_data = new List<string> { name, last_name, age, email, salary, department };
			var row_index = ++empty_row_index;

			foreach (string value in row_data)
			{
				var result = _webTablesPage.CheckTableCellValueByRow(row_index, value);
				Assert.That(result.Result == true, $"Cell with value {value} not exist in table");
			}
		}

		[Test]
		[Description("Verify User can edit row in the table with correct data")]
		public async Task CheckEditTableRowDataFunctionality()
		{
			await _webTablesPage.GoToWebTablesPage();

			var name = "autotestName";
			var last_name = "autotestLastName";
			var age = "42";
			var email = "autotest@test.com";
			var salary = "13000";
			var department = "autotestDepartment";

			var empty_row_index = await _webTablesPage.GetFirstEmptyRowIndex();
			var last_filled_index = empty_row_index;

			await _webTablesPage.ClickEditIconWithId(last_filled_index);

			await _webTablesPage.CheckRegistrationFormIsVisible();
			await _webTablesPage.InputFirstNameField(name);
			await _webTablesPage.InputLastNameField(last_name);
			await _webTablesPage.InputAgeField(age);
			await _webTablesPage.InputEmailField(email);
			await _webTablesPage.InputSalaryField(salary);
			await _webTablesPage.InputDepartmentField(department);
			await _webTablesPage.ClickSubmitButton();

			await _webTablesPage.CheckRegistrationFormIsNotVisible();
			var row_data = new List<string> { name, last_name, age, email, salary, department };

			foreach (string value in row_data)
			{
				var result = _webTablesPage.CheckTableCellValueByRow(last_filled_index, value);
				Assert.That(result.Result == true, $"Cell with value {value} was not updated in table");
			}
		}

		[Test]
		[Description("Verify User can delete row in the table")]
		public async Task CheckDeleteTableRowDataFunctionality()
		{
			await _webTablesPage.GoToWebTablesPage();

			var empty_row_index = await _webTablesPage.GetFirstEmptyRowIndex();
			var icon_index = empty_row_index;

			await _webTablesPage.ClickDeleteIconWithId(icon_index);

			var updated_empty_row_index = await _webTablesPage.GetFirstEmptyRowIndex();
			var expected_index = empty_row_index - 1;
			
			Assert.That(updated_empty_row_index == expected_index, $"Index of empty row is {updated_empty_row_index} after deletion is != to expected index {expected_index} ");
		}

		[Test]
		[Description("Verify User can't submit data row in the table with empty field")]
		public async Task CheckImpossibleToSubmitDataWithEmptyField()
		{
			await _webTablesPage.GoToWebTablesPage();
			
			var last_name = "autotestLastName";
			var age = "42";
			var email = "autotest@test.com";
			var salary = "13000";
			var department = "autotestDepartment";

			await _webTablesPage.ClickAddButton();

			await _webTablesPage.CheckRegistrationFormIsVisible();
			await _webTablesPage.InputLastNameField(last_name);
			await _webTablesPage.InputAgeField(age);
			await _webTablesPage.InputEmailField(email);
			await _webTablesPage.InputSalaryField(salary);
			await _webTablesPage.InputDepartmentField(department);
			await _webTablesPage.ClickSubmitButton();

			await _webTablesPage.CheckRegistrationFormIsVisible();
			var result = _webTablesPage.CheckFormWithValidationErrorVisible();

			Assert.That(result.Result == true, $"Visibility status for Registration form with error == {result}, expected - true");
		}

		[Test]
		[Description("Verify search field functionality by User name")]
		public async Task CheckSearchFieldFunctionalityByName()
		{
			await _webTablesPage.GoToWebTablesPage();

			var name = "Kierra";
			await _webTablesPage.InputSearchField(name);

			var result = await _webTablesPage.CheckTableCellValueExists(name);

			Assert.That(result == true, $"Searched name value {name} is not visible in the table, visibility status == {result}");
		}

		[Test]
		[Description("Verify search field functionality by User email")]
		public async Task CheckSearchFieldFunctionalityByEmail()
		{
			await _webTablesPage.GoToWebTablesPage();

			var email = "alden@example.com";
			await _webTablesPage.InputSearchField(email);

			var result = await _webTablesPage.CheckTableCellValueExists(email);

			Assert.That(result == true, $"Searched email value {email} is not visible in the table, visibility status == {result}");
		}
	}
}
