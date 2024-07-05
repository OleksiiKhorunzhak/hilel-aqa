using Atata;
using _ = AtataSamples.SpecFlow.PageObjects.UpDownloadPage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("upload-download")]
    public sealed class UpDownloadPage : _DemoQAPage<_>
    {
        [FindById("downloadButton")]
        public Link<_> Download { get; private set; }

        [FindById("uploadFile")]
        public FileInput<_> Upload { get; private set; }

        [FindById("uploadedFilePath")]
        public Text<_> UploadedFile { get; private set; }
    }
}
