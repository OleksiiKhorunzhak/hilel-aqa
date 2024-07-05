using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    //[Category("DynamicPropertiesTests")]
    internal class DynamicPropertiesTests : UITestFixture
    {
        private DynamicPropertiesPage _DynamicPropertiesPage;

        #region TEST DATA:
        //page:
        private readonly string testPageUrl = "https://demoqa.com/dynamic-properties";
        private readonly string testPageH1 = "Dynamic Properties";
        //Labels:
        //Inputs:
        #endregion

        [SetUp]
        public void SetupDemoQAPage()
        {
            _DynamicPropertiesPage = new DynamicPropertiesPage(page);
        }

        [Test, Retry(2)]
        [Description("H1 'Text Box' should be visible")]
        public async Task VerifyTextBoxPageH1()
        {
            await _DynamicPropertiesPage.GoToURL(testPageUrl);
            await _DynamicPropertiesPage.IsPageH1Visible(testPageH1);
        }

        [Test, Description("Verify ColorChange button have color black at page init and after 5 sec color red")]
        public async Task VerifyDynamicColorChange()
        {
            await _DynamicPropertiesPage.GoToURL(testPageUrl);
            await _DynamicPropertiesPage.GetColorChangeChangeColor("rgb(255, 255, 255)");
            await Task.Delay(5000);
            await _DynamicPropertiesPage.GetColorChangeChangeColor("rgb(220, 53, 69)");
        }

        [Test]
        public async Task TestEnableAfter()
        {
            await _DynamicPropertiesPage.GoToURL(testPageUrl);
            await _DynamicPropertiesPage.EnableAfter5sec();
        }

        [Test]
        public async Task TestVisibleAfter()
        {
            await _DynamicPropertiesPage.GoToURL(testPageUrl);
            await _DynamicPropertiesPage.VisibleAfter5sec();
        }

        [Test]
        public async Task TestVisibleAfterClickWait()
        {
            await _DynamicPropertiesPage.GoToURL(testPageUrl);
            await _DynamicPropertiesPage.VisibleAfter5sec();
        }
    }
}
