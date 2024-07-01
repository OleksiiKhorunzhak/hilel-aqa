using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using static System.Net.Mime.MediaTypeNames;

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

    public async Task VerifyPopupNotVisible()
    {
        var popup = Page.Locator(".modal-content");
        await Assertions.Expect(popup).Not.ToBeVisibleAsync();
    }

    public async Task VerifyFirstNameVisible()
    {
        var popup = Page.Locator(".modal-content");
        var firstName = popup.GetByPlaceholder("First Name");
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }

    public async Task FillFirstNameField(string firstName)
    {
        await Page.GetByPlaceholder("First Name").FillAsync(firstName);
    }

    public async Task FillLastNameField(string lastName)
    {
        await Page.GetByPlaceholder("Last Name").FillAsync(lastName);
    }

    public async Task FillEmailField(string email)
    {
        await Page.GetByPlaceholder("name@example.com").FillAsync(email);
    }

    public async Task FillAgeField(int age)
    {
        await Page.GetByPlaceholder("Age").FillAsync(age.ToString());
    }

    public async Task FillSalaryField(int salary)
    {
        await Page.GetByPlaceholder("Salary").FillAsync(salary.ToString());
    }

    public async Task FillDepartmentField(string department)
    {
        await Page.GetByPlaceholder("Department").FillAsync(department);
    }

    public async Task ClickSubmitButton()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
    }

    public async Task VerifyFirstNameIsAddedToTable(string text)
    {
        var firstName = Page.GetByRole(AriaRole.Gridcell, new() { Name = $"{text}", Exact = true });
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }

    public async Task VerifyValidationOfRegistrationForm()
    {
        var validation = Page.Locator("//form[@class='was-validated']");
        await Assertions.Expect(validation).ToBeVisibleAsync();
    }

    public async Task ClickEditIconWithId(int id)
    {
        await Page.Locator($"#edit-record-{id} path").ClickAsync();
    }
    public async Task ClickDeleteIconWithId(int id)
    {
        await Page.Locator($"#delete-record-{id} path").ClickAsync();
    }

    public async Task VerifyNewRowIsAdded(int id)
    {
        await Page.Locator($"rt-tr -padRow -even-{id} path").IsVisibleAsync();
    }

    public async Task VerifyNewRowIsNotVisible(int id)
    {
        var newAddedRoe = Page.Locator($"rt-tr -padRow -even-{id} path");
        await Assertions.Expect(newAddedRoe).Not.ToBeVisibleAsync();
    }

}
