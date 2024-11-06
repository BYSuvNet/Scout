using ScoutApp.Core;
using ScoutApp.UI;

FakeScoutRepository scoutRepo = new();
FakeActivityRepository activityRepo = new();

ScoutUI ui = new(scoutRepo, activityRepo); //Start UI och ge den referens till grundsystemet

ui.Run(); //Kör igång huvudloopen