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

    public void SignupScoutToEctivity(int scoutId, int activityId)
    {
        var scout = _scoutRepository.GetById(scoutId);
        var activity = _activityRepository.GetById(activityId);

        if (scout == null) throw new KeyNotFoundException($"Scout with id {scoutId} not found");
        if (activity == null) throw new KeyNotFoundException($"Activity with id {activityId} not found");

        activity.AddParticipant(scout);
        _activityRepository.Update(activity);
    }
}