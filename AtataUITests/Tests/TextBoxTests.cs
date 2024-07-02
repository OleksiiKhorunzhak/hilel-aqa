using Atata;
using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    //[Category("TextBoxTests")]
    internal class TextBoxTests : UITestFixture
    {
        //Pre-conditions:
        [Test, Description("TextBox Url should be https://demoqa.com/text-box"), Retry(2)]
        public void TextBoxUrl()
        {
            Go.To<TextBoxPage>()
                .PageUrl.Should.Be("https://demoqa.com/text-box");
            Go.On<TextBoxPage>()
                .PageUrl.Should.EndWith("/text-box");
        }

        //TC 1:
        [Test, Description("TextBoxH1 text should be = Text Box"), Retry(2)]
        public void PageTitleH1()
        {
            Go.To<TextBoxPage>()
                .TextBoxH1.Should.Be("Text Box");
        }

        //Full Name Input:
        //TC 2:
        [Test, Description("FullNameLabel text should be = Full Name"), Retry(2)]
        public void UserNameLabelText()
        {
            Go.To<TextBoxPage>()
                .FullNameLabel.Should.Be("Full Name");
        }
        //TC 3:
        [Test, Description("FullNameInput type should be = text and placeholder = Full Name"), Retry(2)]
        public void UserNameInputType()
        {
            Go.To<TextBoxPage>()
                .FullNameInput.DomAttributes["type"].Should.Equal("text");
        }

        //TC 4:
        [Test, Description("FullNameInput should be autocomplete = off"), Retry(2)]
        public void UserNameInputAutocomplete()
        {
            Go.To<TextBoxPage>()
                .FullNameInput.DomAttributes["autocomplete"].Should.Equal("off");
        }
        //TC 5:
        [Test, Description("FullNameInput style should be display: block"), Retry(2)]
        public void UserNameInputStyle()
        {
            Go.To<TextBoxPage>()
                .FullNameInput.Css["display"].Should.Equal("block");
        }

        //TC 6: 
        [Test, Description("FullNameInput enter value FirstName 123"), Retry(2)]
        public void UserNameInputEnterValue()
        {
            Go.To<TextBoxPage>()
                .FullNameInput.Type("FirstName 123")
                .Should.Equals("FirstName 123");
        }

        //TC 7: 
        [Test, Description("FullNameInput clear should be empty"), Retry(2)]
        public void UserNameInputClear()
        {
            Go.To<TextBoxPage>()
                .FullNameInput.Clear()
                .FullNameInput.Should.BeEmpty();
        }
        //[Email input]
        //TC 8: 
        [Test, Description("label of User Email label should be Email"), Retry(2)]
        public void VerifyEmailInputLabel()
        {
            Go.To<TextBoxPage>()
                .EmailLabel.Should.Be("Email");
        }

        //TC 9: input id="userEmail" should be type="email"
        //TC 10: input id="userEmail" should be placeholder="name@example.com"
        //TC 11: input id="userEmail" should be autocomplete = "off"
        //TC 12: input id="userEmail" enter value "testMail123@gmail.com" => input id="userEmail" text should be "testMail123@gmail.com" and placeholder style="display: none"
        //TC 13: clear input id="userEmail" => input id="userEmail" text should be "" and placeholder style="display: block"

        //[Current Address textarea]:
        //TC 14: label id="currentAddress-label" text should be "Current Address"
        //TC 15: textarea id="currentAddress" size should be rows="5" and cols="20"
        //TC 16: textarea id="currentAddress" should be placeholder="Current Address"
        //TC 17: textarea id="currentAddress" enter value "Test Current Address 123 Road" => textarea id="currentAddress" text should be "Test Current Address 123 Road" and placeholder style="display: none"
        //TC 18: clear textarea id="currentAddress" => textarea id="currentAddress" text should be "" and placeholder style="display: block"


        //[Permanent Address textarea]:
        //TC 19: label id="permanentAddress-label" text should be "Permanent Address"
        //TC 20: textarea id="permanentAddress" size should be rows="5" and cols="20"
        //TC 21: textarea id="permanentAddress" enter value "Test Permanent Address 789 Road" => textarea id="permanentAddress" text should be "Test Permanent Address 789 Road"
        //TC 22: clear textarea id="permanentAddress" => textarea id="permanentAddress" text should be "" 

        //[Submit]:
        //TC 23: button id="submit" should be text "Submit"
        //TC 24: fill in input id="userName" value "FirstName 123" and click button id="submit" => output id="name" text = "Name:FirstName 123"
        //TC 25: fill in input id="userName" value "Second Name 321" and click button id="submit" => output id="name" text changed to "Second Name 321"
        //TC 26: fill in input id="userEmail" value "IncorrectEmail.com" and click button id="submit" => input border color should be red: rgb(255, 0, 0)
        //TC 27: fill in input id="userEmail" value "testMail123@gmail.com" and click button id="submit" => output id="email" text = "testMail123@gmail.com"
        //TC 28: fill in textarea id="currentAddress" value "Test Current Address 123 Road" and click button id="submit" => output id="currentAddress" text = "Current Address :Test Current Address 123 Road"
        //TC 29: fill in textarea id="permanentAddress" value "Test Permanent Address 789 Road" and click button id="submit" => output id="permanentAddress" text = "Permananet Address :Test Permanent Address 789 Road"
        //TC 30: clear input id="userName" and click button id="submit" => output id="name" is deleted
        //TC 31: clear input id="userEmail" and click button id="submit" => output id="email" is deleted
        //TC 32: clear textarea id="currentAddress" and click button id="submit" => output id="currentAddress" is deleted
        //TC 33: clear textarea id="permanentAddress" and click button id="submit" => output id="permanentAddress" is deleted
    }
}
