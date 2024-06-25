using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "rt-table")]
    public class ReactTable<TRow, TOwner> : Table<TableHeader<TOwner>, TRow, TOwner>
        where TRow : TableRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
