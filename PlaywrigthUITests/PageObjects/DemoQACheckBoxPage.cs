using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQACheckBoxPage
    {
        private IPage _page;
        private string RadioButtonPageUrl = "https://demoqa.com/checkbox";

        public DemoQACheckBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToDemoQaChecboxPage()
        {
            await _page.GotoAsync(RadioButtonPageUrl);
        }

        public async Task CheckHomeCheckbox()
        {
            await _page.Locator("#tree-node").GetByRole(AriaRole.Img).Nth(3).ClickAsync();
        }

        public async Task CheckCheckbox(string branch)
        {
            await _page.Locator("label").Filter(new() { HasText = branch }).GetByRole(AriaRole.Img).First.ClickAsync();
        }

        public async Task OpenHome()
        {
            await _page.GetByLabel("Toggle").First.ClickAsync();
        }

        public async Task VerifyHomeChecked()
        {
            await Assertions.Expect(_page.Locator("#tree-node path").Nth(3)).ToBeCheckedAsync();
        }

        public async Task<bool> VerifyCheckboxChecked(string branch)
        {
            // Locate `span` element containing the branch title
            var spanElement = _page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}'))");
            // Locate the checkbox in `span` element
            var checkboxLocator = spanElement.Locator(".rct-icon-check");
            // Check if the checkbox is visible
            var checkboxVisible = await checkboxLocator.IsVisibleAsync();
            return checkboxVisible;
        }
        public async Task OpenCheckbox(string name)
        {
            await _page.Locator("li").Filter(new() { HasTextRegex = new Regex($"^{Regex.Escape(name)}$") }).GetByLabel("Toggle").ClickAsync();
        }
        public async Task CheckTextAFterDocumentsCheckboxChecked(string text)
        {
            await Assertions.Expect(_page.Locator("#result")).ToContainTextAsync(text);
        }
        public async Task CheckPicture(string name)
        {
            // await Assertions.Expect(_page.Locator("label").Filter(new() { HasText = name }).Locator("path").Nth(1)).ToHaveClassAsync("rct-icon-leaf-close");
            var element = _page.Locator("span.rct-text").Filter(new() { HasText = name }).Locator("svg.rct-icon.rct-icon-leaf-close").First;

            // Проверка наличия класса rct-icon-leaf-close у найденного элемента
            await Assertions.Expect(element).ToHaveClassAsync("rct-icon rct-icon-leaf-close");

        }
        //public async Task VerifyCheckBoxHasCloseIcon(string branch)
        //{
        //    //Create a locator for the React checkbox's icon
        //    var iconLocator = _page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}')) svg.rct-icon.rct-icon-leaf-close");

        //    // Use Assert to check that the close icon is visible
        //    var isCloseIconVisible = await iconLocator.IsVisibleAsync();
        //    Assert.That(isCloseIconVisible, Is.True, $"The checkbox for '{branch}' should have the 'rct-icon-leaf-close' icon visible.");

        //}
    }
}
