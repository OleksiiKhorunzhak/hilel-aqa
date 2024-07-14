using PlaywrigthUITests.PageObjects;
using Microsoft.Playwright;
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
        }

        //TODO: automate test cases
        //TC4 - Check Descktop Checkbox, verify checked
        [Test, Retry(2)]
        [Description("Expand Home > Check Desktop Checkbox, verify checked")]
        [Category("UI")]
        public async Task VerifyDesktopCheckboxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Desktop");
            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck, "Desktop checkbox unchecked");
        }

        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        [Test, Retry(2)]
        [Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        [Category("UI")]
        public async Task VerifyWorkSpaceCheckboxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            await _demoQACheckBoxPage.OpenCheckbox("Documents");
            var WorkspaceCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("WorkSpace");
            Assert.That(WorkspaceCheck, "WorkSpace checkbox unchecked");
        }
        //TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        [Test, Retry(2)]
        [Description("Expand Home > Check Documents. Verify text 'You have selected :" +
           " documents workspace react angular veu office public private classified general")]
        [Category("UI")]
        public async Task VerifyTextAFterDocumentsCheckboxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            await _demoQACheckBoxPage.CheckTextAFterDocumentsCheckboxChecked("You have selected :documentsworkspacereactangularveuofficepublicprivateclassifiedgeneral");
        }
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        [Test, Retry(2)]
        [Description("Expand Home > Documents > WorkSpace, verify React have rct  icon-leaf-close icon")]
        [Category("UI")]
        public async Task VerifyReactChIcon()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.OpenHome();
            await _demoQACheckBoxPage.OpenCheckbox("Documents");
            await _demoQACheckBoxPage.OpenCheckbox("WorkSpace");
            await _demoQACheckBoxPage.CheckPicture("React");
        }
        //TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
        [Test, Retry(2)]
        [Description("Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        [Category("UI")]
        public async Task VerifyDesktopDocumentsDownloadsCheckboxChecked()
        {
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
            await _demoQACheckBoxPage.CheckHomeCheckbox();
            await _demoQACheckBoxPage.OpenHome();
            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck, "Desktop checkbox unchecked");
            var DocumentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(DocumentsCheck, "Documents checkbox unchecked");
            var DownloadsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Downloads");
            Assert.That(DownloadsCheck, "Downloads checkbox unchecked");

        }



    }
}
