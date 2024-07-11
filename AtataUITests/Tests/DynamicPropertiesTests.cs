using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    internal class DynamicPropertiesTests
    {
        [Test]
        public void TestChangeColor()
        {
            Go.To<DemoQADynamicPropertiesPage>().
                ColorChange.Css["color"].Should.Be("rgba(255, 255, 255, 1)").
                ColorChange.Css["color"].Should.Be("rgba(220, 53, 69, 1)");
        }

        [Test]
        public void TestEnableAfter()
        {
            Go.To<DemoQADynamicPropertiesPage>().
                Enable5Sec.Should.BeDisabled().
                Enable5Sec.Should.WithinSeconds(5).BeEnabled();
        }

        [Test]
        public void TestVisibleAfter()
        {
            Go.To<DemoQADynamicPropertiesPage>().
                VisibleAfter.Should.WithinSeconds(4).Not.BeVisible().
                VisibleAfter.Should.BeVisible();
        }

        [Test]
        public void TestVisibleAfterClickWait()
        {
            Go.To<DemoQADynamicPropertiesPage>().
                VisibleAfter.Click().
                VisibleAfter.Should.BeFocused();
        }
    }
}
