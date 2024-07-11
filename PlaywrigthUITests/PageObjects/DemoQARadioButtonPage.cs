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

        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(_page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

        public async Task CheckYesRadioChecked()
        {
            await _page.Locator("#yesRadio").IsCheckedAsync();
        }

        public async Task CheckImpressiveRadioButton()
        {
            await _page.Locator("#impressiveRadio").IsCheckedAsync();
        }
    }
}
