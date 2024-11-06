namespace ScoutApp.UI;

static class Input
{
    public static char GetChar(string prompt = "", bool toUpper = true)
    {
        do
        {
            Console.Write(prompt);
            char input = Console.ReadKey().KeyChar;
            Console.WriteLine();
            return toUpper ? char.ToUpper(input) : input;

        } while (true);
    }

    public static string GetString(string prompt = "")
    {
        do
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input;
            }
            Console.WriteLine("Du måste ange något!");
        } while (true);
    }

    public static DateTime GetDateTime(string prompt = "")
    {
        do
        {
            Console.Write(prompt);
            if (DateTime.TryParse(Console.ReadLine(), out DateTime date))
            {
                return date;
            }
            Console.WriteLine("Du måste ange ett datum!");
        } while (true);
    }

    public static DateOnly GetDateOnly(string prompt = "")
    {
        do
        {
            Console.Write(prompt);
            if (DateOnly.TryParse(Console.ReadLine(), out DateOnly date))
            {
                return date;
            }
            Console.WriteLine("Du måste ange ett datum!");
        } while (true);
    }

    public static string GetEmail(string prompt = "")
    {
        do
        {
            Console.Write(prompt);
            string email = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(email) && IsValidEmail(email))
            {
                return email;
            }
            Console.WriteLine("E-postadressen inte giltig!");
        } while (true);
    }

    //https://www.reddit.com/r/csharp/comments/sbvlgp/is_using_systemnetmailmailaddress_enough_to/
    private static bool IsValidEmail(string email)
    {
        return System.Text.RegularExpressions.Regex.IsMatch(email, @"^\w+([-+.']\w+)*@(\[*\w+)([-.]\w+)*\.\w+([-.]\w+\])*$");
    }
}