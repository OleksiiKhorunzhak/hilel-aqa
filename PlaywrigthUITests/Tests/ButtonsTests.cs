using Microsoft.Playwright;
using NUnitTests.Features.Drive;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify Buttons on buttons page")]
    class ButtonsTestsrun : UITestFixture
    {

        public byte newstring = DrivePresetup.Accelerate;
        public byte newstring1 = DrivePresetup.InternalClass.InternalAccelerate;

        [Test, Description("Verify Click Me button"), Retry(2)]
        public async Task ClickButtonTest()
        {
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I click the 'Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).ClickAsync();
            // Then  I see "You have done a dynamic click" text.
            var isVisible = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
            // And I NOT see "You have done a double click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a double click' should NOT be visible after clicking the button.");
        }

        [Test, Description("Verify Double Click Me button"), Retry(3)]
        public async Task DoubleClickButtonTest()
        {
            // Given I go to DemoQA Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I double click the 'Double Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Double Click Me" }).DblClickAsync();
            // Then I see "You have done a double click" text.
            var isVisible = await Page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a double click' should be visible after clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a dynamic click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");
        }

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public async Task RigthClickButtonTest()
        {
            // Given I go to DemoQA Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            // And I Rigth click the 'Right Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });
            // Then I see "You have done a right click" text.
            var isVisible = await Page.GetByText("You have done a right click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a double click' should be visible after Rigth clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isNotVisible, "The element with text 'You have done a dynamic click' should NOT be visible after Rigth clicking the button.");
        }

        //Homework Lesson_9
        //TODO : 

        [Test, Description("Verify that 'Click Me' button is enabled")]
        public async Task ClickMeButtonIsEnabled()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).ClickAsync();

            // Assert that the "Click Me" button is enabled
            var isEnabled = await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).IsEnabledAsync();
            Assert.That(isEnabled, Is.True, "'Click Me' button should be enabled");
        }



        [Test, Description("Verify Click Rigth Click Me button verify button focused")]
        public async Task VerifyClickOfRightClickButtonIsFocused()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Right Click Me" }).ClickAsync(new LocatorClickOptions
            {
                Button = MouseButton.Right,
            });

            var isFocused = await Page.GetByRole(AriaRole.Button, new() { Name = "Right Click Me" }).IsVisibleAsync();
            Assert.That(isFocused, Is.True, "Right-click should have focused the button");

        }

        [Test, Description("Verify H1 Buttons is visible")]
        public async Task VerifyTitleOfButtonsPage()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            await Page.GetByRole(AriaRole.Heading, new() { Name = "Buttons" }).IsEnabledAsync();

            var isVisible = await Page.GetByRole(AriaRole.Heading, new() { Name = "Buttons" }).IsVisibleAsync();
            Assert.That(isVisible, Is.True, "H1 Buttons is visible");

        }

        [Test, Description("Verify text 'You have done a dynamic click' is not visible after page refresh")]

        public async Task VerifyThatTextIsNotVisibleAfterPafeRefreshwhenClickOnClickMeButton()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            await Page.Locator("li:has-text('Buttons')").ClickAsync();
            await Page.WaitForURLAsync("https://demoqa.com/buttons");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).ClickAsync();

            var isVisible = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");

            await Page.ReloadAsync();

            var isNotVisibleAfterRefresh = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.That(isNotVisibleAfterRefresh, Is.False, "The element with text 'You have done a dynamic click' should not be visible after the page refresh.");

        }


    }
}