using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "modal-content", ComponentTypeName = "popup")]
    public class ReactAddPopup<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByPlaceholder("FirstName")]
        public TextInput<TOwner> FirstName { get; private set; }

        public Button<TOwner> Submit { get; private set; }
    }
}
