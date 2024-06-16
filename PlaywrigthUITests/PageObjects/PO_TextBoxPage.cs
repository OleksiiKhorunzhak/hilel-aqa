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
    internal class PO_TextBoxPage
    {
        private IPage page;
        public string TextBoxPageUrl = "https://demoqa.com/text-box";
        private string fullNamePlaceholder = "Full Name";
        private string submitButtonRole = "button";
        private string submitButtonName = "Submit";

        public PO_TextBoxPage(IPage page)
        {
            this.page = page;
        }
        public async Task GoToTextBoxPage()
        {
            await page.GotoAsync(TextBoxPageUrl);
            //await page.WaitForURLAsync(TextBoxPageUrl);
        }

        public async Task<bool> IsFullNameTextlVisible()
        {
            return await page.GetByText("Full Name").IsVisibleAsync();
        }

        public async Task<bool> IsFullNamePlaceholderVisible()
        {
            return await page.GetByPlaceholder(fullNamePlaceholder).IsVisibleAsync();
        }

        public async Task FillFullName(string fullName)
        {
            await page.GetByPlaceholder(fullNamePlaceholder).FillAsync(fullName);
        }

        public async Task isFullNameFocused()
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClickAsync();
            await Assertions.Expect(page.GetByPlaceholder("Full Name")).ToBeFocusedAsync();
        }

        public async Task ClickSubmitButton()
        {
            await page.GetByRole(AriaRole.Button, new() { Name = submitButtonName }).ClickAsync();
        }

        public async Task isSubmitButtonFocused()
        {
            var submitButton = page.GetByRole(AriaRole.Button, new() { Name = submitButtonName });
            await submitButton.ClickAsync();
            await Assertions.Expect(submitButton).ToBeFocusedAsync();
        }

        public async Task ClearFullNameInput()
        {
            await page.GetByPlaceholder(fullNamePlaceholder).ClearAsync();
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
