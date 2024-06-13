using Atata;
using NUnit.Framework.Internal;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    internal class CheckBoxTests : UITestFixture
    {
        private PO_CheckBoxPage _CheckBoxPage;

        [SetUp]
        public void SetupCheckBoxPage()
        {
            _CheckBoxPage = new PO_CheckBoxPage(Page);
        }

        [Test]
        public async Task VerifyHomeTreeItems()
        {
            await _CheckBoxPage.GoToPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.VerifyPageTitle("Check Box");
            await _CheckBoxPage.ClickParentToggle();
            await _CheckBoxPage.VerifyCheckboxVisability("Desktop");
            await _CheckBoxPage.VerifyCheckboxVisability("Documents");
            await _CheckBoxPage.VerifyCheckboxVisability("Downloads");
            await _CheckBoxPage.ClickCheckbox("Home");
            await _CheckBoxPage.VerifyCheckboxChecked("Home");
            await _CheckBoxPage.VerifyCheckboxChecked("Desktop");
            await _CheckBoxPage.VerifyCheckboxChecked("Documents");
            await _CheckBoxPage.VerifyCheckboxChecked("Downloads");
            await _CheckBoxPage.UncheckCheckbox("Desktop");
            await _CheckBoxPage.UncheckCheckbox("Documents");
            await _CheckBoxPage.UncheckCheckbox("Downloads");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Desktop");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Documents");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Downloads");

        }

        [Test]
        [Description("Verify First Child items tree")]
        public async Task VerifyFirstChildItems()
        {
            await _CheckBoxPage.GoToPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.ClickParentToggle();
            await _CheckBoxPage.ClickToggle("Desktop");
            await _CheckBoxPage.ClickToggle("Documents");
            await _CheckBoxPage.ClickToggle("Downloads");
        }

        [Test]
        [Description("Verify Second Child items tree")]
        public async Task VerifySecondChildItems()
        {
            await _CheckBoxPage.GoToPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.ClickParentToggle();
            await _CheckBoxPage.ClickToggle("Documents");
            await _CheckBoxPage.ClickToggle("WorkSpace");
            await _CheckBoxPage.ClickToggle("Office");
        }
    }
}
