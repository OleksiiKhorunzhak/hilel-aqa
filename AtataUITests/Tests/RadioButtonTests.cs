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
        //TC-2 : Verify No radio Button disabled and not show text 'You have selected'
        //TC-3 : Verify H1 Radio Button is visible
        //TC-7 : Verify text 'You have selected Impressive' is not visible after page refresh

    }
}
