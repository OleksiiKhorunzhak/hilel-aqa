using Microsoft.Playwright;
using static PlaywrigthUITests.Helpers.CommonHelperActions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PlaywrigthUITests.PageObjects
{
	internal class DemoQAUploadAndDownloadPage
	{
		private IPage _page;
		private string elementsPageUrl = "https://demoqa.com/elements";
		private string uploadDownloadPageUrl = "https://demoqa.com/upload-download";

		public DemoQAUploadAndDownloadPage(IPage page)
		{
			_page = page;
		}

		#region Actions
		public async Task GoToElementsPage()
		{
			await _page.GotoAsync(elementsPageUrl);
		}

		public async Task ClickUploadDownloadMenu()
		{
			await _page.GetByText("Upload and Download").ClickAsync();
		}

		public async Task ClickUploadButton()
		{
			var download = await _page.RunAndWaitForDownloadAsync(async () =>
			{
				await _page.GetByRole(AriaRole.Link, new() { Name = "Download" }).ClickAsync();
			});
		}

		public async Task<string> SaveDownloadedFileAndGetSuggestedName()
		{
			var waitForDownloadTask = _page.WaitForDownloadAsync();
			await _page.RunAndWaitForDownloadAsync(async () =>
			{
				await _page.GetByRole(AriaRole.Link, new() { Name = "Download" }).ClickAsync();
			});
			var download = await waitForDownloadTask;

			string pathFile = GetPathToProjectFolder();
			pathFile = pathFile + "Downloads\\";

			await download.SaveAsAsync(pathFile + download.SuggestedFilename);
			return download.SuggestedFilename;
		}
		#endregion

		#region Verifications
		public async Task UploadFileWithChooseFileButton(string filePath)
		{
			var fileChooser = await _page.RunAndWaitForFileChooserAsync(async () =>
			{
				await _page.Locator("#uploadFile").ClickAsync();
			});
			await fileChooser.SetFilesAsync($"{filePath}");
		}

		public async Task<bool> CheckFakePathRowIsVisibleWithFileName(string fileName)
		{
			string path = "C:\\fakepath\\";
			path = path + fileName;
			return await _page.GetByText(path).IsVisibleAsync();
		}

		public async Task WaitForUploadAndDownloadPage()
		{
			await _page.WaitForURLAsync(uploadDownloadPageUrl);
		}

		public async Task<bool> CheckUploadAndDownloadHeader()
		{
			return await _page.GetByRole(AriaRole.Heading, new() { Name = "Upload and Download" }).IsVisibleAsync();
		}
		#endregion
	}
}