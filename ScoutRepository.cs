namespace ScoutApp.Core;

class ScoutRepository //Medlemslista
{
    List<Scout> _scouts = new();
    List<Activity> _activities = new();

    public bool AddScout(string name, string email, DateOnly birthdate)
    {
        if (string.IsNullOrWhiteSpace(name)) return false;
        if (string.IsNullOrWhiteSpace(email)) return false;

        Scout scout = new()
        {
            Name = name,
            Email = email,
            DateOfBirth = birthdate
        };
        _scouts.Add(scout);
        return true;
    }

    public void AddActivity(Activity activity)
    {
        //TODO Kolla om scout-objektet är ok innan vi lägger in det
        _activities.Add(activity);
    }

    public void RegisterParticipantToActivity(int scoutId, int activityID)
    {
        _activities[activityID].Participants.Add(_scouts[scoutId]);
    }

    public Activity GetActivityById(int activityID)
    {
        return _activities[activityID];
    }

    public List<Activity> GetAllActivities()
    {
        return _activities;
    }

    public Scout GetScoutById(int scoutId)
    {
        return _scouts[scoutId];
    }

    public List<Scout> GetAllScouts()
    {
        return _scouts;
    }

    public List<Activity> GetUpcomingActivities()
    {
        List<Activity> upcomingActivities = new();
        foreach (var activity in _activities)
        {
            if (activity.Date.Date >= DateTime.Now)
            {
                upcomingActivities.Add(activity);
            }

        }
        return upcomingActivities;
    }

    public void SendEmailsToAllScouts()
    {
        foreach (var scout in _scouts)
        {
            Console.WriteLine("Maila till: " + scout.Email);
        }
    }
}