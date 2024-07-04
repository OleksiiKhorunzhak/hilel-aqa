using Atata;
using _ = AtataUITests.PageObjects.DynamicPropertiesPage;

namespace AtataUITests.PageObjects
{
    [Url("dynamic-properties")]
    public sealed class DynamicPropertiesPage : Page<_>
    {
        public Button<_> ColorChange { get; private set; }

        [FindById("enableAfter")]
        public Button<_> Enable5Sec { get; private set; }


        [FindById("visibleAfter")]
        [WaitFor(Until.MissingThenVisible, TriggerEvents.BeforeClick)]
        public Button<_> VisibleAfter { get; private set; }
    }
}
