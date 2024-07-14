using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    internal class RadioButtonTests : UITestFixture
    {
        [Test, Retry(2)]
        [Category("RadioButtonTest")]
        public void VerifyYesRadioButtonVisible()
        {
            Go.To<DemoQARadioButtonPage>().
                RadioButtons[x => x.Label.Content.Value.Equals("Yes")].Label.Click().
                RadioButtons[x => x.Label.Content.Value.Equals("Yes")].RadioButton.Should.BeChecked().
                Text.Should.Be("You have selected Yes");
        }

        //Homework Lesson_9
        //TODO : 

        //TC-2 : Verify Impressive radio Button can be checked and display text 'You have selected Impressive'
        [Test, Retry(2)]
        [Description("Verify Impressive radio Button can be checked and display " +
            "text 'You have selected Impressive'")]
        [Category("RadioButtonTest")]
        public void VerifyImpressiveRadioButton()
        {
            Go.To<DemoQARadioButtonPage>().
                 RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
                 RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].RadioButton.Should.BeChecked().
                 Text.Should.Be("You have selected Impressive");
        }

        //TC-3 : Verify No radio Button disabled and not show text 'You have selected'
        [Test, Retry(2)]
        [Description("Verify No radio Button disabled and not show text 'You have selected'")]
        [Category("RadioButtonTest")]
        public void VerifyNoRadioButtonDisabled()
        {
            Go.To<DemoQARadioButtonPage>().
                 RadioButtons[x => x.Label.Content.Value.Equals("No")].RadioButton.Should.BeDisabled().
                 Text.Should.Not.BeVisible();
        }
        //TC-4 : Verify H1 Radio Button is visible
        [Test, Retry(2)]
        [Description("Verify H1 Radio Button is visible")]
        [Category("RadioButtonTest")]
        public void VerifyH1RadioButtonIsVisible()
        {
            Go.To<DemoQARadioButtonPage>().
                 RadioButtonsH1.Should.BeVisible();
        }
        //TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh
        [Test, Retry(2)]
        [Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        [Category("RadioButtonTest")]
        public void VerifyImpressiveRadioButtonIsNotVisibleAfterRefresh()
        {
            Go.To<DemoQARadioButtonPage>().
                RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
                Text.Should.Be("You have selected Impressive").
                RefreshPage().
                Text.Should.Not.BeVisible();
        }
    }
}
