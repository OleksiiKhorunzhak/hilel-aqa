using Microsoft.Playwright;

namespace SolarTechHW.PageObjects
{
    internal class SolarTechShopCartPage
    {
        private IPage page;
        private string SolarTechShopCartPageUrl = "https://solartechnology.com.ua/shop";

        public SolarTechShopCartPage(IPage pagenew)
        {
            page = pagenew;
        }

        public async Task GoToSolarTechShopCartPage()
        {
            await page.GotoAsync(SolarTechShopCartPageUrl);
        }

        public async Task VerifyAnyItemsInCart()
        {
            await Assertions.Expect(page.Locator("[class*='cart-product']").First).ToBeVisibleAsync();
        }

        public async Task ClickDeleteItemFromShopCart()
        {
            await page.Locator("span[class*='remove-from-cart']:has-text('close')").ClickAsync();
        }
    }
}
