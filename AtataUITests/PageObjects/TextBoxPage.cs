using Atata;
using _ = AtataUITests.PageObjects.TextBoxPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Text Box")]
    [Url("text-box")]
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [FindByClass("text-center")]
        public Text<_> TextBoxPageH1 { get; set; }

        [FindById("userName-label")]
        public Label<_> UserNameLable { get; set; }

        [FindByPlaceholder("Full Name")]
        public TextInput<_> UserNameInput { get; set; }

        
        //Label to 'Email' input
  
        //'Email' input type=email

        //Label to 'Current Address' textarea

        //'Current Address' textarea
    }
}
    