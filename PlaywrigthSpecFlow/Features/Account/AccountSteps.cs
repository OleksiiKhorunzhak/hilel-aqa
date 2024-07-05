using PlaywrigthSpecFlow.API.Features.Account;
using System;
using TechTalk.SpecFlow;

namespace PlaywrigthSpecFlow.Features.Account
{
    [Binding]
    public class AccountSteps
    {
        private readonly FeatureContext _featureContext;

        public AccountSteps(FeatureContext featureContext)
        {
            _featureContext = featureContext;
        }

        [BeforeFeature(@"ICreateAccountByAPI")]
        public static void WhenICreateAccountByAPI(FeatureContext featureContext)
        {
            AccountPresetup accountPresetup = new AccountPresetup();
            accountPresetup.AccountApiPresetup();
            featureContext["AccountApiPresetup"] = accountPresetup;
        }

        [Then(@"I get success status code from API")]
        public void ThenISeeSuccessStatusCode()
        {
            if (_featureContext.TryGetValue("AccountApiPresetup", out var presetupObj) && presetupObj is AccountPresetup presetup)
            {
                Assert.That(presetup.AccountCreated, Is.True, "Account not created");
            }
        }
    }
}
