using AtataUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class DynamicPropertiesTests
    {
        [Test]
        public void TestChangeColor()
        {
            Go.To<DemoQADynamicPropertiesPage>().
                ColorChange.Css["color"].Should.WithinSeconds(2).Be("expected");
        }
    }
}
