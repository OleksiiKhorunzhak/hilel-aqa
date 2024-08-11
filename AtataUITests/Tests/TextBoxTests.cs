using Atata;
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
        //    "Full Name" field
        //Test Case 1: Field title "Full Name" should be visible on the page
        //Test Case 2: Text "Full Name" Input should be visible on the field
        //Test Case 3: Enter "John Doe" in the "Full Name" field, press 'Submit', text "Name:John Doe" should be visible in the after submitting area
        //Test Case 4: Clear text in the "Full Name" field, press 'Submit', after submitting area should be empty
        //Test Case 5: "Full Name" field accepts letters, numbers, and special characters

        [Test]
        public void VerifyFullNameLabel()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullNameLabel.Should.BeVisible();

        }

        [Test]
        public void VerifyFullNameFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Should.BeVisible();

        }

        [Test]
        public void VerifyFullNameSubmitted()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("John Doe").
                        ScrollDown().Submit.Click().
                            NameOutput.Should.Contain("Name:John Doe");

        }

        [Test]
        public void VerifyFullNameCleared()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("John Doe").
                        ScrollDown().Submit.Click().
                     FullName.Clear().
                        ScrollDown().Submit.Click().
                        NameOutput.Should.Not.BeVisible();

        }

        [Test]
        public void VerifyFullNameAcceptAnyStringValue()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("John Doe 12 .@!#%&'*+/=?^_`").
                        ScrollDown().Submit.Click().
                        NameOutput.Should.Contain("John Doe 12 .@!#%&'*+/=?^_`");
        }

        //    "Email" field
        //Test Case 1: Field title "Email" should be visible on the page
        //Test Case 2: Text "name@example.com" Input should be visible on the field
        //Test Case 3: Enter valid format ("johndoe@gmail.com") in the "Email" field, press 'Submit', text "Email:johndoe@gmail.com" should be visible in the after submitting area
        //Test Case 4: Enter invalid fomat ("johndoegmail.com" or "johndoe@gmailcom") in the "Email" field, press 'Submit', the "email" field should be highlighted with red, and after submitting area should be empty
        //Test Case 5: Clear text in the "Email" field, press 'Submit', after submitting area should be empty

        [Test]
        public void VerifyEmailLabel()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailLabel.Should.BeVisible();
        }

        [Test]
        public void VerifyEmailFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                Email.Should.BeVisible();
        }

        [Test]
        public void VerifyValidEmailSubmitted()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    Email.Set("johndoe@gmail.com").
                        ScrollDown().Submit.Click().
                        EmailOutput.Should.Contain("Email:johndoe@gmail.com");

        }

        [Test]

        public void VerifyInvalidEmailNotSubmitted()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    Email.Set("johndoe@com").
                        ScrollDown().Submit.Click().
                        EmailOutput.Should.Not.BeVisible();

        }

        [Test]
        public void VerifyEmailFieldCleared()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    Email.Set("johndoe@gmail.com").
                        ScrollDown().Submit.Click().
                     Email.Clear().
                        ScrollDown().Submit.Click().
                        EmailOutput.Should.Not.BeVisible();

        }

        //    "Current Address" field
        //Test Case 1: Field title "Current Address" should be visible on the page
        //Test Case 2: Text "Current Address" Input should be visible on the field
        //Test Case 3: Enter "123 Main Street, Anytown, CA 12345" in the "Current Address" field, press 'Submit', text "Current Address :123 Main Street, Anytown, CA 12345" should be visible in the after submitting area
        //Test Case 4: Clear text in the "Current Address" field, press 'Submit', after submitting area should be empty
        //Test Case 5: The "Current Address" field can be expanded 


        [Test]
        public void VerifyCurrentAddressLabel()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddressLabel.Should.BeVisible();
        }

        [Test]
        public void VerifyCurrentAddressFieldInput()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                CurrentAddress.Should.BeVisible();
        }

        [Test]
        public void VerifyCurrentAddressSubmitted()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    CurrentAddress.Set("123 Main Street, Anytown, CA 12345").
                        ScrollDown().Submit.Click().
                        CurrentAddressOutput.Should.Contain("Current Address :123 Main Street, Anytown, CA 12345");

        }

        [Test]
        public void VerifyCurrentAddressCleared()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    CurrentAddress.Set("123 Main Street, Anytown, CA 12345").
                        ScrollDown().Submit.Click().
                        CurrentAddress.Clear().
                            ScrollDown().Submit.Click().
                            CurrentAddressOutput.Should.Not.BeVisible();


        }
        //Test Case 5: The "Current Address" field can be expanded - cannot be tested

        //    "Permanent Address" field
        //Test Case 1: Field title "Permanent Address" should be visible on the page
        //Test Case 2: Enter "123 Main Street, Anytown, CA 12345" in the "Permanent Address" field, press 'Submit', text "Current Address :123 Main Street, Anytown, CA 12345" should be visible in the after submitting area
        //Test Case 3: Clear text in the "Permanent Address" field, press 'Submit', after submitting area should be empty
        //Test Case 4: The "Permanent Address" field can be expanded 

        [Test]
        public void VerifyPermanentAddressLabel()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                PermanentAddressLabel.Should.BeVisible();
        }

        [Test]
        public void VerifyPermanentAddressSubmitted()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    PermanentAddress.Set("123 Main Street, Anytown, CA 12345").
                        Submit.Click().
                        PermanentAddressOutput.Should.Contain("Permananet Address :123 Main Street, Anytown, CA 12345");

        }

        [Test]
        public void VerifyPermanentAddressCleared()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    PermanentAddress.Set("123 Main Street, Anytown, CA 12345").
                        Submit.Click().
                        PermanentAddress.Clear().
                        Submit.Click().
                        PermanentAddressOutput.Should.Not.BeVisible();
        }

        //Test Case 4: The "Permanent Address" field can be expanded  - cannot be tested
    }
}

