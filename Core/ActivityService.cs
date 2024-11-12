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

    public Result SignupScoutToActivity(int scoutId, int activityId)
    {
        var (scout, activity) = GetScoutAndActivity(scoutId, activityId);

        if (IsAlreadySignedUpToActivity(scoutId, activity!))
            return Result.Failure("Scout is already signed up for this activity");

        if (IsSignedupToActivityOnSameDate(scoutId, activity!.Date))
            return Result.Failure("Scout is already signed up for an activity at the same time");

        UpdateActivity(scout!, activity);
        return Result.Success();
    }

    private void UpdateActivity(Scout scout, Activity activity)
    {
        activity.AddParticipant(scout!);
        _activityRepository.Update(activity);
    }

    private (Scout? scout, Activity? activity) GetScoutAndActivity(int scoutId, int activityId)
    {
        Scout? scout = _scoutRepository.GetById(scoutId);
        GuardAgainst.Null(scout, $"Scout with id {scoutId} not found");

        Activity? activity = _activityRepository.GetById(activityId);
        GuardAgainst.Null(activity, $"Activity with id {activityId} not found");

        // Make sure the activity is not in the past
        GuardAgainst.NotInFuture(activity!.Date, nameof(activity.Date));

        return (scout, activity);
    }

    private bool IsAlreadySignedUpToActivity(int scoutId, Activity activity)
    {
        return activity.Participants.Any(s => s.Id == scoutId);
    }

    private bool IsSignedupToActivityOnSameDate(int scoutId, DateTime date)
    {
        var activities = _activityRepository.GetUpcomingActivities();
        return activities.Any(a => a.Date == date && a.Participants.Any(s => s.Id == scoutId));
    }

    /*
        NOTES:
        * Use GuardAgainst and exceptions for situations that represent unexpected or illegal state 
          (e.g., null records, activity in the past).
        * Use a Result type to signal expected, manageable conditions(e.g., scout already signed up, scheduling conflicts), 
          providing feedback without throwing exceptions.
    */

}