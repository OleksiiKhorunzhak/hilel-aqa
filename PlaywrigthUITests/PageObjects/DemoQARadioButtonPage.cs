using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQARadioButtonPage
    {
        private IPage _page;
        private string _radioButtonPageUrl = "https://demoqa.com/radio-button";

        public DemoQARadioButtonPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToRadiButtonsPage()
        {
            await _page.GotoAsync(_radioButtonPageUrl);
            await _page.WaitForURLAsync(_radioButtonPageUrl);
        }

        public async Task ClickYesRadioButton()
        {
            await _page.GetByText("Yes").CheckAsync();
        }

        public async Task<bool> IsYesRadioChecked()
        {
            return await _page.Locator("#yesRadio").IsCheckedAsync();
        }

        public async Task<bool> IsYesResultVisible()
        {
            return await _page.GetByText("You have selected Yes").IsVisibleAsync();
        }

        public async Task ClickImpressiveRadioButton()
        {
            await _page.GetByText("Impressive").CheckAsync();
        }

        public async Task<bool> IsImpressiveRadioChecked()
        {
            return await _page.Locator("#impressiveRadio").IsCheckedAsync();
        }

        public async Task<bool> IsImpressiveResultVisible()
        {
            return await _page.GetByText("You have selected Impressive").IsVisibleAsync();
        }

        public async Task ClickNoRadioButton()
        {
            await _page.GetByText("No").CheckAsync();
        }

        public async Task<bool> IsNoRadioChecked()
        {
            return await _page.Locator("#noRadio").IsCheckedAsync();
        }

        public async Task<bool> IsNoResultVisible()
        {
            return await _page.GetByText("You have selected No").IsVisibleAsync();
        }

        public async Task<bool> IsNoRadioEnabled()
        {
            return await _page.Locator("#noRadio").IsEnabledAsync();
        }

        public async Task<bool> IsRadioButtonPageHeaderVisible()
        {
            return await _page.GetByRole(AriaRole.Heading, new() { Name = "Radio Button" }).IsVisibleAsync();
        }

        public async Task RadioButtonPageRefresh()
        {
            await _page.ReloadAsync();
        }

        public async Task<bool> IsRadioButtonPageInDefaultState()
        {
            return !await this.IsYesRadioChecked()! & !await this.IsYesResultVisible()
                 & !await this.IsImpressiveRadioChecked() & !await this.IsImpressiveResultVisible() ? true : false;
        }

        public async Task SelectRandomRadioButton()
        {
            int randomNumber = new Random().Next(1, 3);

            switch (randomNumber)
            {
                case 1:
                    await this.ClickYesRadioButton();
                    break;
                case 2:
                    await this.ClickImpressiveRadioButton();
                    break;
            }
        }
    }
}