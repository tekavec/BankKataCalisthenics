using System;
using TechTalk.SpecFlow;

namespace BankKataCalisthenics.AcceptanceTests
{
    [Binding]
    public class AccountSteps
    {

        [Given(@"that account is created")]
        public void GivenThatAccountIsCreated()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a client makes a deposit of (.*) on '(.*)'")]
        public void GivenAClientMakesADepositOfOn(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a deposit of (.*) on '(.*)'")]
        public void GivenADepositOfOn(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"a withdrawal of (.*) on '(.*)'")]
        public void GivenAWithdrawalOfOn(int p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"she prints her bank statement")]
        public void WhenShePrintsHerBankStatement()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"she would see")]
        public void ThenSheWouldSee(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
