using Microsoft.Playwright;
using static PlaywrigthUITests.Helpers.CommonHelperActions;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PlaywrigthUITests.Tests
{
	internal class UploadDownloadTests : UITestFixture
	{
		private DemoQAUploadAndDownloadPage _uploadDownloadPage;

		[SetUp]
		public void SetupCheckBoxPage()
		{
			_uploadDownloadPage = new DemoQAUploadAndDownloadPage(Page);
		}
		[Category ("pipeline")]
		[Test]
		[Description("Verify header with 'Upload And Download' text is visible on the page")]
		public async Task VerifyCheckBoxHeaderVisibility()
		{
			await _uploadDownloadPage.GoToElementsPage();
			await _uploadDownloadPage.ClickUploadDownloadMenu();
			await _uploadDownloadPage.WaitForUploadAndDownloadPage();

			var result = await _uploadDownloadPage.CheckUploadAndDownloadHeader();
			Assert.That(result == true, "Header 'Upload And Download' is not visible on the page");
		}

		[Test]
		[Description("Verify file upload functionality with click on Choose File button")]
		public async Task VerifyFileUploadFunction()
		{
			await _uploadDownloadPage.GoToElementsPage();
			await _uploadDownloadPage.ClickUploadDownloadMenu();
			await _uploadDownloadPage.WaitForUploadAndDownloadPage();

			string pathFile = GetPathToProjectFolder();
			pathFile = pathFile + "Downloads\\test.txt";
			await _uploadDownloadPage.UploadFileWithChooseFileButton(pathFile);

			string fileName = "test.txt";
			var result = await _uploadDownloadPage.CheckFakePathRowIsVisibleWithFileName(fileName);

			Assert.That(result, Is.EqualTo(true), "Fake path row is not visible");
		}

		[Test]
		[Description("Verify file download after click on Download button")]
		public async Task VerifyFileDownloadFunction()
		{
			await _uploadDownloadPage.GoToElementsPage();
			await _uploadDownloadPage.ClickUploadDownloadMenu();
			await _uploadDownloadPage.WaitForUploadAndDownloadPage();

			var fileName = await _uploadDownloadPage.SaveDownloadedFileAndGetSuggestedName();
			string pathFile = GetPathToProjectFolder();
			pathFile = pathFile + "Downloads";
			string fullPath = $"{pathFile}\\{fileName}";
			Assert.That(File.Exists($"{fullPath}"),Is.EqualTo(true), $"File {fileName} does not exists in folder {pathFile}");

			File.Delete($"{fullPath}");
		}
	}
}
