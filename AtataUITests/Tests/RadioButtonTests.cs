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
        [Description("RadioButtonH1 text should be = Radio Button")]
        public void PageTitleH1()
        {
            Go.To<RadioButtonPage>().
                RadioButtonPageH1.Should.Be("Radio Button");
        }

        [Test]
        [Description("Verify RadioButton check")]
        public void RadioButtonCheck()
        {
            Go.To<RadioButtonPage>()
                .YesRadio.Should.BeVisible()
                .YesRadio.Check();
                //. YesRadio.Click()
        }
    }
}
