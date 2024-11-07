namespace ScoutApp.Core;

public interface IActivityRepository
{
    public void Add(Activity s);
    public void Update(Activity s);
    public void Delete(int activityId);
    public Activity? GetById(int activityId);
    public IEnumerable<Activity> GetAll();
    public IEnumerable<Activity> GetUpcomingActivities();
}