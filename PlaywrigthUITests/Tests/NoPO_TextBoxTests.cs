using Microsoft.Playwright;
namespace PlaywrigthUITests.Tests
{
    [Description("Verify text box on buttons page")]
    class NoPO_TextBoxTests : UITestFixture
    {
        //Test Data:
        private string textBoxURL = "https://demoqa.com/text-box";
        private string fullName = "Test Name 123";


        [SetUp]
        [Description("Precondition GoTo text-box page")]
        public async Task TextBoxPageSetUp()
        {
            await Page.GotoAsync(textBoxURL);
            //await Page.WaitForURLAsync(textBoxURL);
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
        [Description("Input placeholder 'Full Name' should be visible")]
        public async Task VerifyPLaceholderFullName()
        {
            var isVisiblePlaceholder = await Page.GetByPlaceholder("Full Name").IsVisibleAsync();
            Assert.That(isVisiblePlaceholder, "Input placeholder 'Full Name' is not visible");
        }

        [Test]
        [Description("Enter {fullName} into 'Full Name' text input, press submit btn -> output text should be 'Name:{fullName}'")]
        public async Task VerifyFilledTextFullName()
        {
            await Page.GetByPlaceholder("Full Name").FillAsync(fullName);
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisibleOutput = await Page.GetByText($"Name:{fullName}").IsVisibleAsync();
            Assert.That(isVisibleOutput, $"Output text Name is not same as {fullName}");
        }

        [Test]
        [Order(2)]
        [Description("Clear Full Name text input, press submit, Output text should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await Page.GetByPlaceholder("Full Name").ClearAsync();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisibleOutput = await Page.GetByText($"Name:{fullName}").IsHiddenAsync();
            Assert.That(isVisibleOutput, "Output text Name is not cleared");
        }
    }
}