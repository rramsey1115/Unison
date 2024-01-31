using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Unison.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    UserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true),
                    SecurityStamp = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "boolean", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    ClaimType = table.Column<string>(type: "text", nullable: true),
                    ClaimValue = table.Column<string>(type: "text", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    ProviderKey = table.Column<string>(type: "text", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "text", nullable: true),
                    UserId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    RoleId = table.Column<string>(type: "text", nullable: false)
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    LoginProvider = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
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
                name: "UserProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Address = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Roles = table.Column<List<string>>(type: "text[]", nullable: true),
                    IdentityUserId = table.Column<string>(type: "text", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProfiles_AspNetUsers_IdentityUserId",
                        column: x => x.IdentityUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserProfiles_UserProfiles_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: false),
                    CreatorId = table.Column<int>(type: "integer", nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    Body = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_UserProfiles_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusicianId = table.Column<int>(type: "integer", nullable: false),
                    DateCompleted = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_UserProfiles_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MusicianId = table.Column<int>(type: "integer", nullable: false),
                    TeacherId = table.Column<int>(type: "integer", nullable: false),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assignments_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_UserProfiles_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_UserProfiles_TeacherId",
                        column: x => x.TeacherId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavoriteSessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    MusicianId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavoriteSessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavoriteSessions_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavoriteSessions_UserProfiles_MusicianId",
                        column: x => x.MusicianId,
                        principalTable: "UserProfiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SessionActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<int>(type: "integer", nullable: false),
                    ActivityId = table.Column<int>(type: "integer", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionActivities_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SessionActivities_Sessions_SessionId",
                        column: x => x.SessionId,
                        principalTable: "Sessions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "fed07ba0-3f25-4c14-941e-f76e42525eb9", "Musician", "musician" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "bcee65e2-261e-41e0-8e95-8940290ea146", "Teacher", "teacher" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", 0, "c2bc9470-6c3a-4a3f-ae84-574bec96c922", "teststudent2@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEANFSPEqaoYyLuhgcecRjQhZc9lYjuQaGoV3Ukbqln/5ts6H3nm7TrfUVknWZy5Saw==", null, false, "ed2ede96-5844-41bd-8870-fd6ba31c9279", false, "TestStudent2" },
                    { "4342d71c-3d92-49ea-9f84-8f3412b65679", 0, "ce10e9b4-8cc1-4145-88e4-f43882a59f9d", "teststudent1@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENhEGaCcmLgic0mO7rPWce9kY8opMEZUWrR7HRrXkAbGpYku9lhTbURbh21sv88ZNA==", null, false, "76277378-0466-461a-8b11-bf217e919b57", false, "TestStudent1" },
                    { "7c8b955a-c256-4505-bf0f-468489633f5f", 0, "cff51aba-329f-47be-be1f-adf753803fed", "teststudent4@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPM5QOA7QNJHi5Qrg4vzFz7UBuFQwwssS/F7UbSC67nl2tmDxEmvVe3ZzNdYbWfyyA==", null, false, "44929277-930f-4e82-9999-24e11ba18540", false, "TestStudent4" },
                    { "7e60e6dc-579e-43af-9b2a-b4fe5bb42407", 0, "262fa64a-d99c-4fb5-aabe-a9343cff99ad", "teststudent7@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEDmE284TzMnw4Met2B5uSP2M9Dd0jX1pW+jevqFEiVKa6V3Y+tsr9/cmyXN3IX8TKw==", null, false, "45315c94-0534-4eb4-9a37-5f84b65d33a9", false, "TestStudent7" },
                    { "91a84af5-48ef-4bce-aa4e-7271d83d4d8c", 0, "ed486e5a-6874-4eae-a9c7-bd71c7ee6b5a", "teststudent10@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEJ2D6ClyqaelGWp/K2jVqm1dX5IyPZSqbDi8VsbRx0kTWInUAsilsGU3CLPqk1SpDQ==", null, false, "fb0f4714-7022-4c6b-b8bb-76643c5d1dd9", false, "TestStudent10" },
                    { "a03371b3-edeb-4184-8917-14fa66adb89f", 0, "0eebebdb-1cb0-44b5-8e06-a5a24d7aa6b4", "teststudent8@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEHXBz33K+FVZyaLlFVfdRlbAiudQE+u5wF1C8yBcddKyD9jBjqMn3fn8vU31+OxCxA==", null, false, "7adcfe73-4baf-4901-8a89-b89d10c58885", false, "TestStudent8" },
                    { "a541cf62-3506-462f-8901-eee6d9d5145f", 0, "8618dbea-c1a2-4cba-a34a-bc626ed2a007", "teststudent9@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEB+s2kinTjFRJnL9waIBVyx9D2D5tT7L/3GRbMdTLhcP6uO4jKwAEp4g8xg6ceY9yg==", null, false, "2c21ca31-4ada-4996-8286-c9aa99c691ac", false, "TestStudent9" },
                    { "ad6fe687-1ebf-4ef4-9e10-4e23b483140c", 0, "de1f77e4-40c4-4a62-a023-a739ef9ebebb", "teststudent5@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENa854WRHMgTLtL8pA2UuagU0KQWkS3ImwTwo9zSVVcWkk4lKBFIhylgFHY837AwTA==", null, false, "a3f2ca94-fc68-44a1-9017-72544a3c7abb", false, "TestStudent5" },
                    { "b1df4873-5564-479b-94c0-172f799e820b", 0, "c550a576-ca78-426c-9b43-547f955bb721", "teststudent6@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEOA1HIV8zR8cZMzNWbIQ1rL8Wf4Ewm2fiV7xCEDP8QMw2sSeSeNwYN3zARrnOVYzcQ==", null, false, "289449a0-6bd0-45e5-a17d-c3041d53125d", false, "TestStudent6" },
                    { "b6d8aa7f-ae65-4feb-95ab-377d810bc270", 0, "75813512-223f-41f1-bbd8-5b039cbfba02", "teststudent3@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECZooajmvM9/6Qr773hQTNuI+vM/rUvmRnePPCOvwXgyUpGuNEa++U21x4JxrfLrCg==", null, false, "fb8f79f6-9506-412c-b47b-d2fcbb9adf52", false, "TestStudent3" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "971a8da2-1196-434e-8fe9-9b55706ed229", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEO+/fQO0jpdjuw1b7JzoPOv4hr233ByLz7Xulm4/4t93XK5IHmcJbhV5gDl2U4ayxA==", null, false, "9aa4eaff-c665-4eda-a622-1047af999353", false, "Administrator" },
                    { "e9fd3bbc-17a0-4ba7-857e-e6d695698548", 0, "3b5d9b90-b71f-434b-bf91-b18fc77afab6", "teacher1@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBOADXS3nnMEHKMVcYaDs8Ck6IzJO/aK/wfYO6gwNXjem+4TrzFLTDhnxUvoP4Bg9g==", null, false, "a72e0796-a80e-495a-af24-c935577f4572", false, "Teacher2" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Details", "Name" },
                values: new object[,]
                {
                    { 1, "Start a session with solid tonal development, can also be used as a warm-down", "Tonal Warm-Ups" },
                    { 2, "Start a session getting technically warmed up, vocal chords, fingers, etc.", "Technical Warm-Ups" },
                    { 3, "Fundamentals of musical development, scales in multiple forms, modes, ranges", "Scales" },
                    { 4, "Isolated chords, arpeggios, voicings, etc.", "Chords/Arpeggios" },
                    { 5, "Any techniques not tradtionally taught for producing sound on your instrument or voice", "Extended Techniques" },
                    { 6, "Any activity to develop jazz, rock, pop, etc. improvisation", "Improvisation" },
                    { 7, "Learn class jazz tunes, or songs needed for commercial gigs", "Tune/Song Learning" },
                    { 8, "Sonatas, Concertos, Solos, etc. for your specific instrument or voice", "Solo Repertoire" },
                    { 9, "Learn or pratice any chamber music pieces for upcoming gigs, recitals, etc.", "Chamber Music Repertoire" },
                    { 10, "Essential for developing musicianship, technique, and musical literacy", "Etudes" },
                    { 11, "Any variety of music you read down on the first try", "Sight-Reading" },
                    { 12, "Specific well-known excerpts for you instrument from the symphonic repertoire", "Orchestral Excerpts" },
                    { 13, "Learning full-length large ensemle pieces for upcoming concerts", "Large Ensemble Repertoire" },
                    { 14, "Whatever keeps you playing!", "Fun" },
                    { 15, "Anything which doesn't fit securely into a previous category", "Other" }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "CategoryId", "CreatorId", "Details", "Name" },
                values: new object[,]
                {
                    { 1, 1, null, "Any variation of sustained tone with focus on tone quality and proper technique", "Long-Tones" },
                    { 2, 1, null, "Any variation of Remington exercise across any register", "Remington Exercises" },
                    { 3, 1, null, "Playing mouthpiece only, flexibilty or long tones", "Mouthpiece Exercises" },
                    { 4, 1, null, "Studies out of the Clarke method book, not intended to be played as fast as possible for long tone warm up", "Clarke Studies" },
                    { 5, 2, null, "Choose a pattern and play in all keys", "Scale Patterns" },
                    { 6, 2, null, "Patterns from the Hanon book", "Hanon Patterns" },
                    { 7, 2, null, "Slowly build speed on using first three fingers on first three frets", "Fret Fingering Pattern" },
                    { 8, 2, null, "String instruments exercising left hand fingers without support of back thumb", "No Thumb - Left Hand" },
                    { 9, 3, null, "Major Scales - full range of instrument", "Major" },
                    { 10, 3, null, "Harmonic Minor - full range of instrument", "Harmonic Minor" },
                    { 11, 3, null, "Melodic Minor - full range of instrument", "Melodic Minor" },
                    { 12, 3, null, "Natural Minor - full range of instrument", "Natural Minor" },
                    { 13, 4, null, "Major Chords/Arpeggios - all keys", "Major" },
                    { 14, 4, null, "Minor Chords/Arpeggios - all keys", "Minor" },
                    { 15, 4, null, "Dominant Chords/Arpeggios - all keys", "Dominant" },
                    { 16, 4, null, "Half-Diminished - all keys", "Half-Diminised" },
                    { 17, 5, null, "Practice and/or listen to subtone examples", "Subtone" },
                    { 18, 5, null, "Pratice slow isolated slap tongues and build speed", "Slap Tongue" },
                    { 19, 5, null, "Practice isolated flutter tongue on one pitch, then add scales, etc.", "Flutter Tongue" },
                    { 20, 5, null, "Testing alternate fingerings for tricky passages or tonal effects/intonation", "Alternate Fingerings" },
                    { 21, 6, null, "Pick a 2-5-1 pattern and apply to all keys", "2-5-1 Patterns" },
                    { 22, 6, null, "Pick a set of changes or tune and walk a bass line over them", "Walk Bass Line" },
                    { 23, 6, null, "Pick a set of changes or tune to improvise over freely", "Improvise" },
                    { 24, 6, null, "Listen and mimic high-quality recordings", "Listen" },
                    { 25, 7, null, "Learn changes, form, melody, lyrics, etc.", "Donna Lee" },
                    { 26, 7, null, "Learn changes, form, melody, lyric, etc.", "Misty" },
                    { 27, 7, null, "You can't play guitar unless you play Wonderwall", "Wonderwall" },
                    { 28, 7, null, "That one George Michael Song", "Careless Whisper" },
                    { 29, 8, null, "Hummel Concerto for Trumpet", "Hummel Concerto" },
                    { 30, 8, null, "Partita for solo vionlin", "Bach Partita in D minor" },
                    { 31, 8, null, "John Cage -4'33\" for piano", "Cage 4'33\"" },
                    { 32, 8, null, "Berio - Sequnza III for solo voice", "Berio Sequenza III" },
                    { 33, 9, null, "Mozart String Quartet No. 15", "Mozart String Quartet No. 15" },
                    { 34, 9, null, "Ciudades for saxophone quartet - movement II", "Ciudades for Saxophone Quartet" },
                    { 35, 9, null, "Poulenc Sonata for four hands", "Poulenc Sonata for four hands" },
                    { 36, 9, null, "Six Bagatelles - Ligeti - for Woodwind quintet", "Six Bagatelles" },
                    { 37, 10, null, "Ferling 48 Famous Studies Etudes for oboe", "Ferling Etude No. 14" },
                    { 38, 10, null, "From the saxophone Voxman Selected Studies book", "Voxman Etude No. 2" },
                    { 39, 10, null, "Milde Concert studies for piano - No. 3", "Milde Concert Study 3" },
                    { 40, 10, null, "Chopin Etude No. 3 for piano", "Chopin Etude No. 3" },
                    { 41, 11, null, "Custom exercises on SRF website", "Sight Reading Factory" },
                    { 42, 11, null, "Sight read lines from easier method book", "Intermediate Method" },
                    { 43, 11, null, "Sight read new pieces for band class", "New Pieces for band" },
                    { 44, 11, null, "Googled sight-reading excerpts for free online", "Googled Random tuba pieces" },
                    { 45, 12, null, "Trumpet opening to Mahler Symphony No. 5", "Mahler 5 opening" },
                    { 46, 12, null, "Trumpet opening to Promenade from Pictures at an Exhibition by Mussorgsky", "Pictures - Promenade" },
                    { 47, 12, null, "Just find something hard in this piece and get better at it", "Symphonie Fantastique" },
                    { 48, 12, null, "Don Juan by Strauss - practiced the horn part", "Strauss - Don Juan" },
                    { 49, 13, null, "Maslanka Symphony No. 4 for band concert coming up", "Maslanka 4" },
                    { 50, 13, null, "Missa Papae Marcelli - by Palestrina for upcoming gig", "Palestrina" },
                    { 51, 13, null, "Practice violin 1 part for upcoming concert in Chattanooga", "Beethoven 7" },
                    { 52, 13, null, "Practiced my part for our guitar ensemble recital", "Gymnopedie for guitar ensemble" },
                    { 53, 14, null, "Learned the Pink Panther theme on kazoo", "Learn Pink Panther" },
                    { 54, 14, null, "Learn Mandalorian theme on alto flute", "Learn Mandalorian" },
                    { 55, 14, null, "Never gonna give you up", "Learn the Rick-Roll song" },
                    { 56, 14, null, "It helps", "Scream Into the Mirror" },
                    { 57, 15, null, "Walk, breathe, rest your eyes, whatever you need!", "Take a break" },
                    { 58, 15, null, "Stretch to prevent repetitive motion injuries", "Stretch" },
                    { 59, 15, null, "As a pre-warm up or warm-down, or if you get frustrated", "Deep-Breathing" },
                    { 60, 15, null, "I did it on Bassoon, pick your poison", "Rick-Roll mom" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "4342d71c-3d92-49ea-9f84-8f3412b65679" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "7c8b955a-c256-4505-bf0f-468489633f5f" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "7e60e6dc-579e-43af-9b2a-b4fe5bb42407" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "91a84af5-48ef-4bce-aa4e-7271d83d4d8c" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "a03371b3-edeb-4184-8917-14fa66adb89f" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "a541cf62-3506-462f-8901-eee6d9d5145f" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "ad6fe687-1ebf-4ef4-9e10-4e23b483140c" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "b1df4873-5564-479b-94c0-172f799e820b" },
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "b6d8aa7f-ae65-4feb-95ab-377d810bc270" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "e9fd3bbc-17a0-4ba7-857e-e6d695698548" }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IdentityUserId", "LastName", "Roles", "TeacherId", "UserName" },
                values: new object[,]
                {
                    { 1, "101 Main St.", null, "Admina", "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", "Strator", null, null, null },
                    { 2, "5531 Broad St.", null, "Teacher 2", "e9fd3bbc-17a0-4ba7-857e-e6d695698548", "Test", null, null, null }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "Body", "SessionId", "TeacherId" },
                values: new object[,]
                {
                    { 1, "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own.", 1, 1 },
                    { 2, "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own.", 3, 1 },
                    { 3, "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own.", 5, 1 },
                    { 4, "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own.", 8, 2 },
                    { 5, "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own.", 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "Id", "Address", "Email", "FirstName", "IdentityUserId", "LastName", "Roles", "TeacherId", "UserName" },
                values: new object[,]
                {
                    { 3, "900 Willow Ave.", null, "Suzy", "4342d71c-3d92-49ea-9f84-8f3412b65679", "Bumpkin", null, 1, null },
                    { 4, "133 W Elm St.", null, "Billy", "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", "Mack", null, 1, null },
                    { 5, "6161 Maple St.", null, "Lizzie", "b6d8aa7f-ae65-4feb-95ab-377d810bc270", "McGuire", null, 1, null },
                    { 6, "775 N Spruce St.", null, "Macy", "7c8b955a-c256-4505-bf0f-468489633f5f", "Greene", null, 1, null },
                    { 7, "202 SW Poplar Rd.", null, "Tracy", "ad6fe687-1ebf-4ef4-9e10-4e23b483140c", "Moore", null, 2, null },
                    { 8, "801 Pine St.", null, "Eric", "b1df4873-5564-479b-94c0-172f799e820b", "Linn", null, 2, null },
                    { 9, "454 Elm St.", null, "Blake", "7e60e6dc-579e-43af-9b2a-b4fe5bb42407", "White", null, 2, null },
                    { 10, "303 Beech St.", null, "Kyle", "a03371b3-edeb-4184-8917-14fa66adb89f", "Vance", null, 2, null },
                    { 11, "754 N. Walnut St.", null, "Walter", "a541cf62-3506-462f-8901-eee6d9d5145f", "White", null, 2, null },
                    { 12, "900 S. Walnut St.", null, "Corey", "91a84af5-48ef-4bce-aa4e-7271d83d4d8c", "Graves", null, 2, null }
                });

            migrationBuilder.InsertData(
                table: "Sessions",
                columns: new[] { "Id", "DateCompleted", "MusicianId", "Notes" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 3, 13, 11, 0, 0, DateTimeKind.Unspecified), 5, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 2, new DateTime(2024, 1, 9, 13, 11, 0, 0, DateTimeKind.Unspecified), 3, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 3, new DateTime(2024, 1, 12, 13, 11, 0, 0, DateTimeKind.Unspecified), 4, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 4, new DateTime(2024, 1, 14, 13, 11, 0, 0, DateTimeKind.Unspecified), 5, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 5, new DateTime(2024, 1, 15, 13, 11, 0, 0, DateTimeKind.Unspecified), 4, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 6, new DateTime(2024, 1, 17, 13, 11, 0, 0, DateTimeKind.Unspecified), 3, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 7, new DateTime(2024, 1, 18, 13, 11, 0, 0, DateTimeKind.Unspecified), 7, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 8, null, 7, null },
                    { 9, null, 10, null },
                    { 10, null, 8, null }
                });

            migrationBuilder.InsertData(
                table: "Assignments",
                columns: new[] { "Id", "DueDate", "MusicianId", "SessionId", "TeacherId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { 2, new DateTime(2024, 2, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 3, new DateTime(2024, 2, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 4, new DateTime(2024, 2, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 5, new DateTime(2024, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 9, 10, 2 }
                });

            migrationBuilder.InsertData(
                table: "FavoriteSessions",
                columns: new[] { "Id", "MusicianId", "SessionId" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 2, 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "SessionActivities",
                columns: new[] { "Id", "ActivityId", "Duration", "SessionId" },
                values: new object[,]
                {
                    { 1, 9, 20, 1 },
                    { 2, 49, 15, 1 },
                    { 3, 57, 15, 1 },
                    { 4, 40, 30, 1 },
                    { 5, 30, 10, 2 },
                    { 6, 20, 30, 2 },
                    { 7, 46, 40, 2 },
                    { 8, 10, 25, 3 },
                    { 9, 6, 10, 3 },
                    { 10, 20, 15, 3 },
                    { 11, 38, 20, 4 },
                    { 12, 55, 20, 4 },
                    { 13, 2, 10, 5 },
                    { 14, 33, 20, 5 },
                    { 15, 13, 15, 5 },
                    { 16, 19, 20, 6 },
                    { 17, 40, 30, 6 },
                    { 18, 5, 15, 6 },
                    { 19, 3, 10, 7 },
                    { 20, 11, 40, 7 },
                    { 21, 49, 20, 7 },
                    { 22, 22, 30, 8 },
                    { 23, 16, 15, 9 },
                    { 24, 51, 25, 10 },
                    { 25, 44, 30, 10 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_CategoryId",
                table: "Activities",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

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
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_MusicianId",
                table: "Assignments",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_SessionId",
                table: "Assignments",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_TeacherId",
                table: "Assignments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_TeacherId",
                table: "Comments",
                column: "TeacherId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSessions_MusicianId",
                table: "FavoriteSessions",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_FavoriteSessions_SessionId",
                table: "FavoriteSessions",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionActivities_ActivityId",
                table: "SessionActivities",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionActivities_SessionId",
                table: "SessionActivities",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_MusicianId",
                table: "Sessions",
                column: "MusicianId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_IdentityUserId",
                table: "UserProfiles",
                column: "IdentityUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfiles_TeacherId",
                table: "UserProfiles",
                column: "TeacherId");
        }

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
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "FavoriteSessions");

            migrationBuilder.DropTable(
                name: "SessionActivities");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "UserProfiles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
