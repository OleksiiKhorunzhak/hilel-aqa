using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
	internal class DemoQAWebTablesPage
	{
		private IPage _page;
		private string elementsPageUrl = "https://demoqa.com/elements";
		private string webTablesPageUrl = "https://demoqa.com/webtables";

		public DemoQAWebTablesPage(IPage page)
		{
			_page = page;
		}

		public async Task GoToWebTablesPage()
		{
			await _page.GotoAsync(elementsPageUrl);
			await _page.GetByText("Web Tables").ClickAsync();
			await _page.WaitForURLAsync(webTablesPageUrl);
		}
		#region Verifications
		public async Task<bool> CheckHeaderNameVisibility(string name)
		{
			return await _page.GetByRole(AriaRole.Columnheader, new() { Name = name }).IsVisibleAsync();
		}

		public async Task<bool> CheckTableCellValueExists(string value)
		{
			return await _page.GetByRole(AriaRole.Gridcell, new() { Name = value }).Nth(0).IsVisibleAsync();
		}

		public async Task<bool> CheckTableCellValueByRow(int row, string value)
		{
			var data = await _page.GetByRole(AriaRole.Row, new() { Level = 0 }).Nth(row).InnerTextAsync();
			return data.Contains(value);
		}

		public async Task<bool> CheckTableCellValueVisible(string value)
		{
			var cell = await _page.WaitForSelectorAsync($"css=.rt-td >> text={value}");
			return await cell.IsVisibleAsync();
		}

		public async Task CheckRegistrationFormIsVisible()
		{
			await _page.GetByText("Registration Form").IsVisibleAsync();
		}

		public async Task CheckRegistrationFormIsNotVisible()
		{
			await Assertions.Expect(_page.Locator("Registration Form")).Not.ToBeVisibleAsync();
		}
		#endregion

		#region Actions
		public async Task ClickAddButton()
		{
			await _page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
		}		
		
		public async Task InputFirstNameField(string input_text)
		{
			await _page.GetByPlaceholder("First Name").FillAsync(input_text);
		}

		public async Task InputLastNameField(string input_text)
		{
			await _page.GetByPlaceholder("Last Name").FillAsync(input_text);
		}

		public async Task InputEmailField(string input_text)
		{
			await _page.GetByPlaceholder("name@example.com").FillAsync(input_text);
		}

		public async Task InputAgeField(string input_text)
		{
			await _page.GetByPlaceholder("Age").FillAsync(input_text);
		}

		public async Task InputSalaryField(string input_text)
		{
			await _page.GetByPlaceholder("Salary").FillAsync(input_text);
		}

		public async Task InputDepartmentField(string input_text)
		{
			await _page.GetByPlaceholder("Department").FillAsync(input_text);
		}

		public async Task ClickSubmitButton()
		{
			await _page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
		}

		public async Task<int> GetLastFilledRow()
		{
			var rowsinnertextcell = await _page.Locator("role=rowgroup").AllInnerTextsAsync();

			return 1;
		}
		#endregion
	}
}
