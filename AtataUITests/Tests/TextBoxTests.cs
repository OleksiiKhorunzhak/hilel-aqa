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


        //Olehs Test Cases 
        //TC1: Title "Email" exists on the page

        [Test]
        [Description("Text Email should be visible")]
        public void EmailLabelIsVisible()
        {
	        Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().EmailLabel.Should.BeVisible();
        }

        //TC2: Checking that "olehrush@gmail.com" as input can be done and is visible in afterSubmit text area

        [Test]
        [Description("Email input is visible in after-submit are")]
        public void EmailInput()
        {
	        Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().Email.Set("olehrush@gmail.com").Submit.Click().EmailText
		        .Should.Be("Email:olehrush@gmail.com");

        }

        // //TC3: Checking that "olehrush@gmail.com" can be deleted as input and shouldn't be visible in afterSubmit area after deletion

        [Test]
        [Description("Clear Email Input, press submit, text email should not be visible")]
        public void EmailInputClearance()
        {
	        Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().Email.Set("olehrush@gmail.com").Submit.Click().
		        Email.Clear().
		        EmailText.Should.Not.BeVisible();
        }

        //TC4: Checking that empty form can be submitted

        [Test]
        [Description("Submitting empty form with spaces")]
        public void SpacesInForm()
        {
	        Go.To<DemoQAElementsPage>().TextBox.ClickAndGo().FullName.Set("  ").Email.Set("  ").PermanentAddress
		        .Set("  ").CurrentAddress.Set("  ").Submit.Click();
        }


    }

}
