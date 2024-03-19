using Mc2.CrudTest.AcceptanceTests.Drivers;
using Mc2.CrudTest.Core.Application.PersonHandlers.Command;
using Mc2.CrudTest.Core.Application.PersonHandlers.Query;
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
        for (int i = 1; i < customersCount + 1; i++)
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
        var response = await handler.Handle(new GetAllCustomersQuery(), default);
        _scenarioContext["CustomersCount"] = response.Count();
    }

    [Scope(Scenario = "Get all the inserted customer in a list")]
    [Then(@"All (.*) customers should return")]
    public void ThenAllCustomersShouldReturn(int customersCount)
    {
        var actual = Convert.ToInt32(_scenarioContext["CustomersCount"]);

        Assert.AreEqual(actual, customersCount);
    }

    #endregion

    #region Get an empty list if no customer inserted

    [Scope(Scenario = "Get an empty list if no customer inserted")]
    [When(@"Operator call the empty list")]
    public async Task WhenOperatorCallTheEmptyList()
    {
        GetAllCustomersHandler handler = new(_dbContext);
        var response = await handler.Handle(new GetAllCustomersQuery(), default);
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

    #region Operator updates the customer

    [Scope(Tag = "update_customer")]
    [Given(@"Operator saved a customer before")]
    public async Task GivenOperatorSavedACustomerBeforeUpdating()
    {
        Customer entity = new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = 55555555,
            Email = "Email",
            BankAccountNumber = "BankAccountNumber",
            DateOfBirth = DateTime.Now
        };
        _dbContext.Add(entity);

        await _dbContext.SaveChangesAsync();
        _scenarioContext["UpdateCustomerId"] = entity.Id;
    }

    [Scope(Scenario = "Operator updates the customer")]
    [When(@"he update the customer")]
    public async Task WhenHeUpdateTheCustomer()
    {
        UpdateCustomerCommand command = new()
        {
            FirstName = "FirstName is changed",
            LastName = "LastNameis changed",
            PhoneNumber = 2312312312,
            Email = "Emailis changed",
            BankAccountNumber = "BankAccountNumberis changed",
            DateOfBirth = DateTime.Now
        };
        command.SetId(Convert.ToInt32(_scenarioContext["UpdateCustomerId"]));
        UpdateCustomerHandler handler = new(_dbContext);
        await handler.Handle(command, default);

        _scenarioContext["UpdatedCustomer"] = command;
    }

    [Scope(Scenario = "Operator updates the customer")]
    [Then(@"the customer should change")]
    public async void ThenTheCustomerShouldChange()
    {
        var actual = (UpdateCustomerCommand)_scenarioContext["UpdatedCustomer"];
        var expected = await _dbContext.Set<Customer>().FindAsync(actual.Id);

        Assert.IsNotNull(expected);
        Assert.AreEqual(expected.FirstName, actual.FirstName);
        Assert.AreEqual(expected.LastName, actual.LastName);
        Assert.AreEqual(expected.PhoneNumber, actual.PhoneNumber);
        Assert.AreEqual(expected.BankAccountNumber, actual.BankAccountNumber);
        Assert.AreEqual(expected.DateOfBirth, actual.DateOfBirth);
    }

    #endregion

    #region Operator updates the wrong customer

    [Scope(Scenario = "Operator updates the wrong customer")]
    [When(@"he updates an invalid customer")]
    public void WhenHeUpdateAnInvalidCustomer()
    {
        UpdateCustomerCommand command = new();
        command.SetId(-1);

        _scenarioContext["WrongUpdateCommand"] = command;
    }

    [Scope(Scenario = "Operator updates the wrong customer")]
    [Then(@"should throws not found error")]
    public void ThenShouldThrowsNotFoundErrorUpdate()
    {
        UpdateCustomerHandler handler = new(_dbContext);

        Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle((UpdateCustomerCommand)_scenarioContext["WrongUpdateCommand"], default));
    }

    #endregion

    #region Operator deletes the customer

    [Scope(Tag = "delete_customer")]
    [Given(@"Operator saved a customer before")]
    public async Task GivenOperatorSavedACustomerBeforeDeleting()
    {
        Customer entity = new()
        {
            FirstName = "FirstName",
            LastName = "LastName",
            PhoneNumber = 777777,
            Email = "Email",
            BankAccountNumber = "BankAccountNumber",
            DateOfBirth = DateTime.Now
        };
        _dbContext.Add(entity);

        await _dbContext.SaveChangesAsync();
        _scenarioContext["DeleteCustomerId"] = entity.Id;
    }

    [Scope(Scenario = "Operator deletes the customer")]
    [When(@"he delete the customer")]
    public async Task WhenHeDeleteTheCustomer()
    {
        DeleteCustomerCommand command = new()
        {
            Id = Convert.ToInt32(_scenarioContext["DeleteCustomerId"])
        };
        DeleteCustomerHandler handler = new(_dbContext);

        await handler.Handle(command, default);
    }

    [Scope(Scenario = "Operator deletes the customer")]
    [Then(@"the customer should remove")]
    public async void ThenTheCustomerShouldRemove()
    {
        var expected = await _dbContext.Set<Customer>()
            .FindAsync(Convert.ToInt32(_scenarioContext["DeleteCustomerId"]));

        Assert.Null(expected);
    }

    #endregion

    #region Operator deletes the wrong customer

    [Scope(Scenario = "Operator deletes the wrong customer")]
    [When(@"he deletes an invalid customer")]
    public void WhenHeDeletesAnInvalidCustomer()
    {
        DeleteCustomerCommand command = new()
        {
            Id = -1
        };
        _scenarioContext["WrongDeleteCustomerCommand"] = command;
    }

    [Scope(Scenario = "Operator deletes the wrong customer")]
    [Then(@"should throws not found error")]
    public void ThenShouldThrowsNotFoundErrorDelete()
    {
        DeleteCustomerHandler handler = new(_dbContext);

        Assert.ThrowsAsync<NotFoundException>(async () => await handler.Handle((DeleteCustomerCommand)_scenarioContext["WrongDeleteCustomerCommand"], default));
    }

    #endregion

    #region Operator wants to see a customer

    [Scope(Tag = "get_customer_by_id")]
    [Given(@"Operator saved a customer before")]
    public async Task GivenOperatorSavedACustomerBeforeGettingById()
    {
        Customer entity = new()
        {
            FirstName = "FirstName by id",
            LastName = "LastName by id",
            PhoneNumber = 666666666,
            Email = "Email by id",
            BankAccountNumber = "BankAccountNumber by id",
            DateOfBirth = DateTime.Now
        };
        _dbContext.Add(entity);

        await _dbContext.SaveChangesAsync();
        _scenarioContext["GetCustomerId"] = entity.Id;
    }

    [Scope(Scenario = "Operator wants to see a customer")]
    [When(@"he requests the customer by id")]
    public async Task WhenHeRequestsTheCustomerById()
    {
        GetCustomerByIdHandler handler = new(_dbContext);
        GetCustomerByIdQuery query = new()
        {
            Id = Convert.ToInt32(_scenarioContext["GetCustomerId"])
        };
        var response = await handler.Handle(query, default);

        _scenarioContext["GetCustomerById"] = response;
    }

    [Scope(Scenario = "Operator wants to see a customer")]
    [Then(@"the customer should returns")]
    public void ThenTheCustomerShouldReturns()
    {
        var entity = (GetCustomerByIdQueryResponse)_scenarioContext["GetCustomerById"];

        Assert.NotNull(entity);
    }

    #endregion

    #region MyRegion

    [Scope(Scenario = "Operator requests a wrong customer")]
    [When(@"he requests a wrong customer")]
    public void WhenHeRequestsAWrongCustomer()
    {
        throw new PendingStepException();
    }

    [Scope(Scenario = "Operator requests a wrong customer")]
    [Then(@"should throws customer id not found")]
    public void ThenShouldThrowsCustomerIdNotFound()
    {
        throw new PendingStepException();
    }

    #endregion
}
