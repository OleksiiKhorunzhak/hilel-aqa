using Atata;
using Gherkin.Ast;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "react-checkbox-tree rct-icons-fa4", ComponentTypeName = "Tree")]
    public class CheckBoxTreeControl<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ControlList<Node, TOwner> Branch { get; set; }

        [ControlDefinition("span", ContainingClass = "rct-text", ComponentTypeName = "Branch")]
        public class Node : Control<TOwner>
        {
            [FindByTitle("Toggle")]
            public Button<TOwner> Toggle { get; set; }

            [FindByAttribute("type", "checkbox")]
            public CheckBox<TOwner> CheckBox { get; set; }

            [FindByClass("rct-node-icon")]
            public Image<TOwner> Icon { get; set; }

            [FindByClass("rct-title")]
            public Text<TOwner> Title { get; set; }
        }
    }
}
