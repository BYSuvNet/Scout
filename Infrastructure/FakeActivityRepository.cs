using ScoutApp.Core;

namespace ScoutApp.Infrastructure;

public class FakeActivityRepository : IActivityRepository
{
    private readonly List<Activity> _activities = [];

    public FakeActivityRepository()
    {
        _activities.Add(new Activity("Hiking", DateTime.Now.AddDays(1)));
        _activities.Add(new Activity("Swimming", DateTime.Now.AddDays(2)));
        _activities.Add(new Activity("Camping", DateTime.Now.AddDays(3)));
    }

    public void Add(Activity a)
    {
        _activities.Add(a);
    }

    public void Delete(int activityId)
    {
        _activities.RemoveAll(a => a.Id == activityId);
    }

    public IEnumerable<Activity> GetAll()
    {
        return _activities;
    }

    public Activity? GetById(int activityId)
    {
        return _activities.FirstOrDefault(a => a.Id == activityId);
    }

    public void Update(Activity activity)
    {
        var index = _activities.FindIndex(a => a.Id == activity.Id);
        if (index != -1)
        {
            _activities[index] = activity;
        }
        else
        {
            throw new KeyNotFoundException($"Activity with id {activity.Id} not found");
        }
    }

    public IEnumerable<Activity> GetUpcomingActivities()
    {
        List<Activity> upcomingActivities = [];
        foreach (var activity in _activities)
        {
            if (activity.Date.Date >= DateTime.Now)
            {
                upcomingActivities.Add(activity);
            }

        }
        return upcomingActivities;
    }
}