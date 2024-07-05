using Microsoft.Playwright;
using PlaywrigthSpecFlow.Infrastructure;

namespace PlaywrigthSpecFlow.PageObjects
{
    internal class DemoQADownloadPage
    {
        private readonly IPage page;
        private readonly string RadioButtonPageUrl = "https://demoqa.com/upload-download";

        public DemoQADownloadPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToDemoQaUploadDownloadPage()
        {
            await page.GotoAsync(RadioButtonPageUrl);
        }

        public async Task ClickDownloadButton()
        {
            var download = await page.RunAndWaitForDownloadAsync(async () =>
            {
                await page.GetByRole(AriaRole.Link, new() { NameString = "Download" }).ClickAsync();
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
            var download = await page.RunAndWaitForDownloadAsync(async () =>
            {
                await page.GetByRole(AriaRole.Link, new() { NameString = "Download" }).ClickAsync();
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
            await page.GetByLabel("Select a file").ClickAsync();
            await page.GetByLabel("Select a file").SetInputFilesAsync(new[] { inputFile });
            await Assertions.Expect(page.GetByText("C:\\fakepath\\sampleFile.jpeg")).ToBeVisibleAsync();
        }
    }
}

