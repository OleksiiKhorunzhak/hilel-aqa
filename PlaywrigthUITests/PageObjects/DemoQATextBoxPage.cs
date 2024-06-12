using Atata;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

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

        public async Task<bool> IsFullNamePlaceholderVisible()
        {
            return await _page.GetByPlaceholder(fullNamePlaceholder).IsVisibleAsync();
        }

        public async Task FillFullName(string fullName)
        {
            await _page.GetByPlaceholder(fullNamePlaceholder).FillAsync(fullName);
        }
        public async Task isFullNameFocused()
        {
            await _page.GetByPlaceholder(fullNamePlaceholder).ClickAsync();
            await Assertions.Expect(_page.GetByPlaceholder("Full Name")).ToBeFocusedAsync();
        }
        

        public async Task ClearFullNameInput()
        {
            await _page.GetByPlaceholder(fullNamePlaceholder).ClearAsync();
        }

        public async Task ClickSubmitButton()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = submitButtonName }).ClickAsync();
        }
        public async Task isSubmitButtonFocused()
        {
            var submitButton = _page.GetByRole(AriaRole.Button, new() { Name = submitButtonName });
            await submitButton.ClickAsync();
            await Assertions.Expect(submitButton).ToBeFocusedAsync();
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
