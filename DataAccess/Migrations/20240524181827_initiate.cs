using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initiate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EventDataAccessModels",
                columns: table => new
                {
                    EventDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventDataAccessModels", x => x.EventDataAccessModelId);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseDataAccessModels",
                columns: table => new
                {
                    ExerciseDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HandlingPosition = table.Column<int>(type: "int", nullable: false),
                    Stationary = table.Column<bool>(type: "bit", nullable: false),
                    WithCone = table.Column<bool>(type: "bit", nullable: false),
                    TypeOfJump = table.Column<int>(type: "int", nullable: true),
                    Level = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseDataAccessModels", x => x.ExerciseDataAccessModelId);
                });

            migrationBuilder.CreateTable(
                name: "JudgeDataAccessModels",
                columns: table => new
                {
                    JudgeDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JudgeDataAccessModels", x => x.JudgeDataAccessModelId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseDataAccessModels",
                columns: table => new
                {
                    CourseDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<int>(type: "int", nullable: false),
                    JudgeDataAccessModelId = table.Column<int>(type: "int", nullable: true),
                    EventDataAccessModelId = table.Column<int>(type: "int", nullable: true),
                    ExerciseCount = table.Column<int>(type: "int", nullable: true),
                    Theme = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseDataAccessModels", x => x.CourseDataAccessModelId);
                    table.ForeignKey(
                        name: "FK_CourseDataAccessModels_EventDataAccessModels_EventDataAccessModelId",
                        column: x => x.EventDataAccessModelId,
                        principalTable: "EventDataAccessModels",
                        principalColumn: "EventDataAccessModelId");
                    table.ForeignKey(
                        name: "FK_CourseDataAccessModels_JudgeDataAccessModels_JudgeDataAccessModelId",
                        column: x => x.JudgeDataAccessModelId,
                        principalTable: "JudgeDataAccessModels",
                        principalColumn: "JudgeDataAccessModelId");
                });

            migrationBuilder.CreateTable(
                name: "CourseExerciseRelations",
                columns: table => new
                {
                    CourseExerciseRelationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseDataAccessModelId = table.Column<int>(type: "int", nullable: false),
                    ExerciseDataAccessModelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseExerciseRelations", x => x.CourseExerciseRelationId);
                    table.ForeignKey(
                        name: "FK_CourseExerciseRelations_CourseDataAccessModels_CourseDataAccessModelId",
                        column: x => x.CourseDataAccessModelId,
                        principalTable: "CourseDataAccessModels",
                        principalColumn: "CourseDataAccessModelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseExerciseRelations_ExerciseDataAccessModels_ExerciseDataAccessModelId",
                        column: x => x.ExerciseDataAccessModelId,
                        principalTable: "ExerciseDataAccessModels",
                        principalColumn: "ExerciseDataAccessModelId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1ca1abc7-24b8-4d66-a7b1-b21adc12101c", 0, "0f969750-5c2b-498e-888e-c62230c56bed", "oscar@test.com", true, false, null, "OSCAR@TEST.COM", "OSCAR", "AQAAAAIAAYagAAAAEPKENK8QofwcXqT2di7eQdi8gunOIxxpGaJQZze58k/tFNCi3+ZwDMZzY7CK5KxNNQ==", null, false, "72a75642-8305-4601-a5fa-37a7b01d2032", false, "oscar" },
                    { "9d8b0a60-e3b1-4088-9ff5-6b0a68d80cac", 0, "2ddd8289-1042-42cb-af4c-f6eedd0a3a62", "ulla@test.com", true, false, null, "ULLA@TEST.COM", "ULLA@TEST.COM", "AQAAAAIAAYagAAAAEMCW7sBibSJ8XEwot/qLn2TUffwAdlIB8SdrV7CkB4Yvl3K6yZPO/I/4sr7YxZnEPA==", null, false, "de0d1f56-673e-40df-9f98-54c6a30d8b59", false, "ulla@test.com" },
                    { "f47c5bf1-740c-4fb9-94b7-941e90ad7d23", 0, "28fc0dd9-b328-46a8-ac1c-9b52c7c395a6", "lyanne@test.com", true, false, null, "LYANNE@TEST.COM", "LYANNE", "AQAAAAIAAYagAAAAEBpBMPsYLsCzhndbuOS8PjBzuBTMQyICG75B7NMwMgMX/jWDVYlTEqFlFEAjomhiwg==", null, false, "f0e06d97-481a-42d6-ae03-28cd20993b21", false, "lyanne" }
                });

            migrationBuilder.InsertData(
                table: "EventDataAccessModels",
                columns: new[] { "EventDataAccessModelId", "Date", "Location", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "5000 Odense", "Odense RallyEvent" },
                    { 2, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "7190 Billund", "Billund Rally-Cup" },
                    { 3, new DateTime(2025, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "4000 Roskilde", "Roskilde Rally" }
                });

            migrationBuilder.InsertData(
                table: "ExerciseDataAccessModels",
                columns: new[] { "ExerciseDataAccessModelId", "Description", "HandlingPosition", "Level", "Name", "Number", "Stationary", "TypeOfJump", "WithCone" },
                values: new object[,]
                {
                    { -1, "", 2, 0, "", 0, false, null, false },
                    { 1, " Her starter banen! Hunden behøver ikke at sidde inden start, og skal være i venstrepositionen - kan være i højreposition i Ekpert- og Championklassen. Tidtagningen starter på dommerens kommando f.eks. ”Fremad”.", 2, 4, "Start", 1, false, null, false },
                    { 2, "Banen er slut. Tidtagningen stoppes, når teamet passerer skiltet. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 4, "Mål", 2, false, null, false },
                    { 3, "Teamet drejer 90° skarpt til højre. Drejningen udføres med en lille bue og foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Højre sving", 3, false, null, false },
                    { 4, "Teamet drejer 90° skarpt til venstre. Drejningen udføres med en lille bue og foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Venstre sving", 4, false, null, false },
                    { 5, "Teamet drejer 270° højre rundt til førerens højre side. Drejningen udføres med en lille bue foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "270º Højre rundt", 5, false, null, false },
                    { 6, "Teamet drejer 270° venstre rundt til førerens venstre side. Drejningen udføres med en lille bue foran skiltet. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "270º Venstre rundt", 6, false, null, false },
                    { 7, "Teamet drejer diagonalt mod højre. Føreren skal holde en konstant hastighed under drejet. Hunden skal sætte farten op under drejningen, således at teamet følges ad. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Diagonalt højre", 7, false, null, false },
                    { 8, "Teamet drejer diagonalt mod venstre. Føreren skal holde en konstant hastighed under drejet. Hunden skal sætte farten ned under drejningen, således at teamet følges ad. Hunden må ikke sætte sig.", 2, 0, "Diagonalt venstre", 8, false, null, false },
                    { 9, "Teamet drejer 225° højre rundt til førerens højre side. Drejningen udføres med en lille bue. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "225° Højre rundt", 9, false, null, false },
                    { 10, "Teamet drejer 225° venstre rundt til førerens venstre side. Drejningen udføres med en lille bue. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "225° Venstre rundt", 10, false, null, false },
                    { 11, "Teamet drejer 180° rundt til førerens højre side. Drejningen udføres med en lille bue. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Højre omkring", 11, false, null, false },
                    { 12, "Teamet drejer 180° venstre rundt til førerens venstre side. Drejningen udføres med en lille bue. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Venstre omkring", 12, false, null, false },
                    { 13, "Med hunden i venstrepositionen går føreren venstre omkring foran skiltet, mens hunden går højre om rundt om føreren til venstrepositionen. Øvelsen gennemføres uden stop. Højrehandling gennemføres ved, at føreren går højre omkring foran skiltet, mens hunden går venstre om rundt om føreren til højrepositionen uden stop. Hunden fortsætter i højreposition.", 2, 0, "Tyskervending", 13, false, null, false },
                    { 14, "Teamet drejer 360° til førerens højre side. Cirklen skal være så lille som muligt og foretages, før skiltet passeres. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "360º til højre", 14, false, null, false },
                    { 15, "Teamet drejer 360° til førerens venstre side. Cirklen skal være så lille som mulig og foretages, før skiltet passeres. Hunden må ikke sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "360º til venstre", 15, false, null, false },
                    { 16, "Teamet stopper, og hunden sætter sig i venstreposition. Derefter drejer teamet samtidig, på stedet, 90° til højre. Hunden følger med og holder sin venstreposition uden at sætte sig, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 0, "STOP - drej 90º højre om", 16, true, null, false },
                    { 17, "Teamet stopper, og hunden sætter sig i venstreposition. Derefter drejer teamet samtidig, på stedet, 90° til venstre. Hunden følger med og holder sin venstreposition uden at sætte sig igen, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 0, "STOP - drej 90º venstre om", 17, true, null, false },
                    { 18, "Foran skiltet ændrer teamet retning 180° rundt mod højre, således at hunden bytter side fra venstre til højre. Dette skal ske samtidigt, i en flydende bevægelse og uden stop. Højrehandling gennemføres også med 180° rundt mod højre, således, at hunden bytter side fra højre til venstre. Hunden drejer derfor væk fra føreren.", 3, 0, "Synkron højre om", 18, false, null, false },
                    { 19, "Foran skiltet ændrer teamet retning 180° rundt mod venstre, således at hunden bytter side fra venstre til højre. Dette skal ske samtidigt, i en flydende bevægelse og uden stop. Højrehandling gennemføres også med 180° rundt mod venstre, således, at hunden bytter side fra højre til venstre. Hunden drejer derfor væk fra føreren.", 3, 0, "Synkron venstre om", 19, false, null, false },
                    { 20, "Foran skiltet ændrer teamet retning ved at dreje ind mod hinanden og fortsætte i modsat retning således, at hunden bytter side fra venstre til højre. Dette skal ske samtidigt i en flydende bevægelse og uden stop. Højrehandling gennemføres på samme måde ved at dreje ind mod hinanden, og fortsætte i modsatte retning således, at hunden bytter side fra højre til venstre.", 3, 0, "Tulipan", 20, false, null, false },
                    { 21, "Teamet skal synligt sænke farten. Hunden holder hele tiden venstreposition. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Langsom gang", 21, false, null, false },
                    { 22, "Teamet skal synligt øge farten. Hunden holder hele tiden venstreposition. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Løb", 22, false, null, false },
                    { 23, "Teamet skal synligt ændre farten og fortsætte fremad i almindelig gang. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Almindelig gang", 23, false, null, false },
                    { 24, "Efter skiltet og i bevægelse tager føreren ét skridt diagonalt til højre med højre fod, hvorefter teamet fortsætter af den nye linje - parallelforskudt fra den oprindelige i en flydende bevægelse og uden stop. Hunden holder hele tiden venstreposition. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 0, "Sidestep til højre", 24, false, null, false },
                    { 25, "Skiltet holdes på venstre side. Efter skiltet og i bevægelse tager føreren ét skridt diagonalt til venstre med venstre fod, og teamet fortsætter af den nye linje - parallelforskudt fra den oprindelige en flydende bevægelse og uden stop. Hunden holder hele tiden venstreposition. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 0, "Sidestep til venstre", 25, false, null, false },
                    { 26, "Teamet skal gå højre om keglerne - først rundt om alle 3, derefter om 2 og til sidst om 1. Hunden følger i venstrepositionen og er på den udvendige side af svingene. Højrehandling gennemføres også højre om keglerne. Hunden holder hele tiden højreposition og er på den indvendige side af svingene.", 2, 0, "Højre spiral", 26, false, null, true },
                    { 27, "Teamet skal gå venstre om keglerne først rundt om alle 3, derefter om 2 og til sidst om 1. Hunden følger i venstrepositionen og er på den indvendige side af svingene. Højrehandling gennemføres også venstre om keglerne. Hunden holder hele tiden højreposition og er på den udvendige side af svingene.", 2, 0, "Venstre spiral", 27, false, null, true },
                    { 28, "Indgangen er med den første kegle på teamets venstre side. Teamet skal færdiggøre hele øvelsen ved at passere mellem keglerne og retur med hunden i venstrepositionen. Højrehandling gennemføres med samme indgang. Hunden holder hele tiden højreposition.", 2, 0, "Dobbelt slalom", 28, false, null, true },
                    { 29, "Indgangen er med den første kegle på teamets venstre side. Teamet skal færdiggøre hele øvelsen ved at passere mellem keglerne med hunden i venstrepositionen. Højrehandling gennemføres med samme indgang. Hunden holder hele tiden højreposition.", 2, 0, "Enkelt slalom", 29, false, null, true },
                    { 30, "Øvelsen kræver 2 kegler. Teamet skal gå et helt 8-tal, hvorved de passerer centrum 3 gange. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "8 tal", 30, false, null, true },
                    { 31, "Føreren stopper og dirigerer hunden ind foran sig, hvor hunden sætter sig foran (med front mod føreren). I øvelsens anden del dirigeres hunden til venstrepositionen ved at gå højre rundt og bagom føreren. Uden at hunden sætter sig, fortsætter teamet til næste øvelse. Højrehandling gennemføres ved, at hunden dirigeres ind foran, hvor den sætter sig foran føreren. Øvelsen afsluttes ved at hunden går venstre rundt og bagom føreren til højrepositionen.", 2, 0, "Sit foran - hund bagom - fremad", 31, true, null, false },
                    { 32, "Føreren stopper og dirigerer hunden ind foran sig, hvor hunden sætter sig foran (med front mod føreren). I øvelsens anden del dirigeres hunden til venstrepositionen ved at gå den korte vej til venstreposition med front mod føreren. Uden at hunden sætter sig, fortsætter teamet til næste øvelse. Højrehandling gennemføres ved, at hunden dirigeres ind foran, hvor den sætter sig foran føreren. Øvelsen afsluttes ved, at hunden går den korte vej direkte til højrepositionen.", 2, 0, "Sit foran - hund kort vej rundt - fremad", 32, true, null, false },
                    { 33, "Føreren stopper og dirigerer hunden ind foran sig, hvor hunden sætter sig foran (med front mod føreren). I øvelsens anden del dirigeres hunden til venstrepositionen ved at gå højre rundt og bagom føreren. Først når hunden sidder i venstreposition, går teamet atter fremad. Højrehandling gennemføres ved, at hunden dirigeres ind foran, hvor den sætter sig foran føreren. Øvelsen afsluttes ved, at hunden går venstre rundt og bagom føreren og sætter sig i højrepositionen.", 2, 0, "Sit foran - hund bagom rundt - STOP", 33, true, null, false },
                    { 34, "Føreren stopper og dirigerer hunden ind foran sig, hvor hunden sætter sig foran (med front mod føreren). I øvelsens anden del dirigeres hunden til venstrepositionen ved at gå direkte til venstre side med front mod føreren. Først når hunden sidder i venstrepositionen, går teamet atter fremad. Højrehandling gennemføres ved, at hunden dirigeres ind foran, hvor den sætter sig foran føreren. Øvelsen afsluttes ved, at hunden går den korte vej direkte til højrepositionen og sætter sig, hvorefter teamet går frem.", 2, 0, "Sit foran - hund kort vej rundt - STOP", 34, true, null, false },
                    { 35, "Teamet stopper, og hunden sætter sig i venstrepositionen. Teamet tager 1 skridt fremad med hunden i venstrepositionen og stopper, derefter 2 skridt fremad, stop og 3 skridt fremad, stop. Hunden holder venstrepositionen under bevægelsen, og hunden sætter sig i venstrepositionen, hver gang føreren stopper. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højrepositionen.", 2, 0, "STOP - 1, 2, 3 skridt fremad - STOP", 35, false, null, false },
                    { 36, "Føreren stopper, og dirigerer hunden ind foran sig, hvor hunden sætter sig foran (med front mod føreren). Når hunden sidder, går føreren 1 skridt bagud, stopper. Hunden følger med og sætter sig foran føreren, når denne stopper. Føreren tager derefter 2 skridt, stop og 3 skridt stop. Hunden følger med hver gang, at føreren bevæger sig og sætter sig hver gang, at føreren stopper. Herefter dirigeres hunden selvvalgt til venstrepositionen, før føreren går fremad. Hunden må ikke sætte sig, før teamet fortsætter. Højrehandling gennemføres på samme måde. Hunden fortsætter i højrepositionen.", 2, 0, "Sit foran - 1, 2, 3 skridt bagud", 36, false, null, false },
                    { 37, "Teamet stopper, og hunden sætter sig i venstrepositionen - straks efter fortsætter teamet til den næste øvelse med hunden i venstrepositionen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højrepositionen.", 2, 0, "STOP", 37, true, null, false },
                    { 38, "Teamet stopper, og hunden sætter sig i venstreposition, straks efter dirigeres hunden med fremad direkte i løb i venstrepositionen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "STOP - løb fremad fra sit", 38, true, null, false },
                    { 39, "Teamet stopper, og hunden sætter sig i venstreposition. Hunden bliver siddende, mens føreren går ind foran venstre rundt om hunden. Højrehandling gennemføres ved, at føreren går ind foran højre rundt om hunden. Hunden holder derefter højrepositionen.", 2, 0, "STOP - gå rundt", 39, true, null, false },
                    { 40, "Teamet stopper, og hunden sætter sig i venstrepositionen. Herefter dirigeres hunden i dæk efterfulgt af en kommando til at fortsætte fremad fra dæk positionen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "STOP - dæk", 40, true, null, false },
                    { 41, "Teamet stopper, og hunden dirigeres direkte i dæk uden at sætte sig først. Når hunden er kommet helt ned i dæk, går føreren atter fremad, samtidig med at hunden dirigeres fremad i venstreposition direkte fra dæk. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Dæk", 41, false, null, true },
                    { 42, "Teamet stopper, og hunden sætter sig i venstrepositionen. Herfra dirigeres hunden i dæk, og hunden bliver liggende, mens føreren går ind foran venstre rundt om hunden til venstrepositionen. Hunden går fremad direkte fra dæk. Højrehandling gennemføres ved, at føreren går højre rundt om hunden til højrepositionen. Hunden går fremad direkte fra dæk i højreposition.", 2, 0, "STOP - dæk - gå rundt", 42, true, null, false },
                    { 43, "Teamet stopper, og hunden dirigeres til at blive stående. Når hunden står helt stille, går føreren atter fremad samtidig med, at hunden dirigeres fremad i venstreposition direkte fra stående position. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "Stå", 43, true, null, false },
                    { 44, "Før skiltet passeres, dirigeres hunden til at snurre en gang rundt, væk fra føreren, og komme tilbage i venstrepositionen, mens føreren fortsætter sin gang fremad. Højrehandling gennomføres ved, at før skiltet passeres, dirigeres hunden til at snurre en gang rundt, væk fra føreren, og kommer tilbage i højreposition, mens føreren fortsætter sin gang fremad. Hunden holder hele tiden højreposition.", 2, 0, "Hund snur rundt", 44, false, null, false },
                    { 45, "Føreren stopper. Hunden gennemfører, uden at stoppe, en cirkel, på 360° ind foran højre rundt om føreren. Føreren bliver stående med samlede ben. Cirklen afsluttes med, at hunden kommer direkte ind i venstrepositionen uden at sætte sig, hvorefter teamet fortsætter fremad. Føreren må ikke flytte fødderne, mens hunden går rundt om føreren. Højrehandling gennemføres på samme måde, dog går hunden ind foran venstre rundt om føreren tilbage til højrepositionen. Hunden fortsætter i højreposition.", 2, 0, "Fører stop, hund rundt om fører", 45, true, null, false },
                    { 46, "Teamet stopper, og hunden sætter sig i venstreposition. Hunden gennemfører en cirkel på 360° ind foran højre rundt om føreren, mens føreren bliver stående med samlede ben. Cirklen afsluttes med, at hunden sætter sig i venstrepositionen. Føreren må ikke flytte fødderne under øvelsen. Højrehandling gennemføres med cirkel på 360° ind foran venstre rundt om føreren, afsluttende med, at hunden sætter sig i højrepositionen. Hunden fortsætter i højreposition.", 2, 0, "STOP - hund i gang om fører - STOP", 46, true, null, false },
                    { 47, "Fra almindelig gang skifter føreren retning ved at bakke mindst 1 skridtlængde uden at stoppe op, herefter fortsætter teamet fremad. Hunden bakker med føreren og holder sin position under hele øvelsen uden at sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 0, "1 skridt baglæns - hunden bakker", 47, false, null, false },
                    { 48, "Indgangen til slalom er med den første kegle på teamets venstre side. Teamet går én cirkel om den afvigende kegle. Teamet skal færdiggøre hele øvelsen ved at passere den sidste kegle. Højrehandling gennemføres på samme måde med første kegle på venstre side, og teamet går én cirkel rundt om afvigende kegle. Hunden holder hele tiden højreposition.", 2, 1, "Slalom med rundtur", 100, false, null, true },
                    { 49, "Teamet skal gå et helt 8-tal, hvorved de passerer centrum 3 gange. Hunden holder venstrepositionen uden, at fristelserne berøres. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 1, "Fristende 8-tal", 101, false, null, true },
                    { 50, "Teamet skal gå et kløverblad, hvorved de passerer midten 4 gange. Hunden holder venstrepositionen under hele øvelsen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 1, "Kløverbladet", 102, false, null, true },
                    { 51, "Efter skiltet og direkte fra venstrepositionen dirigeres hunden til at springe fremad over springet uden at rive ned, mens føreren fortsætter fremad uden opstandsning, afventning eller stop. Teamet fortsætter til næste øvelse med hunden i venstreposition. Højrehandling gennemføres på samme måde. Hunden vender tilbage til højreposition.", 2, 1, "Send over spring", 103, false, 0, false },
                    { 52, "Teamet stopper, og hunden sætter sig i venstreposition. Hunden bliver siddende, mens føreren går forbi springet. Næste skilt skal være indkald. Idet fører kalder, springer hunden over springet uden at rive ned og søger direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden starter og slutter i højreposition.", 2, 1, "STOP - bliv – forbi 1 spring", 104, true, 0, false },
                    { 53, "I øvelsesområdet kalder føreren på hunden, som skal komme direkte til den gående venstreposition. Føreren må ikke ændre tempo under øvelsen, men fortsætter til den næste øvelse med hunden i venstreposition. Højrehandling gennemføres på samme måde. Hunden dirigeres til højreposition.", 2, 1, "Indkald under gang", 105, false, null, false },
                    { 54, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer teamet, på stedet 90° til højre. Hunden følger med og holder sin venstreposition, sætter sig igen hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - 90º højre om – STOP", 106, true, null, false },
                    { 55, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer teamet, på stedet 90° til venstre. Hunden følger med og holder sin venstreposition, sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - 90º venstre om - STOP", 107, true, null, false },
                    { 56, "Teamet stopper, og hunden sætter sig i venstrepositionen. Hunden dirigeres til at blive siddende, mens føreren drejer til højre og derefter tager et skridt og stopper. Hunden, der dirigeres, skal gå til venstrepositionen og sætte sig, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - højre om - 1 skridt - kald på plads – STOP", 108, true, null, false },
                    { 57, "Teamet stopper, og hunden sætter sig i venstrepositionen. Hunden dirigeres til at blive siddende, mens føreren drejer til venstre og derefter tager et skridt og stopper. Hunden, der dirigeres, skal gå til venstrepositionen og sætte sig, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til venstre. Hunden fortsætter i højreposition.", 2, 1, "STOP - venstre om - 1 skridt - kald på plads - STOP", 109, true, null, false },
                    { 58, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer teamet 180° højre rundt på stedet og bevæger sig direkte fremad. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - højre omkring - fremad", 110, true, null, false },
                    { 59, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer teamet 180° venstre rundt på stedet og bevæger sig direkte fremad. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - venstre omkring - fremad", 111, true, null, false },
                    { 60, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer føreren på stedet 180° til højre. Hunden følger med og holder sin venstreposition. Hunden sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - højre omkring - STOP", 112, true, null, false },
                    { 61, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer føreren på stedet 180° til venstre. Hunden følger med og holder sin venstreposition. Hunden sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - venstre omkring - STOP", 113, true, null, false },
                    { 62, "Teamet stopper efter skiltet, og hunden sætter sig i venstrepositionen. Føreren træder 1 sideskridt lige til højre (uden at ændre retning). Hunden følger med og holder sin venstreposition, sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til højre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - 1 sideskridt til højre - STOP", 114, true, null, false },
                    { 63, "Skiltet holdes på venstre side. Teamet stopper efter skiltet, og hunden sætter sig i venstrepositionen. Føreren træder 1 sideskridt lige til venstre (uden at ændre retning). Hunden følger med og holder sin venstreposition, sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 1, "STOP - 1 sideskridt til venstre - STOP", 115, true, null, false },
                    { 64, "Teamet stopper efter skiltet, og hunden sætter sig i venstrepositionen. Føreren træder 2 sideskridt lige til højre (uden at ændre retning). Hunden følger med og holder sin venstreposition, sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Kan ikke udføres i højrehandling.", 1, 1, "STOP - 2 sideskridt til højre - STOP", 116, true, null, false },
                    { 65, "Teamet stopper efter skiltet, og hunden sætter sig i højrepositionen. Føreren træder 2 sideskridt lige til venstre (uden at ændre retning). Hunden følger med og holder sin højreposition, sætter sig igen, hvorefter teamet fortsætter til næste øvelse. Kan kun udføres i højrehandling.", 0, 1, "STOP - 2 sidekridt til venstre - STOP", 117, true, null, false },
                    { 66, "Øvelsen udføres efter skiltet. Føreren træder 2 sideskridt lige til højre (uden at ændre retning). Hunden følger med og holder sin venstreposition, hvorefter teamet fortsætter til næste øvelse. Denne øvelse er under gang og uden opstandsning. Kan ikke udføres i højrehandling.", 1, 1, "2 sideskridt til højre", 118, false, null, false },
                    { 67, "Øvelsen udføres efter skiltet. Føreren træder 2 sideskridt lige til venstre (uden at ændre retning). Hunden følger med og holder sin højreposition, hvorefter teamet fortsætter til næste øvelse. Denne øvelse er under gang og uden opstandsning. Kan kun udføres i højrehandling.", 0, 1, "2 sideskridt til venstre", 119, false, null, false },
                    { 68, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter dirigerer føreren hunden ind foran sig, hvor hunden sætter sig (med front mod føreren). I øvelsens anden del dirigeres hunden til venstrepositionen ved at gå bag om føreren. Først når hunden sidder i venstreposition, går teamet atter fremad. Føreren må ikke flytte sig for at hjælpe hunden under øvelsen. Højrehandling gennemføres ved, at hunden dirigeres ind foran, hvor den sætter sig foran føreren, og afsluttes ved at hunden går bag om føreren og sætter sig i højrepositionen.", 2, 1, "STOP - sit foran - bagom - STOP", 120, true, null, false },
                    { 69, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter dirigerer føreren hunden ind foran sig, hvor hunden sætter sig (med front mod føreren). I øvelsens anden del dirigeres hunden til venstrepositionen ved at gå den korte vej rundt til venstreposition med front mod føreren. Først når hunden sidder i venstreposition, går teamet atter fremad. Føreren må ikke flytte sig for at hjælpe hunden under øvelsen. Højrehandling gennemføres ved, at hunden dirigeres ind foran, hvor den sætter sig foran føreren, og afsluttes ved at hunden går den korte vej direkte til højrepositionen og sætter sig.", 2, 1, "STOP - sit foran - kort vej rundt - STOP", 121, true, null, false },
                    { 70, "Under gang dirigeres hunden ind foran, hvor den skal stå med front mod føreren, idet føreren stopper. Hunden dirigeres bagom rundt om føreren, og kommer direkte ind i venstrepositionen uden, at hunden sætter sig, hvorefter teamet fortsætter fremad. Føreren må ikke flytte fødderne, mens hunden går rundt om fører. Højrehandling gennemføres ved at hunden dirigeres ind foran i stå, og afsluttes ved at hunden går venstre rundt og bag om føreren til højrepositionen.", 2, 1, "Stå foran - bagom rundt", 122, true, null, false },
                    { 71, "Under gang dirigeres hunden ind foran, hvor den skal stå med front mod føreren, idet føreren stopper. Hunden dirigeres den korte vej rundt direkte ind i venstrepositionen uden, at hunden sætter sig, hvorefter teamet fortsætter fremad. Føreren må ikke flytte fødderne, mens hunden går rundt om fører. Højrehandling gennemføres ved, at hunden dirigeres ind foran i stå og afsluttes ved, at hunden dirigeres den korte vej højre rundt direkte til højrepositionen.", 2, 1, "Stå foran - kort vej rundt", 123, true, null, false },
                    { 72, "Teamet stopper, og hunden sætter sig i venstrepositionen. Når hunden sidder, dirigeres hunden direkte i dæk, og derefter direkte i sit. Føreren må ikke flytte sig under øvelsen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 1, "STOP - dæk - sit", 124, true, null, false },
                    { 73, "Teamet stopper, og hunden sætter sig i venstrepositionen. Hunden skal derefter stå og blive stående, mens føreren går til venstre og rundt den. Teamet fortsætter med hunden direkte fra stå. Højrehandling gennemføres ved, at føreren går højre ind foran og rundt om hunden, som står i højreposition uden at røre sig. Teamet fortsætter med hunden direkte fra stå.", 2, 1, "STOP - stå - gå rundt", 125, true, null, false },
                    { 74, "Teamet stopper, og hunden sætter sig i venstrepositionen. Teamet går 1 skridt, stopper, hunden står stille. Teamet går 1 skridt, stopper, hunden sætter sig. Teamet går 1 skridt, stopper, hunden lægger sig, dernæst fortsætter teamet fremad med hunden i venstrepositionen direkte fra dæk. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 1, "STOP - 1 skridt stå, 1 skridt sit, 1 skridt dæk", 126, true, null, false },
                    { 75, "Teamet stopper, og hunden sætter sig i venstrepositionen. Hunden dirigeres til at bytte side fra venstre til højre, foran føreren og med front mod denne, direkte til sit i højrepositionen. Højrehandling gennemføres ved, at hunden bytter side fra højre til venstre, foran øreren og med front mod denne, direkte til sit i venstrepositionen.", 3, 1, "STOP - hund foran rundt - STOP", 127, true, null, false },
                    { 76, "Teamet stopper, og hunden sætter sig i venstrepositionen. Hunden dirigeres til at bytte side fra venstre til højre, bagved føreren og med front mod denne, direkte til sit i højreposition. Højrehandling gennemføres ved, at hunden bytter side fra højre til venstre, bagved fører og med front mod denne, direkte til sit i venstrepositionen.", 3, 1, "STOP - hund bagved rundt - STOP", 128, true, null, false },
                    { 77, "Foran skiltet ændrer teamet retning ved at dreje væk fra hinanden og fortsætte i modsat retning, således at hunden bytter side fra venstre til højre. Dette skal ske samtidigt, i en flydende bevægelse og uden stop. Højrehandling gennemføres på samme måde ved, at fører og hund drejer væk fra hinanden, hvorved hunden bytter side fra højre til venstre.", 3, 1, "Springvand", 129, false, null, false },
                    { 78, "Før skiltet passeres og med hunden i venstrepositionen, går føreren venstre omkring, mens hunden går højre om rundt om føreren til venstrepositionen. Føreren tager herefter 1 - 3 skridt med hunden i venstreposition, før der foretages endnu en vending, og teamet fortsætter i den oprindelige retning. Vendingerne skal ske samtidigt og uden stop. Højrehandling gennemføres ved, at føreren går højre omkring, mens hunden går venstre om. Hunden fortsætter i højreposition.", 2, 1, "To tyskervendinger", 130, false, null, false },
                    { 79, "Før skiltet passeres og med hunden i venstrepositionen dirigeres hunden til at gå en gang højre rundt om føreren, og komme tilbage i venstrepositionen, mens føreren fortsætter sin gang fremad uden stop. Højrehandling gennemføres ved, at hunden går en gang venstre rundt om føreren tilbage til Højreposition, mens føreren fortsætter sin gang fremad uden stop. Hunden fortsætter i højreposition.", 2, 1, "Cirkel i gang omkring fører", 131, false, null, false },
                    { 80, "Før skiltet passeres dirigeres hunden til at snurre en gang rundt, ind imod føreren, og komme tilbage i venstrepositionen, mens føreren fortsætter sin gang fremad. Højrehandling gennemføres ved, at før skiltet passeres dirigeres hunden til at snurre en gang rundt, ind imod føreren, og komme tilbage i højrepositionen, mens føreren fortsætter sin gang fremad. Hunden holder hele tiden højreposition.", 2, 1, "Hund snur ind mod fører", 132, false, null, false },
                    { 81, "Med hunden i venstreposition skifter føreren retning ved at bakke mindst 2 skridtlængder uden at stoppe op, herefter fortsætter teamet fremad. Hunden bakker med føreren og holder sin position under hele øvelsen uden at sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 1, "2 skridt baglæns - hunden bakker", 133, false, null, false },
                    { 82, "Teamet stopper før springet, og hunden sætter sig i venstrepositionen. Føreren bliver stående, mens hunden springer over springet uden at rive ned, stoppes på modsat side i en selvvalgt position, på signal springer hunden tilbage over springet uden at rive ned og sætter sig direkte i venstrepositionen. Teamet fortsætter herfra i banens retning. Højrehandling gennemføres på samme måde. Hunden holder højreposition.", 2, 2, "STOP - spring - ro - spring - STOP", 200, true, 1, false },
                    { 83, "Teamet stopper, og hunden dirigeres direkte i dæk. Hunden bliver liggende, mens føreren går forbi springet. Næste skilt skal være indkald. Idet fører dirigerer, springer hunden over springet uden at rive ned og søger direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden holder højreposition.", 2, 2, "Dæk - bliv - alm. gang - forbi 1 spring", 201, true, 0, false },
                    { 84, "Teamet stopper, og hunden dirigeres direkte i dæk. Hunden bliver liggende, mens føreren løber forbi springet. Næste skilt skal være indkald. Idet fører dirigerer, springer hunden over springet uden at rive ned og søger direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden holder højreposition.", 2, 2, "Dæk - bliv - løb - forbi 1 spring", 202, true, 0, false },
                    { 85, "Teamet stopper, og hunden dirigeres direkte i stå. Hunden bliver stående, mens føreren går forbi springet. Næste skilt skal være indkald. Idet fører dirigerer, springer hunden over springet uden at rive ned og søger direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden holder højreposition.", 2, 2, "Stå - bliv - alm. gang - forbi 1 spring", 203, true, 0, false },
                    { 86, "Teamet stopper, og hunden dirigeres direkte i stå. Hunden bliver stående, mens føreren løber forbi springet. Næste skilt skal være indkald. Idet fører dirigerer, springer hunden over springet uden at rive ned og søger direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden holder højreposition.", 2, 2, "Stå - bliv - løb - forbi 1 spring", 204, true, 0, false },
                    { 87, "Under gang drejer teamet i retning mod feltet, hvor teamet stopper, og hunden sætter sig ned i venstrepositionen. Når hunden sidder i venstrepositionen, dirigeres den til at løbe frem til feltet og lægge sig med størstedelen af kroppen inden for dette. Herefter fortsætter føreren fremad. Hunden bliver liggende, indtil indkald, der skal være næste øvelse. Højrehandling gennemføres på samme måde. Hunden holder højreposition.", 2, 2, "STOP - gå hen og læg dig", 205, true, null, false },
                    { 88, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter dirigeres hunden op at stå. Herefter dirigeres hunden i dæk, og til sidst fortsætter teamet fremad med hunden i venstrepositionen direkte fra dæk. Føreren må ikke flytte sig under øvelsen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "STOP - stå - dæk", 206, true, null, false },
                    { 89, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter dirigeres hunden op at stå. Herefter dirigeres hunden i sit, hvorefter teamet fortsætter fremad. Føreren må ikke flytte sig under øvelsen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "STOP - stå - sit", 207, true, null, false },
                    { 90, "Teamet stopper, og hunden sætter sig i venstrepositionen og bliver siddende, mens føreren går fra den og kommer tilbage igen. En Hent-øvelse skal efterfølges af en Bring-øvelse. Hunden skal holde venstrepositionen mellem de to øvelser. Højrehandling gennemføres på samme. Hunden holder hele tiden højreposition.", 2, 2, "STOP - hent/bring", 208, true, null, false },
                    { 91, "Teamet stopper, og hunden dirigeres til at blive stående i venstreposition og blive stående helt stille, mens føreren går fra den og kommer tilbage igen. En Hent-øvelse skal efterfølges af en Bring-øvelse. Hunden skal holde venstrepositionen mellem de to øvelser. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Stå - hent/bring", 209, true, null, false },
                    { 92, "Teamet stopper, og hunden dirigeres direkte i dæk uden at sætte sig først og bliver liggende, mens føreren går fra den og kommer tilbage igen. En Hent-øvelse skal efterfølges af en Bring-øvelse. Hunden skal holde venstrepositionen mellem de to øvelser. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Dæk - hent/bring", 210, true, null, false },
                    { 93, "Teamet stopper, og hunden sætter sig i venstrepositionen og bliver siddende, mens føreren går fra den. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "STOP - gå fra", 211, true, null, false },
                    { 94, "Teamet stopper, og hunden dirigeres til at blive stående, idet føreren stopper. Hunden bliver stående, mens føreren går fra den. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Stå - gå fra", 212, true, null, false },
                    { 95, "Teamet stopper, og hunden dirigeres direkte i dæk uden at sætte sig først og blive liggende, mens føreren går fra den. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Dæk - gå fra", 213, true, null, false },
                    { 96, "Fra gang og uden at tøve får føreren hunden til at blive stående og går venstre rundt ind foran og omkring hunden. Hunden fortsætter direkte fra stå. Højrehandling gennemføres ved, at føreren går højre rundt ind foran og omkring hunden. Hunden fortsætter i højreposition.", 2, 2, "Stå under gang - gå rundt", 214, true, null, false },
                    { 97, "Med hunden i venstreposition skifter føreren retning ved at bakke mindst 3 skridtlængder uden at stoppe op, herefter fortsætter teamet fremad. Hunden bakker med føreren og holder sin position under hele øvelsen uden at sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "3 skridt baglæns - hunden bakker", 215, false, null, false },
                    { 98, "Hunden dirigeres ind foran, hvor den skal stå med front mod føreren. Hunden dirigeres derefter til at bakke, mens føreren bliver stående. Når den har bakket mindst 1 hundelængde, går føreren fremad, mens hunden bliver stående, overhaler hunden og får den ind i venstreposition. Det er valgfrit om det sker til højre eller venstre, men skal ske i en flydende bevægelse. Højrehandling gennemføres på samme måde. Hunden samles op til højreposition.", 2, 2, "Stå foran - hund bak 1 længde - fremad", 216, true, null, false },
                    { 99, "Før skiltet passeres og med hunden i venstrepositionen laver teamet en højre 180° vending. Føreren tager herefter 2-3 skridt med hunden i position, før der foretages endnu en 180° vending, denne gang til venstre. Hunden skal være i venstreposition under hele øvelsen, og denne foretages uden stop. Teamet fortsætter i den oprindelige retning. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Dobbelt 180° vending - højre rundt - venstre rundt", 217, false, null, false },
                    { 100, "Før skiltet passeres og med hunden i venstrepositionen laver teamet en venstre 180° vending. Føreren tager herefter 2-3 skridt med hunden i position, før der foretages endnu en 180° vending, denne gang til højre. Hunden skal være i venstreposition under hele øvelsen og denne foretages uden stop. Teamet fortsætter i den oprindelige retning. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Dobbelt 180° vending - venstre rundt - højre rundt", 218, false, null, false },
                    { 101, "Teamet stopper efter skiltet, og hunden sætter sig i venstrepositionen. Føreren træder 3 sideskridt lige til højre (uden at ændre retning). Hunden følger med i venstreposition. Idet føreren stopper, sætter hunden sig igen i venstreposition, hvorefter teamet fortsætter til næste øvelse. Kan ikke udføres i højrehandling.", 1, 2, "STOP - 3 sideskridt højre - STOP", 219, true, null, false },
                    { 102, "Teamet stopper efter skiltet, og hunden sætter sig i højrepositionen. Føreren træder 3 sideskridt lige til venstre (uden at ændre retning). Hunden følger med i højreposition. Idet føreren stopper, sætter hunden sig igen i højreposition, hvorefter teamet fortsætter til næste øvelse. Kan ikke udføres i venstrehandling.", 0, 2, "STOP - 3 sideskridt venstre - STOP", 220, true, null, false },
                    { 103, "Føreren træder 3 sideskridt lige til højre (uden at ændre retning). Hunden følger med i venstreposition, hvorefter teamet fortsætter til næste øvelse. Kan ikke udføres i højrehandling.", 1, 2, "3 sideskridt til højre", 221, false, null, false },
                    { 104, "Føreren træder 3 sideskridt lige til venstre (uden at ændre retning). Hunden følger med i højreposition, hvorefter teamet fortsætter til næste øvelse. Kan ikke udføres i venstrehandling.", 0, 2, "3 sideskridt til venstre", 222, false, null, false },
                    { 105, "Lige før skiltet skal hunden under gang gå en venstre cirkel ind foran og rundt om føreren, mens føreren laver en 90° drejning til højre. Øvelsen kan ikke laves i venstrehandling.", 0, 2, "Cirkel i gang om fører - 90° højre", 223, false, null, false },
                    { 106, "Lige før skiltet skal hunden under gang gå i en cirkel om føreren, mens føreren laver en 90° drejning til venstre. Øvelsen kan ikke laves i højrehandling.", 1, 2, "Cirkel i gang om fører - 90° venstre", 224, false, null, false },
                    { 107, "Før skiltet passeres og med hunden i venstrepositionen dirigeres hunden til at bytte side bagved føreren til højreposition, mens føreren holder banelinjen. Dette skal ske i en flydende bevægelse uden stop. Højrehandling gennemføres også bagved føreren, og hunden ender i venstreposition.", 3, 2, "Sideskift bagved", 225, false, null, false },
                    { 108, "Teamet skal gå et helt 8-tal, hvorved de passerer centrum 3 gange. Anden gang centrum passeres, laves et sideskift bagved, så hunden ender i højreposition. Hunden regulerer sit tempo efter føreren. Højrehandling gennemføres på samme måde. Hunden starter i højreposition, laver sideskift bagved og ender i venstreposition.", 3, 2, "8 tal med sideskift bagved", 226, false, null, true },
                    { 109, "Teamet skal gå en kløverbladsform, hvorved de passerer midten 4 gange. Hunden holder venstrepositionen, uden at fristelserne berøres. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 2, "Kløverblad med fristelser", 227, false, null, true },
                    { 110, "I øvelsesområdet kalder føreren på hunden, som skal komme direkte til den gående position på modsat side i forhold til forrige øvelse. Føreren må ikke ændre tempo under øvelsen, men fortsætter til den næste øvelse med hunden i position. Højrehandling gennemføres på samme måde.", 3, 2, "Indkald til modsat side under gang", 228, false, null, false },
                    { 111, "Føreren afslutter øvelserne 200, 208, 209, 210, 216, 309 og 311 med hunden i modsat position af, hvordan øvelsen startede. Føreren starter øvelse 1 med hunden i højreposition. Dette er et tillægsskilt og tæller ikke med i det samlede antal øvelser på banen.", 3, 2, "Med sideskift", 229, false, null, false },
                    { 112, "Før skiltet passeres og med hunden i venstrepositionen dirigeres hunden til at bytte side foran føreren til venstreposition, mens føreren holder banelinjen. Skiftet skal ske i en flydende bevægelse uden stop. Højrehandling gennemføres også foran føreren. Hunden ender i venstreposition.", 3, 3, "Sideskift foran", 300, false, null, false },
                    { 113, "Under gang dirigeres hunden, med uret rundt om keglen, mens føreren drejer 90° venstre, og hunden ender i højreposition. Øvelsen kan ikke udføres i højrehandling.", 1, 3, "90° venstre - sideskift med kegle", 301, false, null, true },
                    { 114, "Under gang dirigeres hunden, mod uret rundt om keglen, mens føreren drejer 90° højre om, og hunden ender i venstreposition. Øvelsen kan ikke udføres i venstrehandling.", 0, 3, "90° højre - sideskift med kegle", 302, false, null, true },
                    { 115, "Efter skiltet og direkte fra venstrepositionen dirigeres hunden gennem tunnelen, mens føreren fortsætter fremad uden opstandsning, afventning eller stop. Efter hundens passage fortsætter teamet til den næste øvelse med hunden i venstreposition. Højrehandling gennemføres på samme måde. Hunden returnerer til højreposition.", 2, 3, "Tunnel", 303, false, null, false },
                    { 116, "Teamet stopper, og hunden sætter sig i venstrepositionen. Føreren tager 1 skridt baglæns, mens hunden holder venstrepositionen ved at rejse sig, bakke og sætte sig igen. Føreren tager 2 skridt baglæns, mens hunden holder venstrepositionen ved at rejse sig, bakke og sætte sig igen, før teamet igen fortsætter fremad. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "STOP - 1, 2 skridt baglæns - hund bakker - STOP", 304, true, null, false },
                    { 117, "Teamet stopper, og hunden sætter sig i venstrepositionen. Teamet bakker 1 skridt, stopper, hunden står stille. Teamet bakker 1 skridt, stopper, hunden sætter sig i venstreposition. Teamet bakker 1 skridt, stopper, hunden lægger sig og til sidst fortsætter teamet fremad med hunden i venstrepositionen direkte fra dæk. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "STOP - 1 skridt baglæns stå - 1 skridt baglæns sit - 1 skridt baglæns dæk", 305, true, null, false },
                    { 118, "Teamet stopper, og hunden sætter sig i venstrepositionen. Teamet bakker 1 skridt, stopper, hunden står stille. Teamet bakker 2 skridt, stopper, hunden sætter sig i venstreposition. Teamet bakker 3 skridt, stopper, hunden lægger sig og til sidst fortsætter teamet fremad med hunden i venstrepositionen direkte fra dæk. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "STOP - 1 skridt baglæns stå - 2 skridt baglæns sit - 3 skridt baglæns dæk", 306, true, null, false },
                    { 119, "Med hunden i venstreposition skifter føreren retning ved at bakke mindst 2 skridtlængder uden at stoppe op, herefter drejer teamet 90° højre og bakker mindst 2 skridtlængder uden at stoppe. Teamet fortsætter herefter fremad. Hunden bakker med føreren og holder sin position under hele øvelsen uden at sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "2 skridt baglæns - 90° højre - 2 skridt baglæns", 307, false, null, false },
                    { 120, "Med hunden i venstreposition skifter føreren retning ved at bakke mindst 2 skridtlængder uden at stoppe op, herefter drejer teamet 90° venstre og bakker mindst 2 skridtlængder uden at stoppe. Teamet fortsætter herefter fremad. Hunden bakker med føreren og holder sin position under hele øvelsen uden at sætte sig. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "2 skridt baglæns - 90° venstre - 2 skridt baglæns", 308, false, null, false },
                    { 121, "Under gang dirigerer føreren hunden ind foran sig, hvor den skal stå med front mod føreren. Hunden dirigeres derefter til at bakke, mens føreren bliver stående. Når den har bakket mindst 3 hundelængder, går føreren videre fremad, overhaler hunden og får den i venstreposition. Det er valgfrit om det sker til højre eller venstre, men skal ske i en flydende bevægelse. Højrehandling gennemføres på samme måde. Hunden samles op til højreposition.", 2, 3, "Stå foran - hund bak 3 længder - fremad", 309, true, null, false },
                    { 122, "Efter skiltet og direkte fra venstrepositionen dirigeres hunden til at springe fremad over springene uden at rive ned, mens føreren fortsætter fremad uden opstandsning, afventning eller stop. Teamet fortsætter til den næste øvelse med hunden i venstreposition. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "Send over 2 spring", 310, false, 1, false },
                    { 123, "Teamet stopper, før springene, og hunden sætter sig i venstrepositionen. Føreren bliver stående, mens hunden springer over springene uden at rive ned, stoppes på modsat side i en selvvalgt position. På signal springer hunden tilbage over begge spring uden at rive ned og sætter sig direkte i venstrepositionen. Teamet fortsætter herfra i banens retning. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "STOP - Dobbeltspring - ro - spring - STOP", 311, false, 1, false },
                    { 124, "Teamet stopper og hunden sætter sig i venstrepositionen. Hunden bliver siddende, mens føreren løber forbi springene. Næste øvelse skal være et indkald. Hunden dirigeres over begge spring uden at rive ned og direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden fortsætter i højreposition.", 2, 3, "STOP - bliv - løb frem - forbi 2 spring", 312, true, 1, false },
                    { 125, "Teamet stopper, og hunden dirigeres direkte i stå, idet føreren stopper. Hunden bliver stående, mens føreren går forbi 2 spring. Næste øvelse skal være et indkald. Hunden dirigeres over begge spring uden at rive ned, og direkte ind i venstrepositionen. Højrehandling gennemføres på samme måde. Hunden holder hele tiden højreposition.", 2, 3, "Stå - bliv - alm. gang - forbi 2 spring", 313, true, 1, false },
                    { 126, "Teamet stopper og hunden dirigeres direkte i stå, idet føreren stopper. Hunden bliver stående, mens føreren løber forbi 2 spring. Næste øvelse skal være et indkald. Hunden dirigeres over begge spring uden at rive ned og direkte ind i venstreposition. Højrehandling gennemføres på samme måde. Hunden fortsætter i højreposition.", 2, 3, "Stå - bliv - løb - forbi 2 spring", 314, true, 1, false },
                    { 127, "Under gang drejer teamet i retning mod keglen, før hunden sætter sig i venstrepositionen. Når hunden sidder, dirigeres den til at løbe frem til en afvigende kegle og stå (indenfor 1 meter fra keglen). Herefter fortsætter føreren fremad. Næste øvelse skal være et indkald. Højrehandling gennemføres på samme måde. Hunden sendes fra højreposition.", 2, 3, "STOP - send frem - stå", 315, true, null, true },
                    { 128, "Teamet skal gå 2 gange et 8-tal, hvorved de passerer midten 5 gange. Ved 3. passage af midten udføres et sideskift bagved. Hunden holder venstreposition, indtil sideskift, hvorefter der fortsættes i højreposition. Højrehandling gennemføres på samme måde. Hunden holder højreposition, indtil sideskift, hvorefter der fortsættes i venstreposition.", 3, 3, "Dobbelt 8 tal med sideskift bagved", 316, false, null, true },
                    { 129, "Fra venstrepositionen og uden at tøve får føreren hunden til at sætte sig og går venstre ind foran og omkring hunden. Højrehandling gennemføres ved, at føreren går højre rundt ind foran og omkring hunden. Hunden fortsætter i højrepositionen.", 2, 3, "Sit under gang - Gå rundt", 317, true, null, false },
                    { 130, "Fra venstrepositionen og uden at tøve får føreren hunden til at dække og går venstre ind foran og omkring hunden. Hunden fortsætter direkte fra dæk. Højrehandling gennemføres ved, at føreren går højre ind foran og omkring hunden. Hunden fortsætter i højrepositionen direkte fra dæk.", 2, 3, "Dæk under gang - Gå rundt", 318, true, null, false },
                    { 131, "Teamet stopper, og hunden sætter sig i venstrepositionen. Derefter drejer teamet på stedet, 90° til venstre. Hunden følger med og holder sin venstreposition, bliver stående i venstrepositionen. Teamet drejer 90° til venstre, hvor hunden følger med og sætter sig i venstrepositionen. Teamet drejer yderligere 90° til venstre, hvor hunden følger med og holder sin venstrepositionen, og hunden dækker, hvorefter teamet fortsætter til næste øvelse. Højrehandling gennemføres også til venstre. Hunden holder hele tiden højreposition.", 2, 3, "STOP - 90° venstre om stå - 90° venstre om sit - 90° venstre om dæk", 319, true, null, false }
                });

            migrationBuilder.InsertData(
                table: "JudgeDataAccessModels",
                columns: new[] { "JudgeDataAccessModelId", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Peter", "Madsen" },
                    { 2, "Minna", "Mogensen" },
                    { 3, "Thilde", "Thrane" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDataAccessModels_EventDataAccessModelId",
                table: "CourseDataAccessModels",
                column: "EventDataAccessModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseDataAccessModels_JudgeDataAccessModelId",
                table: "CourseDataAccessModels",
                column: "JudgeDataAccessModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExerciseRelations_CourseDataAccessModelId",
                table: "CourseExerciseRelations",
                column: "CourseDataAccessModelId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseExerciseRelations_ExerciseDataAccessModelId",
                table: "CourseExerciseRelations",
                column: "ExerciseDataAccessModelId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "CourseExerciseRelations");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CourseDataAccessModels");

            migrationBuilder.DropTable(
                name: "ExerciseDataAccessModels");

            migrationBuilder.DropTable(
                name: "EventDataAccessModels");

            migrationBuilder.DropTable(
                name: "JudgeDataAccessModels");
        }
    }
}
