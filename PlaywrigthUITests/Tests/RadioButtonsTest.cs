using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class RadioButtonsTest : UITestFixture
    {
        private DemoQARadioButtonPage _radioButtonPage;

        [SetUp]
        public void SetupRadioButtonQAPage()
        {
            _radioButtonPage = new DemoQARadioButtonPage(Page);
        }

        [Test]
        [Description("Verify Yes radio Button can be checked and display text You have selected Yes")]
        public async Task VerifyTextFullName()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickYesRadioButton();
            await _radioButtonPage.CheckYesRadioChecked();
            await _radioButtonPage.VerifyTextYesVisible();
        }

        //Homework Lesson_9
        //TODO : 

        [Test]
        [Description("Verify Impressive radio Button can be checked and display text 'You have selected Impressive'")]
        public async Task VerifyImpressiveRadioButton()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickImpressiveRadioButton();
            await _radioButtonPage.CheckImpressiveRadioButton();
            await _radioButtonPage.VerifyTextImpressiveButtonIsVisible();
        }

        [Test, Description("Verify No radio Button disabled and not show text 'You have selected'")]
        public async Task VerifyNoButtonIsDisabled()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickNoRadioButton();
            await _radioButtonPage.VerifyNoButtonIsDisabled();
            await _radioButtonPage.VerifyTextNoIsNotVisible();
        }

        [Test, Description("Verify H1 Radio Button is visible")]
        public async Task VerifyTitleOfRadioButtonPage()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.CheckTitleOfRadioButtonPage();
        }

        [Test, Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        public async Task VerifyTextOfImpressiveButtonIsNotVisibleAfrePageRefresh()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickImpressiveRadioButton();
            await _radioButtonPage.CheckImpressiveRadioButton();
           // await _radioButtonPage.VerifyTextImpressiveButtonIsVisible(); Oleksiy do we need this Verification step in this test?
            await _radioButtonPage.RefreshPage();
            await _radioButtonPage.VerifyTextImpressiveButtonIsVisible();
        }


    }
}
