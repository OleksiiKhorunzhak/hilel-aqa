using _ = AtataUITests.PageObjects.ButtonsPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Buttons")]
    [Url("buttons")]
    public sealed class ButtonsPage : DemoQAPage<_>
    {
        [FindById("doubleClickBtn")]
        public Button<_> DoubleClickMeBtn { get; private set; }

        [FindById("rightClickBtn")]
        public Button<_> RigthClickMeBtn { get; private set; }

        public Button<_> ClickMeBtn { get; private set; }

        [FindById("dynamicClickMessage")]
        public Text<_> DinamicClickMessage { get; private set; }

        [FindById("rightClickMessage")]
        public Text<_> RightClickMessage { get; private set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickMessage { get; private set; }
    }
}
