namespace ScoutApp.Core;

class Activity
{
    //Göra dem till private??
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public List<Scout> Participants { get; set; } = new();  //Se till så att en tom lista finns

    public string Info
    {
        get
        {
            string scouts = "DELTAGARE:\n";
            foreach (var scout in Participants)
            {
                scouts += scout.Name + "\n";
            }

            return "Aktivitet:" + Name + "\nDatum: " + Date.ToShortDateString() + "\n" + scouts;
        }
    }

    public Activity(string name, DateTime date)
    {
        Name = name;
        Date = date;
    }
}