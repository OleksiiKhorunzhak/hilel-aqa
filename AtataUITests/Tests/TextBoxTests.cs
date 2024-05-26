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

        //[Full Name] field
        //TC1: Label "Full Name" should be visible
        //TC2: Full Name input should be visible
        //TC3: Enter "John Doe" in Full Name input, press Submit, text should be "Name:John Doe" in afterSubmit area
        //TC4: Clear Full Name input, press Submit, label "Name:" should not be visible in afterSubmit area
        //TC5: Full Name accepts any string input
        //TC6: Min/Max validation 
        //TC7: Do not fill in Full Name field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Full Name

        //[Email] field
        //TC1: Label Email should be visible
        //TC2: Email input should be visible
        //TC3: Email accepts only correct email format - RegExp: ([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+) - for incorrect format the field is highlighted in red on submit
        //TC4: Enter @correct_email into Email input, press Submit, text should be "Email:@correct_email" in afterSubmit area
        //TC5: Clear Email input, press Submit, label "Email:" should not be visible in afterSubmit area
        //TC6: Min/Max validation 
        //TC7: Do not fill in Email field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Email

        //[Current Address] field
        //TC1: Label "Current Address" should be visible
        //TC2: Current Address input should be visible
        //TC3: Current Address input accepts multiline text ("Enter" button is correctly handled)
        //TC4: Enter @current_address in Current Address input, press Submit, text should be "Current Address:@current_address" in afterSubmit area, multiline should be correctly shown
        //TC5: Clear Current Address input, press Submit, label "Current Address:" should not be visible in afterSubmit area
        //TC6: Min/Max validation 
        //TC7: Do not fill in Current Address field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Current Address
        //TC8: It's possible to change input field size by drag-n-dropping the corresponding text area control

        //[Permanent Address] field
        //TC1: Label "Permanent Address" should be visible
        //TC2: Permanent Address input should be visible
        //TC3: Permanent Address input accepts multiline text ("Enter" button is correctly handled)
        //TC4: Enter @permanent_address in Permanent Address input, press Submit, text should be "Permanent Address:@permanent_address" in afterSubmit area, multiline should be correctly shown
        //TC5: Clear Permanent Address input, press Submit, label "Permanent Address:" should not be visible in afterSubmit area
        //TC6: Min/Max validation 
        //TC7: Do not fill in Permanent Address field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Permanent Address
        //TC8: It's possible to change input field size by drag-n-dropping the corresponding text area control

        //[Form]
        //TC1: It's possible to submit all empty fields - no error messages are shown
        //TC2: It's possible to submit values by pressing "Enter" button
        //TC3: Submitted values are shown in the grey frame
        //TC4: The order for submitted values in the frame is: Name, Email, Current Address, Permanent Address and each value is shown from the new line
        //TC5: If some values are not submitted the empty space is not added and the frame is adjusted accordingly.
    }
}
