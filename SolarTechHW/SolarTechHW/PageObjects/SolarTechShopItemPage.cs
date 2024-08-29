using Microsoft.Playwright;

namespace SolarTechHW.PageObjects
{
    internal class SolarTechShopItemPage
    {

        private IPage page;
        private string SolarTechShopCartPageUrl = "https://solartechnology.com.ua/shop";

        public SolarTechShopItemPage(IPage pagenew)
        {
            page = pagenew;
        }

        public async Task VerifyProductURL()
        {
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            string currentUrl = page.Url;

            Assert.That(currentUrl.Contains(SolarTechShopCartPageUrl, StringComparison.OrdinalIgnoreCase),
                "URL of page after click differ from general URL for products ");
        }

        public async Task VerifyNamesAreIdentical(string productTitle)
        {
            var h1Element = await page.Locator("h1").InnerTextAsync();
            Assert.That(h1Element.Contains(productTitle, StringComparison.OrdinalIgnoreCase),
                  $"Product name '{productTitle}' didnt match '{h1Element}'");

        }
    }
}
