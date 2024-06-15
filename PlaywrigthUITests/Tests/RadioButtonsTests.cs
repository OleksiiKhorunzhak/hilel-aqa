using Atata;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    internal class RadioButtonsTests : UITestFixture
    {
        private PO_RadioButtonPage _RadioButtonPage;

        [SetUp]
        public void SetupRadioButtonPage()
        {
            _RadioButtonPage = new PO_RadioButtonPage(Page);
        }

        [Test]
        [Description("Check 'Yes' radiobutton")]
        public async Task VerifyYesRadioButtn()
        {
            await _RadioButtonPage.GoToRadioButtonPage();
            await _RadioButtonPage.CheckYesRadioButton();
            await _RadioButtonPage.VerifyTextYesVisible();
        }
    }
}
