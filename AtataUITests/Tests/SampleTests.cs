using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
	internal class TextBoxTests : UITestFixture
	{
		//Preconditions: Visit https://demoqa.com/text-box

		//[Full Name] field:

		//TC1: Title "Full Name" exists on the page
		//TC2: Checking that "Oleh Rushchak" as input can be done and is visible in afterSubmit text area
		//TC3: Checking that "Oleh Rushchak" can be deleted as input and shouldn't be visible in afterSubmit area after deletion
		//TC4: Full Name can have any number input

		//[Email] field:

		//TC1: Title "Email" exists on the page
		//TC2: Checking that "olehrush@gmail.com" as input can be done and is visible in afterSubmit text area
		//TC3: Checking that "olehrush@gmail.com" can be deleted as input and shouldn't be visible in afterSubmit area after deletion
		//TC4: Check that "1", "=" as inputs cannot be accepted

		//[Current Address] field:

		//TC1: Title "Current Address" exists on the page
		//TC2: Checking that "Munich, Germany, 81476" as input can be done and is visible in afterSubmit text area
		//TC3: Checking that "Munich, Germany, 81476" can be deleted as input and shouldn't be visible in afterSubmit area after deletion

		//[Permanent Address] field
		//TC1: Title "Current Address" exists on the page
		//TC2: Checking that "Munich, Germany, 81476" as input can be done and is visible in afterSubmit text area
		//TC3: Checking that "Munich, Germany, 81476" can be deleted as input and shouldn't be visible in afterSubmit area after deletion

		//[Form]
		//TC1: Checking that empty form can be submitted
		//TC2: Checking that if email value is invalid, submitting other inputs is impossible

		//[Elements menu]
		//TC1: Checking that Elements menu can be collapsed

	}
}