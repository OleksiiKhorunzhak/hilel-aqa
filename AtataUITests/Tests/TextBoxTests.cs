using Atata;
using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using DescriptionAttribute = NUnit.Framework.DescriptionAttribute;
using NUnit.Framework;

namespace AtataUITests.Tests
{
    internal class TextBoxTests : UITestFixture
    {

        [Test, Description("TC 1:Text Box Page should have a title 'Text Box'")]
        public void VerifyTextBoxPageHasTitleTextBox()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            TextBox.Should.Be("Text Box");
        }

        [Test, Description("TC 2: label of the field 'Full Name' should be visible on the page")]
        public void VerifyLabelOfTextField()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            FullNameLabel.Should.BeVisible();
        }

        [Test, Description("TC 3: Text 'Full Name' placeholder should be visible in the field")]
        public void VerifyTextFieldHasFullNamePlaceholder()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            FullNamePlaceholder.Should.BeVisible();
        }

        [Test, Description("TC 5: Text 'Full Name' input should be visible in the field and TC 6: Enter 'John Does' Input in Full Name field and Press submit and Text Name should be 'Name: John Doe' visible")]
        public void VerifyTextfieldInputValidation()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            FullName.Set("John Doe").
            FullName.Should.BeVisible().
            Submit.Click().
            NameInput.Should.BeVisible();
        }

        [Test, Description("TC7: Placeholder text 'Full Name' should be disappeared when name input indicated and TC 8: Clear Text Full Name Input and Placeholder is visible")]
        public void VerifyPaceholderDissapearsAfterTextNameInput()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            FullNamePlaceholder.Should.BeVisible().
            FullName.Set("John Doe").
            FullName.Should.BeVisible().
            FullName.Clear().
            FullNamePlaceholder.Should.BeVisible().
            NameInput.Should.Not.BeVisible();
        }

        [Test, Description("TC 9: Label of the field 'Email' should be visible on the page")]
        public void VerifyLabelOfEmailField()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                EmailLabel.Should.BeVisible();
        }

        [Test, Description("TC10: Email placeholder should be visible in the field")]
        public void VerifyEmailFieldHasPlaceholder()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            EmailPlaceholder.Should.BeVisible();
        }

        [Test, DescriptionAttribute("Test Case 12: Text 'Email' input should be visible in the field and TC 13:Test Case 13: Enter 'test@gmail.com' input in Email field and press submit and Text email should be 'Email:test_name@gmail.com' visible")]
        public void VerifyEmailInputValidation()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                Email.Set("test@gmail.com").
                Email.Should.BeVisible().
                Submit.Click().
                EmailInput.Should.BeVisible();
        }

        [Test, Description("TC14: Placeholder text 'name@example.com' should be disappeared when email input indicated")]

        public void VerifyPaceholderDissapearsAfterEmailInput()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            EmailPlaceholder.Should.BeVisible().
            Email.Set("test@gmail.com").
            Email.Should.BeVisible().
            Email.Clear().
            EmailPlaceholder.Should.BeVisible().
            EmailInput.Should.Not.BeVisible();
        }

        [Test, DescriptionAttribute("TC15: Enter invalid 'test_name' email input and click on submit and Text email is not visible")]

        public void VerifyThatEmailInputIsNotVisibleWhenEmailIsNotCorrect()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            EmailPlaceholder.Should.BeVisible().
            Email.Set("test@gmail").
            Email.Should.BeVisible().
            Submit.Click().
            EmailInput.Should.Not.BeVisible();
        }

        [Test, Description("TC20: Text 'Current Address' input should be visible in the field after click on Submit")]
        public void VerifyCurrentAddressInputIsVisisble()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            CurrentAddressPlaceholder.Should.BeVisible().
            CurrentAddress.Set("Address_1 street Number_1").
            CurrentAddress.Should.BeVisible().
            Submit.Click().
            CurrentAddressInput.Should.BeVisible().
            CurrentAddressInput.Should.Equals("Current Address :Address_1 street Number_1");
        }

        [Test, Description("TC 30: Text 'Permanent Address' input should be visible in the field")]
        public void VerifyPermanentAddressInput()
        {
            Go.To<DemoQAElementsPage>().
            TextBox.ClickAndGo().
            PermanentAddress.Set("Address_1 street Number_1").
            PermanentAddress.Should.BeVisible().
            Submit.Click().
            PermanentAddressInputField.Should.BeVisible().
            PermanentAddressInputField.Should.Equals("Permanent Address :Address_1 street Number_1");

        }


        //Test Case 4: Field boundaries should be highlighted when Name field is active 
        //Test Case 11: Field boundaries should be highlighted when Email field is active
        //Test Case 17: Label of the field 'Current Address' should be visible on the page
        //Test Case 19: Field boundaries should be highlighted when Current Address field is active

        //Test Case 22: Placeholder text 'Current Address' should be disappeared when address input indicated
        //Test Case 23: The height of the Current Address field should be resizable _When change the height by cursor
        //Test Case 24: After putting 462 characters in Current Address field _Then the scrollbar appears in the field
        //Test Case 25: After putting 461 characters in Current Address field _And the scrollbar does not appear in the field
        //Test Case 26: Clear Current Address Input and Press submit and Current Address should not be visible

        //Test Case 27: Label of the field 'Permanent Address' should be visible on the page
        //Test Case 28: Text 'Permanent Address' placeholder should be visible in the field
        //Test Case 29: Field boundaries should be highlighted when Permanent Address field is active

        //Test Case 31: Enter "Address_1 street Number_1" Input in Permanent Address field and Press submit and Text Permanent Address should be "Permanent Address:Address_1 street Number_1" visible
        //Test Case 32: Placeholder text 'Permanent Address' should be disappeared when address input indicated
        //Test Case 33: The height of the Permanent Address field should be resizable _When change the height by cursor
        //Test Case 34: After putting 462 characters in Permanent Address field _Then the scrollbar appears in the field
        //Test Case 35: After putting 461 characters in Permanent Address field _And the scrollbar does not appear in the field
        //Test Case 36: Clear Permanent Address Input and Press submit and Permanent Address should not be visible

    }
        }
