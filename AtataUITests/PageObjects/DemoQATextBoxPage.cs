using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }

        [FindById("userName-label")]
        public Label<_> FullNameLabel { get; set; }

        [ScrollTo]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameText { get; set; }
        
        [FindById("userEmail-label")]
        public Label<_> EmailLabel { get; set; }
        
        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> EmailInput { get; set; }

        [FindById("email")] 
        public Text<_> EmailText { get; set; }
        
        [FindById("currentAddress-label")]
        public Label<_> CurrentAddressLabel { get; set; }
        
        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddressArea { get; set; }
        
        [FindById("currentAddress")]
        public TextArea<_> CurrentAddressText { get; set; }
        
        [FindById("permanentAddress-label")]
        public Label<_> PermanentAddressLabel { get; set; }
        
        [FindByXPath("*[@id=\"permanentAddress\"]")] 
        public TextArea<_> PermanentAddressArea { get; set; }
        
        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddressText { get; set; }
    }
}
