﻿using Atata;
using AtataUITests.PageObjects;
using NUnit.Framework.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests
{
    internal class TextBoxTests : UITestFixture
    {

        //Elements:
        //Preconditions: Go to https://demoqa.com/elements
        //TC 1: Image "https://demoqa.com/images/Toolsqa.jpg" should be in the Header
        //TC 2: Image "https://demoqa.com/images/Toolsqa.jpg" should be centered in the header
        //TC 3: Image "https://demoqa.com/images/Toolsqa.jpg" should be a link to Home page "https://demoqa.com/"

        //___________________________________________________
        //Text Box:
        //Preconditions: Go to https://demoqa.com/text-box
        [Test]
        [Description("TextBox Url should be https://demoqa.com/text-box")]
        public void VerifyTextBoxUrl()
        {
            Go.To<TextBoxPage>().
                PageUrl.Should.Be("https://demoqa.com/text-box");
        }
        //TC 1: class="text-center" should have text = "Text Box"
        [Test]
        [Description("TextBox Page title <h1> text should be = Text Box")]
        public void VerifyPageH1()
        {
            Go.To<TextBoxPage>().
                PageTitleH1.Should.Be("Text Box");
        }


        //[Full Name input]: - textInput
        //TC 2: label id="userName-label" text should be "Full Name"
        //TC 3: input id="userName" should be type="text"
        //TC 4: input id="userName" should be placeholder="Full Name"
        //TC 5: input id="userName" should be autocomplete = "off"
        //TC 6: input id="userName" enter value "FirstName 123" => input id="userName" text should be "FirstName 123" and placeholder style="display: none"
        //TC 7: clear input id="userName" => input id="userName" text should be "" and placeholder style="display: block"

        //[Email input]: - use EmailInput
        //TC 8: label id="userEmail-label" text should be "Email"
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
