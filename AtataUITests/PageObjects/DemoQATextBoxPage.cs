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

        [WaitSeconds(5, TriggerEvents.BeforeClick)]
        [ScrollDownAttribute(TriggerEvents.BeforeClick)]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameText { get; set; }
        
        [FindById("userEmail-label")]
        public Label<_> EmailLabel { get; set; }
        
        [FindById("userEmail")]
        public EmailInput<_> EmailLabelInput { get; set; }
        
        [FindById("currentAddress-label")]
        public Label<_> CurrentAddress { get; set; }
        
        [FindByPlaceholder("Current Address")]
        public TextArea<_> CurrentAddressLabel { get; set; }
        
        [FindById("permanentAddress-label")]
        public Label<_> PermanentAddress { get; set; }
        
        [FindById("permanentAddress")]
        public TextArea<_> PermanentAddressLabel { get; set; }
        
        [FindById("submit")]
        public Button<_> SubmitButton { get; set; }
        
        [FindById("submit")]
        public Text<_> SubmitLabel { get; set; }
        
        [FindById("name")]
        public Text<_> FullNameResult { get; set; }
        
        [FindById("email")]
        public Text<_> EmailResult { get; set; }
        
        [FindByCss("p#currentAddress.mb-1")]
        public Text<_> CurrentAddressResult { get; set; }
        
        [FindByCss("p#permanentAddress.mb-1")]
        public Text<_> PermanentAddressResult { get; set; }
        
        [FindByXPath ("mr-sm-2 field-error form-control")]
        public EmailInput<_> EmailValidationError { get; set; }
    }
}
