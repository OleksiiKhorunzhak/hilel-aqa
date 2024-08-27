using Microsoft.Playwright;

namespace SolarTechnology.PageObjects
{
	internal class SolarPanelsPage : BasePage
	{
        //private IPage Page;
        private string shopSolarPanelsUrl = "https://solartechnology.com.ua/shop/solar-panels";
        public override string GetUrl()
        {
            return shopSolarPanelsUrl;
        }

        public SolarPanelsPage(IPage page) : base(page)
        {
            //Page = page;
        }

		//public async Task GoToSolarPanelsPage()
		//{
		//	await Page.GotoAsync(shopSolarPanelsUrl);
		//}

		public async Task ClickFiltersButton()
		{
			await Page.GetByText("Фільтр товарів").ClickAsync();
		}

		public async Task<string> GetFirstProductFullTitle()
		{
			return await Page.Locator(".list-product-title").First.InnerTextAsync();
		}

		public async Task ClickFilterManufacturerByName(string name)
		{
			//var waitForRequestTask = Page.WaitForRequestAsync("**/solar-panels?filter%5Bbrand%5D=*");
			await Page.Locator($"//span[text()='{name}']").ClickAsync();

			await WaitForLoader();

            //await waitForRequestTask;
        }

		public async Task VerifySolarPanelsPageLoaded()
		{
			//await Page.WaitForURLAsync(shopSolarPanelsUrl);
			await Page.WaitForURLAsync(GetUrl());
			var linkElements = Page.GetByRole(AriaRole.Link);
			await Assertions.Expect(linkElements.First).ToBeVisibleAsync();
		}

		public async Task VerifyFilterSectionVisible()
		{
			await Assertions.Expect(Page.Locator("[name='filter[elements]']").First).ToBeVisibleAsync();
		}

		public async Task CheckProductSectionLoaded()
		{
			await Assertions.Expect(Page.Locator(".list-product-title").Last).ToBeVisibleAsync();
		}

		public async Task<bool> IsFirstProductTitleContainsExpectedText(string expected_text)
		{
			await Page.WaitForSelectorAsync(".list-product-title");
			string productInnertext = await Page.Locator(".list-product-title").First.InnerTextAsync();
			var spaceIndex = productInnertext.IndexOf(' ');

			string trimmedExpected = expected_text.Remove(spaceIndex).ToLower();
			string trimmedTitle = productInnertext.Remove(spaceIndex).ToLower();

			return (trimmedExpected == trimmedTitle);
		}
	}
}
