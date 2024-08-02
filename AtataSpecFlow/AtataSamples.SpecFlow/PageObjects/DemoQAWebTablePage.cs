using Atata;
using AtataSamples.SpecFlow.PageObjects.Controls;
using _ = AtataSamples.SpecFlow.PageObjects.DemoQAWebTablePage;

namespace AtataSamples.SpecFlow.PageObjects
{
    [Url("webtables")]
    public sealed class DemoQAWebTablePage : DemoQAPage<_>
    {
        public ReactTable<WebTableRow, _> WebTable { get; private set; }

        public Button<_> Add{ get; private set; }

        public ReactAddPopup<_> AddPopup { get; private set; }

        public class WebTableRow : ReactRow<_>
        {
            //[FindByXPath("//div[@role='gridcell'][1]")]
            //[FindByXPath("//div[@class='rt-td'][1]")]
            [FindByCss(".rt-td:nth-of-type(1)")]
            public Text<_> FirstName { get; private set; }

            //[FindByXPath("//div[@role='gridcell'][2]")]
            //[FindByXPath("//div[@class='rt-td'][2]")]
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
            public Button<_> DeleteButton { get; private set; }

            [FindByXPath("//span[@title='Edit']")]
            public Button<_> EditButton { get; private set; }


        }

    }
}
