using Microsoft.Playwright;
using TechTalk.SpecFlow;

namespace PlaywrightSpecFlow.PageObjects 
{
    [Binding]
    internal class DemoQAWebTablesPage
    {
        private IPage page;
        private string WebTablePageUrl = "https://demoqa.com/webtables";

        public DemoQAWebTablesPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToDemoQaWebTablesPage()
        {
            await page.GotoAsync(WebTablePageUrl);
        }

        public async Task VerifyTableVisible()
        {
            var table = page.Locator(".ReactTable");
            await Assertions.Expect(table).ToBeVisibleAsync();
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

            // Locate all rows using EvaluateAllAsync
            var rows = await table.Locator(".rt-tr-group").EvaluateAllAsync<ILocator[]>("(elements) => elements");

            if (rows.Length == 0)
            {
                Assert.Fail("No rows found in the table.");
            }

            // Locate the cells in the specified column for each row
            var cells = new List<ILocator>();
            foreach (var row in rows)
            {
                var rowCells = await row.Locator(".rt-td").EvaluateAllAsync<ILocator[]>("(elements) => elements");
                if (rowCells.Length > headerIndex)
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

        public async Task IClickAddButton()
        {
            await page.GetByRole(AriaRole.Button, new() { NameString = "Add" }).ClickAsync();
        }


        public async Task IFillFirstName(string firstName)
        {
            await page.GetByPlaceholder("First Name").FillAsync(firstName);
            //await page.GetByPlaceholder("First Name").PressAsync("Enter");
        }

        public async Task IFillLastName(string lastName)
        {
            await page.GetByPlaceholder("Last Name").FillAsync(lastName);
            //await page.GetByPlaceholder("Last Name").PressAsync("Enter");
        }

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
    }
}
