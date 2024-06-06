using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQATextBoxPage
    {
        private IPage _page;
        private string elementsPageUrl = "https://demoqa.com/elements";
        private string textBoxPageUrl = "https://demoqa.com/text-box";
        private string fullNamePlaceholder = "Full Name";
        private string submitButtonRole = "button";
        private string submitButtonName = "Submit";

        public DemoQATextBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToElementsPage()
        {
            await _page.GotoAsync(elementsPageUrl);
        }

        public async Task ClickTextBoxMenu()
        {
            await _page.GetByText("Text Box").ClickAsync();
        }

        public async Task WaitForTextBoxPage()
        {
            await _page.WaitForURLAsync(textBoxPageUrl);
        }

        public async Task<bool> IsFullNameTextVisible()
        {
            return await _page.GetByText("Full Name").IsVisibleAsync();
        }

        public async Task<bool> IsFullNameInputVisible()
        {
            return await _page.GetByPlaceholder(fullNamePlaceholder).IsVisibleAsync();
        }

        public async Task FillFullName(string fullName)
        {
            await _page.GetByPlaceholder(fullNamePlaceholder).FillAsync(fullName);
        }

        public async Task ClickSubmitButton()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = submitButtonName }).ClickAsync();
        }

        public async Task<bool> IsNameVisible(string name)
        {
            return await _page.GetByText($"Name:{name}").IsVisibleAsync();
        }

        public async Task<bool> IsNameHidden(string name)
        {
            return await _page.GetByText($"Name:{name}").IsHiddenAsync();
        }
    }
}
