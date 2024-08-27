using PlaywrigthUITests;
using SolarTechnology.Data;
using SolarTechnology.PageObjects;

namespace SolarTechnology.SolarTechologyTests;

public class SolarTechnologyTests : UITestFixture
{
	private ShopPage _shopPage;
	private SolarPanelsPage _solarPanelsPage;
	
	[Description("Checking 'Solar panels' page functionality")]
	[SetUp]
	public void SetupShopPage()
	{
		_shopPage = new ShopPage(Page);
		_solarPanelsPage = new SolarPanelsPage(Page);
	}

	[Test]
	[Description("Verify that catalog filter by name works correctly")]
	public async Task CheckSolarPanelCatalogFilterByName()
    {
		//Arrange
		await _shopPage.GoTo();
		
		//await _solarPanelsPage.GoToSolarPanelsPage();
		await _solarPanelsPage.GoTo();
		await _solarPanelsPage.VerifySolarPanelsPageLoaded();
		await _solarPanelsPage.ClickFiltersButton();
		await _solarPanelsPage.VerifyFilterSectionVisible();

        //Act
        
        var manufacturer = DataLoader.GetManufacturer();

        //string manufacturer = await _solarPanelsPage.GetFilterManufacturerNameById(id);
        await _solarPanelsPage.CheckProductSectionLoaded();
		await _solarPanelsPage.ClickFilterManufacturerByName(manufacturer);
		var result = await _solarPanelsPage.IsFirstProductTitleContainsExpectedText(manufacturer);
		
		//Assert
		Assert.True(result == true, $"Manufaturer {manufacturer} is not equal to expected product title after filtering");
	}

}