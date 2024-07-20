using Atata;

namespace AtataUITests.PageObjects.Controls
{
    [ControlDefinition("div", ContainingClass = "modal-content", ComponentTypeName = "popup")]
    public class ReactAddPopup<TOwner> : Control<TOwner>
        where TOwner : PageObject<TOwner>
    {
        public List <TextInput<TOwner>> TextFields { get; set; }

        public ReactAddPopup() => TextFields = new List<TextInput<TOwner>>();
            
        [FindByPlaceholder("First Name")]
        public TextInput<TOwner> FirstName { get; set; }

        [FindByPlaceholder("Last Name")]
        public TextInput<TOwner> LastName { get; set; }

        [FindById("userEmail")]
        public TextInput<TOwner> Email { get; set; }

        [FindByPlaceholder("Salary")]
        public TextInput<TOwner> Salary { get; set; }

        [FindByPlaceholder("Age")]
        public TextInput<TOwner> Age { get; set; }

        [FindByPlaceholder("Department")]
        public TextInput<TOwner> Department { get; set; }

        public Button<TOwner> Submit { get; set; }

        protected override void OnInit()
        {           
            TextFields.Add(FirstName);
            TextFields.Add(LastName);
            TextFields.Add(Email);
            TextFields.Add(Salary);
            TextFields.Add(Age);
            TextFields.Add(Department);
        }
    }
}