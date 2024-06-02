using Microsoft.Playwright;
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
        public async Task VerifyYesRadioButtonSelectedTextRow()
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
        public async Task VerifyImpressiveRadioButtonSelectedTextRow()
        {
            await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.ClickImpressiveRadioButton();
			await _radioButtonPage.CheckImpressiveRadioButton();
			await _radioButtonPage.VerifySelectedImpressiveButtonTextRow();
        }

		//TC-3 : Verify No radio Button disabled and not show text 'You have selected'
		[Test]
		[Description("Verify No radio Button disabled and not show text 'You have selected'")]
		public async Task VerifyNoRadioButtonSelectedTextRowNotVisible()
		{
			await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.CheckNoRadioButtonIsDisabled();
			//await _radioButtonPage.ClickNoRadioButton(); - Impossible to click disabled button?!
			await _radioButtonPage.VerifySelectedTextRowNotExists();
		}

		//TC-4 : Verify H1 Radio Button is visible
		[Test]
		[Description("Verify H1 Radio Button is visible")]
		public async Task VerifyRadioButtonHeaderVisiblity()
		{
			await _radioButtonPage.GoToRadiButtonsPage();
            await _radioButtonPage.CheckHeaderRadioButtonVisible();
		}

		//TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh
		[Test]
		[Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
		public async Task VerifyYouHaveSelectedImpressiveNotVisibleAfterRefresh()
		{
			await _radioButtonPage.GoToRadiButtonsPage();
			await _radioButtonPage.ClickImpressiveRadioButton();
			await _radioButtonPage.CheckImpressiveRadioButton();
			await _radioButtonPage.VerifySelectedImpressiveButtonTextRow();
			await Page.ReloadAsync();
			await _radioButtonPage.VerifySelectedImpressiveButtonTextRowIsNotVisible();
		}
	}
}
