using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "rt-tr-group", ComponentTypeName = "row")]
    public class ReactRow<TOwner> : TableRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
        //[FindByXPath("//div[@role='gridcell'][1]")]
        [FindByCss(".rt-td:nth-of-type(1)")]
        public Text<TOwner> FirstName { get; private set; }

        [FindByCss(".rt-td:nth-of-type(2)")]
        //[FindByXPath("//div[@role='gridcell'][2]")]
        public Text<TOwner> LastName { get; private set; }

        [FindByCss(".rt-td:nth-of-type(3)")]
        //[FindByXPath("//div[@role='gridcell'][3]")]
        public Text<TOwner> Age { get; private set; }

        [FindByCss(".rt-td:nth-of-type(4)")]
        //[FindByXPath("//div[@role='gridcell'][4]")]
        public Text<TOwner> Email { get; private set; }

        [FindByCss(".rt-td:nth-of-type(5)")]
        //[FindByXPath("//div[@role='gridcell'][5]")]
        public Text<TOwner> Salary { get; private set; }

        [FindByCss(".rt-td:nth-of-type(6)")]
        //[FindByXPath("//div[@role='gridcell'][6]")]
        public Text<TOwner> Department { get; private set; }

        [FindByCss("span[title='Delete']")]
        public Clickable<TOwner> DeleteButton { get; private set; }

        [FindByCss("span[title='Edit']")]
        public Clickable<TOwner> EditButton { get; private set; }
    }
}