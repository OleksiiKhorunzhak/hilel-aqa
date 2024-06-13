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

        private IPage _page;
        private string CheckBoxPageURL = "https://demoqa.com/checkbox";

        public PO_CheckBoxPage(IPage page)
        {
            _page = page;
        }

        public async Task GoToChechBoxPage()
        {
            await _page.GotoAsync(CheckBoxPageURL);
            //await _page.WaitForURLAsync(RadioButtonPageUrl);
            await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "Check Box" })).ToBeVisibleAsync();
        }
        public async Task ClickToggle()
        {
            await _page.GetByLabel("Toggle").First.ClickAsync();
            await Assertions.Expect(_page.GetByText("Desktop")).ToBeVisibleAsync();
            await Assertions.Expect(_page.GetByText("Documents")).ToBeVisibleAsync();
            await Assertions.Expect(_page.GetByText("Downloads")).ToBeVisibleAsync();
            await Assertions.Expect(_page.Locator("label").Filter(new() { HasText = "Documents" }).Locator("path").First).ToBeVisibleAsync();
        }
    }
}
