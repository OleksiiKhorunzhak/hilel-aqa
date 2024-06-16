using Atata;
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
        //TC4 - Expand Home > Check Desktop Checkbox, verify checked
        [Test]
        [Description("Expand Home > Check Desktop Checkbox, verify checked")]
        public void VerifyDesktopCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked();
        }
        //TC5 - Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked
        [Test]
        [Description("Expand Home > Documents, Check Documents Checkbox. Verify WorkSpace checked")]
        public void VerifyWorkSpaceCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].CheckBox.Should.BeChecked();
        }
        //TC6 - Expand Home > Check Documents. Verify text 'You have selected : documents workspace react angular veu
        //office public private classified general'
        [Test]
        [Description("Expand Home > Check Documents. Verify text 'You have selected :" +
            " documents workspace react angular veu office public private classified general")]
        public void VerifyTextAFterDocumentsCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                CheckBoxTree.Should.BeVisible().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
                Result.Should.Be("documents workspace react angular veu office public private classified general");
        }
        //TC7 - Expand Home > Documents > WorkSpace, verify React have rct  icon-leaf-close icon
        [Test]
        [Description("Expand Home > Documents > WorkSpace, verify React have rct  icon-leaf-close icon")]
        public void VerifyReactChIcon()
        {
            Go.To<DemoQACheckBoxPage>().
                 CheckBoxTree.Should.BeVisible().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("React")].Title.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("React")].Style.Should.BeVisible();
        }

        //TC8 - Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked

        [Test]
        [Description("Expand Home > Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        public void VerifyDesktopDocumentsDownloadsCheckboxChecked()
        {
            Go.To<DemoQACheckBoxPage>().
                 CheckBoxTree.Should.BeVisible().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked().
                 CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Downloads")].CheckBox.Should.BeChecked();
        }
    }
}
