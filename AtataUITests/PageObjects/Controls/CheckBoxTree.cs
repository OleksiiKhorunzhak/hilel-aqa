using Atata;
using System.ComponentModel;

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

            [FindByClass("rct-icon rct-icon-leaf-close")]
            //public Button<TOwner> Icon { get; set; }
            public Control<TOwner> Icon { get; set; }

        }
    }
}
