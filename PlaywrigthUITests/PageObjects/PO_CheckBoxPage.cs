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
        public PO_CheckBoxPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToTestedPage(string TestPageURL)
        {
            await page.GotoAsync(TestPageURL);
            //await page.WaitForURLAsync(TestPageURL);    uncomment if needed
        }

        public async Task VerifyPageTitle(string pageTitle)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = pageTitle })).ToHaveTextAsync("Check Box");
        }

        public async Task ClickToggle()
        {
            await page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task VerifyToggleClicked()
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Desktop" }).Locator("path").First).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Documents" }).Locator("path").First).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Downloads" }).Locator("path").First).ToBeVisibleAsync();
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
