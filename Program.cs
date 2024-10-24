using ScoutApp.Core;
using ScoutApp.UI;

ScoutRepository repo = new(); //Starta grundfunktionalitet
ScoutUI ui = new(repo); //Start UI och ge den referens till grundsystemet

ui.Run(); //Kör igång huvudloopen

//bajsbajsbajs