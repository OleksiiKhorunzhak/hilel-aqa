<<<<<<< HEAD
﻿using Microsoft.Playwright;
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
			await _page.WaitForSelectorAsync($"[role='rowgroup']:nth-child({row})");
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

		public async Task<bool> CheckFormWithValidationErrorVisible()
		{
			var form = await _page.WaitForSelectorAsync("//form[@class='was-validated']");
			return await form.IsVisibleAsync();
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

		public async Task<int> GetFirstEmptyRowIndex()
		{
			var rows_innertext = await _page.Locator("role=rowgroup").AllInnerTextsAsync();
			Array row_string = rows_innertext.ToArray();
			var index = Array.IndexOf(row_string, " \n \n \n \n \n \n ");
			return index;
		}

		public async Task ClickEditIconWithId(int id)
		{
			await _page.Locator($"#edit-record-{id} path").ClickAsync();
		}

		public async Task ClickDeleteIconWithId(int id)
		{
			await _page.Locator($"#delete-record-{id} path").ClickAsync();
		}

		public async Task InputSearchField(string input_text)
		{
			await _page.GetByPlaceholder("Type to search").FillAsync($"{input_text}");
		}
		#endregion
	}
=======
﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

internal class DemoQAWebTablesPage
{
    private IPage Page;
    private string WebTablePageUrl = "https://demoqa.com/webtables";

    public DemoQAWebTablesPage(IPage page)
    {
        Page = page;
    }

    public async Task GoToDemoQaWebTablesPage()
    {
        await Page.GotoAsync(WebTablePageUrl);
    }

    public async Task VerifyTableVisible()
    {
        var table = Page.Locator(".ReactTable");
        await Assertions.Expect(table).ToBeVisibleAsync();
    }

    public async Task VerifyTableRowVisible()
    {
        var table = Page.Locator(".ReactTable");
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        if (rows.Any())
        {
            await Assertions.Expect(rows.First()).ToBeVisibleAsync();
        }
        else
        {
            Assert.Fail("No rows found in the table.");
        }
    }

    public async Task VerifyTableRowContent(string headerName = "First Name", string value = "Cierra")
    {
        var table = Page.Locator(".ReactTable");

        // Locate headers
        var headers = await table.Locator(".rt-th").AllInnerTextsAsync();
        var headersList = headers.ToList();

        // Find the index of the specified header
        int headerIndex = headersList.IndexOf(headerName);

        if (headerIndex == -1)
        {
            Assert.Fail($"Header '{headerName}' not found.");
        }

        // Locate all rows
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        // Locate the cells in the specified column for each row
        var cells = new List<ILocator>();
        foreach (var row in rows)
        {
            var rowCells = await row.Locator(".rt-td").AllAsync();
            if (rowCells.Count > headerIndex)
            {
                cells.Add(rowCells[headerIndex]);
            }
            else
            {
                Assert.Fail("Row does not contain enough cells.");
            }
        }

        // Check if the content of the first cell in the specified column matches the given value
        if (cells.Any())
        {
            var cellContent = await cells.First().InnerTextAsync();
            Assert.That(cellContent == value, $"The content of the first cell in the '{headerName}' column does not match '{value}'.");
        }
        else
        {
            Assert.Fail($"No cells found in the '{headerName}' column.");
        }
    }

    public async Task VerifyPopupVisible()
    {
        var popup = Page.Locator(".modal-content");
        await Assertions.Expect(popup).ToBeVisibleAsync();
    }

    public async Task VerifyFirstNameVisible()
    {
        var popup = Page.Locator(".modal-content");
        var firstName = popup.GetByPlaceholder("First Name");
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }
    

>>>>>>> andriyMykytenkohomework20
}
