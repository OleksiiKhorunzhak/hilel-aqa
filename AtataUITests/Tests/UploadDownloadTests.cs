using Atata;
using AtataUITests.PageObjects;
using AtataUITests;
using _ = AtataUITests.Tests.CheckBoxTests;
using System.Reflection.Emit;
using AtataUITests.Infrastructure;
using System.Diagnostics;

namespace AtataUITests.Tests
{
    //[Category("UploadDownloadTests")]
    internal class UploadDownloadTests : UITestFixture
    {
        [Test, Retry(2)]
        public void VerifyPageH1()
        {
            Go.To<UpDownloadPage>()
                .Find<H1<UpDownloadPage>>().Should.Equal("Upload and Download");
        }

        [Test, Retry(2)]
        public void VerifFileUpload()
        {
            Go.To<UpDownloadPage>()
                .Download.Click();

            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");
        }

        [Test, Retry(2)]
        public void VerifFileDownload()
        {
            Go.To<UpDownloadPage>()
                .Download.Click();
            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");

            Go.To<UpDownloadPage>()
                .Upload.Set(HelperMethods.GetArtifactsDirectoryPath() + "\\sampleFile.jpeg")
                .UploadedFilePath.Should.BeVisible()
                .UploadedFilePath.Should.Contain("sampleFile.jpeg");
               
            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");
        }

    }
}