using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            await _page.Locator("#tree-node").Locator(".rct-checkbox").Locator(":scope > :first-child").ClickAsync();
        }

        public async Task VerifyHomeChecked()
        {
            await Assertions.Expect(_page.Locator("#tree-node path").Nth(3)).ToBeCheckedAsync();
        }

        public async Task OpenNode(string nodeName)
        {
            await _page.Locator("label").Filter(new() { HasText = nodeName }).Locator("xpath=preceding-sibling::*[1]").ClickAsync();
        }

        public async Task OpenHomeNode()
        {
            await _page.GetByLabel("Toggle").First.ClickAsync();
        }
        public async Task CheckCheckbox(string branch)
        {
            await _page.Locator("label").Filter(new() { HasText = branch }).Locator(".rct-checkbox").Locator(":scope > :first-child").ClickAsync();
        }

        public async Task<bool> IsCheckboxChecked(string branch)
        {
            // Locate `span` element containing the branch title
            var spanElement = _page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}'))");

            // Locate the checkbox in `span` element
            var checkboxLocator = spanElement.Locator(".rct-icon-check");

            // Check if the checkbox is visible
            return await checkboxLocator.IsVisibleAsync();
        }

        public async Task<bool> IsFileIconShown(string branch)
        {            
            var fileIcon = _page.Locator($"span.rct-text:has(span.rct-title:text-is('{branch}'))").Locator(".rct-icon-leaf-close"); ;
                       
            return await fileIcon.IsVisibleAsync();
        }

        public async Task<bool> DocumentsCheckedTextIsShown()
        {
            string? documentsCheckedResult = await _page.Locator("#result").TextContentAsync();

            return documentsCheckedResult == "You have selected :documentsworkspacereactangularveuofficepublicprivateclassifiedgeneral" ? true : false;
        }
    }
}