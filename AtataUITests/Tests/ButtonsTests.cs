using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    [Description("Verify Buttons on buttons page")]
    public sealed class ButtonsTests : UITestFixture
    {
        [Test, Description("Verify Double Click Me button"), Retry(2)]
        public void DoubleClickButtonTest() =>
            Go.To<ButtonsPage>().PageUrl.Should.Be("https://demoqa.com/buttons")
            .DoubleClickMe.Should.BeEnabled()
            .DoubleClickMe.DoubleClick()
            .DoubleClickMessage.Should.Be("You have done a double click")
            .DinamicClickMessage.Should.Not.BeVisible()
            .RightClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public void RigthClickButtonTest() =>
            Go.To<ButtonsPage>().PageUrl.Should.Be("https://demoqa.com/buttons")
            .RigthClickMe.Should.BeEnabled()
            .RigthClickMe.RightClick()
            .RightClickMessage.Should.Be("You have done a right click")
            .DinamicClickMessage.Should.Not.BeVisible()
            .DoubleClickMessage.Should.Not.BeVisible();

        [Test, Description("Verify Click Me button"), Retry(2)]
        public void ClickButtonTest() =>
            Go.To<ButtonsPage>().PageUrl.Should.Be("https://demoqa.com/buttons")
            .ClickMe.Should.BeEnabled()
            .ClickMe.Click()
            .DinamicClickMessage.Should.Be("You have done a dynamic click")
            .DoubleClickMessage.Should.Not.BeVisible()
            .RightClickMessage.Should.Not.BeVisible();
    }
}
