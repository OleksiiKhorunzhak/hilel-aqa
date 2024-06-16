using Atata;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class PO_RadioButtonPage
    {
        private IPage page;
        private string RadioButtonPageUrl = "https://demoqa.com/radio-button";

        public PO_RadioButtonPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToRadioButtonPage()
        {
            await page.GotoAsync(RadioButtonPageUrl);
        }

        public async Task CheckYesRadioButton()
        {
            await page.GetByText("Yes").CheckAsync();
        }
        public async Task VerifySuccessTextYesVisible()
        {
            await Assertions.Expect(page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

        public async Task isImpressiveRadioButtonChecked()
        {
            await page.GetByText("Impressive").CheckAsync();
        }

        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

        public async Task VerifyYesRadioChecked()
        {
            await page.Locator("#yesRadio").IsCheckedAsync();
        }

        public async Task VerifyImpressiveRadioButton()
        {
            await page.Locator("#impressiveRadio").IsCheckedAsync();
        }
    }
}
