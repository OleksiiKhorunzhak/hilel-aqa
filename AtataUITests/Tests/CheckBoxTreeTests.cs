using AtataUITests.PageObjects;
using AtataUITests.PageObjects.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class CheckBoxTreeTests : UITestFixture
    {
        [Test]
        public void VerifyCheckBoxTreeeHomeCheckboxVisible()
        {
            Go.To<DemoQACheckBoxPage>().
                reactCheckboxTree.Should.BeVisible().
                reactCheckboxTree.TreeNodeElement[0].CheckBox.Should.BePresent().
                reactCheckboxTree.TreeNodeElement[0].CheckBox.Should.BeUnchecked().
                reactCheckboxTree.TreeNodeElement[0].Title.Click().
                reactCheckboxTree.TreeNodeElement[0].CheckBox.Should.BeChecked();
        }
    }
}
