using Microsoft.Playwright;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify text box on buttons page")]
    class TextBoxTests : UITestFixture
     

    {
        [SetUp]
        public async Task SetupRadioButtonQAPage()
        {
            // Given I go to DemoQa Elements Page 
            await Page.GotoAsync("https://demoqa.com/elements");
            // When I Click the Buttons button in menu
            await Page.GetByText("Text Box").ClickAsync();
            // And I see 'buttons Page
            await Page.WaitForURLAsync("https://demoqa.com/text-box");


        }
        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            // Given I go to DemoQa Elements Page 
              var isVisible = await Page.GetByText("Full Name").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public async Task VerifyTextFieldFullName()
        {
           
            var isVisible = await Page.GetByPlaceholder("Full Name").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyTextSetFullName()
        {
           
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
           await Page.GetByPlaceholder("Full Name").FillAsync("");
            // And I click Submit button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            // Then I not see "Name:John Doe" text.
            var isVisible = await Page.GetByText("Name:John Doe").IsHiddenAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }
        [Test, Retry(2)]
        [Description("Text Email Name should be visible")]
        [Category("UI")]
        public async Task VerifyEmailLabelVisible()
        {
            var isVisible = await Page.GetByText("email").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }
        [Test, Retry(2)]
        [Description("Text Email Name should be visible")]
        [Category("UI")]
        public async Task VerifyEmailFieldVisible()
        {
             var isVisible = await Page.GetByPlaceholder("name@example.com").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }
        [Test, Retry(2)]
        [Description("Enter invalid email data like \"John Doe\" in name@example.com Input, press submit, bar should become red")]
        [Category("UI")]
        public async Task TestIncorrectInputInEmailField()
        {
             await Page.GetByPlaceholder("name@example.com").FillAsync("John Doe");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisible = await Page.GetByText("dwwddw").IsHiddenAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should not be visible after clicking the button.");
        }
        [Test, Retry(2)]
        [Description(" Enter valid email data like \"ABC@gmail.com\" in " +
            "name@example.com Input, press submit, text Name should be ABC@gmail.com")]
        [Category("UI")]
        public async Task TestEmailFieldInput()
        {
            await Page.GetByPlaceholder("name@example.com").FillAsync("ABC@gmail.com");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisible = await Page.GetByText("Email:ABC@gmail.com").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should not be visible after clicking the button.");
        }
        [Test, Retry(2)]
        [Description("Clear name@example.com Input, press submit, text email " +
            "should not be visible")]
        [Category("UI")]
        public async Task TestEmailFieldClearence()
        {
             await Page.GetByPlaceholder("name@example.com").FillAsync("ABC@gmail.com");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisible = await Page.GetByText("Email:ABC@gmail.com").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should not be visible after clicking the button.");
            await Page.GetByPlaceholder("name@example.com").FillAsync("");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            isVisible = await Page.GetByText("Email:ABC@gmail.com").IsHiddenAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should not be visible after clicking the button.");
        }

    }
}
