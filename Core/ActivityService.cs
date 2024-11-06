namespace ScoutApp.Core;

public class ActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IScoutRepository _scoutRepository;

    public ActivityService(IActivityRepository activityRepository, IScoutRepository scoutRepository)
    {
        _activityRepository = activityRepository;
        _scoutRepository = scoutRepository;
    }

    public void SignupScoutToActivity(int scoutId, int activityId)
    {
        var scout = _scoutRepository.GetById(scoutId);
        if (scout == null) throw new KeyNotFoundException($"Scout with id {scoutId} not found");

        var activity = _activityRepository.GetById(activityId);
        if (activity == null) throw new KeyNotFoundException($"Activity with id {activityId} not found");
        if (activity.Date.Date < DateTime.Now) throw new ArgumentException("Activity is in the past");
        if (activity.Participants.Any(s => s.Id == scoutId)) throw new ArgumentException("Scout is already signed up for this activity");

        //TODO make sure scout is not already signed up for an activity on the same time and date

        activity.AddParticipant(scout);
        _activityRepository.Update(activity);
    }
}