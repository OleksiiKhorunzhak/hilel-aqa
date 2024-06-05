using Atata;
using _ = AtataUITests.PageObjects.TextBoxPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [Url("/text-box")]
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [ControlDefinition("Header <h1> - page title")]
        [FindByClass("text-center")]
        public Text<_> TextBoxPageH1 { get; set; }

        [ControlDefinition("Label to 'Full Name' input")]
        [FindById("userName-label")]
        public Label<_> UserNameLable { get; set; }

        [ControlDefinition("'Full Name' input type=text")]
        [FindByPlaceholder("Full Name")]
        public TextInput<_> UserNameInput { get; set; }

        
        [ControlDefinition("Label to 'Email' input")]
        

        [ControlDefinition("'Email' input type=email")]

        [ControlDefinition("Label to 'Current Address' textarea")]

        [ControlDefinition("'Current Address' textarea size:rows=5, cols=20")]

        //[ControlDefinition("'Email' input type=email")]

        //[ControlDefinition("'Email' input type=email")]

    }
}
    