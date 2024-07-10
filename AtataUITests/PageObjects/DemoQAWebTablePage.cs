using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQAWebTablePage;

namespace AtataUITests.PageObjects
{
    [Url("webtables")]
    public sealed class DemoQAWebTablePage : DemoQAPage<_>
    {
        public ReactTable<WebTableRow, _> WebTable { get; private set; }

        public Button<_> Add{ get; private set; }

        public ReactAddPopup<_> AddPopup { get; private set; }

        public class WebTableRow : ReactRow<_>
        {
            [FindByXPath("//div[@role='gridcell'][1]")]
            public Text<_> FirstName { get; private set; }

            [FindByXPath("//div[@role='gridcell'][2]")]
            public Text<_> LastName { get; private set; }

            [FindByXPath("//div[@role='gridcell'][3]")]
            public Text<_> Age { get; private set; }

            [FindByXPath("//div[@role='gridcell'][4]")]
            public Text<_> Email { get; private set; }

            [FindByXPath("//div[@role='gridcell'][5]")]
            public Text<_> Salary { get; private set; }

            [FindByXPath("//div[@role='gridcell'][6]")]
            public Text<_> Department { get; private set; }

            [FindByXPath("//span[@title='Delete']")]
            public Button<_> DeleteButton { get; private set; }

            [FindByXPath("//span[@title='Edit']")]
            public Button<_> EditButton { get; private set; }


        }

    }
}
