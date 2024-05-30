using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    public class TextBoxTests : UITestFixture
    {
        [Test]
        [Description("Text Full Name should be visible")]
        public void VerifyTextFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullNameLabel.Should.BeVisible();
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public void VerifyTextFieldFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullName.Should.BeVisible();
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public void VerifyTextSetFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("John Doe").
                    Submit.Click().
                    FullNameText.Should.Be("Name:John Doe");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public void VerifyTextClearFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Clear().
                    Submit.Click().
                    FullNameText.Should.Not.BeVisible();
        }
    internal class TextBoxTests : UITestFixture
    {
        //Preconditions: Go to https://demoqa.com/text-box
        //Field "Full Name" 

        //Test Case 1: Mark "Full Name" should be visible
        //Test Case 2:  Full Name Input should be visible and input " Dog Pulya" can be done
        //Test Case 3: Enter " Dog Pulya" in  Full Name Input, press submit, the input should be  visible as "Full Name:Dog Pulya"  in aftersubmit text area
        // Test Case 4 :Full Name Input doesn`t accept any number or special symbol and after entering invalid imput, frame of the field "Full Name" is highlighted in red
        // Test Case 5: Max and Min input validation of the field "Full Name" 
        // Test Case 6: Checking that empty field "Full Name" can`t be submited and after pressing submit an appropriate allert appiars

        //Field "Email" 

        //Test Case 7: Mark "Email" should be visible
        //Test Case 8: Email Input should be visible and  "valid email" as input  can be done
        //Test Case 9: Enter "valid email" in Email Input, press submit, the input should be  visible in aftersubmit text area
        //Test Case 10: Email Input accepts only Latin letters and after entering "invalid email", frame of the field "Email" is highlighted in red

        // Field "Current Address"

        //Test Case 11: Current Address Input should be visible and  "valid current address" as input  can be done
        //Test Case 12: Current Address Input accepts any string input 
        //Test Case 13: Enter "valid current address" in Current Address Input, press submit, the input should be  visible in aftersubmit text area
        //Test Case 14: Max input validation of the field "Current Address"
        //Test Case 15: Enter "invalid current address" in Current Address Input, frame of the field  is highlighted in red

        // Field "Permanent Address"

        //Test Case 16: Permanent Address Input should be visible and  "valid permanent address" as input  can be done
        //Test Case 17: Permanent Address Input accepts any string input 
        //Test Case 18: Enter "valid permanent address" in Permanent Address Input, press submit, the input should be  visible in aftersubmit text area
        //Test Case 19: Max input validation of the field "Permanent Address"
        //Test Case 20: Enter "invalid permanent address" in Permanent Address Input, frame of the field  is highlighted in red

        //General Form "TextBox"

        // Enter character "!" in Full Name Input leaving other fields of the General Form empty and after pressing submit an appropriate allert appiars


    }
}

