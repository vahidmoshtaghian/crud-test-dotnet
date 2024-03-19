using System.Net.Mail;

namespace Mc2.CrudTest.Core.Domain.Utility;

public static class EmailValidator
{
    public static bool IsValidEmail(this string email)
    {
        try
        {
            _ = new MailAddress(email);

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
