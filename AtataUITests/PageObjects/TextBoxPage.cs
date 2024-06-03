using Atata;
using _ = AtataUITests.PageObjects.TextBoxPage;

namespace AtataUITests.PageObjects
{
    [Url("/text-box")]
    public sealed class TextBoxPage : DemoQAPage<_>
    {
        [FindByClass("text-center")]
        public Text<_> TextBoxPageH1 { get; set; }

        [FindById("userName-label")]
        public Text<_> UserNameLable { get; set; }


    }
}
    