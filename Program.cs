using ScoutApp.Core;
using ScoutApp.UI;

ScoutRepository repo = new(); //Starta grundfunktionalitet
ScoutUI ui = new(repo); //Start UI och ge den referens till grundsystemet

Console.BackgroundColor = ConsoleColor.DarkBlue; // Varsågoda, Martin

ui.Run(); //Kör igång huvudloopen