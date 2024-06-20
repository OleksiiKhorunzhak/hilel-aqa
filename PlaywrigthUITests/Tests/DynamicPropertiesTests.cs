using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    internal class DynamicPropertiesTests : PageTest
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
            await _demoQADynamicPropertiesPage.GetColorChangeColor("expectedcolor");
        }
    }
}
