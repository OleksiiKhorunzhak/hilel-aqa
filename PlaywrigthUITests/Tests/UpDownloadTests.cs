using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    //[Category("DownloadUploadTests")]
    internal class UpDownloadTests : UITestFixture
    {
        private UpDownloadPage _UpDownloadPage;
        private readonly string testPageUrl = "https://demoqa.com/upload-download";

        [SetUp]
        public void SetupDemoQAPage()
        {
            _UpDownloadPage = new UpDownloadPage(page);
        }

        [Test, Retry(2), Description("Donwload file verify file updated")]
        public async Task VerifyDownload()
        {
            await _UpDownloadPage.GoToURL(testPageUrl);
            await _UpDownloadPage.ClickDownloadButton();
        }

        [Test, Retry(2)]
        public async Task VerifyUpload()
        {
            await _UpDownloadPage.GoToURL(testPageUrl);
            await _UpDownloadPage.ClickChooseFileButton();
        }
    }
}
