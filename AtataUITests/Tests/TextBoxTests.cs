using AtataUITests.PageObjects;
using NUnit.Framework;
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

        //[Full Name] field:

        //Test Case 1: Text Full Name should be visible
        //Test Case 2: Text Full Name Input should be visible
        //Test Case 3: Enter "John Doe" in Text Full Name Input, press submit, text Name should be "Name:John Doe"
        //Test Case 4: Clear Text Full Name Input, press submit, text Name should not be visible
        #region "Full Name" input field

        //TC1: Label "Full Name" should be visible
        [Test]
        public void VerifyFullNameFieldLabelVisible()
        {
            Go.To<DemoQAElementsPage>().
               TextBox.ClickAndGo().
               FullName.Should.BeVisible().
               FullName.Set("John Doe").
               FullName.Should.BeVisible();
        }

        //TC2: Full Name input should be visible

        //[Email] field:

        //Test Case 1: Text Email Name should be visible
        //Test Case 2: Text name@example.com should be visible
        //Test Case 3: Enter invalid email data like "John Doe" in name@example.com Input, press submit, bar should become red
        //Test Case 4: Enter valid email data like "ABC@gmail.com" in name@example.com Input, press submit, text Name should be
        //"ABC@gmail.com
        //Test Case 5 Clear name@example.com Input, press submit, text email should not be visible


        //[Current Address] field:

        //Test Case 1: Text Current Address should be visible
        //Test Case 2: Text Current Address Input should be visible
        //Test Case 3: Enter "Bajana 10" in Current Address Input, press submit, text Current Address should be "Name:Bajana 10"
        //Test Case 4: Clear Text Current Address Input, press submit, text Current Address should not be visible


        //[Permanent Address] field:

        //Test Case 1: Text Permanent Address should be visible
        //Test Case 2: Permanent Address Input should be visible
        //Test Case 3: Enter "Bajana 14" in Permanent Address Input, press submit, text Permanent Address should be "Name:Bajana 14"
        //Test Case 4: Clear Text Permanent Address Input, press submit, text Permanent Address should not be visible
    }
}

