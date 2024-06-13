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
            //await page.WaitForURLAsync(RadioButtonPageUrl);
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = "Check Box" })).ToBeVisibleAsync();
        }
        public async Task VerifyToggleClicked()
        {
            await page.GetByLabel("Toggle").First.ClickAsync();
            await Assertions.Expect(page.GetByText("Desktop")).ToBeVisibleAsync();
            //await Assertions.Expect(page.GetByText("Documents")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Documents" }).Locator("path").First).ToBeVisibleAsync();
            await Assertions.Expect(page.GetByText("Downloads")).ToBeVisibleAsync();
        }
        public async Task VerifyHomeChecked()
        {
            await page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
            await Assertions.Expect(page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3)).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Desktop" }).GetByRole(AriaRole.Img).First).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Documents" }).GetByRole(AriaRole.Img).First).ToBeCheckedAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Downloads" }).GetByRole(AriaRole.Img).First).ToBeCheckedAsync();
        }
        public async Task VerifyDownloadsUnchecked()
        {
            await page.Locator("label").Filter(new() { HasText = "Downloads" }).ClickAsync();
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = "Downloads" }).GetByRole(AriaRole.Img).First).Not.ToBeCheckedAsync();
        }


}
}
