using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    internal class DownloadUploadTest : UITestFixture
    {
        private DemoQADownloadPage _demoQADownloadPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQADownloadPage = new DemoQADownloadPage(Page);
        }

        [Test]
        public async Task VerifyDownload()
        {
            await _demoQADownloadPage.GoToDemoQaUploadDownloadPage();
            await _demoQADownloadPage.ClickDownloadButton();
        }

        [Test]
        public async Task VerifyDownloadDebug()
        {
            await _demoQADownloadPage.GoToDemoQaUploadDownloadPage();
            await _demoQADownloadPage.ClickDownloadButton();
        }
    }
}
