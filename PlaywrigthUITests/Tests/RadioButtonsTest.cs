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
        
        [Test]
        [Description("Verify No radio Button disabled and not show text 'You have selected'")]
        public async Task VerifyNoRadioButton()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.CheckNoRadioButton();
            await _radioButtonPage.VerifyTextNoVisible();
        }
        
        //TC-4 : Verify H1 Radio Button is visible
        
        [Test]
        [Description("Verify H1 Radio Button is visible")]
        public async Task VerifyH1RadioButton()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.CheckH1RadioButton();
        }
        
        //TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh
        
        [Test]
        [Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        public async Task VerifyImpressiveTextNotVisibleAfterRefresh()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickImpressiveRadioButton();
            await _radioButtonPage.CheckImpressiveRadioButton();
            await _radioButtonPage.VerifyTextImpressiveVisible();
            await Page.ReloadAsync();
            // Assert
            await _radioButtonPage.VerifyTextImpressiveNotVisible();
        }
    }
}
