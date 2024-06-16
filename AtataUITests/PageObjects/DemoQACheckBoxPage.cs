using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQACheckBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("/checkbox")]
    public sealed class DemoQACheckBoxPage : DemoQAPage<_>
    {
        public CheckBoxTree<_> CheckBoxTree { get; set; }


        [FindByClass("display-result mt-4")]
        public Text<_> Result { get; set; }

    }


}
