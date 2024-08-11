using Atata;
using System.Reflection.Emit;
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
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> NameOutput { get; set; }

        [FindById("userEmail-label")]
        public Label<_> EmailLabel { get; private set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> Email { get; set; }

        [FindById("email")]
        public Text<_> EmailOutput { get; set; }

        [FindById("currentAddress-label")]
        public Label<_> CurrentAddressLabel { get; set; }

        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddress { get; set; }

        [FindByXPath("//*[@id=\"currentAddress\" and @class=\"mb-1\"]")]
        public Text<_> CurrentAddressOutput { get; set; }

        [FindById("permanentAddress-label")]
        public Label<_> PermanentAddressLabel { get; set; }

        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddress { get; set; }

        [FindByXPath("//*[@id=\"permanentAddress\" and @class=\"mb-1\"]")]
        public Text<_> PermanentAddressOutput { get; set; }
    }
}