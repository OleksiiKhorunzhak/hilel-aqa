using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    //[Category("ButtonTests")]
    public sealed class ButtonsTests : UITestFixture
    {
        [Test]
        [Retry(2)]
        [Description("Verify Buttons page Text")]
        public void VerifyTextButtonsPage()
        {
            Go.To<ButtonsPage>()
                .PageUrl.Should.Be("https://demoqa.com/buttons")
                .ButtonsPageH1.Should.Be("Buttons");
        }

        [Test]
        [Retry(2)]
        [Description("Verify Double Click Me button")]
        public void DoubleClickButtonTest() =>
            Go.To<ButtonsPage>()//.ScrollDown()
            .DoubleClickMe.Should.BeEnabled()
            .DoubleClickMe.DoubleClick()
            .DoubleClickMe.Should.BeFocused()
            .DoubleClickMessage.Should.Be("You have done a double click")
            .DinamicClickMessage.Should.Not.BeVisible()
            .RightClickMessage.Should.Not.BeVisible();

        [Test]
        [Retry(2)]
        [Description("Verify Rigth Click Me button")]
        public void RigthClickButtonTest() =>
            Go.To<ButtonsPage>()//.ScrollDown()
            .RigthClickMe.Should.BeEnabled()
            .RigthClickMe.RightClick()
            .RigthClickMe.Should.BeFocused()
            .RightClickMessage.Should.Be("You have done a right click")
            .DinamicClickMessage.Should.Not.BeVisible()
            .DoubleClickMessage.Should.Not.BeVisible();

        [Test]
        [Retry(2)]
        [Description("Verify Click Me button")]
        public void ClickButtonTest() =>
            Go.To<ButtonsPage>()//.ScrollDown()
            .ClickMe.Should.BeEnabled()
            .ClickMe.Click()
            .ClickMe.Should.BeFocused()
            .DinamicClickMessage.Should.Be("You have done a dynamic click")
            .DoubleClickMessage.Should.Not.BeVisible()
            .RightClickMessage.Should.Not.BeVisible();
    }
}
