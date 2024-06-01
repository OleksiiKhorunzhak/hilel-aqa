using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    //Preconditions: Go to https://demoqa.com/text-box
        //Test Case 1: Text Full Name should be visible
        //Test Case 2: Text Full Name Input should be visible
        //Test Case 3: Enter "John Doe" in Text Full Name Input, press submit, text Name should be "Name:John Doe"
        //Test Case 4: Clear Text Full Name Input, press submit, text Name should not be visible
        //Test Case 5: Text Email should be visible
        //Test Case 6: Text Email Input should be visible
        //Test Case 7: Enter "myemail@myemail.com" in the Email input, press submit, text Email should be "Email:myemail@myemail.com"
        //Test Case 8: Enter "1" in the Email input, press submit, Email input should be "Email:1" and the borders highlighted in red
        //Test Case 9: Enter "myemail@myemail" in the Email input, press submit, Email input should be "Email:myemail@myemail" and the borders highlighted in red
        //Test Case 10: Enter "myemail@myemail." in the Email input, press submit, Email input should be "Email:myemail@myemail." and the borders highlighted in red
        //Test Case 11: Enter "myemail@myemail.c" in the Email input, press submit, Email input should be "Email:myemail@myemail.c" and the borders highlighted in red
        //Test Case 12: Enter "@myemail.com" in the Email input, press submit, Email input should be "Email:@myemail.com" and the borders highlighted in red
        //Test Case 13: Enter "myemail.com" in the Email input, press submit, Email input should be "Email:myemail.com" and the borders highlighted in red
        //Test Case 14: Enter "current address" in the Current Address input, press submit, text Current Address should be "Current Address : current address"
        //Test Case 15: Enter "1111" in the Current Address input, press submit, text Current Address should be "Current Address : 1111"
        //Test Case 16: Enter "permanent address" in the Permanent Address input, press submit, text Permanent Address should be "Permanent Address : permanent address"
        //Test Case 17: Enter "2222" in the Permanent Address input, press submit, text Permanent Address should be "Permanent Address : 2222"

    public class TextBoxTests : UITestFixture
    {
        [Test]
        [Description("Text Full Name should be visible")]
        public void VerifyTextFullName()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().FullNameLabel.Should.BeVisible();
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        public void VerifyTextFieldFullName()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().FullName.Should.BeVisible();
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        public void VerifyTextSetFullName()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().FullName.Set("John Doe").Submit.Click().FullNameText.Should
                .Be("Name:John Doe");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public void VerifyTextClearFullName()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().FullName.Clear().Submit.Click().FullNameText.Should.Not
                .BeVisible();
        }

        [Test]
        [Description("Text Email should be visible")]
        public void VerifyTextEmail()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().EmailLabel.Should.BeVisible();
        }

        [Test]
        [Description("Text Email Input should be visible")]
        public void VerifyTextEmailInputLabel()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().EmailLabelInput.Should.BeVisible();
        }

        [Test]
        [Description("Text Current Address should be visible")]
        public void VerifyTextCurrentAddress()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().CurrentAddress.Should.BeVisible();
        }

        [Test]
        [Description("Text Current Address Input should be visible")]
        public void VerifyTextCurrentAddressLabel()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().CurrentAddressLabel.Should.BeVisible();
        }

        [Test]
        [Description("Text Permanent Address should be visible")]
        public void VerifyTextPermanentAddress()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().PermanentAddress.Should.BeVisible();
        }

        [Test]
        [Description("Text Permanent Address Input should be visible")]
        public void VerifyTextPermanentAddressLabel()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().PermanentAddressLabel.Should.BeVisible();
        }

        [Test]
        [Description("Submit button should be visible")]
        public void VerifySubmitButtomVisibility()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                SubmitButton.Should.BeVisible();
        }
        
        [Test]
        [Description("Submit button text should be visible")]
        public void VerifyTextSubmitButtom()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                SubmitLabel.Should.BeVisible();
        }
        
        [Test]
        [Description("Submit Jon Doe Full Name")]
        public void VerifyFullNameSubmit()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                FullName.Set("Jon Doe").
                Submit.Click().
                FullNameResult.Should.Be("Name:Jon Doe");
        }
        
        [Test]
        [Description("Submit Jon Doe Full Name")]
        public void VerifyEmailSubmit()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                EmailLabelInput.Set("myemail@email.com").
                Submit.ScrollTo().
                Submit.Click().
                EmailResult.Should.Be("Email:myemail@email.com");
                
        }
        [Test]
        [Description("Submit Current Address")]
        public void VerifyCurrentAddressSubmit()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                CurrentAddressLabel.Set("my current address").
                Submit.ScrollTo().
                Submit.Wait(Until.Visible).
                Submit.Click().
                CurrentAddressResult.Should.Be("Current Address :my current address");
        }
        
        [Test]
        [Description("Submit Permanent Address")]
        public void VerifyPermanentAddressSubmit()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                PermanentAddressLabel.Set("my permanent address").
                Submit.ScrollTo().
                Submit.Click().
                PermanentAddressResult.Should.Be("Permananet Address :my permanent address");
        }
        
        [Test]
        [Description("Validate Email address submit")]
        public void VerifyEmailvalidationOnSubmit()
        {
            Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().
                
                EmailLabelInput.Set("myemail").
                Submit.Wait(Until.Visible).
                Submit.Click().
                EmailValidationError.Should.BeVisible().
                EmailResult.Should.Not.BeVisible();
        }
    }
}
