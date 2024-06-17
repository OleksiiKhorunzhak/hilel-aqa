using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        //TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        //TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
    }
}
