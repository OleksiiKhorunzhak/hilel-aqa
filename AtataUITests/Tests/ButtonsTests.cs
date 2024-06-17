using Atata;
using AtataUITests.PageObjects;
using Microsoft.Playwright;

namespace AtataUITests.Tests
{
    [Description("Verify Buttons on buttons page")]
    public sealed class ButtonsTests : UITestFixture
    {
        [Test, Description("Verify Click Me button"), Retry(2)]
        public void ClickButtonTest() =>
            // Given I go to DemoQa Elements page 
            Go.To<DemoQAElementsPage>().
            // When I Click the Buttons button in menu
            Buttons.ClickAndGo().
            // And I see 'buttons' page
            PageUrl.Should.Be("https://demoqa.com/buttons").
            // And I click the 'Click Me' button
            ClickMe.Click().
            // Then  I see "You have done a dynamic click" text.
            DinamicClickMessage.Should.Be("You have done a dynamic click").
            // And I NOT see "You have done a double click" text.
            DoubleClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Double Click Me button"), Retry(2)]
        public void DoubleClickButtonTest() =>
            // Given I go to DemoQa Elements page 
            Go.To<DemoQAElementsPage>().
            // When I Click the Buttons button in menu
            Buttons.ClickAndGo().
            // And I see 'buttons' page
            PageUrl.Should.Be("https://demoqa.com/buttons").
            // And I double click the 'DoubleClickMe' button
            DoubleClickMe.DoubleClick().
            // Then  I see "You have done a double click" text.
            DoubleClickMessage.Should.Be("You have done a double click").
            // And I NOT see "You have done a dynamic click" text.
            DinamicClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public void RigthClickButtonTest() =>
            // Given I go to DemoQa Elements page 
            Go.To<DemoQAElementsPage>().
            // When I Click the Buttons button in menu
            Buttons.ClickAndGo().
            // And I see 'buttons' page
            PageUrl.Should.Be("https://demoqa.com/buttons").
            // And I click the 'RigthClickMe' button
            RigthClickMe.RightClick().
            // Then  I see "You have done a right click" text.
            RightClickMessage.Should.Be("You have done a right click").
            // And I NOT see "You have done a double click" text.
            DoubleClickMessage.Should.Not.BeVisible();


        //Homework Lesson_9
        //TODO : 
        //TC-4 : Verify Click Me button should be enabled

        [Test, Description("Verify that 'Click Me' button is enabled")]
        public void VerifyClickButtonIsEnabled() =>

            Go.To<DemoQAElementsPage>().
            Buttons.ClickAndGo().
            ClickMe.Should.BeEnabled();


        //TC-5 : Verify Click Rigth Click Me button verify button focused

        [Test, Description("Verify Right Click button "), Retry(2)]
        public void VerifyClickOfRightClickButton() =>

           Go.To<DemoQAElementsPage>().
           Buttons.ClickAndGo().
           RigthClickMe.RightClick().
           RigthClickMe.Should.BeFocused();

        //TC-6 : Verify H1 Buttons is visible

        [Test, Description("Verify H1 Buttons is visible")]
        public void VerifyTitleOfButtonsPage() =>
          Go.To<DemoQAElementsPage>().
          Buttons.ClickAndGo().
          ButtonsTitle.Should.Be("Buttons");


        //TC-7 : Verify text You have done a dynamic click is not visible after page refresh

        [Test, Description("Verify text 'You have done a dynamic click' is not visible after page refresh")]
        public void VerifyMessageOfClickButtonIsNotVisibleAfrePageRefresh() =>
          Go.To<DemoQAElementsPage>().
          Buttons.ClickAndGo().
          ClickMe.Click().
          DinamicClickMessage.Should.Be("You have done a dynamic click").
          RefreshPage().
          DinamicClickMessage.Should.Not.BeVisible();
    }
}
