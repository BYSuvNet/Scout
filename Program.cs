using Microsoft.EntityFrameworkCore;
using ScoutApp.Infrastructure;
using ScoutApp.Core;
using ScoutApp.UI;

// Configure DbContextOptions with the SQLite connection string
var options = new DbContextOptionsBuilder<ScoutAppDbContext>()
    .UseSqlite("Data Source=scoutapp.db").Options;
using var context = new ScoutAppDbContext(options);

//Test code to seed the database with some data
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
context.Activities.Add(new Activity("Plocka svamp", new DateTime(2024, 12, 24, 12, 00, 00)));
context.Activities.Add(new Activity("Bygga koja", new DateTime(2024, 12, 24, 12, 00, 00)));
context.Activities.Add(new Activity("Laga mat", new DateTime(2025, 1, 10, 12, 00, 00)));
context.Scouts.Add(new Scout("Gus", "gus@email.se", new DateOnly(2000, 1, 1)));
context.Scouts.Add(new Scout("Anna", "anna@email.se", new DateOnly(2001, 1, 1)));
context.SaveChanges();

EFScoutRepository scoutRepo = new(context);
EFActivityRepository activityRepo = new(context);
ActivityService activityService = new(activityRepo, scoutRepo);

ScoutUI ui = new(scoutRepo, activityRepo, activityService);

ui.Run();