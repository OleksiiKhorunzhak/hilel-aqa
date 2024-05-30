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
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            var isVisible = await Page.GetByText("Full Name").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public async Task VerifyTextFieldFullName()
        {
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");

            var isVisible = await Page.GetByPlaceholder("Full Name").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyTextSetFullName()
        {
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons page
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
            // Given I go to DemoQa Elements page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Full Name' text input
            await Page.GetByPlaceholder("Full Name").FillAsync("");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I not see "Name:John Doe" text.
            var isVisible = await Page.GetByText("Name:John Doe").IsHiddenAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }
        
        //Test Case 5: Text Email should be visible
        //Test Case 6: Text Email Input should be visible
        //Test Case 7: Enter valid email in Text Email Input, press submit, text Email should be "Email:valid email"
        //Test Case 8: Clear Text Email Input, press submit, text Email should hide
        //Test Case 9: Enter invalid email in Text Email Input, press submit, email input framed with red color
        //Test Case 10: Text Current Address should be visible
        //Test Case 11: Text Current Address Input should be visible
        //Test Case 12: Current Address Input area is resizable
        //Test Case 13: Enter "Current Address" in Text Current Address Input, press submit, text Current Address should be "Current Address:Current Address"
        //Test Case 14: Clear Text Current Address Input, press submit, text Current Address should be visible, Current Address Input should be empty
        //Test Case 15: Text Permanent Address should be visible
        //Test Case 16: Text Permanent Address Input should be visible
        //Test Case 17: Permanent Address Input area is resizable
        //Test Case 18: Enter "Permanent Address" in Text Permanent Address Input, press submit, text Permanent Address should be "Permanent Address:Permanent Address"
        //Test Case 19: Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible, Permanent Address Input should be empty
        
    }
}