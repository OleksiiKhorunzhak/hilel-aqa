using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeSmells.PRCommentsExamples
{
    internal class DemoQAWebTablesPage
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

        public DemoQAWebTablesPage(IPage page)
        {
            Page = page;
        }

        #region
        // Bad name causes bad usage
        //await DemoQAWebTablesPage.VerifyPopupVisible(true);
        //Assert.That(await DemoQAWebTablesPage.VerifyPopupVisible(false), "The 'Add' popup is still visible.");
        #endregion
        public async Task<bool> VerifyPopupVisible(bool result)
        {
            var isPopupOpened = await RegistrationPopup.IsVisibleAsync();
            return isPopupOpened;
        }

        #region
        /*
        bad argument exception handling. In case of failure you have to debug what exactly parameter was null. What is the point to check parameters in this way? You can just skip checking, it will fail later and you will debug anyway

        this is not ArgumentException as rows are not arguments. It can be some NotFoundException or just Exception.

        again, very bad way to verify. In case something missing or all missing or several missing, you have to debug a test.
        Possible approach - find row by e-mail and return it's row.InnerTextAsync() (function name like GetFullRowTest(string email);)
        In the test compare with full expected string:
        var fullRowText = await GetFullRowTest("petrop@gmail.com");
        Assert that fullRowText is not null or empty
        Assert that fullRowText equal to expected full row string
        In this case output like this
        Expected: True but was False
        will be like
        Expected: "Petro Petrenko petrop@gmail.com ..." but found "Petro Symonenko petrop@gmail.com ..."
        */
        #endregion
        public async Task<bool> FindRowInTable(string firstName, string lastName, string email, string age, string salary, string department)
        {
            if (string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(lastName) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(age) ||
                string.IsNullOrWhiteSpace(salary) ||
                string.IsNullOrWhiteSpace(department))
            {
                throw new ArgumentException("One or more fields are empty.");
            }

            var rows = await Page.Locator("//div[@class=\"rt-tr-group\"]").AllAsync();

            if (rows == null || rows.Count == 0)
            {
                throw new ArgumentException("No rows found in the table.");
            }

            bool rowFound = false;

            foreach (var row in rows)
            {
                var rowText = await row.InnerTextAsync();

                if (rowText.Contains(firstName) &&
                    rowText.Contains(lastName) &&
                    rowText.Contains(email) &&
                    rowText.Contains(age) &&
                    rowText.Contains(salary) &&
                    rowText.Contains(department))
                {
                    rowFound = true;
                    break;
                }
            }
            return rowFound;
        }

        #region
        /*
        , string rowContent = "")
        should not be parameter, as it is not used as input values
        put it as first line inside functions as
        var rowContent = "";
        */
        #endregion
        public async Task<string> FindRowContentByEmail(string email, string rowContent = "")
        {
            if (string.IsNullOrWhiteSpace(email)) throw new Exception("Email field is empty.");

            var rows = await Page.Locator("//div[@class=\"rt-tr-group\"]").AllAsync();
            if (rows == null || rows.Count == 0) throw new Exception("No rows found in the table.");

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
    }
}
