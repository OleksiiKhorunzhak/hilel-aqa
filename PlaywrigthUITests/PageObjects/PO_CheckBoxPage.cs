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

        public async Task GoToPage(string pageURL)
        {
            await page.GotoAsync(pageURL);
        }

        public async Task VerifyPageTitle(string pageTitle)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = pageTitle })).ToHaveTextAsync("Check Box");
        }

        public async Task ClickParentToggle()
        {
            await page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task VerifyCheckboxVisible(string checkboxName)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = checkboxName }).Locator("path").First).ToBeVisibleAsync();
        }
        public async Task VerifyCheckboxIsNotVisible(string checkboxName)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = checkboxName }).Locator("path").First).Not.ToBeVisibleAsync();
        }

        public async Task ClickCheckbox(string checkboxName)
        {
            await page.Locator("label").Filter(new() { HasText = checkboxName }).GetByRole(AriaRole.Img).First.ClickAsync();
        }

        public async Task VerifyCheckboxChecked(string checkboxName)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = checkboxName }).Locator("path").First).ToBeCheckedAsync();
        }

        public async Task VerifyCheckboxCheckedImg(string checkboxName)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = checkboxName }).GetByRole(AriaRole.Img).First).ToBeCheckedAsync();
        }

        public async Task UncheckCheckbox(string checkboxName)
        {
            await page.Locator("label").Filter(new() { HasText = checkboxName }).ClickAsync();
        }

        public async Task VerifyCheckboxUnchecked(string checkboxName)
        {
            await Assertions.Expect(page.Locator("label").Filter(new() { HasText = checkboxName }).GetByRole(AriaRole.Img).First).Not.ToBeCheckedAsync();
        }
        public async Task ClickToggle(string toggleName)
        {
            await page.Locator("li").Filter(new() { HasTextRegex = new Regex($"^{toggleName}$") }).GetByLabel("Toggle").ClickAsync();
        }
        public async Task ClickExpandCollapseAll(string todo)
        {
            await page.GetByLabel(todo).ClickAsync();
        }
    }
}
