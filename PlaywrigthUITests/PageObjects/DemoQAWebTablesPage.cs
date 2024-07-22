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

    public async Task VerifyTableRowsVisible()
    {
        var table = Page.Locator(".ReactTable");
        var rows = await table.Locator(".rt-tr-group").AllAsync();

        if (rows.Any())
        {
            Assert.Pass();
        }
        else
        {
            Assert.Fail("No rows found in the table.");
        }
    }

    public async Task ClickAddButton()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
    }

    public async Task ClickSubmitButton()
    {
        await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
    }

    //public async Task GetTableRowContent(string headerName = "First Name", string value = "Cierra")
    //{
    //    var table = Page.Locator(".ReactTable");

    //    #region Unclear_realization
    //    //// Locate headers
    //    //var headers = await table.Locator(".rt-th").AllInnerTextsAsync();
    //    //var headersList = headers.ToList();

    //    //// Find the index of the specified header
    //    //int headerIndex = headersList.IndexOf(headerName);

    //    //if (headerIndex == -1)
    //    //{
    //    //    Assert.Fail($"Header '{headerName}' not found.");
    //    //}

    //    //// Locate all rows
    //    //var rows = await table.Locator(".rt-tr-group").AllAsync();

    //    //// Locate the cells in the specified column for each row
    //    //var cells = new List<ILocator>();
    //    //foreach (var row in rows)
    //    //{
    //    //    var rowCells = await row.Locator(".rt-td").AllAsync();
    //    //    if (rowCells.Count > headerIndex)
    //    //    {
    //    //        cells.Add(rowCells[headerIndex]);
    //    //    }
    //    //    else
    //    //    {
    //    //        Assert.Fail("Row does not contain enough cells.");
    //    //    }
    //    //}

    //    //// Check if the content of the first cell in the specified column matches the given value
    //    //if (cells.Any())
    //    //{
    //    //    var cellContent = await cells.First().InnerTextAsync();
    //    //    Assert.That(cellContent == value, $"The content of the first cell in the '{headerName}' column does not match '{value}'.");
    //    //}
    //    //else
    //    //{
    //    //    Assert.Fail($"No cells found in the '{headerName}' column.");
    //    //}
    //    #endregion

    //}

    public async Task VerifyPopupVisible()
    {
        var popup = Page.Locator(".modal-content");
        await Assertions.Expect(popup).ToBeVisibleAsync();
    }

    public async Task VerifyFirstNameVisibleInPopup()
    {
        var popup = Page.Locator(".modal-content");
        var firstName = popup.GetByPlaceholder("First Name");
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }

    public ILocator GetPopupInput(string fieldID)
    {
        return Page.Locator("#" + fieldID + " ");
    }
    public async Task<string> GetPopupInputColor(ILocator field)
    {
        return await field.EvaluateAsync<string>("element => getComputedStyle(element).getPropertyValue('border-left-color')");
    }

    public async Task FillInPopupField(ILocator field, string value)
    {
        await field.FillAsync(value);
    }

    public ILocator GetRowByFirstNameValue(string firstName)
    {
        return Page.Locator($"//div[contains(@class, 'rt-tr-group')]//div[1][text()='{firstName}']/ancestor::div[contains(@class, 'rt-tr-group')]");
    }

    public async Task ClickEditRowButton(ILocator row)
    {
        await row.Locator("//span[@title='Edit']").ClickAsync();

    }

    public async Task ClickDeleteRowButton(ILocator row)
    {
        await row.Locator("//span[@title='Delete']").ClickAsync();

    }
}