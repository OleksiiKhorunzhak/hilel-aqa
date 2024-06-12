using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    [TestFixture]
    internal class TextBoxTestsPO : UITestFixture
    {
        private DemoQATextBoxPage _demoQATextBoxPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQATextBoxPage = new DemoQATextBoxPage(Page);
        }

        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();

            var isVisible = await _demoQATextBoxPage.IsFullNameTextVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' should be visible.");
        }

        [Test]
        [Description("Text FullName Placeholder should be visible")]
        public async Task VerifyFullNamePlaceholder()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();

            var isVisible = await _demoQATextBoxPage.IsFullNamePlaceholderVisible();
            Assert.That(isVisible, Is.True, "The element with placeholder 'Full Name' should be visible.");
        }

        [Test]
        [Order(1)]
        [Description("Enter 'Test Name 123' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyFilledTextFullName()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
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
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            await _demoQATextBoxPage.ClearFullNameInput();
            await _demoQATextBoxPage.ClickSubmitButton();
            await _demoQATextBoxPage.isSubmitButtonFocused();

            var isVisible = await _demoQATextBoxPage.IsNameHidden("Test Name 123");
            Assert.That(isVisible, Is.True, "The element with text 'Name:Test Name 123' should not be visible.");
        }
    }
}
