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
       
        [Test, Description("verify impressive radio button can be checked and display text 'you have selected impressive'")]
        public void VerifyImpressiveRadioButton()
        {
            Go.To<DemoQARadioButtonPage>().
                RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
                RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].RadioButton.Should.BeChecked().
                Text.Should.Be("You have selected Impressive");
        }

        //TC-3 : Verify No radio Button disabled and not show text 'You have selected'

        [Test, Description("No radio Button disabled and not show text 'You have selected'")]
        public void NoRadioButtonDisabled() 
        {
            Go.To<DemoQARadioButtonPage>().
                RadioButtons[x => x.Label.Content.Value.Equals("No")].Label.Click().
                RadioButtons[x => x.Label.Content.Value.Equals("No")].RadioButton.Should.BeDisabled().
                Text.Should.Not.BeVisible();
 
        }
       
        //TC-4 : Verify H1 Radio Button is visible

        [Test, Description("Verify H1 Radio Button is visible")]
        public void VerifyH1TitleTextRadioButtonVisible() 
        {
            Go.To<DemoQARadioButtonPage>().
                    H1TitleRadioButton.Should.Be("Radio Button");
        }

        //TC-5 : Verify text 'You have selected Impressive' is not visible after page refresh

        [Test, Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        public void VerifyTextImpressiveRadioNotVisibleafterPageRefresh() 
        {
            Go.To<DemoQARadioButtonPage>().
                    RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
                    Text.Should.Be("You have selected Impressive").
                    RefreshPage().
                    Text.Should.Not.BeVisible();


        }


    }
}
