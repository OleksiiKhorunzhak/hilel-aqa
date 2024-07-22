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

        [ScrollTo]
        [WaitSeconds(5, TriggerEvents.BeforeClick)]
        public Button<_> ClickMe { get; private set; }

        [FindById("dynamicClickMessage")]
        public Text<_> DinamicClickMessage { get; private set; }

        [FindById("rightClickMessage")]
        public Text<_> RightClickMessage { get; private set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickMessage { get; private set; }

        [FindByClass("text-center")]
        public Text<_> H1TitleButtons { get; private set; }

            
    }
}
