using Mc2.CrudTest.AcceptanceTests.Drivers;
using Mc2.CrudTest.Core.Application.PersonHandlers.Command;
using NUnit.Framework;

namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class CustomerManagerStepDefinitions
{
    private readonly ScenarioContext _scenarioContext;

    public CustomerManagerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), phone number is (.*), email is (.*) and bank account number is (.*)")]
    public void WhenFirstNameLastnameDateOfBirthIsPhoneNumberIsEmailAndBankAccountNumberIs
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);


        _scenarioContext["Customer"] = request;
    }

    [Then(@"customer should be created")]
    public async Task ThenCustomerShouldBeCreatd()
    {
        var request = (AddCustomerCommand)_scenarioContext["Customer"];

        InMemeoryDbContext db = new();
        AddCustomerHandler handler = new(db);
        var response = await handler.Handle(request, default);

        Assert.NotZero(response);
    }
}
