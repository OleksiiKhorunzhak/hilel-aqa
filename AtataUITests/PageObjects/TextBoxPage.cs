using Atata;
using _ = AtataUITests.PageObjects.TextBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("text-box")]
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [FindByClass("text-center")]
        public Text<_> TextBoxH1 { get; set; }

        //Label:
        [FindById("userName-label")]
        public Label<_> FullNameLabel { get; set; }

        [FindById("userEmail-label")]
        public Label<_> EmailLabel { get; set; }

        [FindById("currentAddress-label")]
        public Label<_> CurrentAddressLabel { get; set; }

        [FindById("permanentAddress-label")]
        public Label<_> PermanentAddressLabel { get; set; }

        //Inputs:
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullNameInput { get; set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> EmailInput { get; set; }

        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddressInput { get; set; }

        [FindById("permanentAddress")]
        public TextInput<_> PermanentAddressInput { get; set; }

        //Button:
        [FindById("submit")]
        public Button<_> Submit { get; set; }

        //Output:
        [FindById("output")]
        public Text<_> Output { get; set; }
    }
}
