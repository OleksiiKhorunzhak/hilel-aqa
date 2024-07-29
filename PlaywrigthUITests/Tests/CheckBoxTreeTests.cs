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
            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck, "Desktop checkbox unchecked");
        }

        //TODO: automate test cases
        //TC4 - Check Descktop Checkbox, verify checked
        [Test]
        [Description("Check Desktop Checkbox, verify checked")]
        public async Task VerifyDesktopCheckboxChecked()
        {
            //Given I go to the DemoQa Checkbox page
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            //When I open the 'Home' menu
            await _demoQACheckBoxPage.OpenHome();
            //And I click the 'Desktop' checkbox
            await _demoQACheckBoxPage.CheckCheckbox("Desktop");
            //Then I see the 'Desktop' checkbox is checked
            Assert.That(await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop"), "Desktop checkbox is not checked");
        }
        
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        [Test]
        [Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        public async Task VerifyWorkSpaceCheckboxChecked()
        {
            //Given I go to the DemoQa Checkbox page
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            //When I open the 'Home' menu
            await _demoQACheckBoxPage.OpenHome();
            //And I open the 'Documents' menu
            await _demoQACheckBoxPage.OpenDocuments();
            //And I click the 'Documents' checkbox
            await _demoQACheckBoxPage.CheckDocuments();
            //Then I see the 'WorkSpace' checkbox is checked
            Assert.That(await _demoQACheckBoxPage.VerifyCheckboxChecked("WorkSpace"), "WorkSpace checkbox is not checked");
        }
        
        //TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        [Test]
        [Description("Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'")]
        public async Task VerifyDocumentSelectedText()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            //And I open the 'Documents' menu
            await _demoQACheckBoxPage.OpenHome();
            //And I click the 'Documents' checkbox
            await _demoQACheckBoxPage.CheckDocuments();
            //And I see the document text result
            await _demoQACheckBoxPage.VerifyDocumentSelectedText();
            
        }
        
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        [Test]
        [Description("Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public async Task VerifyReactIcon()
        {
            //Given I go to the DemoQa Checkbox page
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            //And I open the 'Home' menu
            await _demoQACheckBoxPage.OpenHome();
            //And I open the 'Documents' menu
            await _demoQACheckBoxPage.OpenDocuments();
            //And I open the 'WorkSpace' menu
            await _demoQACheckBoxPage.OpenWorkSpace();
            //Then I see the 'React' item has an icon
            await _demoQACheckBoxPage.VerifyReactIcon("React"); 
            Assert.That(VerifyReactIcon, Is.True, "React icon is not visible");
        }
        
        //TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
        [Test]
        [Description("Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxes checked")]
        public async Task VerifyHomeCheckboxChecked()
        {
            //Given I go to the DemoQa Checkbox page
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            //When I click the 'Home' checkbox
            await _demoQACheckBoxPage.CheckCheckbox("Home");
            //And I open the 'Home' menu
            await _demoQACheckBoxPage.OpenHome();
            //Then I see the 'Desktop' checkbox is checked 
            Assert.That(await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop"), "Desktop checkbox is not checked");
            //And I see the 'Documents' checkbox is checked
            Assert.That(await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents"), "Documents checkbox is not checked");
            //And I see the 'Downloads' checkbox is checked
            Assert.That(await _demoQACheckBoxPage.VerifyCheckboxChecked("Downloads"), "Downloads checkbox is not checked");
        }
    }
}
