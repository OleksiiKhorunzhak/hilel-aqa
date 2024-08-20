using Microsoft.Playwright;
using static System.Net.Mime.MediaTypeNames;

namespace CodeSmells.PRCommentsExamples
{
    internal class ShopPage
    {
        private IPage page;

        public ShopPage(IPage page)
        {
            this.page = page;
        }

        internal async Task GoToBatteriesPage()
        {
            throw new NotImplementedException();
        }

        internal async Task GoToSolarPanelsPage()
        {
            throw new NotImplementedException();
        }

        #region 
        // new CatalogPage(page); - page must not create other pages
        // Fail first. catalog verification should be first
        // Assert.That(await catalogLink.IsVisibleAsync() extra assert which will fail immediately while
        // catalogLink.ClickAsync(); will wait and will give the same failure reason and this assert, but only if element really absent
        // https://playwright.dev/dotnet/docs/api/class-locator#locator-is-visible:
        // If you need to assert that element is visible, prefer Expect(Locator).ToBeVisibleAsync() to avoid flakiness. See assertions guide for more details.
        #endregion

        public async Task OpenCatalog(string catalog)
        {
            var catalogPage = new CatalogPage(page);
            var catalogLink = page.GetByRole(AriaRole.Link, new() { Name = catalog });
            var catalogTitle = page.GetByRole(AriaRole.Heading, new() { Name = catalog, Exact = true });

            if (catalog == null) throw new ArgumentNullException(nameof(catalog), "Catalog name is not provided");
            Assert.That(await catalogLink.IsVisibleAsync(), $"{catalog} catalog is not visible");
            await catalogLink.ClickAsync();
            await catalogPage.Loader.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible }); // check loader state
            Assert.That(await catalogTitle.IsVisibleAsync(), $"{catalog} catalog title is not visible, current URL: {page.Url}");
        }

        #region 
        // name does not match to implementation
        // this is not a "Verify" function. Name should be like IsEmptyProductCardIconVisible
        #endregion
        public async Task<bool> VerifyEmptyProductCardIconIsVisible()
        {
            return await page.Locator("//*[@class='cart-icon ']").IsVisibleAsync();
        }

        #region 
        /*
        KISS — Keep it simple, stupid
        this entire implementation should be just 2 lines of code:

            create locator for add to cart icon based on "string productDescription" input
            click on this locator
            or "Filtering Locators" approach from https://playwright.dev/dotnet/docs/locators

        Verification that product is added - is better to have as a separate method
         */
        #endregion
        public async Task AddSpecifiedProductToCart(string addProduct)
        {
            var productHolderLocator = "//*[contains(@class, 'card z-depth-1 hoverable')]";
            var addToCartBtnLocator = "//*[@class[starts-with(., 'add-product-to-cart')]]";
            var addPopup = page.Locator("//*[@id='cart-modal']");
            var productCards = await page.QuerySelectorAllAsync(productHolderLocator);
            Assert.That(productCards, Is.Not.Empty, "Products not found on the page");

            // Iterate through each product holder to find the {addProduct}
            bool isProductFound = false; // To track if product is found
            foreach (var productCard in productCards)
            {
                var productName = await productCard.InnerTextAsync();
                if (productName.ToLower().Contains(addProduct.ToLower()))
                {
                    isProductFound = true;
                    var addToCartButton = await productCard.QuerySelectorAsync(addToCartBtnLocator);
                    Assert.That(addToCartButton, Is.Not.Null, $"'Add to cart button' not found for product {addProduct}");

                    //Add specified product to the cart
                    if (addToCartButton != null)
                    {
                        await addToCartButton.ClickAsync();
                    }
                    await Assertions.Expect(addPopup).ToContainTextAsync($"{addProduct}");
                    await Assertions.Expect(addPopup).ToContainTextAsync($"Товар додано у кошик");

                    return;
                }
            }
            Assert.That(isProductFound, Is.True, $"Product '{addProduct}' is not found on the page");
        }
        #region Fix
        private readonly string prodHolder = "//div[contains (@class, 'prod-holder')]";
        private readonly string addToCartBtn = "//*[@class[starts-with(., 'add-product-to-cart')]]";
        public async Task AddProductToCart(string productName)
        {
            await page.Locator(prodHolder).Filter(new() { Has = page.GetByRole(AriaRole.Link, new() { Name = productName }) }).Locator(addToCartBtn).ClickAsync();
        }
        #endregion Fix

        #region 
        /*
            do not use locator with only one assertion .Not.ToBeVisibleAsync();
            In case locator changes, this step will be always green. You can make
            private Locator addProductPopup = page.Locator("//*[@id='cart-modal']");
            and then use it in 2 methods like
            public async Task VerifyAddPopupIsVisible()
            public async Task VerifyAddPopupIsNotVisible()
        */
        #endregion
        public async Task VerifyAddPopupNotVisible()
        {
            var addModal = page.Locator("//*[@id='cart-modal']");
            await Assertions.Expect(addModal).Not.ToBeVisibleAsync();
        }

        #region 
        /*
            This approach is not the best. In case of failure you will see result as
            Expected: True
            But was: False
            "Not all Products contains the text filterValue"
            Very inconvenient to debug this. Worst case if test fails "sometimes" and you have no idea what happened even after you re-run it. 
            You have to re-run multiple times and there is no guarantee that you will face exactly the same issue and will be able to fix all issues
        */
        #endregion
        public async Task VerifyFilteredProducts(string filterValue)
        {
            var productTitle = page.Locator("//*[@class[starts-with(., 'list-product-title')]]");
            var allProducts = await productTitle.AllInnerTextsAsync();
            var productsList = allProducts.ToList();
            Assert.That(productsList.Count, Is.GreaterThan(0), $"Products by filter {filterValue} not found");
            bool isAllContainFilterValue = productsList.All(product => product.ToLower().Contains(filterValue.ToLower()));
            Assert.That(isAllContainFilterValue, Is.True, $"Not all Products contains the text {filterValue}");
        }
    }
}