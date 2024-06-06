using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQATextBoxPage 
    {
        private IPage _page;
        private string _textBoxPageUrl = "https://demoqa.com/text-box";
        private string _fullNamePlaceholder = "Full Name";
        private string _submitButtonName = "Submit";

        public DemoQATextBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToTextBoxPage()
        {
            await _page.GotoAsync(_textBoxPageUrl);
            await _page.WaitForURLAsync(_textBoxPageUrl);
        }

        public async Task<bool> IsFullNameTextVisible()
        {
            return await _page.GetByText("Full Name").IsVisibleAsync();
        }

        public async Task<bool> IsFullNameInputVisible()
        {
            return await _page.GetByPlaceholder(_fullNamePlaceholder).IsVisibleAsync();
        }

        public async Task FillFullName(string fullName)
        {
            await _page.GetByPlaceholder(_fullNamePlaceholder).FillAsync(fullName);
        }

        public async Task ClickSubmitButton()
        {
            await _page.Locator("#submit").ClickAsync(); //more preferable selector as for me
            //await _page.GetByRole(AriaRole.Button, new() { Name = _submitButtonName }).ClickAsync();
        }

        public async Task<bool> IsNameVisible(string name)
        {
            return await _page.GetByText($"Name:{name}").IsVisibleAsync();
        }

        public async Task<bool> IsNameHidden(string name)
        {
            return await _page.GetByText($"Name:{name}").IsHiddenAsync();
        }

        public async Task ClearFullNameInput()
        {
            await _page.GetByPlaceholder(_fullNamePlaceholder).ClearAsync();
        }

        public async Task <bool> EmailCorrespondsToRegExp(string pattern)
        {
           var value = await _page.InputValueAsync("#userEmail");
             var regexp = new Regex(pattern);

            return regexp.IsMatch(value) ? true : false;         
        }

        public async Task FillEmail(string email)
        {
            await _page.Locator("#userEmail").FillAsync(email);
        }

        public async Task<bool> IsEmailOutputHidden()
        {
            return await _page.Locator("#email").IsHiddenAsync();
        }

        public async Task<bool> IsCurrentAddressTextArea()
        {
            var tagName = await _page.EvalOnSelectorAsync<string>("#currentAddress", "element => element.tagName");

            return tagName.ToLower() == "textarea" ? true : false;               
        }
    }
}