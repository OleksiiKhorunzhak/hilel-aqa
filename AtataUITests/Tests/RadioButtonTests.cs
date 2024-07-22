using Atata;
using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    internal class RadioButtonTests : UITestFixture
    {        
        [Test]
        [Description("Verify Yes radio Button can be checked and result text is 'You have selected Yes'")]
        public void VerifyYesRadioButton()
        {
            Go.To<DemoQARadioButtonPage>().ScrollDown().
                YesButton.Click().
                ResultText.Should.Be("You have selected Yes");                              
        }

        [Test]
        [Description("Verify Impressive radio Button can be checked and result text is 'You have selected Impressive'")]
        public void VerifyImpressiveRadioButtonClick()
        {
            Go.To<DemoQARadioButtonPage>().ScrollDown().
               ImpressiveButton.Click().
               ResultText.Should.Be("You have selected Impressive");
        }

        [Test]
        [Description("Verify No button is disabled")]
        public void VerifyNoButton()
        {
            Go.To<DemoQARadioButtonPage>().ScrollDown().
               NoButton.Should.BeDisabled();
        }

        [Test]
        [Description("Verify H1 Radio Button is visible")]
        public void VerifyPageHeader()
        {
            Go.To<DemoQARadioButtonPage>().
                Header.Should.Be("Radio Button");
        }

        [Test]
        [Description("Verify Radio Buttons page is back to default state after page refresh")]
        public void VerifyRadioButtonPageStateAfterRefresh()
        {
            var page = Go.To<DemoQARadioButtonPage>().ScrollDown().
                SelectRandomRadio().RefreshPage();

            Assert.That(page.PageInDefaultState, Is.True);                       
        }      
    }
}