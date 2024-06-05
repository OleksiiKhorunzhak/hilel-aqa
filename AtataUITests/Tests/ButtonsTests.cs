using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    [Description("Verify Buttons on buttons page")]
    public sealed class ButtonsTests : UITestFixture
    {
        [Test, Description("Verify Click Me button"), Retry(2)]
        public void ClickButtonTest() =>
            // Given I go to DemoQa Elements page 
            Go.To<ElementsPage>().
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
            Go.To<ElementsPage>().
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
            Go.To<ElementsPage>().
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

        //Check - Is Button Active?
    }
}
