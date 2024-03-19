using Mc2.CrudTest.AcceptanceTests.Drivers;
using Mc2.CrudTest.Core.Application.PersonHandlers.Command;
using Mc2.CrudTest.Core.Domain.Entity;
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

    #region Operator creates a customer

    [Scope(Scenario = "Operator creates a customer")]
    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), phone number is (.*), email is (.*) and bank account number is (.*)")]
    public void WhenFirstNameLastnameDateOfBirthIsPhoneNumberIsEmailAndBankAccountNumberIs
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);

        _scenarioContext["Customer"] = request;
    }

    [Scope(Scenario = "Operator creates a customer")]
    [Then(@"customer should be created")]
    public async Task ThenCustomerShouldBeCreatd()
    {
        var request = (AddCustomerCommand)_scenarioContext["Customer"];

        AddCustomerHandler handler = new(_dbContext);
        var response = await handler.Handle(request, default);

        Assert.NotZero(response);
    }

    #endregion

    #region Operator creates a customer with invalid email

    [Scope(Scenario = "Operator creates a customer with invalid email")]
    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), phone number is (.*), email is wrong like (.*) and bank account number is (.*)")]
    public void WhenFirstNameIsTestLastnameIsTestDateOfBirthIsPhoneNumberIsEmailIsWrongLikeHjftgyhjtgAndBankAccountNumberIsAcocuntNumber
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);

        _scenarioContext["CustomerWrongEmail"] = request;
    }

    [Scope(Scenario = "Operator creates a customer with invalid email")]
    [Then(@"should throws email validation error")]
    public void ThenshouldThrowsRmailValidationError()
    {
        var request = (AddCustomerCommand)_scenarioContext["CustomerWrongEmail"];
        AddCustomerHandler handler = new(_dbContext);

        Assert.ThrowsAsync<EmailValidationException>(async () => await handler.Handle(request, default));
    }

    #endregion

    #region Operator creates a customer with invalid phone number

    [Scope(Scenario = "Operator creates a customer with invalid phone number")]
    [When(@"first name is (.*), lastname is (.*), date of birth is (.*), wrong phone number is (.*), email is (.*) and bank account number is (.*)")]
    public void WhenFirstNameIsTestLastnameIsTestDateOfBirthIsWrongPhoneNumberIsQwerdasdasEmailIsAaBb_CcAndBankAccountNumberIsAcocuntNumber
        (string firstName, string lastName, DateTime birth, long phone, string email, string acocuntNumber)
    {
        AddCustomerCommand request = new(firstName, lastName, birth, phone, email, acocuntNumber);

        _scenarioContext["CustomerWrongPhone"] = request;
    }

    [Scope(Scenario = "Operator creates a customer with invalid phone number")]
    [Then(@"should throws phone validation error")]
    public void ThenSshouldThrowsPhoneValidationError()
    {
        var request = (AddCustomerCommand)_scenarioContext["CustomerWrongPhone"];
        AddCustomerHandler handler = new(_dbContext);

        Assert.ThrowsAsync<PhoneValidationException>(async () => await handler.Handle(request, default));
    }

    #endregion

    #region Get all the inserted customer in a list

    [Scope(Scenario = "Get all the inserted customer in a list")]
    [Given(@"Operator saved (.*) customers")]
    public async Task GivenOperatorSavedCustomers(int customersCount)
    {
        for (int i = 0; i < customersCount; i++)
        {
            _dbContext.Add(new Customer()
            {
                Id = i,
                FirstName = $"Name-{i}",
                LastName = $"LastName-{i}",
                Email = $"Email-{i}",
                DateOfBirth = DateTime.Now,
                PhoneNumber = 555555555,
                BankAccountNumber = $"BankAccountNumber-{i}"
            });
        }
        await _dbContext.SaveChangesAsync();
    }

    [Scope(Scenario = "Get all the inserted customer in a list")]
    [When(@"he call the list")]
    public async Task WhenHeCallTheList()
    {
        GetAllCustomersHandler handler = new(_dbContext);
        var response = await handler.Handle(new GetAllCustomersQuery());
        _scenarioContext["CustomersCount"] = response.Count();
    }

    [Scope(Scenario = "Get all the inserted customer in a list")]
    [Then(@"All (.*) customers should return")]
    public void ThenAllCustomersShouldReturn(int customersCount)
    {
        var actual = Convert.ToInt32(_scenarioContext["CustomersCount"]);

        Assert.Equals(actual, customersCount);
    }

    #endregion

    #region Get an empty list if no customer inserted

    [Scope(Scenario = "Get an empty list if no customer inserted")]
    [When(@"Operator call the empty list")]
    public void WhenOperatorCallTheEmptyList()
    {
        GetAllCustomersHandler handler = new(_dbContext);
        var response = await handler.Handle(new GetAllCustomersQuery());
        _scenarioContext["CustomersEmptyListCount"] = response.Count();
    }

    [Scope(Scenario = "Get an empty list if no customer inserted")]
    [Then(@"No customer should returns")]
    public void ThenNoCustomerShouldReturns()
    {
        var actual = Convert.ToInt32(_scenarioContext["CustomersEmptyListCount"]);

        Assert.Zero(actual);
    }

    #endregion
}
