using Microsoft.Playwright;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify text box on buttons page")]
    class TextBoxTests : UITestFixture
    {
        [SetUp]
        [Description ("Precondition")]
        public async Task TextBoxPageSetUp()
        {
            await Page.GotoAsync("https://demoqa.com/elements");
            await Page.GetByText("Text Box").ClickAsync();
            await Page.WaitForURLAsync("https://demoqa.com/text-box");
        }

        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            var isVisibleText = await Page.GetByText("Full Name").IsVisibleAsync();
            Assert.That(isVisibleText, "The element with text 'Full Name' is not visible on Text Box page.");
        }

        [Test]
        [Order(1)]
        [Description("Input placeholder Full Name should be visible")]
        public async Task VerifyPLaceholderFullName()
        {
            var isVisiblePlaceholder = await Page.GetByPlaceholder("Full Name").IsVisibleAsync();
            Assert.That(isVisiblePlaceholder, "Input placeholder Full Name is not visible");
        }
        //Test Data:
        string filledData = "Test Name 123";

        [Test]
        [Description("Enter 'Test Name 123' into Full Name text input, press submit btn -> output text Name should be 'Test Name 123'")]
        public async Task VerifyTextSetFullName()
        {
            await Page.GetByPlaceholder("Full Name").FillAsync(filledData);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisibleOutput = await Page.GetByText($"Name:{filledData}").IsVisibleAsync();
            Assert.That(isVisibleOutput, $"Output text Name is not same as {filledData}");
        }

        [Test]
        [Order(2)]
        [Description("Clear Full Name text input, press submit, Output text should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await Page.GetByPlaceholder("Full Name").ClearAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisibleOutput = await Page.GetByText($"Name:{filledData}").IsHiddenAsync();
            Assert.That(isVisibleOutput, $"Output text Name is not cleared");
        }
    }
}