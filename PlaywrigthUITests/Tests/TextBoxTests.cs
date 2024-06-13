using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    [TestFixture]
    internal class TextBoxTests : UITestFixture
    {
        private PO_TextBoxPage _demoQATextBoxPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQATextBoxPage = new PO_TextBoxPage(Page);
        }

        [Test]
        [Description("Text 'Full Name' should be visible")]
        public async Task VerifyTextFullName()
        {
            var isVisible = await _demoQATextBoxPage.IsFullNameTextlVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' should be visible.");
        }

        [Test]
        [Description("FullName Placeholder should be visible")]
        public async Task VerifyFullNamePlaceholder()
        {
            await _demoQATextBoxPage.GoToTextBoxPage();
            var isVisible = await _demoQATextBoxPage.IsFullNamePlaceholderVisible();
            Assert.That(isVisible, Is.True, "The element with placeholder 'Full Name' should be visible.");
        }

        [Test]
        [Order(1)]
        [Description("Enter 'Test Name 123' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyFilledTextFullName()
        {
            await _demoQATextBoxPage.GoToTextBoxPage();
            await _demoQATextBoxPage.FillFullName("Test Name 123");
            await _demoQATextBoxPage.isFullNameFocused();
            await _demoQATextBoxPage.ClickSubmitButton();
            await _demoQATextBoxPage.isSubmitButtonFocused();
            var isVisible = await _demoQATextBoxPage.IsNameVisible("Test Name 123");
            Assert.That(isVisible, Is.True, "The element with text 'Name:Test Name 123' should be visible.");
        }

        [Test]
        [Order(2)]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await _demoQATextBoxPage.GoToTextBoxPage();
            await _demoQATextBoxPage.ClearFullNameInput();
            await _demoQATextBoxPage.ClickSubmitButton();
            await _demoQATextBoxPage.isSubmitButtonFocused();
            var isVisible = await _demoQATextBoxPage.IsNameHidden("Test Name 123");
            Assert.That(isVisible, Is.True, "The element with text 'Name:Test Name 123' should not be visible.");
        }
    }
}
