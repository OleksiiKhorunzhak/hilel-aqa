using Atata;
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
        //    "Full Name" field
        //Test Case 1: Field title "Full Name" should be visible on the page
        //Test Case 2: Text "Full Name" Input should be visible on the field
        //Test Case 3: Enter "John Doe" in the "Full Name" field, press 'Submit', text "Name:John Doe" should be visible in the after submitting area
        //Test Case 4: Clear text in the "Full Name" field, press 'Submit', after submitting area should be empty
        //Test Case 5: "Full Name" field accepts letters, numbers, and special characters


        //    "Email" field
        //Test Case 1: Field title "Email" should be visible on the page
        //Test Case 2: Text "name@example.com" Input should be visible on the field
        //Test Case 3: Enter valid format ("johndoe@gmail.com") in the "Email" field, press 'Submit', text "Email:johndoe@gmail.com" should be visible in the after submitting area
        //Test Case 4: Enter invalid fomat ("johndoegmail.com" or "johndoe@gmailcom") in the "Email" field, press 'Submit', the "email" field should be highlighted with red, and after submitting area should be empty
        //Test Case 5: Clear text in the "Email" field, press 'Submit', after submitting area should be empty

        //    "Current Address" field
        //Test Case 1: Field title "Current Address" should be visible on the page
        //Test Case 2: Text "Current Address" Input should be visible on the field
        //Test Case 3: Enter "123 Main Street, Anytown, CA 12345" in the "Current Address" field, press 'Submit', text "Current Address :123 Main Street, Anytown, CA 12345" should be visible in the after submitting area
        //Test Case 4: Clear text in the "Current Address" field, press 'Submit', after submitting area should be empty
        //Test Case 5: The "Current Address" field can be expanded 


        //    "Permanent Address" field
        //Test Case 1: Field title "Permanent Address" should be visible on the page
        //Test Case 2: Enter "123 Main Street, Anytown, CA 12345" in the "Permanent Address" field, press 'Submit', text "Current Address :123 Main Street, Anytown, CA 12345" should be visible in the after submitting area
        //Test Case 3: Clear text in the "Permanent Address" field, press 'Submit', after submitting area should be empty
        //Test Case 4: The "Permanent Address" field can be expanded 

    }
}
