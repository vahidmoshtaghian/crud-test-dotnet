using Mc2.CrudTest.Core.Domain.Exceptions.Base;

namespace Mc2.CrudTest.Core.Domain.Exceptions;

public class EmailValidationException : ExceptionBase
{
    public EmailValidationException() : base(400, "Email is not valid")
    {
    }
}
