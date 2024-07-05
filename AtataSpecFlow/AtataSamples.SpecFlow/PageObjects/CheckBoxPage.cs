using Atata;
using AtataSamples.SpecFlow.PageObjects.Controls;
using _ = AtataSamples.SpecFlow.PageObjects.CheckBoxPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("/checkbox")]
    public sealed class CheckBoxPage : _DemoQAPage<_>
    {
        public CheckBoxTree<_> CheckBoxTree { get; set; }
    }
}
