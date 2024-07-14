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
        //TC-2 : Verify Impressive radio Button can be checked and display text 'You have selected Impressive'
        [Test]
        [Description("Verify Impressive radio Button can be checked and display text 'You have selected Impressive'")]
        public async Task VerifyImpressiveRadioButton()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickImpressiveRadioButton();
            await _radioButtonPage.CheckImpressiveRadioButton();
            await _radioButtonPage.VerifyTextImpressiveVisible();
        }

        //TC-3 : Verify No radio Button disabled and not show text 'You have selected'
        [Test, Retry(2)]
        [Description("Verify No radio Button disabled and not show text 'You have selected'")]
        [Category("RadioButtonTest")]
        public async Task VerifyNoRadioButtonDisabled()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.CheckNoRadioDisabled();
        }
        //TC-4 : Verify H1 Radio Button is visible
        [Test, Retry(2)]
        [Description("Verify H1 Radio Button is visible")]
        [Category("RadioButtonTest")]
        public async Task VerifyH1RadioButtonIsVisible()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.H1Visible();
        }
        //TC-5 : Verify text 'You have selected Impressive' is not visible after Page refresh
        [Test, Retry(2)]
        [Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        [Category("RadioButtonTest")]
        public async Task VerifyImpressiveRadioButtonIsNotVisibleAfterRefresh()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickImpressiveRadioButton();
            await _radioButtonPage.CheckImpressiveRadioButton();
            await _radioButtonPage.VerifyTextImpressiveVisible();
            await _radioButtonPage.ReloadRadiButtonsPage();
            await _radioButtonPage.VerifyTextImpressiveHidden();

        }
    }
}
