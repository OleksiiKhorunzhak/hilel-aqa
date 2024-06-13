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
            //Preconditions:
            await _CheckBoxPage.GoToPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.VerifyPageTitle("Check Box");
            await _CheckBoxPage.ClickParentToggle();

            // Define a list of checkbox labels
            List<string> checkboxLabels = new List<string>
            {
                "Home","Desktop","Documents","Downloads"
            };

            // Iterate through each label and verify the checkbox is checked
            foreach (var label in checkboxLabels)
            {
                await _CheckBoxPage.ClickCheckbox(label);
                await _CheckBoxPage.VerifyCheckboxVisability(label);
                await _CheckBoxPage.VerifyCheckboxChecked(label);
                await _CheckBoxPage.UncheckCheckbox(label);
                await _CheckBoxPage.VerifyCheckboxUnchecked(label);
            }
        }

        [Test]
        [Description("Verify First Child items tree")]
        public async Task VerifyFirstChildItems()
        {
            //Preconditions:
            await _CheckBoxPage.GoToPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.ClickParentToggle();

            // Define a list of Parent checkbox labels
            List<string> checkboxParentLabels = new List<string>
            {
                "Desktop","Documents","Downloads"
            };
            // Iterate through each label and verify the checkbox is checked
            foreach (var parentLabel in checkboxParentLabels)
            {
                await _CheckBoxPage.ClickToggle(parentLabel);
                await _CheckBoxPage.ClickCheckbox(parentLabel);
            }
            // Define a list of Child checkbox labels
            List<string> checkboxChildLabels = new List<string>
            {
                "Notes","Commands","WorkSpace","Office","Word File.doc","Excel File.doc"
            };
            // Iterate through each label and verify the checkbox is checked
            foreach (var childLabel in checkboxChildLabels)
            {
                await _CheckBoxPage.VerifyCheckboxVisability(childLabel);
                await _CheckBoxPage.VerifyCheckboxChecked(childLabel);
                await _CheckBoxPage.UncheckCheckbox(childLabel);
                await _CheckBoxPage.VerifyCheckboxUnchecked(childLabel);
            }
        }

        [Test]
        [Description("Verify Second Child items tree")]
        public async Task VerifySecondChildItems()
        {
            //Preconditions:
            await _CheckBoxPage.GoToPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.ClickParentToggle();
            await _CheckBoxPage.ClickToggle("Documents");

            // Define a list of Parent checkbox labels
            List<string> checkboxParentLabels = new List<string>
            {
                "WorkSpace","Office"
            };

            // Iterate through each label and verify the checkbox is checked
            foreach (var parentLabel in checkboxParentLabels)
            {
                await _CheckBoxPage.ClickToggle(parentLabel);
                await _CheckBoxPage.ClickCheckbox(parentLabel);
            }

            // Define a list of Child checkbox labels
            List<string> checkboxLabels = new List<string>
            {
                "React","Angular","Veu","Public","Private","Classified","General"
            };

            // Iterate through each label and verify the checkbox is checked
            foreach (var childLabel in checkboxLabels)
            {
                await _CheckBoxPage.VerifyCheckboxVisability(childLabel);
                await _CheckBoxPage.VerifyCheckboxChecked(childLabel);
                await _CheckBoxPage.UncheckCheckbox(childLabel);
                await _CheckBoxPage.VerifyCheckboxUnchecked(childLabel);
            }
        }
    }
}
