using PlaywrigthUITests.PageObjects;

namespace PlaywrigthUITests.Tests
{
    internal class RadioButtonsTest : UITestFixture
    {
        private DemoQARadioButtonPage _radioButtonPage;

        [SetUp]
        public async Task SetupRadioButtonQAPage()
        {
            _radioButtonPage = new DemoQARadioButtonPage(Page);
            await _radioButtonPage.GoToRadiButtonsPage();
        }

        [Test]
        [Description("Verify 'Yes'' radio Button can be checked and result text is 'You have selected Yes'")]
        public async Task CheckYesRadioButton()
        {
            await _radioButtonPage.ClickYesRadioButton();
            var isYesChecked = await _radioButtonPage.IsYesRadioChecked();
            var isYesResultVisible = await _radioButtonPage.IsYesResultVisible();

            Assert.Multiple(() =>
            {
                Assert.That(isYesChecked, Is.True);
                Assert.That(isYesResultVisible, Is.True);
            });
        }

        [Test]
        [Description("Verify 'Impressive' radio Button can be checked and result text is 'You have selected Impressive'")]
        public async Task CheckImpressiveRadioButton()
        {
            await _radioButtonPage.ClickImpressiveRadioButton();
            var isImpressiveChecked = await _radioButtonPage.IsImpressiveRadioChecked();
            var isImpressiveResultVisible = await _radioButtonPage.IsImpressiveResultVisible();

            Assert.Multiple(() =>
            {
                Assert.That(isImpressiveChecked, Is.True);
                Assert.That(isImpressiveResultVisible, Is.True);
            });
        }

        [Test]
        [Description("Verify No radio Button is disabled")]
        public async Task CheckNoRadioButton()
        {
            var isNoEnabled = await _radioButtonPage.IsNoRadioEnabled();

            Assert.That(isNoEnabled, Is.False);
        }

        [Test]
        [Description("Verify H1 Radio Button is visible")]
        public async Task VerifyRadioButtonPageHeader()
        {
            var isHeaderVisible = await _radioButtonPage.IsRadioButtonPageHeaderVisible();
            Assert.That(isHeaderVisible, Is.True);
        }

        [Test]
        [Description("Verify Radio Buttons page is back to default state after page refresh")]
        public async Task VerifyRadioButtonPageStateAfterRefresh()
        {
            await _radioButtonPage.SelectRandomRadioButton();
            await _radioButtonPage.RadioButtonPageRefresh();

            Assert.That(await _radioButtonPage.IsRadioButtonPageInDefaultState(), Is.True);
        }
    }
}