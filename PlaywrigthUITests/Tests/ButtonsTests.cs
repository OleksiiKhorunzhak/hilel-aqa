using Microsoft.Playwright;
using NUnitTests.Features.Drive;
using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    [Description("Verify Buttons on buttons page")]
    class ButtonsTestsrun : UITestFixture
    {
        private DemoQaButtonsPage _demoQaButtonsPage;
        
        [SetUp]
        public void SetupDemoQAPage()
        {
            _demoQaButtonsPage = new DemoQaButtonsPage(Page);
        }
        
        public byte newstring = DrivePresetup.Accelerate;
        public byte newstring1 = DrivePresetup.InternalClass.InternalAccelerate;

        // [Test, Description("Verify Click Me button"), Retry(2)]
        public async Task ClickButtonTest()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            // And I click the 'Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).ClickAsync();
            // Then  I see "You have done a dynamic click" text.
            var isVisible = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.That(isVisible,
                "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
            // And I NOT see "You have done a double click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isNotVisible,
                "The element with text 'You have done a double click' should NOT be visible after clicking the button.");
        }

        [Test, Description("Verify Double Click Me button"), Retry(3)]
        public async Task DoubleClickButtonTest()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            // And I double click the 'Double Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Double Click Me" }).DblClickAsync();
            // Then I see "You have done a double click" text.
            var isVisible = await Page.GetByText("You have done a double click").IsVisibleAsync();
            Assert.That(isVisible,
                "The element with text 'You have done a double click' should be visible after clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a dynamic click").IsHiddenAsync();
            Assert.That(isNotVisible,
                "The element with text 'You have done a dynamic click' should NOT be visible after a double click.");
        }

        [Test, Description("Verify Rigth Click Me button"), Retry(2)]
        public async Task RigthClickButtonTest()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            // And I Rigth click the 'Right Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { NameString = "Right Click Me" }).ClickAsync(
                new LocatorClickOptions
                {
                    Button = MouseButton.Right,
                });
            // Then I see "You have done a right click" text.
            var isVisible = await Page.GetByText("You have done a right click").IsVisibleAsync();
            Assert.That(isVisible,
                "The element with text 'You have done a double click' should be visible after Rigth clicking the button.");
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a double click").IsHiddenAsync();
            Assert.That(isNotVisible,
                "The element with text 'You have done a dynamic click' should NOT be visible after Rigth clicking the button.");
        }

        //Homework Lesson_9
        //TODO : 
        //TC-4 : Verify Click Me button should be enabled
        
        [Test]
        [Description("Verify Click Me button should be enabled")]
        public async Task VerifyClickMeButtonEnabled()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            // And I see 'Click Me' button
            var isEnabled = await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).IsEnabledAsync();
            Assert.That(isEnabled, "The 'Click Me' button should be enabled.");
        }
        
        //TC-5 : Verify Click Right Click Me button verify button focused
        
        [Test]
        [Description("Verify Rigth Click Me button verify button focused")]
        public async Task VerifyRigthClickMeButtonFocused()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            await Page.GetByRole(AriaRole.Button, new() { Name = "Right Click Me", Exact = true }).ClickAsync();
            // Assert
            await _demoQaButtonsPage.RightClickMeButtonIsFocused();
        }
        
        //TC-6 : Verify H1 Buttons is visible
        
        [Test]
        [Description("Verify H1 Buttons is visible")]
        public async Task VerifyH1ButtonsVisible()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            var isVisible =  await Page.GetByRole(AriaRole.Heading, new() { Name = "Buttons" }).IsVisibleAsync();
            Assert.That(isVisible, "The 'Buttons' text should be visible.");
        }
        
        //TC-7 : Verify text 'You have done a dynamic click' is not visible after page refresh
        
        [Test]
        [Description("Verify text 'You have done a dynamic click' is not visible after page refresh")]
        public async Task VerifyDynamicClickTextNotVisibleAfterRefresh()
        {
            await _demoQaButtonsPage.GoToButtonsPage();
            // And I click the 'Click Me' button
            await Page.GetByRole(AriaRole.Button, new() { Name = "Click Me", Exact = true }).ClickAsync();
            // Then  I see "You have done a dynamic click" text.
            var isVisible = await Page.GetByText("You have done a dynamic click").IsVisibleAsync();
            Assert.That(isVisible,
                "The element with text 'You have done a dynamic click' should be visible after clicking the button.");
            // And I refresh the page
            await Page.ReloadAsync();
            // And I NOT see "You have done a dynamic click" text.
            var isNotVisible = await Page.GetByText("You have done a dynamic click").IsHiddenAsync();
            Assert.That(isNotVisible,
                "The element with text 'You have done a dynamic click' should NOT be visible after refreshing the page.");
        }
    }
}