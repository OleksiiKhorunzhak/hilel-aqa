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
            await _CheckBoxPage.GoToTestedPage("https://demoqa.com/checkbox");
            await _CheckBoxPage.VerifyPageTitle("Check Box");
            await _CheckBoxPage.ClickToggle();
            await _CheckBoxPage.VerifyToggleClicked();
            await _CheckBoxPage.ClickHomeCheckbox();
            await _CheckBoxPage.VerifyHomeChecked();
            await _CheckBoxPage.VerifyHomeChildChecked("Desktop");
            await _CheckBoxPage.VerifyHomeChildChecked("Documents");
            await _CheckBoxPage.VerifyHomeChildChecked("Downloads");
            await _CheckBoxPage.UncheckHomeChild("Desktop");
            await _CheckBoxPage.UncheckHomeChild("Documents");
            await _CheckBoxPage.UncheckHomeChild("Downloads");
            await _CheckBoxPage.VerifyHomeChildUnchecked("Desktop");
            await _CheckBoxPage.VerifyHomeChildUnchecked("Documents");
            await _CheckBoxPage.VerifyHomeChildUnchecked("Downloads");
        }
    }
}
