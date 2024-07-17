using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V122.Tracing;

internal class WebTablesPage(IPage page)
{
    private readonly IPage page = page;

    #region Page
    public async Task GoToURL(string testPageUrl)
    {
        await page.GotoAsync(testPageUrl);
        //await page.WaitForURLAsync(testPageUrl);
    }

    public async Task IsPageH1Visible(string pageH1)
    {
        await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = pageH1 })).ToBeVisibleAsync();
    }
    #endregion

    #region Table
    public async Task VerifyTableVisible()
    {
        var table = page.Locator(".ReactTable");
        await Assertions.Expect(table).ToBeVisibleAsync();
    }

    public async Task VerifyTableRowVisible()
    {
        var table = page.Locator(".ReactTable");
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
        var table = page.Locator(".ReactTable");

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
    #endregion

    #region PopUp
    public async Task VerifyPopupVisible()
    {
        var popup = page.Locator(".modal-content");
        await Assertions.Expect(popup).ToBeVisibleAsync();
    }

    public async Task VerifyFirstNameVisible()
    {
        var popup = page.Locator(".modal-content");
        var firstName = popup.GetByPlaceholder("First Name");
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }
    #endregion

}
