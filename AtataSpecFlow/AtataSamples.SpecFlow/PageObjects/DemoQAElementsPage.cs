using Atata;
using _ = AtataSamples.SpecFlow.PageObjects.DemoQAElementsPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("/elements")]
    public sealed class DemoQAElementsPage : DemoQAPage<_>
    {
        [FindById("item-0")]
        public Clickable<DemoQATextBoxPage, _> TextBox { get; private set; }

        [FindById("item-4")]
        public Clickable<DemoQAButtonsPage, _> Buttons { get; private set; }
    }
}
