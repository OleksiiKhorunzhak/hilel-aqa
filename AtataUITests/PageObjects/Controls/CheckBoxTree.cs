using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "check-box-tree-wrapper", ComponentTypeName = "Tree")]
    public class CheckBoxTree<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ControlList<Node, TOwner> Branch { get; set; }

        [ControlDefinition("span", ContainingClass = "rct-text", ComponentTypeName = "branch")]
        public class Node : Control<TOwner>
        {
            [FindByAriaLabel("Toggle")]
            public Button<TOwner> Toggle { get; private set; }

            [FindByAttribute("type", "checkbox")]
            public CheckBox<TOwner> CheckBox { get; set; }

            [FindByClass("rct-title")]
            public Text<TOwner> Title { get; set; }
        }
    }
}
