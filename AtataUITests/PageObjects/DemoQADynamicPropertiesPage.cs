using _ = AtataUITests.PageObjects.DemoQADynamicPropertiesPage;

namespace AtataUITests.PageObjects
{
    [Url("/dynamic-properties")]
    public sealed class DemoQADynamicPropertiesPage : Page<_>
    {
        [FindById("colorChange")]
        public Button<_> ColorChange { get; set; }

        [FindById("enableAfter")]
        public Button<_> EnabledIn5Sec { get; private set; }

        [FindById("visibleAfter")]
        [WaitFor(Until.MissingThenVisible, TriggerEvents.BeforeClick)]
        public Button<_> VisibleIn5Sec { get; private set; }
    }
}