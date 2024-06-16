using Atata;
using _ = AtataUITests.PageObjects.DemoQADownloadUploadPage;

namespace AtataUITests.PageObjects
{
    [Url("upload-download")]
    public sealed class DemoQADownloadUploadPage : DemoQAPage<_>
    {
        [FindById("downloadButton")]
        public Link<_> Download { get; private set; }

        [FindById("uploadFile")]
        public FileInput<_> Upload { get; private set; }

        [FindById("uploadedFilePath")]
        public Text<_> UploadedFile { get; private set; }
    }
}
