using System.Text.Json;
using ScoutApp.Core;
using ScoutApp.UI;

ScoutRepository repo = new(); //Starta grundfunktionalitet
ScoutUI ui = new(repo); //Start UI och ge den referens till grundsystemet
Scout nyscout = new() { Name = "Alex", Email = "Gmal.com" };
string json = JsonSerializer.Serialize(nyscout);
File.WriteAllText("scouter.json", json);
ui.Run(); //Kör igång huvudloopen