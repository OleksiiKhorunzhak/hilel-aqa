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
            [FindByCss(".rt-td:nth-of-type(1)")]
            public Text<_> FirstName { get; private set; }

            [FindByCss(".rt-td:nth-of-type(2)")]
            public Text<_> LastName { get; private set; }

            [FindByCss(".rt-td:nth-of-type(3)")]
            public Text<_> Age { get; private set; }

            [FindByCss(".rt-td:nth-of-type(4)")]
            public Text<_> Email { get; private set; }

            [FindByCss(".rt-td:nth-of-type(5)")]
            public Text<_> Salary { get; private set; }

            [FindByCss(".rt-td:nth-of-type(6)")]
            public Text<_> Department { get; private set; }

            [FindByXPath("//span[@title='Delete']")]
            public Svg<_> DeleteButton { get; private set; }

            [FindByXPath("//span[@title='Edit']")]
            public Svg<_> EditButton { get; private set; }


        }

    }
}
