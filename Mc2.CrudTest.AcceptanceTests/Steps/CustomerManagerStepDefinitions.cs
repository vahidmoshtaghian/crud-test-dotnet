namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class CustomerManagerStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public CustomerManagerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"first name is test(.*), lastname is test(.*), date of birth is (.*)/(.*), phone number is (.*), email is aa@bb\.cc and bank account number is (.*)")]
    public void WhenFirstNameIsTestLastnameIsTestDateOfBirthIsPhoneNumberIsEmailIsAaBb_CcAndBankAccountNumberIs(int p0, int p1, decimal p2, int p3, int p4, int p5)
    {
        throw new PendingStepException();
    }

    [Then(@"customer should be creatd")]
    public void ThenCustomerShouldBeCreatd()
    {
        throw new PendingStepException();
    }
}
