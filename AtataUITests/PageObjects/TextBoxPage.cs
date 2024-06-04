using Atata;
using _ = AtataUITests.PageObjects.TextBoxPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [Url("/text-box")]
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [FindByClass("text-center")]
        public Text<_> TextBoxPageH1 { get; set; }

        [FindById("userName-label")]
        public Label<_> UserNameLable { get; set; }

        [FindByPlaceholder("Full Name")]
        public TextInput<_> UserNameInput { get; set; }   
    }
}
    