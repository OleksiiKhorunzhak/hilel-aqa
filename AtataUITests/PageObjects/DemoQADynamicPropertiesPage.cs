using _ = AtataUITests.PageObjects.DemoQADynamicPropertiesPage;

namespace AtataUITests.PageObjects
{
    [Url("/dynamic-properties")]
    public sealed class DemoQADynamicPropertiesPage : Page<_>
    {
        public Button<_> ColorChange { get; set; }

        [FindById("enableAfter")]
        public Button<_> Enable5Sec { get; private set; }


        [FindById("visibleAfter")]
        [WaitFor(Until.MissingThenVisible, TriggerEvents.BeforeClick)]
        public Button<_> VisibleAfter { get; private set; }
    }
}
