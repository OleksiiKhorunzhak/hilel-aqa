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
            await Page.GetByTestId("desktop-menu-container").GetByRole(AriaRole.Link, new() { Name = "Women" }).ClickAsync();
            await Page.GetByLabel("secondary").GetByLabel("Shoes", new() { Exact = true }).ClickAsync();

            //Act
            await Page.GetByRole(AriaRole.Button, new() { Name = "Colour" }).ClickAsync();
            var titelsBefore = await Page.Locator(".product-card__title").AllInnerTextsAsync();
            await Page.GetByLabel("Filter for Blue").ClickAsync();

            await Page.WaitForSelectorAsync(".header-position");
            //await Page.GetByRole(AriaRole.Heading, new() { Name = "Women's Blue Shoes(134)" }).First.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });

            var titelsAfter = await Page.Locator(".product-card__title").AllInnerTextsAsync();

            //Assert
            Assert.That(titelsAfter.First(), Is.Not.EqualTo(titelsBefore.First()));

        }

        [Test]
        public async Task Snikkers()
        {
            //Arrange
            await Page.GotoAsync("https://deltasport.ua/ua/store/women/");

            //Act
            var titelsBefore = await Page.Locator(".item_name").AllInnerTextsAsync();
            await Page.Locator("li").Filter(new() { HasText = "Кросівки" }).Locator("label").ClickAsync();

            await Page.WaitForSelectorAsync(".grid");

            var titelsAfter = await Page.Locator(".item_name").AllInnerTextsAsync();

            //Assert
            Assert.That(titelsBefore.First().ToLower(), Does.Not.Contain("кросівки"));
            Assert.That(titelsAfter.First().ToLower(), Does.Contain("кросівки"));
        }
    }
}
