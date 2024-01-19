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
                    { "a171f807-e85e-46a5-ae04-f287122ede55", "a8cde0b2-5d6c-4ebd-a721-dfcb6cb72ee6", "Musician", "musician" },
                    { "c3aaeb97-d2ba-4a53-a521-4eea61e59b35", "c996f026-ec11-480b-b528-d60d93576c7b", "Teacher", "teacher" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", 0, "bcbb3116-e15e-47d2-9d60-7e7e47fe96d6", "teststudent2@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEE5mOxvMkwGmVqtPcm2W84mRT0vsaE53wXeKyAPpQzXB832OvNLe5T/mty9cQSwTTg==", null, false, "4f1a1b92-f270-4876-b6e5-81f2a8fcd0f2", false, "TestStudent2" },
                    { "4342d71c-3d92-49ea-9f84-8f3412b65679", 0, "4a5ecc43-53cc-43cc-80bd-56ff0111969e", "teststudent1@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEN9eyz4Jf1ETBJXhxeMTBGlHMXOguodVHhGGj8Vsk6ZlA4olhhHabBACW2Rz8xrhMg==", null, false, "8910f0a5-9675-4334-bb50-cb47aea57124", false, "TestStudent1" },
                    { "7c8b955a-c256-4505-bf0f-468489633f5f", 0, "3cc9c3de-d671-45ab-87fb-59f5d99d8d24", "teststudent4@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEEPoykr8ANvVisduWe5EoZmpPblwSvzPAagPQ4zO58P6e7Khqk66z4GRBo3AZRw4iQ==", null, false, "ca7bd168-fac1-40bc-b80c-13dd5ccc3bbb", false, "TestStudent4" },
                    { "7e60e6dc-579e-43af-9b2a-b4fe5bb42407", 0, "abf5a6da-56ad-4f9b-b887-09d76311c1e2", "teststudent7@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEI8q7280FYjAq6OPY0+2YbpRVJLAklBo8+0n2Vj1J+S3d0FyGPqoD5JHL54phd/Erg==", null, false, "d17e2f96-ea35-4b22-bee4-4f7ff4172fff", false, "TestStudent7" },
                    { "91a84af5-48ef-4bce-aa4e-7271d83d4d8c", 0, "49747bd9-8448-43cb-b322-c523f2c1b61b", "teststudent10@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEG4SYSwunRKaqyslEFvrHXht3OHBr9M0zsnMRkb+MuRZTGJWEe68cs6nJcsh+QOmnw==", null, false, "9724f7a4-2296-4fa1-8813-3569446c82ff", false, "TestStudent10" },
                    { "a03371b3-edeb-4184-8917-14fa66adb89f", 0, "d63fa97c-48c3-4b96-b540-640e5d68a5e2", "teststudent8@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAKgWQx83X0YKMJdQZUEwl08PMde/zYSQnRJlq1DB5/g8SUdwP80TLC9DpizBJFMFg==", null, false, "689d7a5e-82cc-4a56-9811-46294a20e96f", false, "TestStudent8" },
                    { "a541cf62-3506-462f-8901-eee6d9d5145f", 0, "568e3a0a-07ba-4735-9355-ab536f2292fa", "teststudent9@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEL0y3QvI/DppkJrPxFeQWla7y61O+2vheJBfOMRDnYf2LljfLjKXTYsNojqhLPTjXw==", null, false, "c7bb75bc-b8fd-4482-a63f-91120b992bf9", false, "TestStudent9" },
                    { "ad6fe687-1ebf-4ef4-9e10-4e23b483140c", 0, "b1e25ada-00eb-40b5-974d-2e6cf4557db1", "teststudent5@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECd8KqKy3Lq514cq2lMMY09Jlp8vi7mpcU9m9KDIPGrCiRSHnBFeOc1hM519UKOoGA==", null, false, "30663dec-4ea8-4f09-a1c2-1ca033271053", false, "TestStudent5" },
                    { "b1df4873-5564-479b-94c0-172f799e820b", 0, "3d57d8fb-1899-4696-863b-1298cae9fe67", "teststudent6@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAECZ4ta8NPOlyuWXYpDy5I+JGPeUXNF9RNZomBmxkofscH5TlHx4URCa4cFMI9gRtQw==", null, false, "c9d0259a-b0c4-4daa-a3cd-82d743b8a22a", false, "TestStudent6" },
                    { "b6d8aa7f-ae65-4feb-95ab-377d810bc270", 0, "01080f95-b3f4-4c45-abd7-80ae54b9213f", "teststudent3@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAELVx6sUXhN065syE2+AR4NujKAyAjuK+IXh0cEhYbIhbDVnd8QHYWmwOgg1lB6pCcA==", null, false, "1fccc81a-d352-482b-876f-acf9dcd5e75f", false, "TestStudent3" },
                    { "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f", 0, "ae243d15-c379-4e47-8bf8-cc90e3ae7797", "admina@strator.comx", false, false, null, null, null, "AQAAAAEAACcQAAAAEIECYDDEpWh3+jD3YgBhbPosSvgP1D13N2v3dnfP2gShsj+S9puiFZZGaUye09+P9A==", null, false, "e25bc5eb-ce77-47a3-95e1-77a9dd15b03c", false, "Administrator" },
                    { "e9fd3bbc-17a0-4ba7-857e-e6d695698548", 0, "287e18c6-70ec-4d05-b28e-24e67a3bba3c", "teacher1@test.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEAGPGiatHgcwZtbKZcuVT5W1pkGKCCFHRVsV2xutrjS/cE8aRBHiD5l7IS4nNPQUXQ==", null, false, "3fb1ebfd-a06b-4dc5-a8f5-e08e1821ab84", false, "Teacher2" }
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
                columns: new[] { "Id", "CategoryId", "Details", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Any variation of sustained tone with focus on tone quality and proper technique", "Long-Tones" },
                    { 2, 1, "Any variation of Remington exercise across any register", "Remington Exercises" },
                    { 3, 1, "Playing mouthpiece only, flexibilty or long tones", "Mouthpiece Exercises" },
                    { 4, 1, "Studies out of the Clarke method book, not intended to be played as fast as possible for long tone warm up", "Clarke Studies" },
                    { 5, 2, "Choose a pattern and play in all keys", "Scale Patterns" },
                    { 6, 2, "Patterns from the Hanon book", "Hanon Patterns" },
                    { 7, 2, "Slowly build speed on using first three fingers on first three frets", "Fret Fingering Pattern" },
                    { 8, 2, "String instruments exercising left hand fingers without support of back thumb", "No Thumb - Left Hand" },
                    { 9, 3, "Major Scales - full range of instrument", "Major" },
                    { 10, 3, "Harmonic Minor - full range of instrument", "Harmonic Minor" },
                    { 11, 3, "Melodic Minor - full range of instrument", "Melodic Minor" },
                    { 12, 3, "Natural Minor - full range of instrument", "Natural Minor" },
                    { 13, 4, "Major Chords/Arpeggios - all keys", "Major" },
                    { 14, 4, "Minor Chords/Arpeggios - all keys", "Minor" },
                    { 15, 4, "Dominant Chords/Arpeggios - all keys", "Dominant" },
                    { 16, 4, "Half-Diminished - all keys", "Half-Diminised" },
                    { 17, 5, "Practice and/or listen to subtone examples", "Subtone" },
                    { 18, 5, "Pratice slow isolated slap tongues and build speed", "Slap Tongue" },
                    { 19, 5, "Practice isolated flutter tongue on one pitch, then add scales, etc.", "Flutter Tongue" },
                    { 20, 5, "Testing alternate fingerings for tricky passages or tonal effects/intonation", "Alternate Fingerings" },
                    { 21, 6, "Pick a 2-5-1 pattern and apply to all keys", "2-5-1 Patterns" },
                    { 22, 6, "Pick a set of changes or tune and walk a bass line over them", "Walk Bass Line" },
                    { 23, 6, "Pick a set of changes or tune to improvise over freely", "Improvise" },
                    { 24, 6, "Listen and mimic high-quality recordings", "Listen" },
                    { 25, 7, "Learn changes, form, melody, lyrics, etc.", "Donna Lee" },
                    { 26, 7, "Learn changes, form, melody, lyric, etc.", "Misty" },
                    { 27, 7, "You can't play guitar unless you play Wonderwall", "Wonderwall" },
                    { 28, 7, "That one George Michael Song", "Careless Whisper" },
                    { 29, 8, "Hummel Concerto for Trumpet", "Hummel Concerto" },
                    { 30, 8, "Partita for solo vionlin", "Bach Partita in D minor" },
                    { 31, 8, "John Cage -4'33\" for piano", "Cage 4'33\"" },
                    { 32, 8, "Berio - Sequnza III for solo voice", "Berio Sequenza III" },
                    { 33, 9, "Mozart String Quartet No. 15", "Mozart String Quartet No. 15" },
                    { 34, 9, "Ciudades for saxophone quartet - movement II", "Ciudades for Saxophone Quartet" },
                    { 35, 9, "Poulenc Sonata for four hands", "Poulenc Sonata for four hands" },
                    { 36, 9, "Six Bagatelles - Ligeti - for Woodwind quintet", "Six Bagatelles" },
                    { 37, 10, "Ferling 48 Famous Studies Etudes for oboe", "Ferling Etude No. 14" },
                    { 38, 10, "From the saxophone Voxman Selected Studies book", "Voxman Etude No. 2" },
                    { 39, 10, "Milde Concert studies for piano - No. 3", "Milde Concert Study 3" },
                    { 40, 10, "Chopin Etude No. 3 for piano", "Chopin Etude No. 3" },
                    { 41, 11, "Custom exercises on SRF website", "Sight Reading Factory" },
                    { 42, 11, "Sight read lines from easier method book", "Intermediate Method" },
                    { 43, 11, "Sight read new pieces for band class", "New Pieces for band" },
                    { 44, 11, "Googled sight-reading excerpts for free online", "Googled Random tuba pieces" },
                    { 45, 12, "Trumpet opening to Mahler Symphony No. 5", "Mahler 5 opening" },
                    { 46, 12, "Trumpet opening to Promenade from Pictures at an Exhibition by Mussorgsky", "Pictures - Promenade" },
                    { 47, 12, "Just find something hard in this piece and get better at it", "Symphonie Fantastique" },
                    { 48, 12, "Don Juan by Strauss - practiced the horn part", "Strauss - Don Juan" },
                    { 49, 13, "Maslanka Symphony No. 4 for band concert coming up", "Maslanka 4" },
                    { 50, 13, "Missa Papae Marcelli - by Palestrina for upcoming gig", "Palestrina" },
                    { 51, 13, "Practice violin 1 part for upcoming concert in Chattanooga", "Beethoven 7" },
                    { 52, 13, "Practiced my part for our guitar ensemble recital", "Gymnopedie for guitar ensemble" },
                    { 53, 14, "Learned the Pink Panther theme on kazoo", "Learn Pink Panther" },
                    { 54, 14, "Learn Mandalorian theme on alto flute", "Learn Mandalorian" },
                    { 55, 14, "Never gonna give you up", "Learn the Rick-Roll song" },
                    { 56, 14, "It helps", "Scream Into the Mirror" },
                    { 57, 15, "Walk, breathe, rest your eyes, whatever you need!", "Take a break" },
                    { 58, 15, "Stretch to prevent repetitive motion injuries", "Stretch" },
                    { 59, 15, "As a pre-warm up or warm-down, or if you get frustrated", "Deep-Breathing" },
                    { 60, 15, "I did it on Bassoon, pick your poison", "Rick-Roll mom" }
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
                    { 2, "5531 Broad St.", null, "Teacher 2", "e9fd3bbc-17a0-4ba7-857e-e6d695698548", "Test", null, null, null },
                    { 3, "900 Willow Ave.", null, "Suzy", "4342d71c-3d92-49ea-9f84-8f3412b65679", "Bumpkin", null, null, null },
                    { 4, "133 W Elm St.", null, "Billy", "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05", "Mack", null, null, null },
                    { 5, "6161 Maple St.", null, "Lizzie", "b6d8aa7f-ae65-4feb-95ab-377d810bc270", "McGuire", null, null, null },
                    { 6, "775 N Spruce St.", null, "Macy", "7c8b955a-c256-4505-bf0f-468489633f5f", "Greene", null, null, null },
                    { 7, "202 SW Poplar Rd.", null, "Tracy", "ad6fe687-1ebf-4ef4-9e10-4e23b483140c", "Moore", null, null, null },
                    { 8, "801 Pine St.", null, "Eric", "b1df4873-5564-479b-94c0-172f799e820b", "Linn", null, null, null },
                    { 9, "454 Elm St.", null, "Blake", "7e60e6dc-579e-43af-9b2a-b4fe5bb42407", "White", null, null, null },
                    { 10, "303 Beech St.", null, "Kyle", "a03371b3-edeb-4184-8917-14fa66adb89f", "Vance", null, null, null },
                    { 11, "754 N. Walnut St.", null, "Walter", "a541cf62-3506-462f-8901-eee6d9d5145f", "White", null, null, null },
                    { 12, "900 S. Walnut St.", null, "Corey", "91a84af5-48ef-4bce-aa4e-7271d83d4d8c", "Graves", null, null, null }
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
                    { 8, null, 7, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 9, null, 10, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" },
                    { 10, null, 8, "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197" }
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
