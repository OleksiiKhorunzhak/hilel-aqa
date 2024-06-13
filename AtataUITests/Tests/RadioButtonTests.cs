using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class RadioButtonTests : UITestFixture
    {
        [Test]
        [Description("Verify Radio Button page Text")]
        [Retry(2)]
        public void VerifyTextRadioButton()
        {
            Go.To<RadioButtonPage>()
                .PageUrl.Should.Be("https://demoqa.com/radio-button")
                .RadioButtonPageH1.Should.Be("Radio Button")
                .DoYouLikeText.Should.Be("Do you like the site?");
        }

        [Test]
        [Description("Verify Yes radiobutton")]
        [Retry(2)]
        public void VerifyYesRadioButton()
        {
            Go.To<RadioButtonPage>()
                .YesLabel.Should.BeVisible()
                .YesLabel.Click()
                .YesRadioButton.Should.BeChecked()
                .SuccessText.Should.Be("You have selected Yes");
        }

        [Test]
        [Description("Verify Impressive radiobutton")]
        [Retry(2)]
        public void VerifyImpressiveRadioButton()
        {
            Go.To<RadioButtonPage>()
                .ImpressiveLabel.Should.BeVisible()
                .ImpressiveLabel.Click()
                .ImpressiveRadioButtom.Should.BeChecked()
                .SuccessText.Should.Be("You have selected Impressive");
        }

        [Test]
        [Description("Verify No radiobutton")]
        [Retry(2)]
        public void VerifyNoRadioButton()
        {
            Go.To<RadioButtonPage>()
                .NoLabel.Should.BeVisible()
                .NoLabel.Click()
                .NoRadioButton.Should.BeDisabled()
                .NoRadioButton.Should.Not.BeChecked();
        }
    }
}
