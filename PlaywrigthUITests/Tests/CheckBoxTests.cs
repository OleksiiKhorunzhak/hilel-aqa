using Atata;
using NUnit.Framework.Internal;
using PlaywrigthUITests.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaywrigthUITests.Tests
{
    internal class CheckBoxTests : UITestFixture
    {
        private PO_CheckBoxPage _CheckBoxPage;

        [SetUp]
        public void SetupCheckBoxPage()
        {
            _CheckBoxPage = new PO_CheckBoxPage(Page);
        }

        [Test]
        public async Task VerifyHomeTreeOpen()
        {
            await _CheckBoxPage.GoToCheckBoxPage();
            await _CheckBoxPage.VerifyToggleClicked();
            await _CheckBoxPage.VerifyHomeChecked();
            await _CheckBoxPage.VerifyDownloadsUnchecked();
        }
    }
}
