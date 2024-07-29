using Atata;
using AtataUITests.Tests;
using OpenQA.Selenium.DevTools.V122.Autofill;
using OpenQA.Selenium.DevTools.V123.Autofill;
using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("text-box")]
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {
        internal readonly object PermanentAddressInput;

        [FindByXPath("//h1[@class='text-center' and text()='Text Box']")]
        public H1<_> TextBox { get; set; }

        [FindById("userName")]
        public TextInput<_> FullName { get; set; }

        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullNamePlaceholder { get; set; }

        [FindByXPath("//label[@id='userName-label']")]
        public Text<_> FullNameLabel { get; set; }

        [FindByXPath("//button[@id='submit' and @class='btn btn-primary']")]
        [ScrollDown(TriggerEvents.BeforeAccess)]
        public Button<_> Submit { get; set; }

        [FindByXPath("//p[@id='name' and @class='mb-1']")]
        public Text<_> NameInput { get; set; }

        [FindByXPath("//label[@id='userEmail-label']")]
        public Text<_> EmailLabel { get; set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> EmailPlaceholder { get; set; }

        [FindById("userEmail")]
        public EmailInput<_> Email { get; set; }

        [FindByXPath("//p[@id='email' and @class='mb-1']")]
        public Text<_> EmailInput { get; set; }

        [FindById("currentAddress")]
        public TextArea<_> CurrentAddress { get; set; }

        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddressPlaceholder { get; set; }

        [FindByXPath("//p[@id='currentAddress' and @class='mb-1']")]
        public Text<_> CurrentAddressInput { get; set; }

        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddress { get; set; }

        [FindByXPath("//p[@id='permanentAddress' and @class='mb-1']")]
        public Text<_> PermanentAddressInputField { get; set; }

    }

}

