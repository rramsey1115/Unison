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
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Complete = table.Column<bool>(type: "boolean", nullable: false)
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
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "5a404fec-b06f-46a0-a8aa-0cc3a2f34a86", "Musician", "musician" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "68f372b5-b95e-42ab-8eb6-5b53c2fd37b0", "Teacher", "teacher" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", 0, "30efe69c-fb51-487a-87bf-3c862cc5b696", "teststudent2@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPJGt/Q4Lq9zcQ8+No5E031QZQe1cv3aBIQmM2KnDh0iDYjXcp/xjLRzJsn1SnHHYA==", null, false, "d6e3193d-4724-471a-b27e-7bc3af42b62d", false, "TestStudent2" },
                    { "4342d71c-3d92-49ea-9f84-8f3412b65679", 0, "4ebe2331-3efe-4949-b530-2e4b412e3886", "teststudent1@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEBPTSExsl2G1pkEkNb92wVilTmKtcAU7aEWETWxs3NQQDN7P04LkvfJw4WfqptHZag==", null, false, "fcb139e7-8676-4e05-b14a-58b397e7538b", false, "TestStudent1" },
                    { "7c8b955a-c256-4505-bf0f-468489633f5f", 0, "6ec44f1b-5319-40f3-baaa-6a2fa0916d37", "teststudent4@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECQ/CxkLU7ltpz1idmh1dFNRg3N16oLm2a3Dspn2iGm8cIE/dUATlvCik8K5cY7KNw==", null, false, "d63fe505-642c-4c12-990a-4162ed348d20", false, "TestStudent4" },
                    { "7e60e6dc-579e-43af-9b2a-b4fe5bb42407", 0, "9679416a-b176-4b17-8ea2-33ebbc7687fe", "teststudent7@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEO6qiKy+88IIWeXjbmsnUxwkiX1WjlxcpI1Dld780pCGlDjLcCq9I3M7z6sO2CB6DA==", null, false, "06bfdff8-ace5-4024-a887-a96c6191ef9f", false, "TestStudent7" },
                    { "91a84af5-48ef-4bce-aa4e-7271d83d4d8c", 0, "b7a8e2d3-776a-4c31-8adb-a7ef037f0a43", "teststudent10@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPXS293tIc9JfAbVXDp/l4xAf8ONr5SSJtWuq2NGYjYeUqnhOE1hIiiowjtAhqvrrA==", null, false, "97eb5596-6133-404e-8762-10f9cc42015f", false, "TestStudent10" },
                    { "a03371b3-edeb-4184-8917-14fa66adb89f", 0, "68591b1d-7545-41b8-8a83-b486427b8d27", "teststudent8@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEGqZ/wDOLa/0F4rgs/6c0RGxtM1EJga58MourgG7QAnIHCAN5EogmtIsFPVxkjVjWA==", null, false, "9cd6feef-11ad-45a5-9ab5-0e86f381e125", false, "TestStudent8" },
                    { "a541cf62-3506-462f-8901-eee6d9d5145f", 0, "cdeebaf6-3bfc-4318-b2d8-3a31b92e8f1b", "teststudent9@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKBjNOJB1NvD1Gj/U7q97cJVdePUq2kGc+K1gcnnUlkOJ8KYd2ulzztUnr2IeKDHYg==", null, false, "5e1c99a7-003a-494f-80c0-d922768edbfb", false, "TestStudent9" },
                    { "ad6fe687-1ebf-4ef4-9e10-4e23b483140c", 0, "220c4d2f-20da-43d9-b2e2-3967df744cef", "teststudent5@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEPIkrVNBdc+wEiaRB6Fd2ngnOIvck0oWE/OB8GoUj5w0jnF0Yhkz0uTt5MlfUH3cjA==", null, false, "88bdb27e-decb-4394-bdcf-0c4d1b0d4ee7", false, "TestStudent5" },
                    { "b1df4873-5564-479b-94c0-172f799e820b", 0, "3ea1aa76-716f-464c-baa8-b24abde78381", "teststudent6@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEC1+1bh2hJpUTW62n/sZjhDMHwzbBXMOtzRSUjj8K09QLY/oQWLZScigWK7pYx3RbQ==", null, false, "2dd63797-dd90-4791-b70e-f6e38dc36cba", false, "TestStudent6" },
                    { "b6d8aa7f-ae65-4feb-95ab-377d810bc270", 0, "426bc0da-6a6b-4440-8b9b-ea8acc7fa0c7", "teststudent3@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEMeV3lETGZ+jHOdDrDkOEmhv6pER0Fak2HHABJffXJV+pxh9Z02ZUaCmATKJYuYcOQ==", null, false, "965adc66-77ba-4c5c-9f19-669d4e71ece1", false, "TestStudent3" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "a2b275fc-52ba-4f96-afc1-aedc26f776fb", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAENGZALr2jaPPh8odhjOxXgpoVl5ue+rWU/d4PWZl1DE5HNOgkGgtcUxo1pM3lbPfbA==", null, false, "41c762f8-a664-47cb-b83c-61e73d6db70e", false, "Administrator" },
                    { "e9fd3bbc-17a0-4ba7-857e-e6d695698548", 0, "0440df21-c887-4db1-8314-cd2cacb20ee5", "teacher1@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEF92Dr5V2VZ2ynVPzCBbUKGNcdergUyJ9o4xDa63uyMNtlaZ5pNsnOsLCXaQeADe9g==", null, false, "b447bc8d-95ee-470f-8626-60666429237b", false, "Teacher2" }
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
                columns: new[] { "Id", "Complete", "DueDate", "MusicianId", "SessionId", "TeacherId" },
                values: new object[,]
                {
                    { 1, true, new DateTime(2024, 2, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 3, 6, 1 },
                    { 2, true, new DateTime(2024, 2, 10, 17, 0, 0, 0, DateTimeKind.Unspecified), 4, 7, 1 },
                    { 3, false, new DateTime(2024, 2, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), 4, 8, 1 },
                    { 4, false, new DateTime(2024, 2, 22, 17, 0, 0, 0, DateTimeKind.Unspecified), 8, 9, 2 },
                    { 5, false, new DateTime(2024, 3, 1, 17, 0, 0, 0, DateTimeKind.Unspecified), 9, 10, 2 }
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
