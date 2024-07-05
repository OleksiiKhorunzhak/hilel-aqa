using Atata;
using _ = AtataUITests.PageObjects.UpDownloadPage;

namespace AtataUITests.PageObjects
{
    [Url("upload-download")]
    public sealed class UpDownloadPage : DemoQAPage<_>
    {
        [FindById("downloadButton")]
        public Link<_> Download { get; private set; }

        [FindById("uploadFile")]
        public FileInput<_> Upload { get; private set; }

        [FindById("UploadedFilePath")]
        public Text<_> UploadedFilePath { get; private set; }
    }
}
