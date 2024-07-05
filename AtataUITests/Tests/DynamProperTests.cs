using AtataUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class DynamProperTests : UITestFixture
    {
        [Test, Retry(2)]
        public void TestChangeColor()
        {
            Go.To<DynamProperPage>()
                .ColorChange.Css["color"].Should.Be("rgba(255, 255, 255, 1)")
                .ColorChange.Css["color"].Should.Be("rgba(220, 53, 69, 1)");
        }

        [Test, Retry(2)]
        public void TestEnableAfter()
        {
            Go.To<DynamProperPage>()
                .Enable5Sec.Should.BeDisabled()
                .Enable5Sec.Should.WithinSeconds(5).BeEnabled();
        }

        [Test, Retry(2)]
        public void TestVisibleAfter()
        {
            Go.To<DynamProperPage>()
                .VisibleAfter.Should.WithinSeconds(4).Not.BeVisible()
                .VisibleAfter.Should.BeVisible();
        }

        [Test, Retry(2)]
        public void TestVisibleAfterClickWait()
        {
            Go.To<DynamProperPage>()
                .VisibleAfter.Click()
                .VisibleAfter.Should.BeFocused();
        }
    }
}
