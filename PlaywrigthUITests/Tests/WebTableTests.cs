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
            await DemoQAWebTablesPage.VerifyTableVisible();
            await DemoQAWebTablesPage.VerifyTableRowsVisible();                             
        }

        [Test]
        public async Task VerifyAddPopupAllFieldsAreMandatory()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await Page.GetByRole(AriaRole.Button, new () { Name = "Add" }).ClickAsync();
            await DemoQAWebTablesPage.VerifyPopupVisible();

            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();

        }

        [Test]
        public void VerifyAddPopupAllFieldsAreMandatory()
        {
            var page = Go.To<DemoQAWebTablePage>().Add.Click().AddPopup.Submit.Click();

            foreach (var input in page.AddPopup.TextFields)
            {
                input.Css["border-color"].Should.Be("rgb(220, 53, 69)");
            }
        }

       
    }
}