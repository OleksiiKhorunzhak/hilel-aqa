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
    }
}
