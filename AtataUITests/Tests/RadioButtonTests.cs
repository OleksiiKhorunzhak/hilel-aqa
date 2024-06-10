using Atata;
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

        [Test, Description("Verify Impressive radio Button can be checked and display text 'You have selected Impressive")]
        public void VerifyImpressiveRadioButton()
        {
            Go.To<DemoQARadioButtonPage>().
                RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
                RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].RadioButton.Should.BeChecked().
                Text.Should.Be("You have selected Impressive");

        }

        [Test, Description("Verify 'No' radio Button disabled and not show text 'You have selected'")]
        public void VarifyThatNoRadioButtonIsDisabled_2()
        {
          Go.To<DemoQARadioButtonPage>().
          RadioButtons[x => x.Label.Content.Value.Equals("No")].Label.Click().
          RadioButtons[x => x.Label.Content.Value.Equals("No")].RadioButton.Should.BeDisabled().
          Text.Should.Not.BeVisible();
            
        }


        [Test, Description("Verify H1 Radio Button is visible")]
        public void VerifyTitleOfRadioButtonPage()
        {
            Go.To<DemoQARadioButtonPage>().
            RadioButtonsTitle.Should.Be("Radio Button");
        }

        [Test, Description("Verify text 'You have selected Impressive' is not visible after page refresh")]
        public void VerifyMessageOfImpressiveRafioButtonIsNotVisibleAfrePageRefresh()
        {
            Go.To<DemoQARadioButtonPage>().
               RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].Label.Click().
               RadioButtons[x => x.Label.Content.Value.Equals("Impressive")].RadioButton.Should.BeChecked().
               Text.Should.Be("You have selected Impressive").
               RefreshPage().
               Text.Should.Not.BeVisible();
        }
    }
}
