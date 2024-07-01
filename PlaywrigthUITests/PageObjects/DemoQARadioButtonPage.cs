using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQARadioButtonPage
    {
        private IPage _page;
        private string elementsPageUrl = "https://demoqa.com/elements";
        private string RadioButtonPageUrl = "https://demoqa.com/radio-button";

        public DemoQARadioButtonPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToRadiButtonsPage()
        {
            await _page.GotoAsync(elementsPageUrl);
            await _page.GetByText("Radio Button").ClickAsync();
            await _page.WaitForURLAsync(RadioButtonPageUrl);
        }

        public async Task ClickYesRadioButton()
        {
            await _page.GetByText("Yes").CheckAsync();
        }

        public async Task ClickImpressiveRadioButton()
        {
            await _page.GetByText("Impressive").CheckAsync();
        }

        public async Task ClickNoRadioButton()
        {
            await _page.Locator("div").Filter(new() { HasTextRegex = new Regex("^No$") }).ClickAsync();
        }

        public async Task VerifyNoButtonIsDisabled()
        {
            await Assertions.Expect(_page.Locator("#noRadio")).ToBeDisabledAsync();
        }

        public async Task VerifyTextNoIsNotVisible()
        {
            var isVisible = await _page.Locator("text='You have selected'").IsVisibleAsync();
            Assert.That(isVisible, Is.False, "The text 'You have selected' should not be visible.");
        }

        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(_page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

        public async Task VerifyTextImpressiveButtonIsVisible()
        {
            var isVisible = await _page.GetByText("You have selected Impressive").IsVisibleAsync();
            Assert.That(isVisible, Is.False, "The text 'You have selected Impressive' should not be visible after page refresh.");

        }

        public async Task VerifyTextImpressiveButtonIsNotVisible()
        {
            await Assertions.Expect(_page.GetByText("You have selected Impressive")).ToBeVisibleAsync();
        }


        public async Task CheckYesRadioChecked()
        {
            await _page.Locator("#yesRadio").IsCheckedAsync();
        }

        public async Task CheckImpressiveRadioButton()
        {
            await _page.Locator("#impressiveRadio").IsCheckedAsync();
        }

        public async Task CheckTitleOfRadioButtonPage()
        {
            var isVisible = await _page.GetByRole(AriaRole.Heading, new() { Name = "Radio Button" }).IsVisibleAsync();
            Assert.That(isVisible, Is.True, "The text 'Radio Button' should be visible.");
        }

        public async Task RefreshPage()
        {
            await _page.ReloadAsync();
        }
    }
}
