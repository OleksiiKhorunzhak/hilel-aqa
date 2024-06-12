using PlaywrigthUITests.PageObjects;
using System.Xml.Linq;

namespace PlaywrigthUITests.Tests
{
    [TestFixture]
    internal class TextBoxTestsUsingPO : UITestFixture
    {
        private DemoQATextBoxPage _demoQATextBoxPage;

        [SetUp]
        public async Task SetupDemoQATextBoxPage()
        {
            _demoQATextBoxPage = new DemoQATextBoxPage(Page);
            await _demoQATextBoxPage.GoToTextBoxPage();
        }

        #region Full_Name
        [Test]
        [Description("Text Full Name should be visible")]
        public async Task VerifyTextFullName()
        {
            var isVisible = await _demoQATextBoxPage.IsFullNameTextVisible();
            Assert.That(isVisible, Is.True, "The element with text 'Full Name' should be visible.");
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public async Task VerifyTextFieldFullName()
        {
            var isVisible = await _demoQATextBoxPage.IsFullNameInputVisible();
            Assert.That(isVisible, Is.True, "The element with placeholder 'Full Name' should be visible.");
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public async Task VerifyTextSetFullName()
        {
            await _demoQATextBoxPage.FillFullName("John Doe");
            await _demoQATextBoxPage.ClickSubmitButton();

            var isVisible = await _demoQATextBoxPage.IsNameVisible("John Doe");
            Assert.That(isVisible, Is.True, "The element with text 'Name:John Doe' should be visible.");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public async Task VerifyTextClearFullName()
        {
            await _demoQATextBoxPage.FillFullName("Test name");
            await _demoQATextBoxPage.ClickSubmitButton();
            await _demoQATextBoxPage.ClearFullNameInput();
            await _demoQATextBoxPage.ClickSubmitButton();

            var isVisible = await _demoQATextBoxPage.IsNameHidden("Test name");
            Assert.That(isVisible, Is.True, "The element with text 'Name:Test name' should not be visible.");
        }
        #endregion

        #region Email

        [Test]
        public async Task VerifyEmailFieldValueComplianceWithRegExp()
        {
            string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
            await _demoQATextBoxPage.FillEmail("email@test.com");
            var isEmailCorrect = await _demoQATextBoxPage.EmailCorrespondsToRegExp(emailPattern);

            Assert.That(isEmailCorrect, Is.True, "Email is incorrect");
        }

        [Test]
        [Description("Incorrect email should not be submitted")]
        public async Task VerifyEmailCannotBeSubmittedWithIncorrectValue()
        {
            await _demoQATextBoxPage.FillEmail("email@com");
            await _demoQATextBoxPage.ClickSubmitButton();

            var IsIncorrectEmailSubmitted = await _demoQATextBoxPage.IsEmailOutputHidden();

            Assert.That(IsIncorrectEmailSubmitted, Is.True);
        }
        #endregion

        #region CurrentAddress
        [Test]
        public async Task VerifyCurrentAddressIsTextArea()
        {
            var isTextArea = await _demoQATextBoxPage.IsCurrentAddressTextArea();
            Assert.That(isTextArea, Is.True);
        }
        #endregion
    }
}