using Atata;
using AtataUITests.PageObjects.Controls;
using _ = AtataUITests.PageObjects.DemoQAWebTablePage;

namespace AtataUITests.PageObjects
{
    public sealed class DemoQAWebTablePage : DemoQAPage<_>
    {
        public ReactTable<WebTableRow, _> WebTable { get; private set; }

        public class WebTableRow : TableRow<_>
        {
            public Text<_> FirstName { get; private set; }
            public Text<_> LastName { get; private set; }
            public Text<_> Age { get; private set; }
            public Text<_> Email { get; private set; }
            public Text<_> Salary { get; private set; }
            public Text<_> Department { get; private set; }
            public Link<_> Action { get; private set; }  // Assuming Action is a link
        }

    }
}
