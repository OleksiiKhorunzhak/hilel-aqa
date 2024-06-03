using Atata;
using _ = AtataUITests.PageObjects.TextBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("/text-box")]
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [FindByClass("text-center")]
        public Text<_> PageTitleH1 { get; set; }
    }
}
    