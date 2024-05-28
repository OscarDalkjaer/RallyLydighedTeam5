<h1><strong>RallyTeam5</strong><h1/>
<h2>3.Semester projekt fra Team 5</h2>

## Dette projekt er bygget som et digitalt værtkøj til hunderally-klubber. 
Projektet er bygget op omkring en bane (course), som først oprettes i systemet/databasen via POST. Ud fra det ønskede bane-niveau returneres en bane med en række af null-øvelser (exercises), som brugeren herefter kan redigere i. <br/>
Banen, der er klar til redigering indeholder udover listen med null-øveleser også en startøvelse, en slutøvelse, en boolsk værdi for, om startøvelsen foregår højre- eller venstrehåndteret, og muligheden for at sætte et tema (enum-værdier). Endelig kan der (valgfrit) sættes et dommerId og et eventId.<br/>
Når der trykkes "execute" i PUT-funktionen valideres banen i forhold til gældende regler, og brugeren vises en liste af de for banen relevante statusser i henhold til dette. Dette kan gøres, selvom banen ikke er færdig-bygget, hvorved brugeren altid kan holde sig ajour omkring banens aktuelle valideringer <br/>
Banen gemmes i databasen i både valid og ikke-valid tilstand, således at en bane kan tages frem og tilrettes på et senere tidspunkt. 
Dog, i situationer, hvor en bruger forsøger at indsætte øvelser, der ikke findes i databasen, gemmes den "forkerte" øvelse som en null-øvelse, der også returneres til brugeren. <br/>
Dommeres id kan fremsøges ud fra søgning på fornavne og efternavne.<br/>
Endvidere kan brugeren fremsøge baner med bestemte temaer, ligesom brugeren kan indsætte minimum- og maximunværdier for antal øvelser på en bane og ud fra disse fremsøge baner, der lever op til kravet.<br/>
Vores projekt er bygget op omkring et API, som har flere endpoints med fuld CRUD-funktionalitet (Course, Exercise, Judge, Event).<br/>
Vi har implementeret identification og authentication i både vores API og i vores UI (blazor).


 <img src="https://i.imgur.com/KPQxsYn.png" alt="Description of Image">

## For at køre programmet kræver det følgende:
Nyeste version af VisualStudio <br>
Minimum .Net 8. <br/>
Pull af master branch <br>
Oprettelse af EntityFramework database (add-migration & update-database (default project: 3. Infrastructure)). <br/>

## Anvendelse af programmet (opret bane med ønskede øvelser gennem Swagger)
1. Login med oprettet bruger, hvor cookies skal været tilvalgt. <br/>
2. Opret [POST] for [Course] med ønsket niveau og få returneret en bane med en liste af null-øvelser.
3. Tilføj i [PUT] for [Course] de ønskede, præ-registrerede øvelser til skabelonen.
4. Aflæs statusbeskeder omkring krav til banens øvelser.
5. Tilføj dommer og/eller event
6. Afgør, om banen skal startes i højre eller venstre-håndteret position.
7. Registrer med [Execute] den foreløbige eller den endelige bane i databasen.
   
## Login via Blazor
1. Start program så Swagger åbnes
2. Højreklik på RallyTeam5Client
3. Debug --> Start new instance
4. Login med bruger registeret i Swagger

