using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class DownloadUploadTest : UITestFixture
    {
        private DemoQADownloadPage _demoQADownloadPage;

        [SetUp]
        public async Task SetupDemoQAPage()
        {
            _demoQADownloadPage = new DemoQADownloadPage(Page);
            await _demoQADownloadPage.GoToDemoQaUploadDownloadPage();
        }

        [Test, Description("Download file, verify file exists")]
        public async Task VerifyDownload()
        {           
            await _demoQADownloadPage.VerifyFileDownloaded();
        }

        [Test, Description("Upload the downloaded file")]
        public async Task VerifyUpload()
        {           
            await _demoQADownloadPage.VerifyFileDownloaded();
            await _demoQADownloadPage.VerifyDownloadedFileUploadedSucessfully();
        }
    }
}