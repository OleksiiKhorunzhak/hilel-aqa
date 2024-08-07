﻿using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public class TextBoxTests : UITestFixture
    {
        [Test]
        [Description("Text Full Name should be visible")]
        [Category("UI")]
        public void VerifyTextFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullNameLabel.Should.BeVisible();
        }

        [Test]
        [Description("Text Full Name Input should be visible")]
        [Category("UI")]
        public void VerifyTextFieldFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                FullName.Should.BeVisible();
        }

        [Test]
        [Description("Enter 'John Doe' in Text Full Name Input, press submit, text Name should be 'Name:John Doe'")]
        [Category("UI")]
        public void VerifyTextSetFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Set("John Doe").
                    Submit.Click().
                    FullName.Should.Be("Name:John Doe");
        }

        [Test]
        [Description("Clear Text Full Name Input, press submit, text Name should not be visible")]
        public void VerifyTextClearFullName()
        {
            Go.To<DemoQAElementsPage>().
                TextBox.ClickAndGo().
                    FullName.Clear().
                    Submit.Click().
                    FullName.Should.Not.BeVisible();
        }
    }
}
