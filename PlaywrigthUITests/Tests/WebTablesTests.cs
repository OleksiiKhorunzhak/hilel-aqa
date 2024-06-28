using Microsoft.Playwright;
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
			var result = await _webTablesPage.CheckTableCellValueExists("Kierra");

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
		[Description("Verify User can add valid data in table")]
		public async Task CheckAddTableValidData()
		{
			await _webTablesPage.GoToWebTablesPage();

			var name = "autotestName";
			var last_name = "autotestLastName";
			var age = "42";
			var email = "autotest@test.com";
			var salary = "13000";
			var department = "autotestDepartment";

			var cell = await _webTablesPage.GetLastFilledRow();
			
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

			foreach (string value in row_data)
			{
				var result = _webTablesPage.CheckTableCellValueVisible(value);
				Assert.That(result.Result == true, $"Cell with value {value} not exist in table");
			}
		}
	}
}
