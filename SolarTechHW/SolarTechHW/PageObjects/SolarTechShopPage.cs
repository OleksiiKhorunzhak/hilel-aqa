using Microsoft.Playwright;

namespace SolarTechHW.PageObjects
{
    internal class SolarTehchShopPage
    {
        private IPage page;
        private string SolarTechShopPageUrl = "https://solartechnology.com.ua/shop";

        public SolarTehchShopPage(IPage pagenew)
        {
            page = pagenew;
        }
        public async Task GoToSolarTehchnologyShopPage()
        {
            await page.GotoAsync(SolarTechShopPageUrl);
        }
        public async Task PressButtonFilterProducts()
        {
            await page.GetByText("Фільтр товарів").ClickAsync();
        }
        #region Pages
        public async Task GoToSolarPannels()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Сонячні панелі" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/solar-panels");
        }
        public async Task GoToInverters()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Інвертори" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/inverters");
        }

        public async Task GoToBatteries()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Акумулятори" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/batteries");
        }

        public async Task GoToChargeControllers()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Контролери заряду" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/charge-controllers");
        }

        public async Task GoToMountingSystems()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Системи кріплення" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/mounting-systems");
        }

        public async Task GoToSolarCable()
        {
            await page.GetByRole(AriaRole.Link, new() { Name = "Кабель і комутація" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/shop/solar-cable");
        }
        #endregion

        public async Task FilterItems(string propertyname)
        {
            var filterCheckbox = page.Locator(".checkbox").Filter(new() { HasText = propertyname }).Locator("span");

            await filterCheckbox.ClickAsync();

            await Assertions.Expect(filterCheckbox).ToBeCheckedAsync();

            await page.WaitForURLAsync("**/*?filter*");
            await page.WaitForLoadStateAsync(LoadState.NetworkIdle);
        }
        public async Task VerifyFilteredItems(string propertyname)
        {
            //Here we count all how many pruducts are suitable for filters 
            int count = await page.Locator("[class*='prod-holder']").CountAsync();
            Assert.That(count, Is.GreaterThan(0));

            for (int i = 0; i < count; i++)
            {
                //Here we compare text inside product quicklook with our specific filter
                var product = page.Locator("[class*='prod-holder']").Nth(i);
                string textContent = await product.InnerTextAsync();
                bool containsText = textContent.Contains(propertyname, StringComparison.OrdinalIgnoreCase);

                // if we fail to find it inside product's quicklook of properties, 
                // we check it on product's pace
                if (!containsText)
                {

                    await page.Locator("[class*='prod-holder']").Nth(i).ClickAsync();

                    var productspecstable = page.Locator(".specs");
                    textContent = await productspecstable.InnerTextAsync();
                    containsText = textContent.Contains(propertyname, StringComparison.OrdinalIgnoreCase);

                    await page.GoBackAsync();
                }
                Assert.IsTrue(containsText, $"Product number {i} does not contain specific filter '{propertyname}'");
            }
        }

        public async Task AddItemToShopCart()
        {
            await page.Locator(".add-product-to-cart").First.ClickAsync();
            await page.GetByRole(AriaRole.Link, new() { Name = "Оформити замовлення" }).ClickAsync();
            await page.WaitForURLAsync("https://solartechnology.com.ua/cart");
        }
        public async Task VerrifyCartIsEmpty()
        {
            //"cart-icon labeled" - red dot when cart is not empty
            await Assertions.Expect(page.Locator(".cart-icon")).ToBeVisibleAsync();
            await Assertions.Expect(page.Locator(".cart-icon.labeled")).Not.ToBeVisibleAsync();
        }

        public async Task VerifyAnyItemsOnPage()
        {
            await Assertions.Expect(page.Locator("[class*='list-product-title']").First).ToBeVisibleAsync();
        }

        public async Task<int> ChooseRandomItem()
        {
            int count = await page.Locator("[class*='prod-holder']").CountAsync();
            Random random = new Random();

            Assert.That(count, Is.GreaterThan(0), "There no items on Page!");

            return random.Next(0, count - 1);
        }

        public async Task<string> GetProductNameToCompare(int productnumber)
        {
            string productTitle = await page.Locator("[class*='list-product-title']").Nth(productnumber).InnerTextAsync();

            //here special check for rare product with wrong product name( includes words on сyrillic)
            bool containsCyrillic = Regex.IsMatch(productTitle, @"[\u0400-\u04FF]");
            if (containsCyrillic)
            {
                productTitle = Regex.Replace(productTitle, @"[\u0400-\u04FF]", "");
            }
            //Here we make sure there are no extra spaces in product name string
            productTitle = productTitle.Trim();

            return productTitle;
        }
        public async Task ClickChosenItem(int productnumber)
        {
            await page.Locator("[class*='list-product-title']").Nth(productnumber).ClickAsync();
        }

    }
}
