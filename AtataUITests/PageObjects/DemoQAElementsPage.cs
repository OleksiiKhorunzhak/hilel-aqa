using _ = AtataUITests.PageObjects.DemoQAElementsPage;

namespace AtataUITests.PageObjects
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
