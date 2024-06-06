using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    [Description("Verify Text on Buttons page")]
    public sealed class ButtonsTests : UITestFixture
    {
        [Test]
        [Description("Verify Buttons page Text")]
        [Retry(2)]
        public void VerifyTextButtonsPage()
        {
            Go.To<ButtonsPage>()
                .PageUrl.Should.Be("https://demoqa.com/buttons")
                .ButtonsPageH1.Should.Be("Buttons");
        }

        [Test, Description("Verify Double Click Me button"), Retry(2)]
        public void DoubleClickButtonTest() =>
            Go.To<ButtonsPage>().PageUrl.Should.Be("https://demoqa.com/buttons")
            .DoubleClickMe.Should.BeEnabled()
            .DoubleClickMe.DoubleClick()
            .DoubleClickMe.Should.BeFocused()
            .DoubleClickMessage.Should.Be("You have done a double click")
            .DinamicClickMessage.Should.Not.BeVisible()
            .RightClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public void RigthClickButtonTest() =>
            Go.To<ButtonsPage>().PageUrl.Should.Be("https://demoqa.com/buttons")
            .RigthClickMe.Should.BeEnabled()
            .RigthClickMe.RightClick()
            .RigthClickMe.Should.BeFocused()
            .RightClickMessage.Should.Be("You have done a right click")
            .DinamicClickMessage.Should.Not.BeVisible()
            .DoubleClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Click Me button"), Retry(2)]
        public void ClickButtonTest() =>
            Go.To<ButtonsPage>().PageUrl.Should.Be("https://demoqa.com/buttons")
            .ClickMe.Should.BeEnabled()
            .ClickMe.Click()
            .ClickMe.Should.BeFocused()
            .DinamicClickMessage.Should.Be("You have done a dynamic click")
            .DoubleClickMessage.Should.Not.BeVisible()
            .RightClickMessage.Should.Not.BeVisible();
    }
}
