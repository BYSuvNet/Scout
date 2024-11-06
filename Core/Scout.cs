namespace ScoutApp.Core;

public class Scout
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public int Age
    {
        get
        {
            return (int)((DateTime.Now - DateOfBirth.ToDateTime(new TimeOnly(12, 0))).TotalDays / 365.25);
        }
    }

    public Scout(string name, string email, DateOnly dateOfBirth)
    {
        if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name cannot be null or empty");
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("Email cannot be null or empty");
        if (dateOfBirth > DateOnly.FromDateTime(DateTime.Now)) throw new ArgumentException("Date of birth cannot be in the future");

        Name = name;
        Email = email;
        DateOfBirth = dateOfBirth;
    }
}