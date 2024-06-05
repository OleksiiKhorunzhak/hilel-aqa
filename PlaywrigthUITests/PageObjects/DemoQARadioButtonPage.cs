﻿using Atata;
using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQARadioButtonPage
    {
        private IPage _page;
        private string elementsPageUrl = "https://demoqa.com/elements";
        private string radioButtonPageUrl = "https://demoqa.com/radio-button";

        public DemoQARadioButtonPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToRadioButtonPage()
        {
            await _page.GotoAsync(elementsPageUrl);
            await _page.GetByText("Elements").ClickAsync();
            await _page.GetByText("Radio Button").ClickAsync();
            await _page.WaitForURLAsync(radioButtonPageUrl);
        }

        public async Task CheckYesRadioButton()
        {
            await _page.GetByText("Yes").CheckAsync();
            //await _page.Locator("label").Filter(new() { HasText = "Yes" }).CheckAsync();
        }
        public async Task VerifyTextYesVisible()
        {
            await Assertions.Expect(_page.GetByText("You have selected Yes")).ToBeVisibleAsync();
        }

    }
}