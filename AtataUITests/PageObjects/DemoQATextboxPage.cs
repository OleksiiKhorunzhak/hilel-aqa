using Atata;
using _ = AtataUITests.PageObjects.DemoQATextboxPage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQATextboxPage : DemoQAPage<_>
    {
        [FindByPlaceholder("Full Name")]
        public TextInput<_> FullName { get; set; }
    }
}
