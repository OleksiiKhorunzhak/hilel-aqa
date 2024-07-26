using Atata;
using AtataSamples.SpecFlow.PageObjects.Controls;
using _ = AtataSamples.SpecFlow.PageObjects.DemoQACheckBoxPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("/checkbox")]
    public sealed class DemoQACheckBoxPage : DemoQAPage<_>
    {
        public CheckBoxTree<_> CheckBoxTree { get; set; }
    }
}
