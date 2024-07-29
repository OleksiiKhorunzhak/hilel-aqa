using Microsoft.Playwright;

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

        public async Task OpenDocuments()
        {
            await _page.Locator("li").Filter(new() { HasTextRegex = new Regex("^Documents$") }).GetByLabel("Toggle")
                .ClickAsync();
        }

        public async Task CheckDocuments()
        {
            await _page.Locator("label").Filter(new() { HasText = "Documents" }).GetByRole(AriaRole.Img).First
                .ClickAsync();
        }

        public async Task OpenWorkSpace()
        {
            await (_page.Locator("li").Filter(new() { HasTextRegex = new Regex("^WorkSpace$") }).GetByLabel("Toggle"))
                .IsVisibleAsync();
        }

        public async Task VerifyDocumentSelectedText()
        {
            if (await _page.Locator("#result").IsVisibleAsync())
            {
                var resultText = await _page.Locator("#result").TextContentAsync();
                
                Assert.That(resultText, Is.EqualTo(
                        "You have selected :documentsworkspacereactangularveuofficepublicprivateclassifiedgeneral"),
                    "Document text is not matched");
            }
            else
            {
                Assert.Fail("Document text is not visible");
            }
        }
        
        public async Task VerifyReactIcon(string element)
        {
           await _page.Locator("label").Filter(new() { HasText = element }).GetByRole(AriaRole.Img).Nth(1)
                .IsVisibleAsync();
        }
    }
}
