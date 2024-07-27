﻿using Atata;

namespace AtataSamples.SpecFlow.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "modal-content", ComponentTypeName = "popup")]
    public class ReactAddPopup<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        [FindByPlaceholder("First Name")]
        public TextInput<TOwner> FirstName { get; private set; }

        [FindByPlaceholder("Last Name")]
        public TextInput<TOwner> LastName { get; private set; }

        [FindById("userEmail")]
        public TextInput<TOwner> Email { get; private set; }

        [FindByPlaceholder("Age")]
        public TextInput<TOwner> Age { get; private set; }

        [FindByPlaceholder("Salary")]
        public TextInput<TOwner> Salary { get; private set; }

        [FindByPlaceholder("Department")]
        public TextInput<TOwner> Department { get; private set; }
        public Button<TOwner> Submit { get; private set; }
    }
}
