using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    public class ShoppingCard(IPage page)
    {
        //Selectors & Locators
        private ILocator RemoveButton => page.Locator("span.remove-from-cart").First;
        private ILocator AddToCartButton => page.Locator(".add-product-to-cart").First;
        public ILocator ContinueShoppingButton => page.GetByRole(AriaRole.Link, new() { Name = "Продовжити купувати" });
        private ILocator CardIcon => page.Locator("li.cart-icon.labeled");
        private ILocator productRowInTheCart => page.Locator("li.cart-product");
        #region 
        //Usually code is written in one style.If you have //Selectors & Locators sections then this selector should be there.
        //In general, it is Ok to have some common selectors at the top (are used in several methods) and place some one-time used selector inside some method.
        #endregion

        //Methods
        public async Task AddFirstProductToCart()
        {
            Assert.IsTrue(await CardIcon.IsHiddenAsync(), "Shopping Cart still marked as empty");
            await AddToCartButton.ClickAsync();
            Assert.Multiple(async () =>
            {
                await page.GetByRole(AriaRole.Heading, new() { Name = "Товар додано у кошик" }).IsVisibleAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Оформити замовлення" }).IsVisibleAsync();
                await page.GetByRole(AriaRole.Link, new() { Name = "Продовжити купувати" }).IsVisibleAsync();
                await page.Locator("#cart-modal > span").IsVisibleAsync();
            });
            await ContinueShoppingButton.ClickAsync();
            Assert.IsFalse(await page.Locator("#cart-modal.modal.open").IsVisibleAsync(), "Product added modal is still visible");
            Assert.IsTrue(await CardIcon.IsVisibleAsync(), "Shopping Cart still marked as empty");
        }

        #region 
        // Fail first. productName verification should be first
        #endregion
        public async Task RemoveProduct(string productName)
        {
            var productsInCard = await productRowInTheCart.AllAsync();
            var removeProductButton = page.Locator($"//li[*//a[contains(text(),'{productName}')]]").GetByText("close");

            if (productName == null) throw new ArgumentNullException(nameof(productName), "Product name is not provided");
            Assert.That(productsInCard.Count, Is.GreaterThan(0).Or.Null, "No products in the cart");
            await removeProductButton.ClickAsync();

            #region 
            // KISS — Keep it simple, stupid
            // this is not a place for such logic. Page should be quite dull - "do this", "do that", "give me count of this",
            // but not "remove item from cart and if it was one item then ensure that we are on catalog page and if not then ensure that we are still on cart page".
            #endregion
            var catalogPage = new CatalogPage(page);
            if (productsInCard.Count == 1)
            {
                await catalogPage.Loader.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
            }
            else
            {
                await page.GetByText(productName).WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });
            }
        }

        internal async Task RemoveProductFromCart()
        {
            throw new NotImplementedException();
        }

        #region 
        /*
            you have "Then" step with _CartPage.VerifyPageUrl
            and implementation of this step is try/catch which just gulps exception and makes this step to be always green. 
            Moreover, for some specific error message you write it into console and for all other cases just do nothing. 
            So whatever exception happens (if it does not contain "crash") this step just ignores everything.
            There is no need in try/catch constructions in tests at all. If something goes wrong, test must fail
        */
        #endregion
        public async Task VerifyPageUrl(string testPageUrl)
        {
            try
            {
                await page.WaitForURLAsync(testPageUrl);
            }
            catch (PlaywrightException e)
            {
                if (e.Message.Contains("crash"))
                {
                    Console.WriteLine("Page crashed: " + e.Message);
                }
            }

            Assert.That(page.Url, Is.EqualTo(testPageUrl));
        }

        public async Task VerifyHeadingText(string heading)
        {
            await Assertions.Expect(page.GetByRole(AriaRole.Heading, new() { Name = heading })).ToBeVisibleAsync();
        }

    }
}