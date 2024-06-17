using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public class TextBoxTests : UITestFixture
    {
        //[Test]
        //[Description("Text Full Name should be visible")]
        //public void VerifyTextFullName()
        //{
        //    Go.To<DemoQAElementsPage>().
        //        TextBox.ClickAndGo().
        //        FullNameLabel.Should.BeVisible();
        //}

        //[Test]
        //[Description("Text Full Name Input should be visible")]
        //public void VerifyTextFieldFullName()
        //{
        //    Go.To<DemoQAElementsPage>().
        //        TextBox.ClickAndGo().
        //        FullName.Should.BeVisible();
        //}

        //[Test]
        //[Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        //public void VerifyTextSetFullName()
        //{
        //    Go.To<DemoQAElementsPage>().
        //        TextBox.ClickAndGo().
        //            FullName.Set("John Doe").
        //            Submit.Click().
        //            FullNameText.Should.Be("Name:John Doe");
        //}

        //[Test]
        //[Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        //public void VerifyTextClearFullName()
        //{
        //    Go.To<DemoQAElementsPage>().
        //        TextBox.ClickAndGo().
        //            FullName.Clear().
        //            Submit.Click().
        //            FullNameText.Should.Not.BeVisible();
        //}

        //Field "Full Name" 

        //Test Case 1: Mark "Full Name" should be visible
        [Test]
        [Description("Mark \"Full Name\" should be visible")]
        public void VerifyTextFullNameLable() 
        { 
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullNameLabel.Should.BeVisible();    
        }

        //Test Case 2:  Full Name Input should be visible and input " Dog Pulya" can be done

        [Test]
        [Description("Full Name Input should be visible and input \" Dog Pulya\" can be done")]
        public void VerifyTextInputFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullName.Should.BeVisible();
        }

        //Test Case 3: Enter " Dog Pulya" in  Full Name Input, press submit, the input should be  visible as "Full Name:Dog Pulya"  in aftersubmit text area

        [Test]
        [Description("The input should be  visible as \"Full Name:Dog Pulya\"  in aftersubmit text area")]
        public void VerifyTexFullNameSet()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("Dog Pulya").
                    ScrollDown().
                    Submit.Click().
                    FullNameText.Should.Be("Name:Dog Pulya");
        }

        // Test Case 4 :Full Name Input doesn`t accept any number or special symbol and after entering invalid imput, frame of the field "Full Name" is highlighted in red
       
        [Test]
        [Description("Enter invalid imput, frame of the field \"Full Name\" is highlighted in red")]
        public void VerifyInvalidFullNameSet()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("456!!").
                    BorderColorFullName.Should.HaveClass("rgba(220, 53, 69)");

            //        var borderColor = Go.To<DemoQAElementsPage>().
            //                    TextBox.ClickAndGo().
            //                    FullName.GetCssValue("border-color");
         
            //Assert.That(borderColor, Is.EqualTo("rgba(220, 53, 69)"), "The border color is not red, indicating an error in the Full Name field.");
        }

        // Test Case 5: Max and Min input validation of the field "Full Name" 
        //Note: There aren`t requirements for Test Case 5, that is why Tests are not added

        // Test Case 6: Checking that empty field "Full Name" can`t be submmited and after pressing submit an appropriate alert appears

        [Test]
        [Description("Checking that empty field \"Full Name\" can`t be submmited and after pressing submit an appropriate alert appears")]
        public void VerifyEmptyFullNameInputSetAllert()
        {
            string expectedAlertText = "The field Full Name must be fill in";
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("  ").
                    ScrollDown().
                    Submit.Click(). 
                    AlertMessage.Should.Be(expectedAlertText);

        }

        //Field "Email" 

        //Test Case 7: Mark "Email" should be visible  
        //Test Case 8: Email Input should be visible and  "valid email" as input  can be done
        //NOTE: Сonceptually similar tests have already been created for field "Full Name"      

        //Test Case 9: Enter "valid email" in Email Input, press submit, the input should be  visible in aftersubmit text area

        [Test]
        [Description("The input should be  visible as \"Email:pulyadog@gmail.com\"  in aftersubmit text area")]
        public void VerifyEmailInputSet()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    EmailInput.Set("pulyadog@gmail.com").
                    ScrollDown().
                    Submit.Click().
                    EmailText.Should.Be("Email:pulyadog@gmail.com");

        }

        //Test Case 10: Email Input accepts only Latin letters and after entering "invalid email", frame of the field "Email" is highlighted in red

        [Test]
        [Description("Enter invalid imput, frame of the field \"Email\" is highlighted in red")]
        public void VerifyInvalidEmailInputSet()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    EmailInput.Set("собакапуля@gmail.com").
                    BorderColorEmail.Should.HaveClass("rgba(220, 53, 69)");

        }

        // Field "Current Address"

        //Test Case 11: Current Address Input should be visible and  "valid current address" as input  can be done
        //Test Case 12: Current Address Input accepts any string input 
        //NOTE: Сonceptually similar tests have already been created for field "Full Name"      

        //Test Case 13: Enter "valid current address" in Current Address Input, press submit, the input should be  visible in aftersubmit text area

        [Test]
        [Description("The input should be  visible as \"Current Address:Varash city, Budivelnikiv street, building 3, apartment 333\"  in aftersubmit text area")]
        public void VerifyCurrentAddressInputSet()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    CurrentAddressInput.Set("Varash city, Budivelnikiv street, building 3, apartment 333").
                    ScrollDown().
                    Submit.Click().
                    CurrentAddressText.Should.Be("Current Address:Varash city, Budivelnikiv street, building 3, apartment 333");
        }


        //Test Case 14: Max input validation of the field "Current Address"
        //NOTE: No such requirements

        //Test Case 15: Enter invalid input in Current Address Input, frame of the field  is highlighted in red

        [Test]
        [Description("Enter invalid imput, frame of the field \"Current Address\" is highlighted in red")]
        public void VerifyInvalidCurrentAddressInputSet()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    CurrentAddressInput.Set("12378%%#!!strett#city**").
                    BorderColorCurrentAddress.Should.HaveClass("rgba(220, 53, 69)");

        }

        // Field "Permanent Address" -  NOTE: There are the same tests for field "Current Address"

        //Test Case 16: Permanent Address Input should be visible and  "valid permanent address" as input  can be done
        //Test Case 17: Permanent Address Input accepts any string input 
        //Test Case 18: Enter "valid permanent address" in Permanent Address Input, press submit, the input should be  visible in aftersubmit text area
        //Test Case 19: Max input validation of the field "Permanent Address"
        //Test Case 20: Enter "invalid permanent address" in Permanent Address Input, frame of the field  is highlighted in red

        //General Form "TextBox"

        // Enter character "!" in Full Name Input leaving other fields of the TextBox Form empty and after pressing submit an appropriate alert appears

        [Test]
        [Description("Enter character \"!\" in Full Name Input leaving other fields of the TextBox Form empty and after pressing submit an appropriate alert appears")]
        public void VerifyEmptyFieldsOfTextBoxFormSetAllert()
        {
            string expectedAlertTextBoxForm = "The fields of the TextBox Form must be fill in";
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("!").EmailInput.Set("  ").CurrentAddressInput.Set("  ").PermanentAddressInput.Set("  ").
                    ScrollDown().
                    Submit.Click().
                    AlertMessage.Should.Be(expectedAlertTextBoxForm);


        }

    }
}

