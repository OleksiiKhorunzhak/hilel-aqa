using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQAWebTablePage;

namespace AtataUITests.PageObjects
{
    [Url("webtables")]
    public sealed class DemoQAWebTablePage : DemoQAPage<_>
    {
        public ReactTable<WebTableRow, _> WebTable { get; private set; }

        public class WebTableRow : TableRow<_>
        {
            [FindByXPath(".//div[@class='rt-td'][1]")]
            public Text<_> FirstName { get; private set; }

            [FindByXPath(".//div[@class='rt-td'][2]")]
            public Text<_> LastName { get; private set; }

            [FindByXPath(".//div[@class='rt-td'][3]")]
            public Text<_> Age { get; private set; }

            [FindByXPath(".//div[@class='rt-td'][4]")]
            public Text<_> Email { get; private set; }

            [FindByXPath(".//div[@class='rt-td'][5]")]
            public Text<_> Salary { get; private set; }

            [FindByXPath(".//div[@class='rt-td'][6]")]
            public Text<_> Department { get; private set; }

            [FindByXPath(".//div[@class='rt-td'][7]//button")]
            public Link<_> Action { get; private set; }  
        }

    }
}
