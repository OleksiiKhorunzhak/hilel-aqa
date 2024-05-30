using Microsoft.Playwright;
using static Microsoft.Playwright.NUnit.SkipAttribute;
namespace PlaywrigthUITests.Tests
{
    [TestFixture]

    [Description("Verify text box on buttons page")]
    class TextBoxTests : UITestFixture
    {
        [SetUp]
        public async Task SetupTextBoxPage()
        {
			await Page.GotoAsync("https://demoqa.com/elements");
			await Page.GetByText("Text Box").ClickAsync();
			await Page.WaitForURLAsync("https://demoqa.com/text-box");
		}

		[Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
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
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisible = await Page.GetByText("Name:John Doe").IsVisibleAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await Page.GetByPlaceholder("Full Name").FillAsync("");
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisible = await Page.GetByText("Name:John Doe").IsHiddenAsync();
            Assert.That(isVisible, "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
        }

		//Test Case 5: "Email" field should be visible
		[Test]
		[Description("Email field should be visible")]
		public async Task VerifyEmailFieldVisibility()
		{
			var isVisible = await Page.GetByPlaceholder("name@example.com").IsVisibleAsync();
			Assert.That(isVisible == true, "Field Email with placeholder 'name@example.com' isn't visible");
		}
		//Test Case 6: "name@example.com" placeholder should be visible in "Email" field
		[Test]
		[Description("Email field placeholder should be visible")]
		public async Task VerifyEmailFieldPlaceholder()
		{
			var isVisible = await Page.GetByPlaceholder("name@example.com").IsVisibleAsync();
			Assert.That(isVisible == true, $"Email field wasn't found by placeholder");
		}
		//Test Case 7: Enter valid email in "Email" field (test@mail.com), click on "Submit" button, text row "Email:{email}" should be visible, field is not red highlighted
		[Test]
		[Description("Email field should submit valid data")]
		public async Task VerifySubmitEmailFieldValidData()
		{
			await Page.GetByPlaceholder("name@example.com").FillAsync("qwerty@test.com");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			var isVisible = await Page.GetByText("Email:qwerty@test.com").IsVisibleAsync();
			Assert.That(isVisible == true, $"Row 'Email:qwerty@test.com' wasn't found after Submit email");
		}
		//Test Case 8: Enter invalid email in "Email" field (testmail.com), click on "Submit" button, text row shouldn't be visible, field is red highlighted
		[Test]
		[Description("Email field should be highlighted after submit invalid data")]
		public async Task VerifySubmitEmailFieldInvalidData()
		{
			await Page.GetByPlaceholder("name@example.com").FillAsync("qwerty");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			var isVisible = await Page.Locator(".mr-sm-2.field-error.form-control").IsVisibleAsync();
			Assert.That(isVisible == true, $"Highlighted Email error field isn't visible after invalid data submit");
		}
		//Test Case 9: Enter text in "Email" field, submit, clear "Email" field, click on "Submit" button, text row "Email:{text}"should shouldn't be visible
		[Test]
		[Description("Text row Email:{text} shouldn't be visible after clear Email field and re-submit")]
		public async Task VerifySubmitEmailFieldAfterClear()
		{
			await Page.GetByPlaceholder("name@example.com").FillAsync("qwerty@test.com");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			await Page.GetByText("Email:qwerty@test.com").IsVisibleAsync();
			await Page.GetByPlaceholder("name@example.com").FillAsync("");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			var isVisible = await Page.GetByText("Email:qwerty@test.com").IsVisibleAsync();
			Assert.That(isVisible == false, $"Row 'Email:qwerty@test.com' is still visible after clear");
		}

		//Test Case 13: Enter text in "Current Address" field, submit, clear "Current Address" field, click on "Submit" button, text row "Current Address: {text}" should shouldn't be visible
		[Test]
		[Description("Text row Current Address:{text} shouldn't be visible after clear Current Address field and re-submit")]
		public async Task VerifyCurrentAdderessTextboxAfterClear()
		{
			await Page.GetByPlaceholder("Current Address").FillAsync("qwerty");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			await Page.GetByText("Current Address :qwerty").IsVisibleAsync();
			await Page.GetByPlaceholder("Current Address").FillAsync("");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			var isVisible = await Page.GetByText("Current Address :qwerty").IsVisibleAsync();
			Assert.That(isVisible == false, $"Row 'Current Address :qwerty' is still visible after clear");
		}

		//Test Case 13: Enter text in "Permanent Address" field, submit, clear "Permanent Address" field, click on "Submit" button, text row "Current Address: {text}" should shouldn't be visible
		[Test]
		[Description("Text row Permanent Address:{text} shouldn't be visible after clear Permanent Address field and re-submit")]
		public async Task VerifyPermanentAdderessTextboxAfterClear()
		{
			await Page.Locator("#permanentAddress").FillAsync("qwerty");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			await Page.GetByText("Permananet Address :qwerty").IsVisibleAsync();
			await Page.Locator("#permanentAddress-wrapper #permanentAddress").FillAsync("");
			await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
			var isVisible = await Page.GetByText("Permananet Address :qwerty").IsVisibleAsync();
			Assert.That(isVisible == false, $"Row 'Permananet Address :qwerty' is still visible after clear");
		}
	}
}