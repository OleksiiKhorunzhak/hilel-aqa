using Atata;
using AtataUITests.Infrastructure;
using AtataUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class DownloadUploadTests : UITestFixture
    {
        [Test,Description("Donwload file verify file updated")]
        public void DownloadTest()
        {
            Go.To<DemoQADownloadUploadPage>().
                Download.Click();

            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");
        }

        [Test,Description("Donwload file then upload same file")]
        public void UploadTest()
        {
            Go.To<DemoQADownloadUploadPage>().
               Download.Click();

            AtataContext.Current.Artifacts.Should.WithinSeconds(10).ContainFile("sampleFile.jpeg");

            Go.To<DemoQADownloadUploadPage>().
                Upload.Set(HelperMethods.GetArtifactsDirectoryPath() + "\\sampleFile.jpeg").
                UploadedFile.Should.BeVisible();
        }
    }
}
