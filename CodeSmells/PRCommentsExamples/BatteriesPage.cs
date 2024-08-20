using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    internal class BatteriesPage
    {
        private IPage page;

        public BatteriesPage(IPage page)
        {
            this.page = page;
        }


        private ILocator Axioma => page.GetByText("AXIOMA", new() { Exact = true });
        private ILocator Pylontech => page.GetByText("PYLONTECH", new() { Exact = true });
        private ILocator Byd => page.GetByText("BYD", new() { Exact = true });
        private ILocator VictronEnergy => page.GetByText("Victron Energy", new() { Exact = true });
        private ILocator Ads => page.GetByText("АДС - Автономні Джерела Струму", new() { Exact = true });
        #region 
        // brand is magic number in the test
        // All Assert inside "if"
        // KISS — Keep it simple, stupid
        #endregion
        public async Task FilterByBrand(int brand)
        {
            var filter = brand switch
            {
                1 => Axioma,
                2 => Pylontech,
                3 => Byd,
                4 => VictronEnergy,
                5 => Ads,
                _ => null
            };

            if (filter != null)
            {
                Assert.That(await filter.IsVisibleAsync(), $"{filter} filter is not visible");
                Assert.IsFalse(await filter.IsCheckedAsync(), $"{filter} checkbox is already checked");
                await filter.ClickAsync();
                Assert.IsTrue(await filter.IsCheckedAsync(), $"{filter} checkbox is not checked");
            }

            await Task.Delay(3000);
        }

        internal async Task FilterByType(int v)
        {
            throw new NotImplementedException();
        }

        internal async Task OpenFilters()
        {
            throw new NotImplementedException();
        }

        internal async Task UncheckFilterByBrand(int v)
        {
            throw new NotImplementedException();
        }

        internal async Task UncheckFilterByType(int v)
        {
            throw new NotImplementedException();
        }
        #region 
        // Assert inside "foreach" only
        // KISS — Keep it simple, stupid
        #endregion
        public async Task VerifyProductsByBrandResult(int brand)
        {
            var expectedBrand = brand switch
            {
                1 => "AXIOMA",
                2 => "PYLONTECH",
                3 => "BYD",
                4 => "Victron Energy", //expected to be failed
                5 => "ADS LT",
                _ => throw new ArgumentOutOfRangeException(nameof(brand), "Invalid brand value")
            };
            var products = await page.Locator("span.list-product-title").AllInnerTextsAsync();
            foreach (var product in products)
            {
                Assert.That(product.ToLower().Contains(expectedBrand.ToLower()), $"Product does not contain brand: {product}");
            }
        }

        internal async Task VerifyProductsByTypeResult(int v)
        {
            throw new NotImplementedException();
        }
    }
}