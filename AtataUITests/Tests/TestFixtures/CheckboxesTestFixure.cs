using AtataUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtataUITests.Tests.TestFixtures
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class CheckboxesTestFixture : UITestFixture
    {
        internal DemoQACheckBoxPage demoQaCheckBoxPage;

        [SetUp]
        public void CheckBoxesSetUp()
        {
            demoQaCheckBoxPage = DemoQAElementsPage.GoToCheckBoxesPage();
        }
    }
}