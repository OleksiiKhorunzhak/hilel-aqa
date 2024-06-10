using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects;

internal class DemoQaButtonsPage
{
    private IPage _page;
    private string elementsPageUrl = "https://demoqa.com/elements";
    private string buttonsPageUrl = "https://demoqa.com/buttons";
    
    public DemoQaButtonsPage(IPage page)
    {
        _page = page;
    }

    public async Task GoToButtonsPage()
    {
        await _page.GotoAsync(elementsPageUrl);
        await _page.Locator("li:has-text('Buttons')").ClickAsync();
        await _page.WaitForURLAsync(buttonsPageUrl);
    }

    public async Task RightClickMeButtonIsFocused()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Button, new() { Name = "Right Click Me", Exact = true })).ToBeFocusedAsync();
    }
}