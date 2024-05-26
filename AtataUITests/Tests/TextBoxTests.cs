using Atata;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class TextBoxTests : UITestFixture
    {
        //Preconditions: Go to https://demoqa.com/text-box
        //Test Case 1: Text Full Name should be visible
        //Test Case 2: Text Full Name Input should be visible
        //Test Case 3: Enter "John Doe" in Text Full Name Input, press submit, text Name should be "Name:John Doe"
        //Test Case 4: Clear Text Full Name Input, press submit, text Name should not be visible

        //TCs
        //Preconditions: Go to https://demoqa.com/text-box
        //Test Case 1:Text Box Page should have a title:'Text Box'

        //Test Case 2: label of the field 'Full Name' should be visible on the page
        //Test Case 3: Text 'Full Name' placeholder should be visible in the field
        //Test Case 4: Field boundaries should be highlighted when Name field is active
        //Test Case 5: Text 'Full Name' input should be visible in the field
        //Test Case 6: Enter "John Doe" Input in Full Name field and Press submit and Text Name should be "Name:John Doe" visible 
        //Test Case 7: Placeholder text 'Full Name' should be disappeared when name input indicated
        //Test Case 8: Clear Text Full Name Input, press submit, text Name should not be visible

        //Test Case 9: Label of the field 'Email' should be visible on the page
        //Test Case 10: Text 'name@example.com' placeholder should be visible in the field
        //Test Case 11: Field boundaries should be highlighted when Email field is active
        //Test Case 12: Text 'Email' input should be visible in the field
        //Test Case 13: Enter "test_name@gmail.com" input in Email field and press submit and Text email should be 'Email:test_name@gmail.com' visible
        //Test Case 14: Placeholder text 'name@example.com' should be disappeared when email input indicated
        //Test Case 15: Enter invalid 'test_name' email input and click on submit and Field boundaries should be highlighted in red color and Text email is not visible
        //Test Case 16: Clear Text Email Input and Press submit and Text Name should not be visible

        //Test Case 17: Label of the field 'Current Address' should be visible on the page
        //Test Case 18: Text 'Current Address' placeholder should be visible in the field
        //Test Case 19: Field boundaries should be highlighted when Current Address field is active
        //Test Case 20: Text 'Current Address' input should be visible in the field
        //Test Case 21: Enter "Address_1 street Number_1" Input in Current Address field and Press submit and Text Current Address should be "Current Address:Address_1 street Number_1" visible
        //Test Case 22: Placeholder text 'Current Address' should be disappeared when address input indicated
        //Test Case 23: The height of the Current Address field should be resizable _When change the height by cursor
        //Test Case 24: After putting 462 characters in Current Address field _Then the scrollbar appears in the field
        //Test Case 25: After putting 461 characters in Current Address field _And the scrollbar does not appear in the field
        //Test Case 26: Clear Current Address Input and Press submit and Current Address should not be visible

        //Test Case 27: Label of the field 'Permanent Address' should be visible on the page
        //Test Case 28: Text 'Permanent Address' placeholder should be visible in the field
        //Test Case 29: Field boundaries should be highlighted when Permanent Address field is active
        //Test Case 30: Text 'Permanent Address' input should be visible in the field
        //Test Case 31: Enter "Address_1 street Number_1" Input in Permanent Address field and Press submit and Text Permanent Address should be "Permanent Address:Address_1 street Number_1" visible
        //Test Case 32: Placeholder text 'Permanent Address' should be disappeared when address input indicated
        //Test Case 33: The height of the Permanent Address field should be resizable _When change the height by cursor
        //Test Case 34: After putting 462 characters in Permanent Address field _Then the scrollbar appears in the field
        //Test Case 35: After putting 461 characters in Permanent Address field _And the scrollbar does not appear in the field
        //Test Case 36: Clear Permanent Address Input and Press submit and Permanent Address should not be visible



    }
}
