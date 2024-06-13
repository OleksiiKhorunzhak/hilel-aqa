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
        private IPage _page;
        private string RadioButtonPageUrl = "https://demoqa.com/radio-button";

        public PO_RadioButtonPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToRadioButtonPage()
        {
            await _page.GotoAsync(RadioButtonPageUrl);
            //await _page.WaitForURLAsync(RadioButtonPageUrl);
        }

        public async Task CheckYesRadioButton()
        {
            await _page.GetByText("Yes").CheckAsync();
        }
        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(_page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

    }
}
