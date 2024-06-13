using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQACheckBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("/checkbox")]
    public sealed class DemoQACheckBoxPage : DemoQAPage<_>
    {        
        public CheckBoxTree<_> CheckBoxTree { get; set; }

        [FindById("result")]
        public Text<_> CheckboxCheckedOutput { get; private set; }
    }
}