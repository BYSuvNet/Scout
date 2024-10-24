namespace ScoutApp.Core;

class Scout
{
    public string Name { get; set; }
    public string Email { get; set; }
    public DateOnly DateOfBirth { get; set; }
    public string Address { get; set; }
    public int Age
    {
        get
        {
            return (int)((DateTime.Now - DateOfBirth.ToDateTime(new TimeOnly(12, 0))).TotalDays / 365.25);
        }
    }
}