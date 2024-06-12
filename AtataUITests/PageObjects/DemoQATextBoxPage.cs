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
        [WaitSeconds(10, TriggerEvents.BeforeClick)]
        [FindById("submit")]

        [FindById("name")]
        public Text<_> FullNameText { get; set; }

        [FindByPlaceholder("name@example.com")]
        public Label<_> EmailLabel { get; set; }

        [FindById("userEmail")]
        public EmailInput<_> Email { get; set; }

        [FindById("email")]
        public Text<_> EmailText { get; set; }

        [FindById("currentAddress-label")]
        public Label<_> CurrentAddressLabel { get; set; }

        [FindById("currentAddress")]
        public TextInput<_> CurrentAddress { get; set; }

        [FindById("permanentAddress-label")]
        public Label<_> PermanentAddressLabel { get; set; }

        [FindById("permanentAddress")]
        public TextInput<_> PermanentAddress { get; set; }

	}
}
