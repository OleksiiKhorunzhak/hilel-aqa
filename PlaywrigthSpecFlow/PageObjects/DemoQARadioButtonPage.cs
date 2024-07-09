using Microsoft.Playwright;

namespace PlaywrigthSpecFlow.PageObjects
{
    internal class DemoQARadioButtonPage
    {
        private readonly IPage page;
        private readonly string elementsPageUrl = "https://demoqa.com/elements";
        private readonly string RadioButtonPageUrl = "https://demoqa.com/radio-button";

        public DemoQARadioButtonPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToRadiButtonsPage()
        {
            await page.GotoAsync(elementsPageUrl);
            await page.GetByText("Radio Button").ClickAsync();
            await page.WaitForURLAsync(RadioButtonPageUrl);
        }

        public async Task ClickYesRadioButton()
        {
            await page.GetByText("Yes").CheckAsync();
        }

        public async Task ClickImpressiveRadioButton()
        {
            await page.GetByText("Impressive").CheckAsync();
        }

        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

        public async Task CheckYesRadioChecked()
        {
            await page.Locator("#yesRadio").IsCheckedAsync();
        }

        public async Task CheckImpressiveRadioButton()
        {
            await page.Locator("#impressiveRadio").IsCheckedAsync();
        }
    }
}
