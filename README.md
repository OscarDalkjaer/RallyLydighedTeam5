<h1><strong>RallyTeam5</strong><h1/>
<h2>3.Semester projekt fra Team 5</h2>

## Dette projekt er bygget som et digitalt værtkøj til hunderally-klubber. 
Projektet er bygget op omkring en bane (course), som først oprettes i systemet/databasen via POST. Ud fra det ønskede bane-niveau returneres en bane med en række af null-øvelser (exercises), som brugeren herefter kan redigere i. 
Banen, der er klar til redigering indeholder udover listen med null-øveleser også en startøvelse, en slutøvelse, en boolsk værdi for, om startøvelsen foregår højre- eller venstrehåndteret, og muligheden for at sætte et tema (enum-værdier). Endelig kan der (valgfrit) sættes et dommerId og et eventId.
Når der trykkes "execute" i PUT-funktionen valideres banen i forhold til gældende regler, og brugeren vises en liste af de for banen relevante statusser i henhold til dette. 
Banen gemmes i databasen i både valid og ikke-valid tilstand, således at en bane kan tages frem og tilrettes på et senere tidspunkt. 
Dog, i situationer, hvor en bruger forsøger at indsætte øvelser, der ikke findes i databasen, gemmes den "forkerte" øvelse som en null-øvelse, der også returneres til brugeren.
Dommeres id kan fremsøges ud fra søgning på fornavne og efternavne.
Endvidere kan brugeren fremsøge baner med bestemte temaer, ligesom brugeren kan indsætte minimum- og maximunværdier for antal øvelser på en bane og ud fra disse fremsøge baner, der lever op til kravet.
Vores projekt er bygget op omkring et API, som har flere endpoints med fuld CRUD-funktionalitet (Course, Exercise, Judge, Event).



Samt tilhørende bonusfeatures som validering, UI, authentication, og meget meget mere..

 <img src="https://i.imgur.com/IpXcJfn.png" alt="Description of Image">

## For at køre programmet kræver det følgende:
Nyeste version af VisualStudio <br>
Pull af master branch <br>
Oprettelse af EntityFramework database (add-migration & update-database)

## Anvendelse af programmet (opret bane med ønskede øvelser gennem Swagger)
1. Opret baneskabelon med en liste af null-øvelser.
2. Tilføj præ-registrerede øvelser til skabelonen.
3. Aflæs statusbeskeder omkring krav til banens øvelser.
4. Tilføj dommer og/eller event
5. Afgør, om banen startes i højre eller venstre-håndteret position.
6. Registrer den endelige bane i databasen.
   


## Eksamen stuff
Sikkerhedens 3 søjler <br> trusselsmodelering <br> CIA <br> risikoanalyse <br> evaluering af risiko <br> STRIDE <br> Tampering som sikkerhedstest
