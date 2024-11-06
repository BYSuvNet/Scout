using ScoutApp.Core;
using ScoutApp.Infrastructure;
using ScoutApp.UI;

FakeScoutRepository scoutRepo = new();
FakeActivityRepository activityRepo = new();
ActivityService activityService = new(activityRepo, scoutRepo);

ScoutUI ui = new(scoutRepo, activityRepo, activityService);

ui.Run();