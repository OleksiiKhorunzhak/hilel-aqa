<<<<<<< HEAD
﻿using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }
=======
﻿using Atata;
using OpenQA.Selenium.DevTools.V123.Database;
using _ = AtataUITests.PageObjects.DemoQATextboxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextboxPage : DemoQAPage<_>
    {
        [FindById("submit")]
        [ScrollDown(TriggerEvents.BeforeAccess)]
        public Button<_> Submit { get; set; }
>>>>>>> Ernest_Bukhanevych_Main

        [FindById("userName-label")]
        public Label<_> FullNameLabel { get; set; }

<<<<<<< HEAD
        [ScrollTo]
        public Button<_> Submit { get; set; }

        [FindById("name")]
        public Text<_> FullNameText { get; set; }
=======
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullNameInput { get; set; }

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
        public TextArea<_> CurrentAddressInput { get; set; }

        [FindByXPath("//p[@id='currentAddress' and @class='mb-1']")]
        public Text<_> CurrentAddressText { get; set; }

        [FindById("permanentAddress-label")]
        public Label<_> PermanentAddressLabel { get; set; }

        [FindByXPath("//textarea[@id='permanentAddress' and @class='form-control']")]
        public TextArea<_> PermanentAddressInput { get; set; }

        [FindByXPath("//p[@id='permanentAddress' and @class='mb-1']")]
        public Text<_> PermanentAddressText { get; set; }









>>>>>>> Ernest_Bukhanevych_Main
    }
}
