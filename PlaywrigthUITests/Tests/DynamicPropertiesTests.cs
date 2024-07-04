﻿using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class DynamicPropertiesTests : UITestFixture
    {
        private DynamicPropertiesPage _DynamicPropertiesPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _DynamicPropertiesPage = new DynamicPropertiesPage(Page);
        }

        [Test, Description("Verify ColorChange button have color black at page init and after 5 sec color red")]
        public async Task VerifyDynamicColorChange()
        {
            await _DynamicPropertiesPage.GoToDynamicPropertiesPage();
            await _DynamicPropertiesPage.GetColorChangeChangeColor("rgb(255, 255, 255)");
            await Task.Delay(5000);
            await _DynamicPropertiesPage.GetColorChangeChangeColor("rgb(220, 53, 69)");
        }

        [Test]
        public async Task TestEnableAfter()
        {
            await _DynamicPropertiesPage.GoToDynamicPropertiesPage();
            await _DynamicPropertiesPage.EnableAfter5sec();
        }

        [Test]
        public async Task TestVisibleAfter()
        {
            await _DynamicPropertiesPage.GoToDynamicPropertiesPage();
            await _DynamicPropertiesPage.VisibleAfter5sec();
        }

        [Test]
        public async Task TestVisibleAfterClickWait()
        {
            await _DynamicPropertiesPage.GoToDynamicPropertiesPage();
            await _DynamicPropertiesPage.VisibleAfter5sec();

        }
    }
}
