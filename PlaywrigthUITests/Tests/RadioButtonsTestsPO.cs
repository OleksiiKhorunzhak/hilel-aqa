using Atata;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    internal class RadioButtonsTestsPO : UITestFixture
    {
        private DemoQARadioButtonPage _radioButtonPage;

        [SetUp]
        public void SetupRadioButtonPage()
        {
            _radioButtonPage = new DemoQARadioButtonPage(Page);
        }

        [Test]
        [Description("Check 'Yes' radiobutton")]
        public async Task VerifyYesRadioButtn()
        {
            await _radioButtonPage.GoToRadioButtonPage();
            await _radioButtonPage.CheckYesRadioButton();
            await _radioButtonPage.VerifyTextYesVisible();
        }
    }
}
