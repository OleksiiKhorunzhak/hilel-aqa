using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.CheckBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("checkbox")]
    public sealed class CheckBoxPage : DemoQAPage<_>
    {
        public CheckBoxTreeControl<_> CheckBoxTree{ get; set; }

        
    }
}
