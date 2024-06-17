using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "check-box-tree-wrapper", ComponentTypeName = "CheckBoxTree")]
    public class ReactCheckboxTree<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        public ControlList<TreeNode, TOwner> TreeNodeElement { get; set; }

        [ControlDefinition("span", ContainingClass = "rct-text", ComponentTypeName = "Tree Node")]
        public class TreeNode : Control<TOwner> 
        { 
            public Button<TOwner> Toggle { get; set; }

            [FindByAttribute("type", "checkbox")]
            public CheckBox<TOwner> CheckBox { get; set; }

            [FindByClass("rct-title")]
            public Text<TOwner> Title { get; set; }
        }
    }
}
