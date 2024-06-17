using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    internal class RadioButtonTests : UITestFixture
    {
        [Test]
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
        //[Test]
        //[Description("Verify Impressive radio Button can be checked and display text 'You have selected Impressive'")]
        //public void VerifyImpressiveRadioButton()
        //{
        //    Go.To<DemoQARadioButtonPage>().
        //        RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
        //}

        //TC-3 : Verify No radio Button disabled and not show text 'You have selected'
        //TC-4 : Verify H1 Radio Button is visible
        //TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh

    }
}
