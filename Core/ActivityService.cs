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
        Scout? scout = _scoutRepository.GetById(scoutId);
        GuardAgainst.Null(scout, $"Scout with id {scoutId} not found");

        var activity = _activityRepository.GetById(activityId);
        GuardAgainst.Null(activity, $"Activity with id {activityId} not found");

        //Make sure the activity is not in the past
        GuardAgainst.NotInFuture(activity!.Date, nameof(activity.Date));

        //A Scout can only sign up for an activity once
        if (activity.Participants.Any(s => s.Id == scoutId)) throw new ArgumentException("Scout is already signed up for this activity");

        //TODO make sure scout is not already signed up for an activity on the same time and date

        activity.AddParticipant(scout!);
        _activityRepository.Update(activity);
    }
}