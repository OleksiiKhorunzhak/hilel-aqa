using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    [TestFixture]
    internal class TextBoxTestsUsingPO : UITestFixture
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
        [Description("Text Full Name Input should be visible")]
        public async Task VerifyTextFieldFullName()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();

            var isVisible = await _demoQATextBoxPage.IsFullNameInputVisible();
            Assert.That(isVisible, Is.True, "The element with placeholder 'Full Name' should be visible.");
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyTextSetFullName()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            await _demoQATextBoxPage.FillFullName("John Doe");
            await _demoQATextBoxPage.ClickSubmitButton();

            var isVisible = await _demoQATextBoxPage.IsNameVisible("John Doe");
            Assert.That(isVisible, Is.True, "The element with text 'Name:John Doe' should be visible.");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            await _demoQATextBoxPage.FillFullName("");
            await _demoQATextBoxPage.ClickSubmitButton();

            var isVisible = await _demoQATextBoxPage.IsNameHidden("John Doe");
            Assert.That(isVisible, Is.True, "The element with text 'Name:John Doe' should not be visible.");
        }
    }
}
