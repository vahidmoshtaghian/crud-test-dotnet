namespace Mc2.CrudTest.Core.Domain.Exceptions.Base;

public class ExceptionBase : Exception
{
    public ExceptionBase(int errorStatusCode, string message, object? data = null)
    {
        _errorStatusCode = errorStatusCode;
        _message = message;
        _data = data;
    }

    public int _errorStatusCode { get; private set; }
    public string _message { get; private set; }
    public object? _data { get; private set; }
}
