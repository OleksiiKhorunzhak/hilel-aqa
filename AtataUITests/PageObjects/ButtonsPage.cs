using _ = AtataUITests.PageObjects.ButtonsPage;

namespace AtataUITests.PageObjects
{
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Buttons")]
    [Url("buttons")]
    public sealed class ButtonsPage : DemoQAPage<_>
    {
        //Page Title:
        [FindByClass("text-center")]
        public Text<_> ButtonsPageH1 { get; set; }  

        //Butons:
        [FindById("doubleClickBtn")]
        public Button<_> DoubleClickMe { get; set; }

        [FindById("rightClickBtn")]
        public Button<_> RigthClickMe { get;  set; }

        public Button<_> ClickMe { get; set; }

        //Messages:
        [FindById("dynamicClickMessage")]
        public Text<_> DinamicClickMessage { get; set; }

        [FindById("rightClickMessage")]
        public Text<_> RightClickMessage { get; set; }

        [FindById("doubleClickMessage")]
        public Text<_> DoubleClickMessage { get; set; }
    }
}
