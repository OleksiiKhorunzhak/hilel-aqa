using Microsoft.Playwright;

namespace PlaywrigthUITests.Homework
{
    internal class SmartWait : UITestFixture
    {
        [Test]
        public async Task Nike()
        {
            //Arrange
            await Page.GotoAsync("https://www.nike.com/");
            await Page.GetByTestId("dialog-accept-button").ClickAsync();
            await Page.GetByRole(AriaRole.Link, new() { Name = "Women" }).ClickAsync();
            await Page.GetByLabel("secondary").GetByLabel("Shoes", new() { Exact = true }).ClickAsync();

            //Act
            await Page.GetByRole(AriaRole.Button, new() { Name = "Color", Exact = true }).ClickAsync();
            var titlesBefore = await Page.Locator(".product-card__title").AllInnerTextsAsync();
            await Page.GetByLabel("Filter for Blue").ClickAsync();
            
            var loader = Page.Locator("//div/div[contains(@class, 'loader-overlay is--visible')]");
            await loader.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Hidden });

            var titlesAfter = await Page.Locator(".product-card__title").AllInnerTextsAsync();
            
            //Assert
            Assert.That(titlesAfter.First(), Is.Not.EqualTo(titlesBefore.First()));

        }
        [Test]
        public async Task Snikkers()
        {
            //Arrange
            await Page.GotoAsync("https://deltasport.ua/ua/store/women/");

            //Act
            var titlesBefore = await Page.Locator(".item_name").AllInnerTextsAsync();
            await Page.Locator("li").Filter(new() { HasText = "Кросівки" }).Locator("label").ClickAsync();
            
            var filterSelected = Page.Locator("//div[@class=\"filter-sort\"]/ul/li[contains(text(), 'Кросівки')]");
            await filterSelected.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            var titlesAfter = await Page.Locator(".item_name").AllInnerTextsAsync();
            
            //Assert
            Assert.That(titlesBefore.First().ToLower(), Does.Not.Contain("кросівки"));
            Assert.That(titlesAfter.First().ToLower(), Does.Contain("кросівки"));
        }
    }
}
