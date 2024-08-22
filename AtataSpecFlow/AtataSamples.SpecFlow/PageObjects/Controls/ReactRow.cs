using Atata;

namespace AtataSamples.SpecFlow.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "rt-tr-group", ComponentTypeName = "row")]
    public class ReactRow<TOwner> : TableRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
