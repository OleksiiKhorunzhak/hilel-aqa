using Atata;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class PO_CheckBoxPage
    {

        private IPage page;
        private string CheckBoxPageURL = "https://demoqa.com/checkbox";

        public PO_CheckBoxPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToCheckBoxPage()
        {
            await page.GotoAsync(CheckBoxPageURL);
            await page.WaitForURLAsync(CheckBoxPageURL);
        }

        public async Task VerifyCheckBoxTitle()
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Check Box" })).ToHaveTextAsync("Check Box");
        }
        public async Task ClickToggle()
        {
            await page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task VerifyToggleClicked()
        {
            await Assertions.Expect(page.GetByText("Desktop")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Documents" }).Locator("path").First).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Downloads")).ToBeVisibleAsync();
        }

        public async Task ClickHomeCheckbox()
        {
            await page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
        }

        public async Task VerifyHomeChecked()
        {
            await Assertions.Expect(page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3)).ToBeCheckedAsync();
        }
        public async Task VerifyHomeChildChecked(string node)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = node }).GetByRole(AriaRole.Img).First).ToBeCheckedAsync();
        }
        public async Task UncheckHomeChild(string node)
        {
            await page.Locator("label").Filter(new() { HasText = node }).ClickAsync();
        }
        public async Task VerifyHomeChildUnchecked(string node)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = node }).GetByRole(AriaRole.Img).First).Not.ToBeCheckedAsync();
        }
    }
}
