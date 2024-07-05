using Microsoft.Playwright;
namespace PlaywrigthUITests.Tests
{
    //[Category("NoPO_TextBoxTests")]
    [Description("Verify text box on buttons page")]
    class _NoPO_TextBoxTests : UITestFixture
    {
        //Test Data:
        private string textBoxURL = "https://demoqa.com/text-box";
        private string fullName = "Test Name 123";


        [SetUp]
        [Description("Precondition GoTo text-box page")]
        public async Task TextBoxPageSetUp()
        {
            await page.GotoAsync(textBoxURL);
            //await page.WaitForURLAsync(textBoxURL);
        }

        [Test, Retry(2)]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            var isVisibleText = await page.GetByText("Full Name").IsVisibleAsync();
            Assert.That(isVisibleText, "The element with text 'Full Name' is not visible on Text Box page.");
        }

        [Test, Retry(2)]
        [Order(1)]
        [Description("Input placeholder 'Full Name' should be visible")]
        public async Task VerifyPLaceholderFullName()
        {
            var isVisiblePlaceholder = await page.GetByPlaceholder("Full Name").IsVisibleAsync();
            Assert.That(isVisiblePlaceholder, "Input placeholder 'Full Name' is not visible");
        }

        [Test, Retry(2)]
        [Description("Enter {fullName} into 'Full Name' text input, press submit btn -> output text should be 'Name:{fullName}'")]
        public async Task VerifyFilledTextFullName()
        {
            await page.GetByPlaceholder("Full Name").FillAsync(fullName);
            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisibleOutput = await page.GetByText($"Name:{fullName}").IsVisibleAsync();
            Assert.That(isVisibleOutput, $"Output text Name is not same as {fullName}");
        }

        [Test, Retry(2)]
        [Order(2)]
        [Description("Clear Full Name text input, press submit, Output text should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await page.GetByPlaceholder("Full Name").ClearAsync();
            await page.GetByRole(AriaRole.Button, new() { Name = "Submit" }).ClickAsync();
            var isVisibleOutput = await page.GetByText($"Name:{fullName}").IsHiddenAsync();
            Assert.That(isVisibleOutput, "Output text Name is not cleared");
        }
    }
}