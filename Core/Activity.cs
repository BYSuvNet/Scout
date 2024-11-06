namespace ScoutApp.Core;

public class Activity
{
    public int Id { get; set; }
    public string Name { get; private set; }
    public DateTime Date { get; private set; }
    public List<Scout> Participants { get; private set; } = [];  //Se till så att en tom lista finns

    public Activity(string name, DateTime date)
    {
        GuardAgainst.NullOrEmpty(name, nameof(name));
        GuardAgainst.NotInFuture(date, nameof(date));

        Name = name;
        Date = date;
    }

    public void AddParticipant(Scout scout)
    {
        Console.WriteLine($"Adding {scout.Name} to {Name}");
        Participants.Add(scout);
    }
}