using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class DynamicPropertiesTests : UITestFixture
    {
        private DemoQADynamicPropertiesPage _demoQADynamicPropertiesPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQADynamicPropertiesPage = new DemoQADynamicPropertiesPage(Page);
        }

        [Test, Description("Verify ColorChange button have color black at page init and after 5 sec color red")]
        public async Task VerifyDynamicColorChange()
        {
            await _demoQADynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
            await _demoQADynamicPropertiesPage.GetColorChangeChangeColor("rgb(255, 255, 255)");
            await Task.Delay(5000);
            await _demoQADynamicPropertiesPage.GetColorChangeChangeColor("rgb(220, 53, 69)");
        }

        [Test]
        public async Task TestEnableAfter()
        {
            await _demoQADynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
            await _demoQADynamicPropertiesPage.EnableAfter5sec();
        }

        [Test]
        public async Task TestVisibleAfter()
        {
            await _demoQADynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
            await _demoQADynamicPropertiesPage.VisibleAfter5sec();
        }

        [Test]
        public async Task TestVisibleAfterClickWait()
        {
            await _demoQADynamicPropertiesPage.GoToDemoQaDynamicPropertiesPage();
            await _demoQADynamicPropertiesPage.VisibleAfter5sec();

        }
    }
}
