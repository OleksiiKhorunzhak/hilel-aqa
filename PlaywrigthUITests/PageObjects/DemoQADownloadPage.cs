using Microsoft.Playwright;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.PageObjects
{
    internal class DemoQADownloadPage
    {
        private IPage page;
        private string RadioButtonPageUrl = "https://demoqa.com/upload-download";

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
    }
}

