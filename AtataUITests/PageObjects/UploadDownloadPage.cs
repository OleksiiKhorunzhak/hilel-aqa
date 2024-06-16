using Atata;
using _ = AtataUITests.PageObjects.UploadDownloadPage;

namespace AtataUITests.PageObjects
{
    [Url("upload-download")]
    [VerifyTitle("DEMOQA")]
    [VerifyContent("Upload and Download")]
    public sealed class UploadDownloadPage : DemoQAPage<_>
    {
        [FindById("downloadButton")]
        public Link<_> Download { get; private set; }

        [FindById("uploadFile")]
        public FileInput<_> Upload { get; private set; }

        [FindById("uploadedFilePath")]
        public Text<_> uploadedFilePath { get; private set; }
    }
}
