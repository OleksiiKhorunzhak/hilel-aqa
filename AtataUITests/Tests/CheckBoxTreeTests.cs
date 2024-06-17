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
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BePresent().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeUnchecked().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeChecked();
        }

        [Test]
        public void VerifyDocumentsCheckBoxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked();
        }

        //TODO: automate test cases
        //TC4 - Expand Home > Check Descktop Checkbox, verify checked
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        //TC6 - Expand Home > Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon
        //TC8 - Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked
    }
}
