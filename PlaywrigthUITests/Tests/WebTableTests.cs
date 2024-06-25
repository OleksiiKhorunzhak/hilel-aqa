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
        public async Task VerifyCheckBoxChecked()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.CheckTableVisible();
        }

               //TODO: automate test cases
    }
}
