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
            // Given I go to DemoQa Radio buttons page
            await _radioButtonPage.GoToRadiButtonsPage();
            // When I Click the Impressive radio button
            await _radioButtonPage.ClickImpressiveRadioButton();
            // Then I see Impressive radio button is checked
            await _radioButtonPage.CheckImpressiveRadioButton();
            // Then I see 'You have selected Impressive' text
            await _radioButtonPage.VerifyTextImpressiveVisible();
        }

        //TC-3 : Verify No radio Button disabled and not show text 'You have selected'
        [Test]
        [Description("Verify No radio Button disabled and not show text 'You have selected")]
        public async Task VerifyNoRadioButton()
        {
            // Given I go to DemoQa Radio buttons page
            await _radioButtonPage.GoToRadiButtonsPage();
            // Then I see No radio button is disabled
            await _radioButtonPage.CheckNoRadioButtonDisabled();
            // Then I see 'You have selected No' text is not visible
            await _radioButtonPage.VerifyTextNoNotVisible();
        }
        
        //TC-4 : Verify H1 Radio Button is visible
        [Test]
        [Description("Verify H1 title Radio Button is visible")]
        public async Task VerifyH1RadioButtonVisible()
        {
            // Given I go to DemoQa Radio buttons page
            await _radioButtonPage.GoToRadiButtonsPage();
            // Then I see H1 title Radio Button is visible
            await _radioButtonPage.VerifyH1RadioButtonVisible();
        }
        
        //TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh
        [Test]
        [Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        public async Task VerifyImpressiveTextNotVisibleAfterRefresh()
        {
            // Given I go to DemoQa Radio buttons page
            await _radioButtonPage.GoToRadiButtonsPage();
            // When I Click the Impressive radio button
            await _radioButtonPage.ClickImpressiveRadioButton();
            // And I refresh the page
            await Page.ReloadAsync();
            // Then I see 'You have selected Impressive' text is not visible
            await _radioButtonPage.VerifyTextImpressiveNotVisible();
        }
    }
}
