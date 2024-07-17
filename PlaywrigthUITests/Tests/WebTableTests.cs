using Microsoft.Playwright;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    //[Category("WebTable)]
    internal class WebTableTests : UITestFixture
    {
        private WebTablesPage _WebTablesPage;

        #region TEST DATA:
        //Page:
        private readonly string testPageUrl = "https://demoqa.com/webtables";
        private readonly string testPageH1 = "Web Tables";
        //Labels:
        //Inputs:
        #endregion

        [SetUp]
        public void SetupDemoQAPage() => _WebTablesPage = new WebTablesPage(page);

        [Test, Retry(2)]
        [Description("H1 'Web Tables' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _WebTablesPage.GoToURL(testPageUrl);
            await _WebTablesPage.IsPageH1Visible(testPageH1);
        }

        [Test]
        public async Task VerifyTableVisible()
        {
            await _WebTablesPage.GoToURL(testPageUrl);
            //await WebTablesPage.VerifyTableRowContent();
            await _WebTablesPage.VerifyTableRowContent("Last Name", "Vega");
            await page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await _WebTablesPage.VerifyPopupVisible();
            await _WebTablesPage.VerifyFirstNameVisible();
        }

        [Test]
        public async Task VerifyTableVisible2()
        {
            await _WebTablesPage.GoToURL(testPageUrl);
            await _WebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");

            await page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await _WebTablesPage.VerifyPopupVisible();
            await _WebTablesPage.VerifyFirstNameVisible();
        }

        //TODO: automate test cases
        //Check any mandatory field
        //Add new row and verify row added
        //Edit row and verify row edited
        //Delete row and verify row deleted
    }
}
