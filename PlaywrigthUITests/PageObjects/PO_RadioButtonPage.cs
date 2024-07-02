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

        public PO_RadioButtonPage(IPage page)
        {
            this.page = page;
        }

        //Page:
        public async Task GoToURL(string testPageUrl)
        {
            await page.GotoAsync(testPageUrl);
        }

        public async Task IsPageH1Visible(string pageH1)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = pageH1 })).ToBeVisibleAsync();
        }

        //Radiobuttons:
        public async Task IsRadioButtonVisible(string radioButtonID)
        {
            await Assertions.Expect(page.Locator(radioButtonID)).ToBeVisibleAsync();
        }

        public async Task CheckRadioButton(string radioButton)
        {
            await page.GetByText(radioButton).CheckAsync(); 
        }

        public async Task IsRadioButtonChecked(string radioButtonID)
        {
            await Assertions.Expect(page.Locator(radioButtonID)).ToBeCheckedAsync();
        }

        public async Task IsRadioButtonNotChecked(string radioButtonID)
        {
            await Assertions.Expect(page.Locator(radioButtonID)).Not.ToBeCheckedAsync();
        }

        public async Task IsRadioButtonEnabled(string radioButtonID)
        {
            await Assertions.Expect(page.Locator(radioButtonID)).ToBeEnabledAsync();
        }

        public async Task IsRadioButtonDisabled(string radioButtonID)
        {
            await Assertions.Expect(page.Locator(radioButtonID)).ToBeDisabledAsync();
        }

        //Success text:
        public async Task IsSuccessTextVisible(string successText)  
        {
            await Assertions.Expect(page.GetByText(successText)).ToBeVisibleAsync();
        }

        public async Task IsSuccessTextNotVisible(string successText)
        {
            await Assertions.Expect(page.GetByText(successText)).Not.ToBeVisibleAsync();
        }
    }
}
