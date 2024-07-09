using Microsoft.Playwright;

namespace PlaywrigthSpecFlow.PageObjects
{
    internal class DemoQATextBoxPage
    {
        private readonly IPage page;
        private readonly string elementsPageUrl = "https://demoqa.com/elements";
        private readonly string textBoxPageUrl = "https://demoqa.com/text-box";
        private readonly string fullNamePlaceholder = "Full Name";
        //private readonly string submitButtonRole = "button";
        private readonly string submitButtonName = "Submit";

        public DemoQATextBoxPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToElementsPage()
        {
            await page.GotoAsync(elementsPageUrl);
        }

        public async Task ClickTextBoxMenu()
        {
            await page.GetByText("Text Box").ClickAsync();
        }

        public async Task WaitForTextBoxPage()
        {
            await page.WaitForURLAsync(textBoxPageUrl);
        }

        public async Task<bool> IsFullNameTextVisible()
        {
            return await page.GetByText("Full Name").IsVisibleAsync();
        }

        public async Task<bool> IsFullNameInputVisible()
        {
            return await page.GetByPlaceholder(fullNamePlaceholder).IsVisibleAsync();
        }

        public async Task FillFullName(string fullName)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).FillAsync(fullName);
        }

        public async Task ClickSubmitButton()
        {
            await page.GetByRole(AriaRole.Button, new() { NameString = submitButtonName }).ClickAsync();
        }

        public async Task<bool> IsNameVisible(string name)
        {
            return await page.GetByText($"Name:{name}").IsVisibleAsync();
        }

        public async Task<bool> IsNameHidden(string name)
        {
            return await page.GetByText($"Name:{name}").IsHiddenAsync();
        }
    }
}
