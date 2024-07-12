using System;
using TechTalk.SpecFlow;

namespace SpecFlow_Atata
{
    [Binding]
    public class WebTableTestStepDefinitions
    {
        [When(@"I see Registration Form")]
        public void WhenISeeRegistrationForm()
        {
            throw new PendingStepException();
        }

        [When(@"I set Age to ""([^""]*)""")]
        public void WhenISetAgeTo(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I set Salary to ""([^""]*)""")]
        public void WhenISetSalaryTo(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"I set Department to ""([^""]*)""")]
        public void WhenISetDepartmentTo(string insurance)
        {
            throw new PendingStepException();
        }

        [When(@"I click Submit Button")]
        public void WhenIClickSubmitButton()
        {
            throw new PendingStepException();
        }
    }
}
