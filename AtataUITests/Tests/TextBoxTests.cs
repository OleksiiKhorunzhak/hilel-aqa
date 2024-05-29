using AtataUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class TextBoxTests : UITestFixture
    {
		//Preconditions: Go to https://demoqa.com/text-box
		//Test Case 1: Text Full Name should be visible
		[Test]
		public void VerifyTextFieldFullName()
		{
			Go.To<DemoQAElementsPage>().
				TextBox.ClickAndGo();

			Go.To<DemoQATextBoxPage>().PageUrl.Should.Be("https://demoqa.com/elements");
		}
		//Test Case 2: "Full Name" placeholder should be visible
		//Test Case 3: Enter "John Doe" in Text Full Name Input, press submit, text Name should be "Name:John Doe"
		//Test Case 4: Clear Text Full Name Input, press submit, text Name should not be visible

		//Test Case 5: "Email" field should be visible
		//Test Case 6: "name@example.com" placeholder should be visible in "Email" field
		//Test Case 7: Enter valid email in "Email" field (test@mail.com), click on "Submit" button, text row "Email:{email}" should be visible, field is not red highlighted
		//Test Case 8: Enter invalid email in "Email" field (testmail.com), click on "Submit" button, text row shouldn't be visible, field is red highlighted
		//Test Case 9: Clear "Email" field, click on "Submit" button, placeholder "name@example.com" should be visible, text row shouldn't be visible

		//Test Case 10: "Current Address" field should be visible
		//Test Case 11: "Current Address" placeholder should be visible
		//Test Case 12: Enter some text in "Current Address" field, click on "Submit button", row "Current Address : {text}" should be visible
		//Test Case 13: Clear "Current Address" field, lick on "Submit" button, placeholder "Current Address" shouldn't be visible, text row shouldn't be visible

		//Test Case 14: "Permanent Address" field should be visible
		//Test Case 15: "Permanent Address" placeholder should be visible
		//Test Case 16: Enter some text in "Permanent Address" field, click on "Submit button", row "Permanent Address : {text}" should be visible
		//Test Case 17: Clear "Current Address" field, lick on "Submit" button, placeholder "Permanent Address" shouldn't be visible, text row shouldn't be visible
	}
}
