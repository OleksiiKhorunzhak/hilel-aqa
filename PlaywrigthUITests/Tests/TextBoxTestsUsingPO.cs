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
        [Test, Retry(2)]
        [Description("Text Email Name should be visible")]
        [Category("UI")]
        public async Task VerifyEmailLabelVisible()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();

            var isVisible = await _demoQATextBoxPage.IsEmailTextVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' should be visible.");

        }
        [Test, Retry(2)]
        [Description("Text Email Name should be visible")]
        [Category("UI")]
        public async Task VerifyEmailFieldVisible()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            var isVisible = await _demoQATextBoxPage.IsEmailInputVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' should be visible.");

        }
        [Test, Retry(2)]
        [Description("Enter invalid email data like \"John Doe\" in name@example.com Input, press submit, bar should become red")]
        [Category("UI")]
        public async Task TestIncorrectInputInEmailField()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            await _demoQATextBoxPage.FillFullEmail("John Doe");
            await _demoQATextBoxPage.ClickSubmitButton();
            var isVisible = await _demoQATextBoxPage.IsEmailVisible("John Doe");
            Assert.That(isVisible, Is.False, "The element with text 'John Doe' should not be visible.");
        }

        [Test, Retry(2)]
        [Description(" Enter valid email data like \"ABC@gmail.com\" in " +
          "name@example.com Input, press submit, text Name should be ABC@gmail.com")]
        [Category("UI")]
        public async Task TestEmailFieldInput()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            await _demoQATextBoxPage.FillFullEmail("ABC@gmail.com");
            await _demoQATextBoxPage.ClickSubmitButton();
            var isVisible = await _demoQATextBoxPage.IsEmailVisible("ABC@gmail.com");
            Assert.That(isVisible, Is.True, "The element with text 'ABC@gmail.com' should be visible.");

        }
        [Test, Retry(2)]
        [Description("Clear name@example.com Input, press submit, text email " +
         "should not be visible")]
        [Category("UI")]
        public async Task TestEmailFieldClearence()
        {
            await _demoQATextBoxPage.GoToElementsPage();
            await _demoQATextBoxPage.ClickTextBoxMenu();
            await _demoQATextBoxPage.WaitForTextBoxPage();
            await _demoQATextBoxPage.FillFullEmail("ABC@gmail.com");
            await _demoQATextBoxPage.ClickSubmitButton();
            var isVisible = await _demoQATextBoxPage.IsEmailVisible("ABC@gmail.com");
            Assert.That(isVisible, Is.True, "The element with text 'ABC@gmail.com' should be visible.");
            await _demoQATextBoxPage.FillFullEmail("");
            await _demoQATextBoxPage.ClickSubmitButton();
            isVisible = await _demoQATextBoxPage.IsEmailVisible("");
            Assert.That(isVisible, Is.False, "The element with text 'ABC@gmail.com' should be visible.");

        }
    }
}