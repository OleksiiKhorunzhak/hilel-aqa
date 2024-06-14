using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.CheckBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("checkbox")]
    public sealed class CheckBoxPage : DemoQAPage<_>
    {
        public CheckBoxTreeControl<_> CheckBoxTree{ get; set; }

        [FindByTitle("Expand all")]
        public Button<_> ExpandAll { get; set; }

        [FindByTitle("Collapse all")]
        public Button<_> CollapseAll { get; set; }

        [FindByClass("rct-title")]
        public Text<_> ItemTitle { get; set; }
    }
}
