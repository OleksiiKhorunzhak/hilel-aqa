using Atata;
using _ = AtataSamples.SpecFlow.PageObjects.ElementsPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("/elements")]
    public sealed class ElementsPage : DemoQAPage<_>
    {
        [FindById("item-0")]
        public Clickable<TextBoxPage, _> TextBox { get; private set; }

        [FindById("item-4")]
        public Clickable<ButtonsPage, _> Buttons { get; private set; }
    }
}
