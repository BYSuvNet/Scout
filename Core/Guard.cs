namespace ScoutApp.Core;

public class GuardAgainst
{
    public static void Null(object? value, string name)
    {
        if (value == null)
        {
            throw new ArgumentNullException(name);
        }
    }

    public static void NullOrEmpty(string value, string name)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{name} cannot be null or empty");
        }
    }

    public static void FutureDate(DateOnly date, string name)
    {
        if (date > DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentException($"{name} cannot be in the future");
        }
    }

    public static void PastDate(DateOnly date, string name)
    {
        if (date < DateOnly.FromDateTime(DateTime.Now))
        {
            throw new ArgumentException($"{name} cannot be in the past");
        }
    }

    public static void LessThan(int value, int min, string name)
    {
        if (value < min)
        {
            throw new ArgumentException($"{name} cannot be less than {min}");
        }
    }

    public static void GreaterThan(int value, int max, string name)
    {
        if (value > max)
        {
            throw new ArgumentException($"{name} cannot be greater than {max}");
        }
    }

    public static void Equal(int value, int otherValue, string name)
    {
        if (value != otherValue)
        {
            throw new ArgumentException($"{name} must be equal to {otherValue}");
        }
    }

    public static void NotEqual(int value, int otherValue, string name)
    {
        if (value == otherValue)
        {
            throw new ArgumentException($"{name} cannot be equal to {otherValue}");
        }
    }

    public static void InRange(int value, int min, int max, string name)
    {
        if (value < min || value > max)
        {
            throw new ArgumentException($"{name} must be between {min} and {max}");
        }
    }

    public static void NotInFuture(DateTime date, string name)
    {
        if (date < DateTime.Now)
        {
            throw new ArgumentException($"{name} must be in the future");
        }
    }

    public static void NotInPast(DateTime date, string name)
    {
        if (date > DateTime.Now)
        {
            throw new ArgumentException($"{name} must be in the past");
        }
    }

    public static void NotEmail(string email, string name)
    {
        if (!IsValidEmail(email))
        {
            throw new ArgumentException($"{name} must be a valid email address");
        }
    }

    //https://www.reddit.com/r/csharp/comments/sbvlgp/is_using_systemnetmailmailaddress_enough_to/
    private static bool IsValidEmail(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(email, @"^\w+([-+.']\w+)*@(\[*\w+)([-.]\w+)*\.\w+([-.]\w+\])*$");
    }
}