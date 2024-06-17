using Atata;
using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }

        [FindById("userName-label")]
        public Label<_> FullNameLabel { get; set; }

        [FindById("submit")]
        [ScrollTo]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameText { get; set; }

        [FindByPlaceholder("Full Name")]
        public Frame<_> BorderColorFullName { get; set; }

        [FindByClass("alert-message")]
        public Text<_> AlertMessage { get; set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> EmailInput { get; set; }
        
        [FindById("email")]
        public Text<_> EmailText { get; set; }

        [FindByPlaceholder("name@example.com")]
        public Frame<_> BorderColorEmail { get; set; }

        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddressInput { get; set;}

        [FindById("currentAddress")]
        public Text<_> CurrentAddressText { get; set; }

        [FindByPlaceholder("Current Address")]
        public Frame<_> BorderColorCurrentAddress { get; set; }

        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddressInput { get; set; }

    }
}
