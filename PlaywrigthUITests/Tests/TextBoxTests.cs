using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    [TestFixture]
    internal class TextBoxTests : UITestFixture
    {
        private PO_TextBoxPage _TextBoxPage;

        [SetUp]
        public void SetupTextBoxPage()
        {
            _TextBoxPage = new PO_TextBoxPage(Page);
        }

        [Test]
        [Description("Text 'Full Name' should be visible")]
        public async Task VerifyTextFullName()
        {
            await _TextBoxPage.GoToTextBoxPage();
            var isVisible = await _TextBoxPage.IsFullNameTextlVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' is not visible.");
        }

        [Test]
        [Description("FullName Placeholder should be visible")]
        public async Task VerifyFullNamePlaceholder()
        {
            await _TextBoxPage.GoToTextBoxPage();
            var isVisible = await _TextBoxPage.IsFullNamePlaceholderVisible();
            Assert.That(isVisible, Is.True, "The element with placeholder 'Full Name' should be visible.");
        }

        [Test]
        [Order(1)]
        [Description("Enter 'Test Name 123' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyFilledTextFullName()
        {
            await _TextBoxPage.GoToTextBoxPage();
            await _TextBoxPage.FillFullName("Test Name 123");
            await _TextBoxPage.isFullNameFocused();
            await _TextBoxPage.ClickSubmitButton();
            await _TextBoxPage.isSubmitButtonFocused();
            var isVisible = await _TextBoxPage.IsNameVisible("Test Name 123");
            Assert.That(isVisible, Is.True, "The element with text 'Name:Test Name 123' should be visible.");
        }

        [Test]
        [Order(2)]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await _TextBoxPage.GoToTextBoxPage();
            await _TextBoxPage.ClearFullNameInput();
            await _TextBoxPage.ClickSubmitButton();
            await _TextBoxPage.isSubmitButtonFocused();
            var isVisible = await _TextBoxPage.IsNameHidden("Test Name 123");
            Assert.That(isVisible, Is.True, "The element with text 'Name:Test Name 123' should not be visible.");
        }
    }
}
