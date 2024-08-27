using Microsoft.Playwright;

namespace SolarTechnology.PageObjects
{
	internal abstract class BasePage
	{
        internal IPage Page;


        public BasePage(IPage page)
        {
            Page = page;
        }

        public abstract string GetUrl();

        public async Task GoTo()
        {
            await Page.GotoAsync(GetUrl());
        }

        public async Task WaitForLoader()
        {
            ILocator locator = Page.Locator("#p_prldr");
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Visible });
            await locator.WaitForAsync(new() { State = WaitForSelectorState.Hidden });
        }

    }
}
