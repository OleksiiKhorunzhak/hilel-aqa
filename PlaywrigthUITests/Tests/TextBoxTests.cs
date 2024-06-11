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
        
        //Test Case 5: Label Email should be visible

        [Test]
        [Description("Text Email should be visible")]
        public async Task VerifyEmailLabel()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Email" label text
            var isVisible = await Page.GetByText("Email").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Email label is not visible.");
        }
        
        //Test Case 6: Text Email Input should be visible
        
        [Test]
        [Description("Text Email Input should be visible")]
        public async Task VerifyEmailInput()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Email" input text
            var isVisible = await Page.GetByPlaceholder("name@example.com").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Email input is not visible.");
        }
        
        //Test Case 7: Enter valid email in Text Email Input, press submit, text Email should be "Email:valid email"
        
        [Test]
        [Description("Enter valid email in Text Email Input, press submit, text Email should be 'Email:valid email'")]
        public async Task VerifyTextSetEmail()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Email' text input
            await Page.GetByPlaceholder("name@example.com").FillAsync("test@test.com");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I see "Email:valid email" text.
            var isVisible = await Page.GetByText("Email:test@test.com").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Displayed text does not match the expected value");
        }
        
        //Test Case 8: Clear Text Email Input, press submit, text Email should hide

        [Test]
        [Description("Clear Text Email Input, press submit, text Email should hide")]
        public async Task VerifyTextClearEmaiIsHide()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Email' text input
            await Page.GetByPlaceholder("name@example.com").FillAsync("test@test.com");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I see "Email:valid email" text.
            var isVisible = await Page.GetByText("Email:test@test.com").IsVisibleAsync();
            // And I clear the 'Email' text input
            await Page.GetByPlaceholder("name@example.com").ClearAsync();
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I don't see "Email:valid email" text.
            var isHidden = await Page.GetByText("Email:test@test.com").IsHiddenAsync();
            //Assert
            Assert.That(isHidden, "Email input is not hidden.");
        }

        //Test Case 9: Enter invalid email in Text Email Input, press submit, email input framed with red color

        [Test]
        [Description("Enter invalid email in Text Email Input, press submit, email input framed with red color")]
        public async Task VerifyTextInvalidEmail()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Email' text input
            await Page.GetByPlaceholder("name@example.com").FillAsync("test");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I see Email input with red border
            var emailInput = Page.GetByPlaceholder("name@example.com");
            var className = await emailInput.GetAttributeAsync("class");
            //Assert
            Assert.That(className.Contains("field-error"), "Email input is not framed with red color");
        }

        //Test Case 10: Text Current Address should be visible
        
        [Test]
        [Description("Text label Current Address should be visible")]
        public async Task VerifyCurrentAddressLabel()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Current Address" label text
            var isVisible = await Page.GetByText("Current Address").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Current Address label is not visible.");
        }
        
        //Test Case 11: Text Current Address Input should be visible
        
        [Test]
        [Description("Text Current Address Input should be visible")]
        public async Task VerifyCurrentAddressInput()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Current Address" input text
            var isVisible = await Page.GetByPlaceholder("Current Address").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Current Address input is not visible.");
        }
        
        //Test Case 12: Current Address Input area is resizable
        
        [Test]
        [Description("Current Address Input area is resizable")]
        public async Task VerifyCurrentAddressInputResizable()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Current Address" input text
            var inputArea = Page.GetByPlaceholder("Current Address");
            var isResizable = await inputArea.GetAttributeAsync("class");
            //Assert
            Assert.That(isResizable.Contains("form-control"), "Current Address input is not resizable.");
        }
        
        //Test Case 13: Enter "Current Address" in Text Current Address Input, press submit, text Current Address should be "Current Address:Current Address"
        
        [Test]
        [Description("Enter 'Current Address' in Text Current Address Input, press submit, text Current Address should be 'Current Address:Current Address'")]
        public async Task VerifyTextSetCurrentAddress()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Current Address' text input
            await Page.Locator("textarea#currentAddress").FillAsync("Test address");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I see "Current Address:Current Address" text.
            var inputedText = Page.Locator("//*[@id=\"currentAddress\"]");
            var isVisible = await inputedText.GetByText("Current Address :Test address").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Displayed text does not match the expected value");
        }
        
        //Test Case 14: Clear Text Current Address Input, press submit, text Current Address should be visible, Current Address Input should be empty
        
        [Test]
        [Description("Clear Text Current Address Input, press submit, text Current Address should be visible, Current Address Input should be empty")]
        public async Task VerifyClearCurrentAddress()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Current Address' text input
            await Page.Locator("textarea#currentAddress").FillAsync("Test address");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // And I clear the 'Current Address' text input
            await Page.Locator("textarea#currentAddress").ClearAsync();
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I check if the text is visible
            var isVisible = await Page.Locator("#currentAddress").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Current Address input is visible.");
        }
        
        //Test Case 15: Text Permanent Address should be visible
        
        [Test]
        [Description("Text Permanent Address should be visible")]
        public async Task VerifyPermanentAddressLabel()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Permanent Address" label text
            var isVisible = await Page.Locator("#permanentAddress-label").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Permanent Address label is not visible.");
        }
        
        //Test Case 16: Text Permanent Address Input should be visible
        
        [Test]
        [Description("Text Permanent Address Input should be visible")]
        public async Task VerifyPermanentAddressInput()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Permanent Address" input text
            var isVisible = await Page.Locator("#permanentAddress").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Permanent Address input is not visible.");
        }
        
        //Test Case 17: Permanent Address Input area is resizable
        
        [Test]
        [Description("Permanent Address Input area is resizable")]
        public async Task VerifyPermanentAddressInputResizable()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // Then I see "Permanent Address" input text
            var inputArea = Page.Locator("#permanentAddress");
            var isResizable = await inputArea.GetAttributeAsync("class");
            //Assert
            Assert.That(isResizable.Contains("form-control"), "Permanent Address input is not resizable.");
        }
        
        //Test Case 18: Enter "Permanent Address" in Text Permanent Address Input, press submit, text Permanent Address should be "Permanent Address:Permanent Address"
        
        [Test]
        [Description("Enter 'Permanent Address' in Text Permanent Address Input, press submit, text Permanent Address should be 'Permanent Address:Permanent Address'")]
        public async Task VerifyTextSetPermanentAddress()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Permanent Address' text input
            await Page.Locator("textarea#permanentAddress").FillAsync("Test address");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I see "Permanent Address:Permanent Address" text.
            var inputedText = Page.Locator("//*[@id=\"permanentAddress\"]");
            var isVisible = await inputedText.GetByText("Permananet Address :Test address").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Displayed text does not match the expected value");
        }
        
        //Test Case 19: Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible, Permanent Address Input should be empty
        
        [Test]
        [Description("Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible, Permanent Address Input should be empty")]
        public async Task VerifyClearPermanentAddress()
        {
            // Given I go to DemoQa Elements page
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Text Box button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see Text Box page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
            // And I fill the 'Permanent Address' text input
            await Page.Locator("textarea#permanentAddress").FillAsync("Test address");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // And I clear the 'Permanent Address' text input
            await Page.Locator("textarea#permanentAddress").ClearAsync();
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I check if the text is visible
            var isVisible = await Page.Locator("#permanentAddress").IsVisibleAsync();
            //Assert
            Assert.That(isVisible, "Current Address input is visible.");
        }
        
        //#permanentAddress-label  #permanentAddress #permanentAddress
        
    }
}