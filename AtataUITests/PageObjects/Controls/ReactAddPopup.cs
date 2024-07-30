using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "modal-content", ComponentTypeName = "popup")]
    public class ReactAddPopup<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByPlaceholder("First Name")]
        public TextInput<TOwner> FirstName { get; private set; }

        [FindByPlaceholder("Last Name")]
        public TextInput<TOwner> LastName { get; private set; }

        public Button<TOwner> Submit { get; private set; }
    }
}
