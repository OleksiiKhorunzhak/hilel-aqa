using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects;

internal class DemoQaWebTablesPage
{
    private IPage Page;
    private string WebTablePageUrl = "https://demoqa.com/webtables";
    
    public ILocator FirstNameField => Page.GetByPlaceholder("First Name");
    public ILocator LastNameField => Page.GetByPlaceholder("Last Name");
    public ILocator EmailField => Page.GetByPlaceholder("name@example.com");
    public ILocator AgeField => Page.GetByPlaceholder("Age");
    public ILocator SalaryField => Page.GetByPlaceholder("Salary");
    public ILocator DepartmentField => Page.GetByPlaceholder("Department");
    public ILocator RegistrationPopup => Page.Locator(".modal-content");
    private ILocator AddButton => Page.GetByRole(AriaRole.Button, new() { Name = "Add" });

    public DemoQaWebTablesPage(IPage page)
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
        var isPopupOpened = await RegistrationPopup.IsVisibleAsync();
        Assert.That(isPopupOpened, "The 'Add' popup is not visible.");
    }

    public async Task VerifyFirstNameVisible()
    {
        var firstName = Page.GetByPlaceholder("First Name");
        await Assertions.Expect(firstName).ToBeVisibleAsync();
    }
    
    public async Task OpenAddPopup()
    {
        await AddButton.ClickAsync();
        Assert.That(await RegistrationPopup.IsVisibleAsync(), "The 'Add' popup is not visible.");
    }
    
    public async Task FillFirstName (string firstName)
    {
        if(firstName == null) throw new ArgumentException ("First Name field should not be null.");
        await FirstNameField.FillAsync(firstName);
        Assert.That(await FirstNameField.GetAttributeAsync("value") == firstName, $"The First Name field was not filled with: '{firstName}'.");
    }
    
    public async Task FillLastName (string lastName)
    {
        if(lastName == null) throw new ArgumentException ("Last Name field should not be null.");
        await LastNameField.FillAsync(lastName);
        Assert.That(await LastNameField.GetAttributeAsync("value") == lastName, $"The Last Name field was not filled with: '{lastName}'.");
    } 
    
    public async Task FillEmail (string email)
    {
        if(email == null) throw new ArgumentException ("Email field should not be null.");
        await EmailField.FillAsync(email);
        Assert.That(await EmailField.GetAttributeAsync("value") == email, $"The Email field was not filled with: '{email}'.");
    }
    
    public async Task FillAge (string age)
    {
        if(age == null) throw new ArgumentException ("Age field should not be null.");
        await AgeField.FillAsync(age);
        Assert.That(await AgeField.GetAttributeAsync("value") == age, $"The Age field was not filled with: '{age}'.");
    }
    
    public async Task FillSalary (string salary)
    {
        if(salary == null) throw new ArgumentException ("Salary field should not be null.");
        await SalaryField.FillAsync(salary);
        Assert.That(await SalaryField.GetAttributeAsync("value") == salary, $"The Salary field was not filled with: '{salary}'.");
    }
    
    public async Task FillDepartment (string department)
    {
        if(department == null) throw new ArgumentException ("Department field should not be null.");
        await DepartmentField.FillAsync(department);
        Assert.That(await DepartmentField.GetAttributeAsync("value") == department, $"The Department field was not filled with: '{department}'.");
    }

    public async Task ClickSubmit()
    {
        var submit = Page.GetByRole(AriaRole.Button, new() { Name = "Submit" });
        await submit.ClickAsync();
    }
    
    public async Task<string> FindRowContentByEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException ("Email field is empty.");
        
        var rows = await Page.Locator("//div[@class=\"rt-tr-group\"]").AllAsync();
        if (rows == null || rows.Count == 0) throw new Exception("No rows found in the table.");
        string rowContent = "";
        foreach (var row in rows)
        {
            var rowText = await row.InnerTextAsync();

            if (rowText.Contains(email))
            {
                rowContent = rowText.Replace("\n", "").Replace(" ", "").Trim();
                break;
            }
        }
        return rowContent;
    }
    
    public async Task ClickEditButton(string email)
    {
        if(string.IsNullOrEmpty(email)) throw new ArgumentException ("Email field is empty.");
        var removeRowButton =
            Page.Locator($"//*[@class=\"rt-tr-group\"]//*[contains(text(),'{email}')]/following-sibling::div//span[@title=\"Edit\"]");
        await removeRowButton.ClickAsync();
    }

    public async Task ClickDeleteButton(string email)
    {
        if(string.IsNullOrEmpty(email)) throw new ArgumentException ("Email field is empty.");
        var removeRowButton =
            Page.Locator($"//*[@class=\"rt-tr-group\"]//*[contains(text(),'{email}')]/following-sibling::div//span[@title=\"Delete\"]");
        await removeRowButton.ClickAsync();
    }
}