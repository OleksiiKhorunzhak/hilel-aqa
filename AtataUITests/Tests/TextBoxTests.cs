using Atata;
using AtataUITests.PageObjects;
using AtataUITests.Tests.Fixtures;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace AtataUITests.Tests
{
    internal class TextBoxTests : TextBoxesTestFixture
    {
        #region "Full Name" input field

        //TC1: Label "Full Name" should be visible
        [Test]
        public void VerifyFullNameFieldLabelVisible()
        {
            demoQaTextBoxPage.FullNameLabel.Should.BeVisible();
        }

        //TC2: Full Name input should be visible
        [Test]
        public void VerifyFullNameInputFieldVisible()
        {
            demoQaTextBoxPage.FullNameInput.Should.BeVisible();
        }

        //TC3: Enter "John Doe" in Full Name input, press Submit, text should be "Name:John Doe" in afterSubmit area
        [Test]
        public void VerifyFullNameCanBeSubmitted()
        {
            demoQaTextBoxPage
                .FullNameInput.Set("John Doe").
                ScrollDown().Submit.Click()
                    .NameOutput.Should.Contain("Name:John Doe");
        }

        //TC4: Clear Full Name input, press Submit, label "Name:" should not be visible in afterSubmit area
        //TC7: Do not fill in Full Name field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Full Name
        //Note: TC4 covers TC7 idea.

        [Test]
        public void VerifyFullNameFieldCanBeCleared()
        {
            demoQaTextBoxPage
                .FullNameInput.Set("John Doe")
                .ScrollDown().Submit.Click()
                    .FullNameInput.Clear()
                    .ScrollDown().Submit.Click()
                        .NameOutput.Should.Not.BeVisible();
        }

        //TC5: Full Name accepts any string input
        [Test]
        public void VerifyFullNameFieldAcceptsAnyStringValue()
        {
            demoQaTextBoxPage
                .FullNameInput.Set("John Doe 1234 !@#$%^&*() привіт!");

            Assert.That(demoQaTextBoxPage.FullNameInput.Value, Is.EqualTo("John Doe 1234 !@#$%^&*() привіт!"));
        }

        //TC6: Min/Max validation - no such requirements

        #endregion

        #region "Email" input field

        //TC1: Label Email should be visible
        //TC2: Email input should be visible
        //Note: the same logic as for the "Full Name" input - that's why TCs are not added

        //TC3_1: Email accepts only correct email format - RegExp: ([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+), incorrect email can not be submitted
        string emailPattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

        [Test]
        public void VerifyEmailFieldComplianceWithRegExp_CorrectValue()
        {
            demoQaTextBoxPage
                .EmailInput.Set("correct@test.com");

            DemoQATextBoxPage.ShouldMatchRegex(demoQaTextBoxPage.EmailInput, emailPattern);
        }

        //TC3_2
        [Test]
        public void VerifyEmailFieldComplianceWithRegExp_IncorrectValue()
        {
            demoQaTextBoxPage
                .EmailInput.Set("incorrect@test")
                .ScrollDown().Submit.Click()
                .EmailOutput.Should.Not.BeVisible();
        }
        //TC4: Enter @correct_email into Email input, press Submit, text should be "Email:@correct_email" in afterSubmit area
        //TC5: Clear Email input, press Submit, label "Email:" should not be visible in afterSubmit area
        //TC7: Do not fill in Email field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Email
        //Note: the same logic as for the "Full Name" input - that's why TCs are not added

        //TC6: Min/Max validation  - no such requirements

        #endregion

        #region "Current address" input field
        //TC1: Label "Current Address" should be visible
        //TC2: Current Address input should be visible
        //Note: the same logic as for the "Full Name" input - that's why TCs are not added

        //TC3: Current Address input accepts multiline text ("Enter" button is correctly handled)
        [Test]
        public void VerifyCurrentAddressIsMultilineInput()
        {
            demoQaTextBoxPage
                .CurrentAddressInput.Set(
                "Line 1\n" +
                "Line 2\n" +
                "Line 3");

            Assert.That(demoQaTextBoxPage.CurrentAddressInput.Value, Is.EqualTo(
                "Line 1" + Environment.NewLine +
                "Line 2" + Environment.NewLine +
                "Line 3"));
        }

        //TC4: Enter @current_address in Current Address input, press Submit, text should be "Current Address:@current_address" in afterSubmit area, multiline should be correctly shown
        //This TC fails because the multiline is not handled in the output area.
        [Test]
        public void VerifyCurrentAddressOutputIsMultiline()
        {
            demoQaTextBoxPage
                .CurrentAddressInput.Set(
                    "Line 1\n" +
                    "Line 2\n" +
                    "Line 3")
                .ScrollDown().Submit.Click()
                .CurrentAddressOutput.Content.Should.Contain(
            "Line 1" + Environment.NewLine +
            "Line 2" + Environment.NewLine +
            "Line 3");
        }

        //TC5: Clear Current Address input, press Submit, label "Current Address:" should not be visible in afterSubmit area
        //TC7: Do not fill in Current Address field, fill in any other(s) field(s), press Submit - it's possible to submit the form with empty Current Address
        //Note: the same logic as for the "Full Name" input - that's why TCs are not added

        //TC6: Min/Max validation  - no such requirements

        //TC8: It's possible to change input field size by drag-n-dropping the corresponding text area control
        [Test]
        public void VerifyCurrentAddressInputIsResizeable()
        {
            string resizeProperty = demoQaTextBoxPage.Script.Execute<string>(
                "return window.getComputedStyle(arguments[0]).resize;",
                demoQaTextBoxPage.CurrentAddressInput.Scope);

            Assert.That(resizeProperty, Is.Not.EqualTo("none"));
        }

        #endregion

        #region "Permanent Address"  input field

        //The same as for the "Current Address" input field

        #endregion

        #region Form TCs

        //TC1: It's possible to submit all empty fields - no error messages are shown - covered by VerifyFullNameFieldCanBeCleared TC

        //TC2: Submitted values are shown in the grey frame
        //Note: topBorder only is checked just as an example

        [Test]
        public void VerifyTopBorderForOutput()
        {
            demoQaTextBoxPage
                .FullNameInput.Set("John Doe").ScrollDown().Submit.Click();

            string borderTopColor = demoQaTextBoxPage.Script.Execute<string>(
                "return window.getComputedStyle(arguments[0]).borderTopColor;",
                demoQaTextBoxPage.OutputBorder.Scope);

            Assert.That(borderTopColor, Is.EqualTo("rgb(222, 226, 230)"));

            string borderTopWidth = demoQaTextBoxPage.Script.Execute<string>(
                "return window.getComputedStyle(arguments[0]).borderTopWidth;",
                demoQaTextBoxPage.OutputBorder.Scope);

            Assert.Multiple(() =>
            {
                Assert.That(borderTopColor, Is.EqualTo("rgb(222, 226, 230)"));
                Assert.That(borderTopWidth, Is.EqualTo("0.8px"));

            });
        }

        #endregion
    }
}