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

            await _CheckBoxPage.VerifyCheckboxVisability("Notes");
            await _CheckBoxPage.VerifyCheckboxVisability("Commands");
            await _CheckBoxPage.VerifyCheckboxVisability("WorkSpace");
            await _CheckBoxPage.VerifyCheckboxVisability("Office");
            await _CheckBoxPage.VerifyCheckboxVisability("Word File.doc");
            await _CheckBoxPage.VerifyCheckboxVisability("Excel File.doc");

            await _CheckBoxPage.ClickCheckbox("Desktop");
            await _CheckBoxPage.ClickCheckbox("Documents");
            await _CheckBoxPage.ClickCheckbox("Downloads");

            await _CheckBoxPage.VerifyCheckboxChecked("Notes");
            await _CheckBoxPage.VerifyCheckboxChecked("Commands");
            await _CheckBoxPage.VerifyCheckboxChecked("WorkSpace");
            await _CheckBoxPage.VerifyCheckboxChecked("Office");
            await _CheckBoxPage.VerifyCheckboxChecked("Word File.doc");
            await _CheckBoxPage.VerifyCheckboxChecked("Excel File.doc");

            await _CheckBoxPage.UncheckCheckbox("Notes");
            await _CheckBoxPage.UncheckCheckbox("Commands");
            await _CheckBoxPage.UncheckCheckbox("WorkSpace");
            await _CheckBoxPage.UncheckCheckbox("Office");
            await _CheckBoxPage.UncheckCheckbox("Word File.doc");
            await _CheckBoxPage.UncheckCheckbox("Excel File.doc");

            await _CheckBoxPage.VerifyCheckboxUnchecked("Notes");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Commands");
            await _CheckBoxPage.VerifyCheckboxUnchecked("WorkSpace");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Office");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Word File.doc");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Excel File.doc");
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

            await _CheckBoxPage.VerifyCheckboxVisability("React");
            await _CheckBoxPage.VerifyCheckboxVisability("Angular");
            await _CheckBoxPage.VerifyCheckboxVisability("Veu");
            await _CheckBoxPage.VerifyCheckboxVisability("Public");
            await _CheckBoxPage.VerifyCheckboxVisability("Private");
            await _CheckBoxPage.VerifyCheckboxVisability("Classified");
            await _CheckBoxPage.VerifyCheckboxVisability("General");

            await _CheckBoxPage.ClickCheckbox("WorkSpace");
            await _CheckBoxPage.ClickCheckbox("Office");

            await _CheckBoxPage.VerifyCheckboxChecked("React");
            await _CheckBoxPage.VerifyCheckboxChecked("Angular");
            await _CheckBoxPage.VerifyCheckboxChecked("Veu");
            await _CheckBoxPage.VerifyCheckboxChecked("Public");
            await _CheckBoxPage.VerifyCheckboxChecked("Private");
            await _CheckBoxPage.VerifyCheckboxChecked("Classified");
            await _CheckBoxPage.VerifyCheckboxChecked("General");

            await _CheckBoxPage.UncheckCheckbox("React");
            await _CheckBoxPage.UncheckCheckbox("Angular");
            await _CheckBoxPage.UncheckCheckbox("Veu");
            await _CheckBoxPage.UncheckCheckbox("Public");
            await _CheckBoxPage.UncheckCheckbox("Private");
            await _CheckBoxPage.UncheckCheckbox("Classified");
            await _CheckBoxPage.UncheckCheckbox("General");

            await _CheckBoxPage.VerifyCheckboxUnchecked("React");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Angular");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Veu");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Public");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Private");
            await _CheckBoxPage.VerifyCheckboxUnchecked("Classified");
            await _CheckBoxPage.VerifyCheckboxUnchecked("General"); ;
        }
    }
}
