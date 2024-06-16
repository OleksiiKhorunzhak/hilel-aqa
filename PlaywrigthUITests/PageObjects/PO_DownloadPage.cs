using Atata;
using Microsoft.Playwright;
using PlaywrigthUITests.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class PO_DownloadPage
    {
        private IPage page;
        private string UploadDownloadPageUrl = "https://demoqa.com/upload-download";

        public PO_DownloadPage(IPage page)
        {
            this.page = page;
        }

        public async Task GoToUploadDownloadPage()
        {
            await page.GotoAsync(UploadDownloadPageUrl);
        }

        public async Task ClickDownloadButton()
        {
            var download = await page.RunAndWaitForDownloadAsync(async () =>
            {
                await page.GetByRole(AriaRole.Link, new() { Name = "Download" }).ClickAsync();
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
        public async Task ClickChooseFileButton()
        {
            string uploadFileAddress = HelperMethods.GetPathToProjectFolder() + "\\bin\\Debug\\net8.0\\downloads/sampleFile.jpeg";
            await page.GetByLabel("Select a file").ClickAsync();
            await page.GetByLabel("Select a file").SetInputFilesAsync(new[] { uploadFileAddress });
            await Assertions.Expect(page.GetByText("C:\\fakepath\\sampleFile.jpeg")).ToBeVisibleAsync();
        }
    }
}

