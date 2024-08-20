using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    internal class CatalogPage
    {
        private IPage _page;
        public ILocator Loader => _page.Locator("css=div#p_prldr");
        private string ShopCatalogFilterUrl = "https://solartechnology.com.ua/shop";

        public CatalogPage(IPage page)
        {
            _page = page;
        }

        #region 
        // this particular model value should be parameter for this ProductModelIsVisible(string modelName), but not hardcoded inside
        #endregion 
        public async Task ProductModelIsVisible()
        {
            var isVisible = await _page.GetByRole(AriaRole.Link, new() { Name = "JA Solar 540Вт" }).IsVisibleAsync();
            Assert.That(isVisible, Is.True, "The text 'JA Solar 540Вт' should be visible.");
        }

        #region 
        /*
        this name has extra information which makes this method hard to reuse. 
        Page object methods should reflect only what they do or what data they return. 
        For example this one should be something like VerifyPageIsOpened() and it should belong to MainPage.cs
        In this case you scenario will be like
        cartPage.RemoveProduct();
        mainPage.VerifyPageIsOpened();

        also "new LocatorWaitForOptions" is redundant
        */
        #endregion
        public async Task VerifyUserIsOnMainPageAfterProductRemoving()
        {
            await _page.GetByRole(AriaRole.Heading, new() { Name = "Магазин" }).WaitForAsync(new LocatorWaitForOptions
            {
                State = WaitForSelectorState.Visible,
                Timeout = 50000 // 50 seconds
            });

            var isVisible = await _page.GetByRole(AriaRole.Heading, new() { Name = "Магазин" }).IsVisibleAsync();
            Assert.That(isVisible, Is.True, "Main Page is Visible");
        }

        #region 
        // This name is wrong. This method does not go to basket, it adds product to basket. Better name is AddProductToBasket()
        #endregion
        public async Task ClickOnBasketButton()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "У кошик" }).WaitForAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "У кошик" }).ClickAsync();
        }
        #region 
        // this name is also wrong. It navigates user to "Оформити замовлення", so it can be OpenBasket() or MakeOrder()
        #endregion        
        public async Task AddProductToBasket() => await _page.GetByRole(AriaRole.Link, new() { Name = "Оформити замовлення" }).ClickAsync();

        #region 
        // Pages must not create other pages.
        // They should not know about other pages at all as this creates additional coupling which leads to additional problems.
        // Only test should create pages and "talk" to them. In this case we have one place where our algorithm is described
        #endregion
        public async Task AddProductToCart(string productName)
        {
            var shoppingCard = new ShoppingCard(_page);
            await _page.GetByRole(AriaRole.Link, new() { Name = productName, Exact = true }).ScrollIntoViewIfNeededAsync();
            var addToCartButton = _page.Locator($"//span[contains(text(), '{productName}')]/ancestor-or-self::div[contains(@class, 'card')]//a/i");
            await addToCartButton.ClickAsync();
            await shoppingCard.ContinueShoppingButton.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        }

        #region 
        // Not reliable selector (auto-generated classes)
        // instead of "//*[@Class='list-product-title grey-text text-darken-4']" just ".list-product-title" should work
        #endregion
        public async Task<string> GetFirstProductFullTitle()
        {
            return await _page.Locator("//*[@class='list-product-title grey-text text-darken-4']").First.InnerTextAsync();
        }

        #region 
        // Name does not match implementation
        // VerifyFilterSectionVisible name does not match to implementation. Name is general (looks like it can be used for any type of FilterSection),
        // but in fact there is a pretty hardcoded "Виробник:" value inside which will work in only one particular case
        #endregion
        public async Task VerifyFilterSectionVisible()
        {
            await Assertions.Expect(_page.GetByText("Виробник:")).ToBeVisibleAsync();
        }

        #region 
        // Name does not match implementation
        // this is not CheckFirstProductTitleContainsText, it is IsFirstProductTitleContainsText.
        // Usually it is done like GetFirstProductTitleText and in the test itself you do something like Assert.That(GetFirstProductTitleText(), Is....
        // SolarTechnologyTests.manufacturerX = productInnertext; - incapsulation violation
        // Visual Studio should suggest that "return (trimmedExpected == trimmedTitle) ? true : false;" could be changed to "return (trimmedExpected == trimmedTitle);", no need to write " ? true : false;" for boolean result
        #endregion
        public async Task<bool> CheckFirstProductTitleContainsText(string expected_text)
        {
            await _page.WaitForSelectorAsync("//*[@class='list-product-title grey-text text-darken-4']");
            string productInnertext = await _page.Locator("//*[@class='list-product-title grey-text text-darken-4']").First.InnerTextAsync();
            SolarTechnologyTests.manufacturerX = productInnertext;
            var spaceIndex = productInnertext.IndexOf(' ');

            string trimmedExpected = expected_text.Remove(spaceIndex).ToLower();
            string trimmedTitle = productInnertext.Remove(spaceIndex).ToLower();

            return trimmedExpected == trimmedTitle ? true : false;
        }

        #region 
        /*
            One function should not do 2 different things like "get value" and "compare value". You need just GetFirstProductTitle() and result of this function you should use in the Assert.
            In the approach like
            var result = IsFirstProductTitleContainsExpectedText("some name");
            Assert.True(result, "result is not equal to expected");
            if test fails, you will see Expected true but was false "result is not equal to expected" or "result is not equal to expected 'some name'"
            In the approach like
            var productText = GetFirstProductTitle();
            Assert.That(productText, Is.Equal("some name"))
            you will see Expected "some name" but was ""
            or but was "some other name"
            You don't need to re-run the test in order to understand what exactly name was on the page
         */
        #endregion
        public async Task<bool> IsFirstProductTitleContainsExpectedText(string expected_text)
        {
            await _page.WaitForSelectorAsync(".list-product-title");
            string productInnertext = await _page.Locator(".list-product-title").First.InnerTextAsync();
            var spaceIndex = productInnertext.IndexOf(' ');

            string trimmedExpected = expected_text.Remove(spaceIndex).ToLower();
            string trimmedTitle = productInnertext.Remove(spaceIndex).ToLower();

            return trimmedExpected == trimmedTitle;
        }
    }
}
