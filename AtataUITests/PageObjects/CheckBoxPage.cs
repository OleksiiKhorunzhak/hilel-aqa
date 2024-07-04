using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.CheckBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("checkbox")]
    public sealed class CheckBoxPage : DemoQAPage<_>
    {
        //Custom control:
        public CheckBoxTreeControl<_> CheckBoxTree{ get; set; }

        //Elements:
        [FindByTitle("Expand all")]
        public Button<_> ExpandAll { get; set; }

        [FindByTitle("Collapse all")]
        public Button<_> CollapseAll { get; set; }
    }
}
