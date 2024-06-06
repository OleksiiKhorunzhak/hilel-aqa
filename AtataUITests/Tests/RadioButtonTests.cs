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
        [Description("Verify Radio Button Text")]
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

        }

        [Test]
        [Description("RadioButton check and Success text")]
        public void VerifyNoRadioButton()
        {
            Go.To<RadioButtonPage>()

        }
    }
}
