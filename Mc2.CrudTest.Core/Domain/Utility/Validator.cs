using System.Net.Mail;

namespace Mc2.CrudTest.Core.Domain.Utility;

public static class Validator
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

    public static bool IsValidPhone(this long phone)
    {
        try
        {
            var phoneUtil = PhoneNumbers.PhoneNumberUtil.GetInstance();
            var phoneNumber = phoneUtil.Parse(phone.ToString(), "US");

            return phoneUtil.IsValidNumber(phoneNumber);
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
