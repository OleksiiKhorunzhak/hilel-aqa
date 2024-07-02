using Atata;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    //[Category("RadioButtonsTests")]
    internal class RadioButtonsTests : UITestFixture
    {
        private PO_RadioButtonPage _RadioButtonPage;

        [SetUp]
        public void SetupRadioButtonPage()
        {
            _RadioButtonPage = new PO_RadioButtonPage(Page);
        }

        //TEST DATA:_______________________________________

        //Page:
        private readonly string testPageUrl = "https://demoqa.com/radio-button";
        private readonly string testPageH1 = "Radio Button";
        //Labels:
        //Inputs:
        private readonly string yesRadioId = "#yesRadio";
        private readonly string impressiveRadioId = "#impressiveRadio";
        private readonly string noRadioId = "#noRadio";
        //_________________________________________________

        [Test, Retry(2)]
        [Description("H1 'Text Box' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _RadioButtonPage.GoToURL(testPageUrl);
            await _RadioButtonPage.IsPageH1Visible(testPageH1);
        }

        [Test, Retry(2)]
        [Description("Verify 'Yes' radiobutton can be checked and success text 'You have selected Yes' is displayed")]
        public async Task VerifyYesRadioButton()
        {
            await _RadioButtonPage.GoToURL(testPageUrl);
            await _RadioButtonPage.IsRadioButtonVisible(yesRadioId);
            await _RadioButtonPage.IsRadioButtonEnabled(yesRadioId);
            await _RadioButtonPage.CheckRadioButton("Yes");
            await _RadioButtonPage.IsRadioButtonChecked(yesRadioId);
            await _RadioButtonPage.IsSuccessTextVisible("You have selected Yes");
        }

        [Test, Retry(2)]
        [Description("Verify 'Impressive' radiobutton can be checked and success text 'You have selected Impressive' is displayed")]
        public async Task VerifyImpressiveRadioButton()
        {
            await _RadioButtonPage.GoToURL(testPageUrl);
            await _RadioButtonPage.IsRadioButtonVisible(impressiveRadioId);
            await _RadioButtonPage.IsRadioButtonEnabled(impressiveRadioId);
            await _RadioButtonPage.CheckRadioButton("Impressive");
            await _RadioButtonPage.IsRadioButtonChecked(impressiveRadioId);
            await _RadioButtonPage.IsSuccessTextVisible("You have selected Impressive");
        }

        [Test, Retry(2)]
        [Description("Verify 'No' radiobutton is disabled and not show text 'You have selected")]
        public async Task VerifyNoRadioButton()
        {
            await _RadioButtonPage.GoToURL(testPageUrl);
            await _RadioButtonPage.IsRadioButtonVisible(noRadioId);
            await _RadioButtonPage.IsRadioButtonDisabled(noRadioId);
            //await _RadioButtonPage.CheckRadioButton("No");
            await _RadioButtonPage.IsRadioButtonNotChecked(noRadioId);
            await _RadioButtonPage.IsSuccessTextNotVisible("You have selected No");
        }

        //Homework Lesson_9
        //TODO need to be finished: 
        //TC-5 : Verify text 'You have selected Impressive' is not visible after Page refresh

    }
}
