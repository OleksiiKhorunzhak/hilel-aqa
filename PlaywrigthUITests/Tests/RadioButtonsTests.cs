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
        //Homework Lesson_9
        //TODO : 
        //TC-2 : Verify Impressive radio Button can be checked and display text 'You have selected Impressive'
        //[Test]
        //[Description("Verify Impressive radio Button can be checked and display text 'You have selected Impressive'")]
        //public async Task isImpressiveRadioButtonChecked()
        //{
        //    await _radioButtonPage.GoToRadiButtonsPage();
        //    await _radioButtonPage.
        //}

        //TC-3 : Verify No radio Button disabled and not show text 'You have selected'
        //TC-4 : Verify H1 Radio Button is visible
        //TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh


    }
}
