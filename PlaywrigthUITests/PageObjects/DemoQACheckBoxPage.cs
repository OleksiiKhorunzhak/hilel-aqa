using Microsoft.Playwright;

namespace PlaywrigthUITests.PageObjects
{
	internal class DemoQACheckBoxPage
	{
		private IPage _page;
		private string elementsPageUrl = "https://demoqa.com/elements";
		private string CheckBoxPageUrl = "https://demoqa.com/checkbox";

		public DemoQACheckBoxPage(IPage page)
		{
			_page = page;
		}

		#region Actions
		public async Task GoToCheckBoxPage()
		{
			await _page.GotoAsync(elementsPageUrl);
			await _page.GetByText("Check Box").ClickAsync();
			await _page.WaitForURLAsync(CheckBoxPageUrl);
		}

		public async Task ClickExpandAllButton()
		{
			await _page.GetByLabel("Expand all").ClickAsync();
		}

		public async Task ClickCollapseAllButton()
		{
			await _page.GetByLabel("Collapse all").ClickAsync();
		}

		public async Task ClickCheckBoxByName(string name)
		{
			await _page.GetByText($"{name}").ClickAsync();
		}

		public async Task ClickHomeToggle()
		{
			await _page.GetByLabel("Toggle").ClickAsync();
		}

		public async Task ClickToggleByDirectoryName(string name)
		{
			await _page.Locator("li").Filter(new() { HasTextRegex = new Regex($"^{name}$") }).GetByLabel("Toggle").ClickAsync();
		}

		#endregion

		#region Verifications
		public async Task<bool> CheckCheckBoxHeaderVisibility()
		{
			return await _page.GetByRole(AriaRole.Heading, new() { Name = "Check Box" }).IsVisibleAsync();
		}

		public async Task CheckCheckBoxHeaderIsVisible()
		{
			await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "Check Box" })).ToBeVisibleAsync();
		}

		public async Task VerifyCheckBoxByName(string name)
		{
			await _page.GetByText($"{name}").IsCheckedAsync();
		}

		public async Task VerifyCheckBoxNotVisibleByName(string name)
		{
			await Assertions.Expect(_page.GetByText($"{name}")).Not.ToBeVisibleAsync();
		}

		public async Task VerifyCheckBoxIsNotSelectedByLabelText(string labelText)
		{
			await Assertions.Expect(_page.Locator("label:has(svg.rct-icon.rct-icon-uncheck)").Filter(new() { HasText = $"{labelText}" })).ToBeVisibleAsync();
		}

		public async Task VerifyCheckBoxIsSelectedByLabelText(string labelText)
		{
			await Assertions.Expect(_page.Locator("label:has(svg.rct-icon.rct-icon-check)").Filter(new() { HasText = $"{labelText}" })).ToBeVisibleAsync();
		}

		public async Task CheckYouHaveSelectedRowWithFileName(string fileName)
		{
			await Assertions.Expect(_page.GetByText($"You have selected :{fileName}")).ToBeVisibleAsync();
		}

		public async Task CheckYouHaveSelectedRowIsNotVisible()
		{
			await Assertions.Expect(_page.GetByText($"You have selected :")).Not.ToBeVisibleAsync();
		}
		#endregion
		//await page.GetByLabel("Expand all").ClickAsync();
		//await page.GetByText("Excel File.doc").ClickAsync();
		//await page.GetByText("You have selected :").ClickAsync();
		//
		//
		//await page.Locator("label").Filter(new () { HasText = "Desktop" }).GetByRole(AriaRole.Img).First.ClickAsync();
		//await page.Locator("label").Filter(new() { HasText = "Notes" }).GetByRole(AriaRole.Img).First.ClickAsync();
		//await page.Locator("label").Filter(new() { HasText = "Notes" }).GetByRole(AriaRole.Img).First.ClickAsync();

		//		rct-icon.rct-icon-uncheck
		//		rct-icon.rct-icon-check
		//		await page.GetByLabel("Toggle").First.ClickAsync();
		//await page.Locator("span").Filter(new () { HasText = "Home" }).First.ClickAsync();
		//await page.Locator("#tree-node span").Nth(1).ClickAsync();
		//	await page.Locator("#result").ClickAsync();
	}
}