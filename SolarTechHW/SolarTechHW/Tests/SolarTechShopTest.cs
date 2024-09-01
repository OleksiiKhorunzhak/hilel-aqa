using NUnit.Framework.Internal;
using SolarTechHW.PageObjects;
using UiTestFixture;

namespace SolarTechHW.Tests
{
    internal class SolarTechShopTest : UITestFixture
    {
        private SolarTehchShopPage SolarTechShopPage;
        private SolarTechShopCartPage SolarTechShopCartPage;
        private SolarTechShopItemPage SolarTechShopItemPage;

        [SetUp]
        public async Task SetupSolarTehchnologyShopPage()
        {
            SolarTechShopPage = new SolarTehchShopPage(Page);
            SolarTechShopCartPage = new SolarTechShopCartPage(Page);
            SolarTechShopItemPage = new SolarTechShopItemPage(Page);

            await SolarTechShopPage.GoToSolarTehchnologyShopPage();

        }

        [Test]
        [Description("Test Filter Fields of Solar Panels")]
        [TestCase("JA Solar")]
        [TestCase("Jinko Solar")]
        [TestCase("Полікристал")]
        [TestCase("60")]
        public async Task VerifyFilterCheckboxSolarPanels(string propertyname)
        {
            // Arrange
            await SolarTechShopPage.GoToSolarPannels();

            // Act
            await SolarTechShopPage.PressButtonFilterProducts();
            await SolarTechShopPage.FilterItems(propertyname);

            // Assert
            await SolarTechShopPage.VerifyFilteredItems(propertyname);
        }

        [Test]
        [Description("Test Filter Fields of Solar Panels")]
        [TestCase("Deye")]
        [TestCase("Huawei")]
        [TestCase("Мережевий")]

        public async Task VerifyFilterCheckboxInventors(string propertyname)
        {
            // Arrange
            await SolarTechShopPage.GoToInverters();

            // Act
            await SolarTechShopPage.PressButtonFilterProducts();
            await SolarTechShopPage.FilterItems(propertyname);

            // Assert
            await SolarTechShopPage.VerifyFilteredItems(propertyname);
        }

        [Test]
        [Description("Test Adding and deleting item of shopping cart ")]

        public async Task AddandDeleteProductsofShoppingCart()
        {
            //Arrange
            await SolarTechShopPage.GoToInverters();
            await SolarTechShopPage.VerifyAnyItemsOnPage();

            //Act #Add
            await SolarTechShopPage.AddItemToShopCart();

            //Assert #Add
            await SolarTechShopCartPage.VerifyAnyItemsInCart();

            //Act #Delete
            await SolarTechShopCartPage.ClickDeleteItemFromShopCart();

            //Assert #Delete
            await SolarTechShopPage.VerrifyCartIsEmpty();
        }


        [Test]
        [Description("Verify that all products in main" +
            " page dispays corret name in quicklook and on product page ")]

        public async Task VerifyProductNamesAreIdentical()
        {

            //Arrange
            int itemnumber = await SolarTechShopPage.ChooseRandomItem();
            string productname = await SolarTechShopPage.GetProductNameToCompare(itemnumber);

            //Act
            await SolarTechShopPage.ClickChosenItem(itemnumber);

            //Assert
            await SolarTechShopItemPage.VerifyProductURL();
            await SolarTechShopItemPage.VerifyNamesAreIdentical(productname);
        }
    }
}