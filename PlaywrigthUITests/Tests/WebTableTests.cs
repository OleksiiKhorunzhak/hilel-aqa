using Microsoft.Playwright;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class WebTableTests : UITestFixture
    {
        private DemoQAWebTablesPage DemoQAWebTablesPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            DemoQAWebTablesPage = new DemoQAWebTablesPage(Page);
        }

        [Test]
        public async Task VerifyTableVisible()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            //await DemoQAWebTablesPage.VerifyTableRowContent();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Vega");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        [Test]
        public async Task VerifyTableVisible2()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.VerifyTableRowContent("Last Name", "Cantrell");

            await Page.GetByRole(AriaRole.Button, new() { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.VerifyFirstNameVisible();
        }

        //TODO: automate test cases
        //Check any mandatory field
        //Add new row and verify row added
        //Edit row and verify row edited
        //Delete row and verify row deleted

    }
}
