using Microsoft.Playwright;
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
            await _demoQACheckBoxPage.ClickCheckbox("Documents");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxChecked1()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.ClickCheckbox("Documents");
            // This should pass
            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck, "Documents checkbox unchecked");
            // This should fail
            // TODO Revert assert to make test green
            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck, "Desktop checkbox unchecked");
        }

        //TODO: Homework lesson_10 Check_box

        //TC4 - Check Descktop Checkbox, verify checked
        [Test, Description("Check Descktop Checkbox, verify checked")]
        public async Task VerifyThatDescktopCheckboxIsChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.ClickCheckbox("Desktop");

            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck, "Desktop checkbox is checked");
        }

        [Test, Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        public async Task VerifyThatDocumnetsAndWorkSpaceCheckboxIsChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.ClickCheckbox("Documents");

            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck);

            await _demoQACheckBoxPage.ExpandDocumentsTree();

            var workspaceCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("WorkSpace");
            Assert.That(workspaceCheck);
        }

        [Test, Description ("Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general")]
        public async Task VerifyTextWhenClickOnDocumentsCheckbox()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.ClickCheckbox("Documents");
            await _demoQACheckBoxPage.VerifyTextAfterClickOnCheckBox("Documents");
        }

        [Test, Description("Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public async Task VerifyReactElementHasCloseIcon()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.ClickCheckbox("Documents");

            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck);

            await _demoQACheckBoxPage.ExpandDocumentsTree();
            await _demoQACheckBoxPage.ClickToggleByName("WorkSpace");

            ///await _demoQACheckBoxPage.ClickCheckbox("React");
            await _demoQACheckBoxPage.VerifyCheckBoxHasCloseIcon("React");
        }

        [Test, Description("Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxes checked")]
        public async Task VerifyThatDesktopDocumentsDownloadsCheckboxesChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.ClickCheckbox("Home");
            await _demoQACheckBoxPage.OpenHome();

            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck);

            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck);

            var downloadsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Downloads");
            Assert.That(downloadsCheck);

        }


    }
}
