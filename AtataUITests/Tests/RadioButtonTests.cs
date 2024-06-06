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
        [Test][Description("Verify RadioButton page URL")]
        public void VerifyRadioButtonUrl()
        {
            Go.To<RadioButtonPage>()
                .PageUrl.Should.Equals("https://demoqa.com/radio-button");
        }

        [Test]
        [Description("Radio Button page text content checking")]
        public void PageTitleH1()
        {
            Go.To<RadioButtonPage>()
                .RadioButtonPageH1.Should.Be("Radio Button")
                .DoYouLikeText.Should.Be("Do you like the site?");
        }

        [Test]
        [Description("RadioButton check and Success text")]
        public void RadioButtonCheck()
        {
            Go.To<RadioButtonPage>()
                .YesLabel.Should.BeVisible()
                .YesLabel.Click()
                .YesRadioButton.Should.BeChecked()
                .SuccessText.Should.Be("You have selected Yes");
        }
    }
}
