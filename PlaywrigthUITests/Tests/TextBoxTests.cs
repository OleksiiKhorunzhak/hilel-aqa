using Microsoft.Playwright;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify text box on buttons page")]
    class TextBoxTests : UITestFixture
    {
        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            // Given I go to DemoQa Elements Page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            var isVisible = await Page.GetByText("Full Name").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public async Task VerifyTextFieldFullName()
        {
            // Given I go to DemoQa Elements Page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");

            var isVisible = await Page.GetByPlaceholder("Full Name").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyTextSetFullName()
        {
            // Given I go to DemoQa Elements Page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Full Name' text input
            await Page.GetByPlaceholder("Full Name").FillAsync("John Doe");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I see "Name:John Doe" text.
            var isVisible = await Page.GetByText("Name:John Doe").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            // Given I go to DemoQa Elements Page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Full Name' text input
            await Page.GetByPlaceholder("Full Name").FillAsync("");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I not see "Name:John Doe" text.
            var isVisible = await Page.GetByText("Name:John Doe").IsHiddenAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }
    }
}