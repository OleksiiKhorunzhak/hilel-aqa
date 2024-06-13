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
            await _demoQACheckBoxPage.IsCheckboxChecked("Documents");            
        }

        [Test]
        public async Task VerifyDocumentsCheckBoxCanChecked1()
        {           
            await _demoQACheckBoxPage.OpenHomeNode();
            await _demoQACheckBoxPage.CheckCheckbox("Documents");
            
            var documentsCheck = await _demoQACheckBoxPage.IsCheckboxChecked("Documents");
            Assert.That(documentsCheck, "Documents checkbox unchecked");
                       
            var desktopCheck = await _demoQACheckBoxPage.IsCheckboxChecked("Desktop");
            Assert.That(desktopCheck, Is.False, "Desktop checkbox is also checked - it should be unvhecked");
        }

        //HW
        [Test, Description ("TC4 - Check Desktop checkbox, verify checked")]
        public async Task VerifyDesktopCheckBoxCanChecked()
        {
            await _demoQACheckBoxPage.OpenHomeNode();
            await _demoQACheckBoxPage.CheckCheckbox("Desktop");
           
            Assert.That(await _demoQACheckBoxPage.IsCheckboxChecked("Desktop"), "Desktop checkbox unchecked");
        }

        [Test, Description("TC5 - Expand Home > Documents, check Documents Checkbox. Verify WorkSpace checked")]
        public async Task VerifyWorkSpaceCheckedIfDocumentsChecked()
        {
            await _demoQACheckBoxPage.OpenNode("Home");
            await _demoQACheckBoxPage.OpenNode("Documents");
            await _demoQACheckBoxPage.CheckCheckbox("Documents");         

            Assert.That(await _demoQACheckBoxPage.IsCheckboxChecked("WorkSpace"));
        }                

        [Test, Description("TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'")]
        public async Task VerifyDocumentsCheckedTextIsShown()
        {
            await _demoQACheckBoxPage.OpenNode("Home");
            await _demoQACheckBoxPage.CheckCheckbox("Documents");

            Assert.That(await _demoQACheckBoxPage.DocumentsCheckedTextIsShown());
        }

        [Test, Description("TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public async Task VerifReactCheckboxIcon()
        {
            await _demoQACheckBoxPage.OpenNode("Home");
            await _demoQACheckBoxPage.OpenNode("Documents");
            await _demoQACheckBoxPage.OpenNode("WorkSpace");           

            Assert.That(await _demoQACheckBoxPage.IsFileIconShown("React"));
        }        

        [Test, Description("TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        public async Task VerifyChildCheckboxesCheckedIfHomeChecked()
        {
            await _demoQACheckBoxPage.OpenNode("Home");
            await _demoQACheckBoxPage.CheckCheckbox("Home");           

            Assert.That(await _demoQACheckBoxPage.IsCheckboxChecked("Desktop"));
            Assert.That(await _demoQACheckBoxPage.IsCheckboxChecked("Documents"));
            Assert.That(await _demoQACheckBoxPage.IsCheckboxChecked("Downloads"));
        }
    }
}