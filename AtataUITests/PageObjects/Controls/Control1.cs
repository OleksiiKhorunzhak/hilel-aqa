using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "react-checkbox-tree rct-icons-fa4", ComponentTypeName = "Tree")]
    public class Control1<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
