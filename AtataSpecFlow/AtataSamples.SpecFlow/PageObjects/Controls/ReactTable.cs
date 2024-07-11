using Atata;

namespace AtataSamples.SpecFlow.PageObjects.Controls
{
    //[ControlDefinition("div", ContainingClass = "rt-table")]
    //public class ReactTable<TRow, TOwner> : Table<TableHeader<TOwner>, TRow, TOwner>
    //    where TRow : ReactRow<TOwner>
    //    where TOwner : PageObject<TOwner>
    //{
    //}

    [ControlDefinition("div", ContainingClass = "rt-table", ComponentTypeName = "Table")]
    public class ReactTable<THeader, TRow, TOwner> : Table<THeader, TRow, TOwner>
    where THeader : TableHeader<TOwner>
    where TRow : TableRow<TOwner>
    where TOwner : PageObject<TOwner>
    {
    }
}
