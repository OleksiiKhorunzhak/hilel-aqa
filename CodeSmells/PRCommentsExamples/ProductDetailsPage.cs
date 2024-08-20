using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    public class ProductDetails(IPage page)
    {
        //Selectors & Locators
        private ILocator ProductLink => page.Locator("span.list-product-title");
        #region 
        // Bad locator
        #endregion
        private ILocator ProductNameTitle => page.Locator("div.col.s12.m6.l5.xl4.black-text.right-block h1");

        #region 
        // Name and implementation does not match. Implementation does too much
        #endregion
        //Methods
        public async Task ClickOnProduct(string productName)
        {
            var productNameLink = ProductLink.GetByText(productName);
            await productNameLink.ClickAsync();

            var productTitle = await ProductNameTitle.InnerTextAsync();
            Assert.That(productTitle, Does.Contain(productName), $"Product name is not displayed correctly, expected: {productName}, actual: {productTitle}");
        }

        public async Task VerifyproductDetails(string productName)
        {
            var productDescription = await page.Locator("div.specs h4.block-title").InnerTextAsync();
            Assert.That(productDescription, Does.Contain(productName), $"Product name is not displayed correctly, expected: {productName}, actual: {productDescription}");
        }
    }
}
