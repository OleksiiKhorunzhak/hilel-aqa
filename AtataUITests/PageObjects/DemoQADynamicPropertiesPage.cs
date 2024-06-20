using Atata;
using _ = AtataUITests.PageObjects.DemoQADynamicPropertiesPage;

namespace AtataUITests.PageObjects
{
    [Url("/dynamic-properties")]
    public sealed class DemoQADynamicPropertiesPage : Page<_>
    {
        public Button<_> ColorChange { get; set; }
    }
}
