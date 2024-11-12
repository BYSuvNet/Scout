using ScoutApp.Core;

namespace ScoutApp.Infrastructure;

public class EFActivityRepository : IActivityRepository
{
    private readonly ScoutAppDbContext _context;

    public EFActivityRepository(ScoutAppDbContext context)
    {
        _context = context;
    }

    public void Add(Activity a)
    {
        _context.Activities.Add(a);
        _context.SaveChanges();
    }

    public void Delete(int activityId)
    {
        var activity = _context.Activities.Find(activityId);
        if (activity != null)
        {
            _context.Activities.Remove(activity);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Activity> GetAll()
    {
        return _context.Activities;
    }

    public Activity? GetById(int activityId)
    {
        return _context.Activities.Find(activityId);
    }

    public void Update(Activity activity)
    {
        _context.Activities.Update(activity);
        _context.SaveChanges();
    }

    public IEnumerable<Activity> GetUpcomingActivities()
    {
        return _context.Activities.Where(a => a.Date >= DateTime.Now);
    }
}