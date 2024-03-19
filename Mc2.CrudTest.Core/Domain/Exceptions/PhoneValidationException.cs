using Mc2.CrudTest.Core.Domain.Exceptions.Base;

namespace Mc2.CrudTest.Core.Domain.Exceptions;

public class PhoneValidationException : ExceptionBase
{
    public PhoneValidationException() : base(400, "Phone number is not valid")
    {
    }
}
