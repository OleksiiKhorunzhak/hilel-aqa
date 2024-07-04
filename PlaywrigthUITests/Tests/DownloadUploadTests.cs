using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    //[Category("DownloadUploadTests")]
    internal class DownloadUploadTests : UITestFixture
    {
        private PO_DownloadPage _UpDownloadPage;

        [SetUp]
        public void SetupDemoQAPage()
        {
            _UpDownloadPage = new PO_DownloadPage(Page);
        }

        [Test, Retry(2), Description("Donwload file verify file updated")]
        public async Task VerifyDownload()
        {
            await _UpDownloadPage.GoToUploadDownloadPage();
            await _UpDownloadPage.ClickDownloadButton();
        }

        [Test, Retry(2)]
        public async Task VerifyUpload()
        {
            await _UpDownloadPage.GoToUploadDownloadPage();
            await _UpDownloadPage.ClickChooseFileButton();
        }
    }
}
