using Mc2.CrudTest.Core.Domain.Exceptions.Base;

namespace Mc2.CrudTest.Core.Domain.Exceptions;

public class NotFoundException : ExceptionBase
{
    public NotFoundException() : base(404, "Not found")
    {
    }
}
