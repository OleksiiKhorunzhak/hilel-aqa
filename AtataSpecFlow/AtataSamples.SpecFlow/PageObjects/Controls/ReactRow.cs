﻿using Atata;

namespace AtataSamples.SpecFlow.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "rt-tr", ComponentTypeName = "row")]
    public class ReactRow<TOwner> : TableRow<TOwner>
        where TOwner : PageObject<TOwner>
    {
    }
}
