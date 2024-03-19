using Mc2.CrudTest.AcceptanceTests.Drivers;
using Mc2.CrudTest.Core.Application.PersonHandlers.Command;
using Mc2.CrudTest.Core.Domain.Exceptions;
using NUnit.Framework;

namespace Mc2.CrudTest.AcceptanceTests.Steps;

[Binding]
public class CustomerManagerStepDefinitions
{

    private readonly ScenarioContext _scenarioContext;
    private InMemeoryDbContext _dbContext;

    public CustomerManagerStepDefinitions(ScenarioContext scenarioContext)
    {
        _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void Initial()
    {
        _dbContext = new();
    }

    [Scope(Tag = "correct_input")]
    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), phone number is (.*), email is (.*) and bank account number is (.*)")]
    public void WhenFirstNameLastnameDateOfBirthIsPhoneNumberIsEmailAndBankAccountNumberIs
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);

        _scenarioContext["Customer"] = request;
    }

    [Scope(Tag = "correct_input")]
    [Then(@"customer should be created")]
    public async Task ThenCustomerShouldBeCreatd()
    {
        var request = (AddCustomerCommand)_scenarioContext["Customer"];

        AddCustomerHandler handler = new(_dbContext);
        var response = await handler.Handle(request, default);

        Assert.NotZero(response);
    }


    [Scope(Tag = "invalid_email")]
    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), phone number is (.*), email is wrong like (.*) and bank account number is (.*)")]
    public void WhenFirstNameIsTestLastnameIsTestDateOfBirthIsPhoneNumberIsEmailIsWrongLikeHjftgyhjtgAndBankAccountNumberIsAcocuntNumber
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);

        _scenarioContext["CustomerWrongEmail"] = request;
    }

    [Scope(Tag = "invalid_email")]
    [Then(@"should throws email validation error")]
    public void ThenshouldThrowsRmailValidationError()
    {
        var request = (AddCustomerCommand)_scenarioContext["CustomerWrongEmail"];
        AddCustomerHandler handler = new(_dbContext);

        Assert.ThrowsAsync<EmailValidationException>(async () => await handler.Handle(request, default));
    }



    [Scope(Tag = "invalid_phone")]
    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), wrong phone number is (.*), email is (.*) and bank account number is (.*)")]
    public void WhenFirstNameIsTestLastnameIsTestDateOfBirthIsWrongPhoneNumberIsQwerdasdasEmailIsAaBb_CcAndBankAccountNumberIsAcocuntNumber
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);

        _scenarioContext["CustomerWrongPhone"] = request;
    }

    [Scope(Tag = "invalid_phone")]
    [Then(@"should throws phone validation error")]
    public void ThenSshouldThrowsPhoneValidationError()
    {
        var request = (AddCustomerCommand)_scenarioContext["CustomerWrongPhone"];
        AddCustomerHandler handler = new(_dbContext);

        Assert.ThrowsAsync<PhoneValidationException>(async () => await handler.Handle(request, default));
    }
}
