using ScoutApp.Core;

namespace ScoutApp.UI;

public class ScoutUI
{
    private IScoutRepository _scoutRepo;
    private IActivityRepository _activityRepo;
    private ActivityService _activityService;

    public ScoutUI(IScoutRepository scoutRepo,
                   IActivityRepository activityRepo,
                   ActivityService activityService)
    {
        _scoutRepo = scoutRepo;
        _activityRepo = activityRepo;
        _activityService = activityService;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
            PrintMenu();
            MakeChoice(Input.GetChar("Välj: "));
        }
    }

    private void PrintMenu()
    {
        Console.WriteLine("GÖR DITT VAL:");
        Console.WriteLine("A: Registrera scout");
        Console.WriteLine("B: Visa scoutregister");
        Console.WriteLine("C: Skapa aktivitet");
        Console.WriteLine("D: Kommande aktiviteter");
        Console.WriteLine("E: Anmäl scout till aktivitet");
        Console.WriteLine("Q: Avsluta");
    }

    private void MakeChoice(char input)
    {
        switch (input)
        {
            case 'A':
                RegisterScout();
                break;
            case 'B':
                ShowAllScouts();
                break;
            case 'C':
                CreateActivity();
                break;
            case 'D':
                ShowAllActivities();
                break;
            case 'E':
                SignupScout();
                break;
            case 'Q':
                Environment.Exit(0);
                break;
        }
        Console.ReadKey();
    }

    private void SignupScout()
    {
        int scoutId = Input.GetInt("Scoutens id: ");
        int activityId = Input.GetInt("Aktivitetens id: ");
        try
        {
            _activityService.SignupScoutToActivity(scoutId, activityId);
            Console.WriteLine("Scouten är anmäld till aktiviteten!");
        }
        catch (KeyNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowAllActivities()
    {
        Console.Clear();
        Console.WriteLine("KOMMANDE AKTIVITETER:");
        foreach (var activity in _activityRepo.GetUpcomingActivities())
        {
            Console.WriteLine($"Aktivitet: {activity.Name}");
            Console.WriteLine($"Datum: {activity.Date}");
            Console.Write("Deltagare: ");
            if (activity.Participants.Count == 0)
            {
                Console.Write("Inga deltagare registrerare ännu");
            }
            foreach (var scout in activity.Participants)
            {
                Console.Write($"{scout.Name}, ");
            }
            Console.WriteLine("\n--------------------");
        }
    }

    private void CreateActivity()
    {
        Console.Clear();
        string name = Input.GetString("Ange aktivitetens namn: ");
        DateTime date = Input.GetDateTime("Ange datum för aktiviteten: ");
        //TODO handle exceptions!
        _activityRepo.Add(new Activity(name, date));
        Console.WriteLine("Aktiviteten är skapad!");
    }

    private void RegisterScout()
    {
        Console.Clear();
        string name = Input.GetString("Namn: ");
        string email = Input.GetEmail("E-post: ");
        DateOnly dob = Input.GetDateOnly("Födelsedatum: ");
        //Todo: handle exceptions!
        _scoutRepo.Add(new Scout(name, email, dob));
        Console.WriteLine("Scouten är registrerad!");
    }

    private void ShowAllScouts()
    {
        Console.Clear();
        Console.WriteLine("ALLA SCOUTER:");
        foreach (var scout in _scoutRepo.GetAll())
        {
            Console.WriteLine($"{scout.Id} - Namn: {scout.Name}, E-post: {scout.Email}, Ålder: {scout.Age}");
        }
    }
}