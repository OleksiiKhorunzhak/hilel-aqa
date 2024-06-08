using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQACheckBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("/checkbox")]
    public sealed class DemoQACheckBoxPage : DemoQAPage<_>
    {
        //public ReactCheckboxTree<_> reactCheckboxTree { get; private set; }
        public CheckBoxTree<_> CheckBoxTree { get; set; }
    }
}
