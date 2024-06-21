using Microsoft.Playwright;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
	internal class CheckBoxTests : UITestFixture
	{
		private DemoQACheckBoxPage _checkboxPage;
		[Category("pipeline")]

		[SetUp]
		public void SetupCheckBoxPage()
		{
			_checkboxPage = new DemoQACheckBoxPage(Page);
		}

		[Test]
		[Description("Verify header with 'Check Box' text is visible on the page")]
		public async Task VerifyCheckBoxHeaderVisibility()
		{
			await _checkboxPage.GoToCheckBoxPage();
			var result = await _checkboxPage.CheckCheckBoxHeaderVisibility();
			Assert.That(result == true, "Header 'Check Box' is not visible on the page");
		}

		[Test]
		[Description("Verify header with 'Check Box' text is visible on the page")]
		public async Task VerifyCheckBoxHeaderIsVisible()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.CheckCheckBoxHeaderIsVisible();
		}

		[Test]
		[Description("Verify Expand All button expands all directories and files")]
		public async Task VerifyExpandAllButtonFunctionality()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickExpandAllButton();
			await _checkboxPage.VerifyCheckBoxByName("Downloads");
			await _checkboxPage.VerifyCheckBoxByName("Excel File.doc");
		}

		[Test]
		[Description("Verify Collapse All button collapse all directories and files")]
		public async Task VerifyCollapseAllButtonFunctionality()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickExpandAllButton();
			await _checkboxPage.VerifyCheckBoxByName("Excel File.doc");
			await _checkboxPage.ClickCollapseAllButton();
			await _checkboxPage.VerifyCheckBoxNotVisibleByName("Excel File.doc");
		}

		[Test]
		[Description("Verify User can click on toggle and it expand lower level of files hierarchy")]
		public async Task VerifyToggleExpandFunctionality()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickHomeToggle();
			await _checkboxPage.VerifyCheckBoxByName("Downloads");
			await _checkboxPage.ClickToggleByDirectoryName("Downloads");
			await _checkboxPage.VerifyCheckBoxByName("Excel File.doc");
		}

		[Test]
		[Description("Verify checkboxes are not selected by default")]
		public async Task VerifyCheckBoxesAreNotSelectedByDefault()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickHomeToggle();
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Downloads");
			await _checkboxPage.ClickToggleByDirectoryName("Downloads");

			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Word File.doc");
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Excel File.doc");
		}

		[Test]
		[Description("Verify checkbox become selected after click on file and unselected after re-click")]
		public async Task VerifyCheckBoxSelectionFileFunction()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickHomeToggle();
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Downloads");
			await _checkboxPage.ClickToggleByDirectoryName("Downloads");
			await _checkboxPage.ClickCheckBoxByName("Excel File.doc");

			await _checkboxPage.VerifyCheckBoxIsSelectedByLabelText("Excel File.doc");
			await _checkboxPage.ClickCheckBoxByName("Excel File.doc");
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Excel File.doc");
		}

		[Test]
		[Description("Verify checkboxes become selected after click on parent folder")]
		public async Task VerifyCheckBoxesSelectionFunction()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickHomeToggle();
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Downloads");
			await _checkboxPage.ClickToggleByDirectoryName("Downloads");
			await _checkboxPage.ClickCheckBoxByName("Downloads");

			await _checkboxPage.VerifyCheckBoxIsSelectedByLabelText("Downloads");
			await _checkboxPage.VerifyCheckBoxIsSelectedByLabelText("Word File.doc");
			await _checkboxPage.VerifyCheckBoxIsSelectedByLabelText("Excel File.doc");
		}

		[Test]
		[Description("Verify 'You have selected' row become visible after click on checkbox and not visible after re-click")]
		public async Task VerifyYouHaveSelectedRowAfterCheckboxClick()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickHomeToggle();
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Downloads");
			await _checkboxPage.ClickToggleByDirectoryName("Downloads");
			await _checkboxPage.ClickCheckBoxByName("Excel File.doc");

			await _checkboxPage.CheckYouHaveSelectedRowWithFileName("excelFile");
			await _checkboxPage.ClickCheckBoxByName("Excel File.doc");
			await _checkboxPage.CheckYouHaveSelectedRowIsNotVisible();
		}

		[Test]
		[Description("Verify 'You have selected' row become visible after multiple click on checkbox and not visible after re-click")]
		public async Task VerifyMultipleFilesYouHaveSelectedRow()
		{
			await _checkboxPage.GoToCheckBoxPage();
			await _checkboxPage.ClickHomeToggle();
			await _checkboxPage.VerifyCheckBoxIsNotSelectedByLabelText("Downloads");
			await _checkboxPage.ClickToggleByDirectoryName("Downloads");
			await _checkboxPage.ClickCheckBoxByName("Excel File.doc");
			await _checkboxPage.ClickCheckBoxByName("Word File.doc");

			await _checkboxPage.CheckYouHaveSelectedRowWithFileName("downloadswordFileexcelFile");
			await _checkboxPage.ClickCheckBoxByName("Excel File.doc");
			await _checkboxPage.ClickCheckBoxByName("Word File.doc");
			await _checkboxPage.CheckYouHaveSelectedRowIsNotVisible();
		}
	}
}
