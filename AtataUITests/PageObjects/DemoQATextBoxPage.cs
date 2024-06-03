using Atata;
using _ = AtataUITests.PageObjects.DemoQATextBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("/text-box")]
    public sealed class DemoQATextBoxPage : DemoQAPage<_>
    {
        [FindByClass("text - center")]
        public Text<_> FullNameText { get; set; }
    }
}
    