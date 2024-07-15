using Microsoft.Playwright;
using PlaywrigthUITests.Infrastructure;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQADownloadPage
    {
        private IPage Page;
        private string RadioButtonPageUrl = "https://demoqa.com/upload-download";

        public DemoQADownloadPage(IPage page)
        {
            this.Page = page;
        }

        public async Task GoToDemoQaUploadDownloadPage()
        {
            await Page.GotoAsync(RadioButtonPageUrl);
        }      

        public async Task VerifyFileDownloaded()
        {
            // Trigger file download
            var download = await Page.RunAndWaitForDownloadAsync(async () =>
            {
                await Page.GetByRole(AriaRole.Link, new() { Name = "Download" }).ClickAsync();
            });

            if (download != null)
            {                
                string downloadsPath = Path.Combine(HelperMethods.GetProjectFilePath(), "Downloads");
                Directory.CreateDirectory(downloadsPath);

                // Set specific location for the file
                var filePath = Path.Combine(downloadsPath, download.SuggestedFilename);
                // Save file to selected location
                await download.SaveAsAsync(filePath);
                // Verify the file exists at the specified location
                Assert.That(File.Exists(filePath), "File download failed.");
            }
            else
            {
                Assert.Fail("Download object is null. File download failed.");
            }
        }

        public async Task VerifyDownloadedFileUploadedSucessfully()
        {
            string inputFile = HelperMethods.GetProjectFilePath() + "Downloads/sampleFile.jpeg";
            await Page.GetByLabel("Select a file").ClickAsync();
            await Page.GetByLabel("Select a file").SetInputFilesAsync(new[] { inputFile });

            await Assertions.Expect(Page.GetByText("C:\\fakepath\\sampleFile.jpeg")).ToBeVisibleAsync();

            Directory.Delete(HelperMethods.GetProjectFilePath() + "Downloads", true);
        } 
    }
}