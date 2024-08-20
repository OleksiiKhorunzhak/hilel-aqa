using Microsoft.Playwright;

namespace CodeSmells.PRCommentsExamples
{
    internal class Tests : UITestFixture
    {
        #region 
        // Other engineer should be able to execute test manually. In fact 2 tests in 1
        //Act & Assert only if single line to check exception
        #endregion
        [Test]

        public async Task VerifyFiltersOnBatteriesPage()

        {
            //Arrange
            var shopPage = new ShopPage(Page);
            var batteriesPage = new BatteriesPage(Page);

            //Act & Assert
            await shopPage.GoToBatteriesPage();
            await batteriesPage.OpenFilters();
            await batteriesPage.FilterByType(1);
            await batteriesPage.VerifyProductsByTypeResult(1);
            await batteriesPage.UncheckFilterByType(1);
            await batteriesPage.FilterByBrand(5);
            await batteriesPage.VerifyProductsByBrandResult(5);
            await batteriesPage.UncheckFilterByBrand(5);
        }

        #region 
        // What exatly is Assert?
        #endregion
        [Test]
        public async Task GuessWhatIDo()
        {
            //Arrange
            var shopPage = new ShopPage(Page);
            var shoppingCard = new ShoppingCard(Page);
            var homeMenu = new HomeMenu(Page);

            //Act & Assert
            await shopPage.GoToSolarPanelsPage();
            await shoppingCard.AddFirstProductToCart();
            await homeMenu.GoToShoppingCart();
            await shoppingCard.RemoveProductFromCart();
        }
    }
}
