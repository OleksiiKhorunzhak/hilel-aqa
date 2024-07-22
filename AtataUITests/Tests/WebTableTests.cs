using Atata;
using AtataUITests.PageObjects;

namespace AtataUITests.Tests
{
    public sealed class WebTableTests : UITestFixture
    {
        [Test]
        public void VerifyTableDefaultState()
        {
            Go.To<DemoQAWebTablePage>().
                WebTable.Should.BeVisible().
                WebTable.Rows.Count.Should.BeGreater(1).
                WebTable.Rows[0].FirstName.Should.Be("Cierra").
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].FirstName.Should.BeVisible().
                WebTable.Rows[row => row.FirstName.Content.Value.Equals("Cierra")].LastName.Should.Be("Vega");                
        }

        [Test]
        public void VerifyAddPopupAllFieldsAreMandatory()
        {
            var page = Go.To<DemoQAWebTablePage>().Add.Click().AddPopup.Submit.Click();
           
            foreach (var input in page.AddPopup.TextFields)
            {
                input.Css["border-color"].Should.Be("rgb(220, 53, 69)");                           
            }
        }

        [Test]
        public void VerifyAddRow()
        {
            var page = Go.To<DemoQAWebTablePage>();

            int initialEmptyRowsCounter = page.WebTable.Rows.Where(row => string.IsNullOrWhiteSpace(row.FirstName.Value)).ToList().Count;

            page.Add.Click().
                 AddPopup.FirstName.Set("Test").
                 AddPopup.LastName.Set("Test2").
                 AddPopup.Email.Set("Test@la.com").
                 AddPopup.Age.Set("34").
                 AddPopup.Salary.Set("1000").
                 AddPopup.Department.Set("Dep1").
                 AddPopup.Submit.Click();

            int afterAddingEmptyRowrCounter = page.WebTable.Rows.Where(row => string.IsNullOrWhiteSpace(row.FirstName.Value)).ToList().Count;

            Assert.That(afterAddingEmptyRowrCounter, Is.LessThan(initialEmptyRowsCounter));
            page.WebTable.Rows[row => row.FirstName.Content.Value.Equals("Test")].FirstName.Should.BeVisible();
        }

        [Test]
        public void VerifyEditRow()
        {
            var page = Go.To<DemoQAWebTablePage>();

            string rowForEditingIndicatorByFirstName = page.WebTable.Rows[0].FirstName.Value;

            page.WebTable.Rows[0].EditButton.Click();
            
                 page.AddPopup.FirstName.Set("Test").
                 AddPopup.LastName.Set("Test2").
                 AddPopup.Email.Set("Test@la.com").
                 AddPopup.Age.Set("34").
                 AddPopup.Salary.Set("1000").
                 AddPopup.Department.Set("Dep1").
                 AddPopup.Submit.Click();
                        
            page.WebTable.Rows[row => row.FirstName.Content.Value.Equals("Test")].Should.BeVisible();
            page.WebTable.Rows[row => row.FirstName.Content.Value.Equals(rowForEditingIndicatorByFirstName)].Should.Not.BeVisible(); ;

        }

        [Test]
        public void VerifyDeleteRow()
        {
            var page = Go.To<DemoQAWebTablePage>();

            int initialEmptyRowsCounter = page.WebTable.Rows.Where(row => string.IsNullOrWhiteSpace(row.FirstName.Value)).ToList().Count;
            string rowForDeletingIndicatorByFirstName = page.WebTable.Rows[0].FirstName.Value;

            page.WebTable.Rows[0].DeleteButton.Click();

            int afterDeletingEmptyRowrCounter = page.WebTable.Rows.Where(row => string.IsNullOrWhiteSpace(row.FirstName.Value)).ToList().Count;

            Assert.That(afterDeletingEmptyRowrCounter, Is.GreaterThan(initialEmptyRowsCounter));
            page.WebTable.Rows[row => row.FirstName.Content.Value.Equals(rowForDeletingIndicatorByFirstName)].Should.Not.BeVisible();
        }
    }
}