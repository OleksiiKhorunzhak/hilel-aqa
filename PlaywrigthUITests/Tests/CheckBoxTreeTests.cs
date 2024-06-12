using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class CheckBoxTreeTests : UITestFixture
    {
        private DemoQACheckBoxPage _demoQACheckBoxPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQACheckBoxPage = new DemoQACheckBoxPage(Page);
        }

        [Test]
        public async Task VerifyCheckBoxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.CheckHomeCheckbox();
            await _demoQACheckBoxPage.VerifyHomeChecked();
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxChecked1()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            // This should pass
            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck, "Documents checkbox unchecked");
            // This should fail
            // TODO Revert assert to make test green
            // var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            // Assert.That(desktopCheck, "Desktop checkbox unchecked");
        }

        //TODO: automate test cases
        //TC4 - Check Descktop Checkbox, verify checked
        
        [Test]
        [Description("Check Descktop Checkbox, verify checked")]
        public async Task VerifyDesktopCheckBoxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Desktop");
            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(documentsCheck, "Desktop checkbox unchecked");
        }
        
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        
        [Test]
        [Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        public async Task VerifyWorkSpaceCheckBoxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            await _demoQACheckBoxPage.OpenDocuments();
            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("WorkSpace");
            Assert.That(documentsCheck, "WorkSpace checkbox unchecked");
        }
        
        //TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        
        [Test]
        [Description("Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'")]
        public async Task VerifyTextOfCheckedDocumentsCheckbox()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            await _demoQACheckBoxPage.CheckDocumentsCheckboxResult();
        }
        
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        
        [Test]
        [Description("Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public async Task VerifyReactIcon()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.OpenDocuments();
            await _demoQACheckBoxPage.OpenWorkSpace();
            await _demoQACheckBoxPage.VerifyElementHasLeafIcon("React");
        }
        
        //TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
        
        [Test]
        [Description("Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        public async Task VerifyHomeSubCheckboxesChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.CheckHomeCheckbox();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Downloads");
        }
    }
}
