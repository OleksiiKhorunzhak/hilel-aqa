using Atata;
using Microsoft.Playwright;
using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {
        [FindByPlaceholder("Full Name")] public TextInput<_> FullNameInput { get; set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> EmailInput { get; set; }

        [FindByPlaceholder("Current Address")] public TextArea<_> CurrentAddressInput { get; set; }

        [FindById("userName-label")] public Label<_> FullNameLabel { get; set; }

        [FindById("submit")] public Button<_> Submit { get; private set; }

        [FindById("name")] public Text<_> NameOutput { get; private set; }

        [FindById("email")] public Text<_> EmailOutput { get; private set; }

        [FindById("currentAddress")] 
        public Text<_> CurrentAddressOutput { get; set; }

        [FindByXPath("//*[contains(@class, 'border col')]")]
        public Control<_> OutputBorder { get; set; }

        public static void ShouldMatchRegex(EmailInput<_> emailInput, string pattern)
        {
            string emailValue = emailInput.Value;
            bool isMatch = System.Text.RegularExpressions.Regex.IsMatch(emailValue, pattern);
            Assert.That(isMatch, $"The email '{emailValue}' does not match the pattern '{pattern}'");
        }
    }
}