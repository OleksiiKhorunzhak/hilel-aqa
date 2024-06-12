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
        public async Task SetupDemoQACheckBoxPage()
        {
            _demoQACheckBoxPage = new DemoQACheckBoxPage(Page);
            await _demoQACheckBoxPage.GoToDemoQaChecboxPage();
        }

        [Test]
        public async Task VerifyHomeCheckBoxCanBeChecked()
        {            
            await _demoQACheckBoxPage.CheckHomeCheckbox();
            await _demoQACheckBoxPage.VerifyHomeChecked();
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxCanBeChecked()
        {            
            await _demoQACheckBoxPage.OpenHomeNode();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");            
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxCanChecked1()
        {           
            await _demoQACheckBoxPage.OpenHomeNode();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            
            var documentsCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Documents");
            Assert.That(documentsCheck, "Documents checkbox unchecked");
                       
            var desktopCheck = await _demoQACheckBoxPage.VerifyCheckboxChecked("Desktop");
            Assert.That(desktopCheck, Is.False, "Desktop checkbox is also checked - it should be unvhecked");
        }

        //TODO: automate test cases
        //TC4 - Check Descktop Checkbox, verify checked
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        //TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        //TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
    }
}