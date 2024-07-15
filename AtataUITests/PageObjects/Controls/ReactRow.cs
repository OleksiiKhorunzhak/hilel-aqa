using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "rt-tr", ComponentTypeName = "row")]
    public class ReactRow<TOwner> : TableRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByXPath("//div[@role='gridcell'][1]")]
        public Text<TOwner> FirstName { get; private set; }

        [FindByXPath("//div[@role='gridcell'][2]")]
        public Text<TOwner> LastName { get; private set; }

        [FindByXPath("//div[@role='gridcell'][3]")]
        public Text<TOwner> Age { get; private set; }

        [FindByXPath("//div[@role='gridcell'][4]")]
        public Text<TOwner> Email { get; private set; }

        [FindByXPath("//div[@role='gridcell'][5]")]
        public Text<TOwner> Salary { get; private set; }

        [FindByXPath("//div[@role='gridcell'][6]")]
        public Text<TOwner> Department { get; private set; }

        [FindByXPath("//span[@title='Delete']")]
        public Button<TOwner> DeleteButton { get; private set; }

        [FindByXPath("//span[@title='Edit']")]
        public Button<TOwner> EditButton { get; private set; }
    }
}