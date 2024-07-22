using Microsoft.Playwright;

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
        public async Task VerifyAddPopupFieldsAreMandatory()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.ClickAddButton();

            await DemoQAWebTablesPage.VerifyPopupVisible();
            await DemoQAWebTablesPage.ClickSubmitButton();

            List<string> fieldIDs = new List<string>
            { "age", "department", "firstName", "lastName", "userEmail", "salary" };

            int randomIndex = new Random().Next(6);
            var elementToCheck = DemoQAWebTablesPage.GetPopupInput(fieldIDs[randomIndex]);
            var actualColor = await DemoQAWebTablesPage.GetPopupInputColor(elementToCheck);
            Thread.Sleep(150);

            Assert.That(actualColor, Is.EqualTo("rgb(220, 53, 69)"));
        }

        [Test]
        public async Task VerifyAddRow()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();
            await DemoQAWebTablesPage.ClickAddButton();           

            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("firstName"), "FN");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("lastName"), "LN");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("userEmail"), "test@test.com");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("salary"), "4500");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("age"), "45");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("department"), "Dep");

            await DemoQAWebTablesPage.ClickSubmitButton();

            await Assertions.Expect(DemoQAWebTablesPage.GetRowByFirstNameValue("FN")).ToBeVisibleAsync();
        }

        [Test]
        public async Task VerifyEditRow()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();

            await DemoQAWebTablesPage.ClickEditRowButton(DemoQAWebTablesPage.GetRowByFirstNameValue("Cierra"));

            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("firstName"), "FN");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("lastName"), "LN");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("userEmail"), "test@test.com");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("salary"), "4500");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("age"), "45");
            await DemoQAWebTablesPage.FillInPopupField(DemoQAWebTablesPage.GetPopupInput("department"), "Dep");

            await DemoQAWebTablesPage.ClickSubmitButton();

            await Assertions.Expect(DemoQAWebTablesPage.GetRowByFirstNameValue("FN")).ToBeVisibleAsync();
            await Assertions.Expect(DemoQAWebTablesPage.GetRowByFirstNameValue("Cierra")).ToBeHiddenAsync();          
        }

        [Test]
        public async Task VerifyDeleteRow()
        {
            await DemoQAWebTablesPage.GoToDemoQaWebTablesPage();

            await DemoQAWebTablesPage.ClickDeleteRowButton(DemoQAWebTablesPage.GetRowByFirstNameValue("Cierra"));    
           
            await Assertions.Expect(DemoQAWebTablesPage.GetRowByFirstNameValue("Cierra")).ToBeHiddenAsync();
        }
    }
}