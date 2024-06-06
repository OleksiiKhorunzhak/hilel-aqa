using _ = AtataUITests.PageObjects.ButtonsPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Buttons")]
    [Url("buttons")]
    public sealed class ButtonsPage : DemoQAPage<_>
    {
        public Button<_> ClickMe { get; private set; }

        [FindById("doubleClickBtn")]
        public Button<_> DoubleClickMe { get; private set; }

        [FindById("rightClickBtn")]
        public Button<_> RigthClickMe { get; private set; }

        [FindById("dynamicClickMessage")]
        public Text<_> DinamicClickMessage { get; private set; }

        [FindById("rightClickMessage")]
        public Text<_> RightClickMessage { get; private set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickMessage { get; private set; }
    }
}
