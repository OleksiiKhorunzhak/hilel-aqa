using AtataUITests.PageObjects;

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
        
        //Test Case 5: Text Email should be visible
        
        [Test]
        [Description("Text Email should be visible")]
        public void VerifyTextEmail()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailLabel.Should.BeVisible();
        }
        
        //Test Case 6: Text Email Input should be visible
        
        [Test]
        [Description("Text Email Input should be visible")]
        public void VerifyFieldEmail()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailInput.Should.BeVisible();
        }
        
        //Test Case 7: Enter valid email in Text Email Input, press submit, text Email should be "Email:valid email"
        
        [Test]
        [Description("Action with Email Input")]
        public void VerifyTextSetEmail()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailInput.Set("test@test.com").
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                EmailText.Should.Be("Email:test@test.com");
        }
        
        //Test Case 8: Clear Text Email Input, press submit, text Email should hide
        
        [Test]
        [Description("Clear Text Email Input, press submit, text Email should hide")]
        public void VerifyTextClearEmail()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailInput.Clear().
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                EmailText.Should.Not.BeVisible();
        }
        
        //Test Case 9: Enter invalid email in Text Email Input, press submit, email input framed with red color
        
        [Test]
        [Description("Enter invalid email in Text Email Input, press submit, email input framed with red color")]
        public void VerifyTextInvalidEmail()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailInput.Set("test").
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                EmailInput.DomAttributes["class"].Should.Contain("field-error");
        }
        
        //Test Case 10: Text Current Address should be visible
        
        [Test]
        [Description("Text Current Address should be visible")]
        public void VerifyTextCurrentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressLabel.Should.BeVisible();
        }
        
        //Test Case 11: Text Current Address Input should be visible
        
        [Test]
        [Description("Text Current Address Input should be visible")]
        public void VerifyFieldCurrentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressArea.Should.BeVisible();
        }
        
        //Test Case 12: Current Address Input area is resizable
        
        [Test]
        [Description("Current Address Input area is resizable")]
        public void VerifyFieldCurrentAddressResizable()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressArea.DomAttributes["class"].Should.Contain("form-control");
        }
        
        //Test Case 13: Enter "Current Address" in Text Current Address Input, press submit, text Current Address should be "Current Address:Current Address"
        
        [Test]
        [Description("Actions with Current Address Input")]
        public void VerifyTextSetCurrentAddress() // Test is typing "Current Address :Test address" instead of "Test address"
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressArea.Set("Current Address :").
                CurrentAddressArea.Type("Test address").
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                CurrentAddressText.Should.Equal("Current Address :Test address");
        }
        
        //Test Case 14: Clear Text Current Address Input, press submit, text Current Address should be visible, Current Address Input should be empty
        
        [Test]
        [Description("Clear Text Current Address Input, press submit, text Current Address should be visible, Current Address Input should be empty")]
        public void VerifyClearCurrentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressArea.Clear().
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                CurrentAddressText.Should.BeEmpty();
        }
        
        //Test Case 15: Text Permanent Address should be visible
        
        [Test]
        [Description("Text Permanent Address should be visible")]
        public void VerifyTextPermanentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressLabel.Should.BeVisible();
        }
        
        //Test Case 16: Text Permanent Address Input should be visible
        
        [Test]
        [Description("Text Permanent Address Input should be visible")]
        public void VerifyFieldPermanentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressArea.Should.BeVisible();
        }
        
        //Test Case 17: Permanent Address Input area is resizable
        
        [Test]
        [Description("Permanent Address Input area is resizable")]
        public void VerifyFieldPermanentAddressResizable()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressArea.DomAttributes["class"].Should.Contain("form-control");
        }
        
        //Test Case 18: Enter "Permanent Address" in Text Permanent Address Input, press submit, text Permanent Address should be "Permanent Address:Permanent Address"

        [Test]
        [Description("Actions with Permanent Address Input")] // Test is typing "Permanent Address :Test" instead of "Test"
        public void VerifyTextSetPermanentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressArea.Set("Permanent Address :").
                PermanentAddressArea.Type("Test").
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                PermanentAddressText.Should.Equal("Permanent Address :Test");
        }
        
        //Test Case 19: Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible, Permanent Address Input should be empty
        
        [Test]
        [Description("Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible, Permanent Address Input should be empty")]
        public void VerifyClearPermanentAddress()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressArea.Clear().
                Submit.ScrollTo().ScrollDown().
                Submit.Click().
                PermanentAddressText.Should.BeEmpty();
        }
    }
}
