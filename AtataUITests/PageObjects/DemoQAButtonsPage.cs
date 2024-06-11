using _ = AtataUITests.PageObjects.DemoQAButtonsPage;

namespace AtataUITests.PageObjects
{
    [Url("/buttons")]
    public sealed class DemoQAButtonsPage : DemoQAPage<_>
    {
        [FindById("doubleClickBtn")]
        public Button<_> DoubleClickMe { get; private set; }

        [FindById("rightClickBtn")]
        public Button<_> RigthClickMe { get; private set; }

        public Button<_> ClickMe { get; private set; }

        [FindById("dynamicClickMessage")]
        public Text<_> DinamicClickMessage { get; private set; }

        [FindById("rightClickMessage")]
        public Text<_> RightClickMessage { get; private set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickMessage { get; private set; }

        [FindByXPath("//h1[@class='text-center' and text()='Buttons']")]
        public H1<_> ButtonsTitle { get; set; }
    }
}
