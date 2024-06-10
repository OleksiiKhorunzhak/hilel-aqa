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

        public async Task ClickDownloadButton()
        {
            var download = await Page.RunAndWaitForDownloadAsync(async () =>
            {
                await Page.GetByRole(AriaRole.Link, new() { Name = "Download" }).ClickAsync();
            });

            if (download != null)
            {
                // Optionally, save the file to a specific location
                var filePath = Path.Combine("downloads", download.SuggestedFilename);
                await download.SaveAsAsync(filePath);

                // Verify the file exists at the specified location
                if (File.Exists(filePath))
                {
                    Console.WriteLine($"File downloaded successfully: {filePath}");
                }
                else
                {
                    Console.WriteLine("File download failed.");
                }
            }
            else
            {
                Console.WriteLine("Download object is null. File download failed.");
            }
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
                // Save the file to a specific location
                var filePath = Path.Combine("downloads", download.SuggestedFilename);
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
            string inputFile = HelperMethods.GetProjectFilePath() + "bin/Debug/net8.0/downloads/sampleFile.jpeg";
            await Page.GetByLabel("Select a file").ClickAsync();
            await Page.GetByLabel("Select a file").SetInputFilesAsync(new[] { inputFile });
            await Assertions.Expect(Page.GetByText("C:\\fakepath\\sampleFile.jpeg")).ToBeVisibleAsync();
        } 
    }
}

