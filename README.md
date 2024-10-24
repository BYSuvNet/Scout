# SCOUT

## Projektbeskrivning

Vi i Bengtsfors Scoutförening organiserar många aktiviteter för våra medlemmar, men vi har svårt att hålla koll på vem som deltar och vilka aktiviteter som har genomförts. Vi skulle vilja ha ett system där vi kan logga varje aktivitet och notera vilka som varit närvarande. Det vore också bra om vi kunde följa upp med noteringar om vad vi gjorde under aktiviteten, så vi har historik på genomförda scoutmöten. Dessutom vore det bra om vi kunde skicka automatiska påminnelser om kommande aktiviteter. Så, vi vill ett system som kan
- Lägga till nya scouter
- Lägga till nya aktiviteter
- Lägga till deltagare till aktiviteter
- Visa genomförda aktiviteter
- Skicka påminnelser om kommande aktiviteter

## Uppgift

Vi kommer behöva två klasser: en för att hålla reda på scouter och en för att hålla reda på aktiviteter. 
Vi behöver också en klass som håller reda på scouter och aktiviteter, så att det inte behöver ligga i koden för användargränssnittet.

* Skapa klassen Scout i filen "Scout.cs" och ge den följande egenskaper: Name, Email, Phone och Birthdate. Vilka typer är lämpliga för dessa egenskaper? 

* Skapa klassen "Activity" i filen "Activity.cs" och ge den följande egenskaper: Name, Date, Location, Participants och Notes. Ge den också en metod "AddParticipant(Scout s)" som lägger till en scout i listan Participants.

* Det kan vara bra att ha en klass som håller reda på alla scouter och aktiviteter, så att det inte behöver ligga i koden för användargränssnittet. Detta kan göras med en så kallad Repository-klass. Skapa klassen ScoutRepository i "ScoutRepository.cs" och ge den följande fält (listor): scouts och activities. Skapa sedan följande metoder: AddScout(Scout s), AddActivity(Activity a), GetComingActivities(), GetPastActivities() och SendReminder(Activity a).

* I filen "Program.cs" skapa och lägg till några scouter i repository-klassen med AddScout, skapa och lägg till en aktivitet, lägg till några deltagare till aktiviteten med AddParticipant(), visa genomförda aktiviteter genom att anropa GetPastActivities() och skriv ut info om aktiviteten och deltagarna med Console.WriteLine

**OBS** Att göra ett användargränssnitt där man kan göra dessa saker mer dynamiskt och inte "hårdkodat" är valfritt. Fokusera på att få klasserna att fungera först. Testa att skapa objekt direkt, och använda funktionerna i dem. Hur mycket av funktionaliteten kan du få till och testa utan att använda Console.ReadLine() och Console.WriteLine()?

