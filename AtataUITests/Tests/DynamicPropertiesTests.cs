using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    internal class DynamicPropertiesTests: UITestFixture
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
                EnabledIn5Sec.Should.BeDisabled().
                EnabledIn5Sec.Should.WithinSeconds(5).BeEnabled();
        }

        [Test]
        public void TestVisibleAfter()
        {
            Go.To<DemoQADynamicPropertiesPage>().ScrollDown().
                VisibleIn5Sec.Should.Not.BeVisible().
            VisibleIn5Sec.Should.WithinSeconds(5).BeVisible(); 
        }        
    }
}