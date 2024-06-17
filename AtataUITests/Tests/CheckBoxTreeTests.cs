using AtataUITests.PageObjects;
using AtataUITests.PageObjects.Controls;
using AtataUITests.Tests.TestFixtures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class CheckBoxTreeTests : CheckboxesTestFixture
    {
        [Test]
        public void VerifyHomeCheckboxChecked()
        {
            demoQaCheckBoxPage.
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].CheckBox.Should.BeChecked();
        }

        [Test]
        public void VerifyDocumentsCheckBoxChecked()
        {
            demoQaCheckBoxPage.ScrollDown().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked();
        }

        //HW
        [Test, Description("TC4 - Check Desktop checkbox, verify checked")]
        public void VerifyDesktopCheckBoxCanChecked()
        {
            demoQaCheckBoxPage.ScrollDown().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].Title.Click().
                CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked();
        }

        [Test, Description("TC5 - Expand Home > Documents, check Documents Checkbox. Verify WorkSpace checked")]
        public void VerifyWorkSpaceCheckedIfDocumentsChecked()
        {
            demoQaCheckBoxPage.ScrollDown().
              CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
              CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
              CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].CheckBox.Should.BeChecked();
        }

        [Test, Description("TC6 - Check Documents. Verify text 'You have selected : documents workspace react angular veu office public private classified general'")]
        public void VerifyDocumentsCheckedTextIsShown()
        {
            demoQaCheckBoxPage.ScrollDown().
             CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
             CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Title.Click().
             CheckboxCheckedOutput.Should.Contain("You have selected :\r\ndocuments\r\nworkspace\r\nreact\r\nangular\r\nveu\r\noffice\r\npublic\r\nprivate\r\nclassified\r\ngeneral");
        }

        [Test, Description("TC7 - Expand Home > Documents > WorkSpace, verify React have rct-icon-leaf-close icon")]
        public void VerifyReactCheckboxIcon()
        {
            demoQaCheckBoxPage.ScrollDown().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].Toggle.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("WorkSpace")].Toggle.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("React")].Icon.DomAttributes["class"].Should.Equal("rct-icon rct-icon-leaf-close");
        }

        [Test, Description("TC8 - Check Home, Expand Home, verify Desktop, Documents, Downloads checkboxex checked")]
        public void VerifyChildCheckboxesCheckedIfHomeChecked()
        {
            demoQaCheckBoxPage.ScrollDown().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Title.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Home")].Toggle.Click().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Desktop")].CheckBox.Should.BeChecked().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Documents")].CheckBox.Should.BeChecked().
               CheckBoxTree.Branch[x => x.Title.Content.Value.Equals("Downloads")].CheckBox.Should.BeChecked();
        }
    }
}