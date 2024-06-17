using Atata;
using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {


        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }

        [FindById("userName-Label")]
        [FindById("userName-label")]
        public Label<_> FullNameLabel { get; set; }

        [FindByXPath("//h1[@class='text-center' and text()='Text Box']")]
        public H1<_> TextBox { get; set; }

        [FindByXPath("//button[@id='submit' and @class='btn btn-primary']")]
        [ScrollDown(TriggerEvents.BeforeAccess)]
        public Button<_> Submit { get; set; }

        [FindByXPath("//p[@id='name' and @class='mb-1']")]
        public Text<_> NameInput { get; set; }

        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullNamePlaceholder { get; set; }

        [FindByXPath("//label[@id='userEmail-label']")]
        public Text<_> EmailLabel { get; set; }

        [FindById("userEmail")]
        public EmailInput<_> Email { get; set; }

        [FindByPlaceholder("name@example.com")]
        public EmailInput<_> EmailPlaceholder { get; set; }

        [FindByXPath("//p[@id='email' and @class='mb-1']")]
        public Text<_> EmailInput { get; set; }
    }

}
