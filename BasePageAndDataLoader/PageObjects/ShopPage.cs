using Microsoft.Playwright;

namespace SolarTechnology.PageObjects
{
	internal class ShopPage : BasePage
    {
		//private IPage _page;
		private string shopPageUrl = "https://solartechnology.com.ua/shop";

        public override string GetUrl()
        {
            return shopPageUrl;
        }
        
		public ShopPage(IPage page) : base (page)
        {
			//_page = page;
		}

		//public async Task GoToShopPage()
		//{
		//	await Page.GotoAsync(shopPageUrl);
		//}

    }
}
