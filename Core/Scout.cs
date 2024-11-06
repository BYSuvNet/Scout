namespace ScoutApp.Core;

public class Scout
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public string Email { get; private set; }
    public DateOnly DateOfBirth { get; private set; }
    public int Age
    {
        get
        {
            var today = DateTime.Today;
            var birthDate = DateOfBirth.ToDateTime(new TimeOnly(12, 0));
            int age = today.Year - birthDate.Year;

            // Justera om födelsedagen inte har inträffat ännu i år
            if (birthDate > today.AddYears(-age))
            {
                age--;
            }

            return age;
        }
    }

    public Scout(string name, string email, DateOnly dateOfBirth)
    {
        GuardAgainst.NullOrEmpty(name, nameof(name));
        GuardAgainst.NotEmail(email, nameof(email));
        GuardAgainst.FutureDate(dateOfBirth, nameof(dateOfBirth));

        Name = name;
        Email = email;
        DateOfBirth = dateOfBirth;
    }
}