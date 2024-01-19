using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Unison.Models;
using Microsoft.AspNetCore.Identity;
using Unison.Models.DTOs;

namespace Unison.Data;
public class UnisonDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }

    public DbSet<ActivityObj> Activities { get; set; }

    public DbSet<Assignment> Assignments { get; set; }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Comment> Comments { get; set; }

    public DbSet<FavoriteSession> FavoriteSessions { get; set; }

    public DbSet<Session> Sessions { get; set; }

    public DbSet<SessionActivity> SessionActivities { get; set; }

    public UnisonDbContext(DbContextOptions<UnisonDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                Name = "Teacher",
                NormalizedName = "teacher"
            },
            new IdentityRole
            {
                Id = "a171f807-e85e-46a5-ae04-f287122ede55",
                Name = "Musician",
                NormalizedName = "musician"
            }
        );

        modelBuilder.Entity<IdentityUser>().HasData(
            new IdentityUser
            {
                Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                UserName = "Administrator",
                Email = "admina@strator.comx",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "e9fd3bbc-17a0-4ba7-857e-e6d695698548",
                UserName = "Teacher2",
                Email = "teacher1@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "4342d71c-3d92-49ea-9f84-8f3412b65679",
                UserName = "TestStudent1",
                Email = "teststudent1@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05",
                UserName = "TestStudent2",
                Email = "teststudent2@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "b6d8aa7f-ae65-4feb-95ab-377d810bc270",
                UserName = "TestStudent3",
                Email = "teststudent3@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "7c8b955a-c256-4505-bf0f-468489633f5f",
                UserName = "TestStudent4",
                Email = "teststudent4@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "ad6fe687-1ebf-4ef4-9e10-4e23b483140c",
                UserName = "TestStudent5",
                Email = "teststudent5@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "b1df4873-5564-479b-94c0-172f799e820b",
                UserName = "TestStudent6",
                Email = "teststudent6@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "7e60e6dc-579e-43af-9b2a-b4fe5bb42407",
                UserName = "TestStudent7",
                Email = "teststudent7@test.com",
                PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a03371b3-edeb-4184-8917-14fa66adb89f",
                UserName = "TestStudent8",
                Email = "teststudent8@test.com",
                PasswordHash =new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "a541cf62-3506-462f-8901-eee6d9d5145f",
                UserName = "TestStudent9",
                Email = "teststudent9@test.com",
                PasswordHash =new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            },
            new IdentityUser
            {
                Id = "91a84af5-48ef-4bce-aa4e-7271d83d4d8c",
                UserName = "TestStudent10",
                Email = "teststudent10@test.com",
                PasswordHash =new PasswordHasher<IdentityUser>().HashPassword(null,  _configuration["AdminPassword"])
            }
        );

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
                UserId = "e9fd3bbc-17a0-4ba7-857e-e6d695698548"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "4342d71c-3d92-49ea-9f84-8f3412b65679"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "b6d8aa7f-ae65-4feb-95ab-377d810bc270"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "7c8b955a-c256-4505-bf0f-468489633f5f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "ad6fe687-1ebf-4ef4-9e10-4e23b483140c"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "b1df4873-5564-479b-94c0-172f799e820b"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "7e60e6dc-579e-43af-9b2a-b4fe5bb42407"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "a03371b3-edeb-4184-8917-14fa66adb89f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "a541cf62-3506-462f-8901-eee6d9d5145f"
            },
            new IdentityUserRole<string>
            {
                RoleId = "a171f807-e85e-46a5-ae04-f287122ede55",
                UserId = "91a84af5-48ef-4bce-aa4e-7271d83d4d8c"
            }
        );

        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                Address = "101 Main St."
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "e9fd3bbc-17a0-4ba7-857e-e6d695698548",
                FirstName = "Teacher 2",
                LastName = "Test",
                Address = "5531 Broad St."
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "4342d71c-3d92-49ea-9f84-8f3412b65679",
                FirstName = "Suzy",
                LastName = "Bumpkin",
                Address = "900 Willow Ave.",
                TeacherId = 1
            },
            new UserProfile
            {
                Id = 4,
                IdentityUserId = "33ab14e6-cca3-4fb4-84d7-99d45b1c9b05",
                FirstName = "Billy",
                LastName = "Mack",
                Address = "133 W Elm St.",
                TeacherId = 1
            },
            new UserProfile
            {
                Id = 5,
                IdentityUserId = "b6d8aa7f-ae65-4feb-95ab-377d810bc270",
                FirstName = "Lizzie",
                LastName = "McGuire",
                Address = "6161 Maple St.",
                TeacherId = 1
            },
            new UserProfile
            {
                Id = 6,
                IdentityUserId = "7c8b955a-c256-4505-bf0f-468489633f5f",
                FirstName = "Macy",
                LastName = "Greene",
                Address = "775 N Spruce St.",
                TeacherId = 1
            },
            new UserProfile
            {
                Id = 7,
                IdentityUserId = "ad6fe687-1ebf-4ef4-9e10-4e23b483140c",
                FirstName = "Tracy",
                LastName = "Moore",
                Address = "202 SW Poplar Rd.",
                TeacherId = 2
            },
            new UserProfile
            {
                Id = 8,
                IdentityUserId = "b1df4873-5564-479b-94c0-172f799e820b",
                FirstName = "Eric",
                LastName = "Linn",
                Address = "801 Pine St.",
                TeacherId = 2
            },
            new UserProfile
            {
                Id = 9,
                IdentityUserId = "7e60e6dc-579e-43af-9b2a-b4fe5bb42407",
                FirstName = "Blake",
                LastName = "White",
                Address = "454 Elm St.",
                TeacherId = 2
            },
            new UserProfile
            {
                Id = 10,
                IdentityUserId = "a03371b3-edeb-4184-8917-14fa66adb89f",
                FirstName = "Kyle",
                LastName = "Vance",
                Address = "303 Beech St.",
                TeacherId = 2
            },
            new UserProfile
            {
                Id = 11,
                IdentityUserId = "a541cf62-3506-462f-8901-eee6d9d5145f",
                FirstName = "Walter",
                LastName = "White",
                Address = "754 N. Walnut St.",
                TeacherId = 2
            },
            new UserProfile
            {
                Id = 12,
                IdentityUserId = "91a84af5-48ef-4bce-aa4e-7271d83d4d8c",
                FirstName = "Corey",
                LastName = "Graves",
                Address = "900 S. Walnut St.",
                TeacherId = 2
            }
        );

        modelBuilder.Entity<Comment>().HasData(
            new
            {
                Id = 1,
                SessionId = 1,
                TeacherId = 1,
                Body = "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own."
            },
            new
            {
                Id = 2,
                SessionId = 3,
                TeacherId = 1,
                Body = "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own."
            },
            new
            {
                Id = 3,
                SessionId = 5,
                TeacherId = 1,
                Body = "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own."
            },
            new
            {
                Id = 4,
                SessionId = 8,
                TeacherId = 2,
                Body = "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own."
            },
            new
            {
                Id = 5,
                SessionId = 9,
                TeacherId = 2,
                Body = "Comment about music, saying very useful and meaningful things. Things a student could never think of on their own."
            }
        );

        modelBuilder.Entity<FavoriteSession>().HasData( 
            new
            {
                Id = 1,
                SessionId = 1,
                MusicianId = 2,
            },
            new
            {
                Id = 2,
                SessionId = 2,
                MusicianId = 2,
            }
        );

        modelBuilder.Entity<Session>().HasData(
            new
            {
                Id = 1,
                MusicianId = 5,
                DateCompleted = new DateTime(2024, 01, 03, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 2,
                MusicianId = 3,
                DateCompleted = new DateTime(2024, 01, 09, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 3,
                MusicianId = 4,
                DateCompleted = new DateTime(2024, 01, 12, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 4,
                MusicianId = 5,
                DateCompleted = new DateTime(2024, 01, 14, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 5,
                MusicianId = 4,
                DateCompleted = new DateTime(2024, 01, 15, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 6,
                MusicianId = 3,
                DateCompleted = new DateTime(2024, 01, 17, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 7,
                MusicianId = 7,
                DateCompleted = new DateTime(2024, 01, 18, 13, 11, 00),
                Notes = "Need to work on C# minor and m. 17-32 of my etudes. Did not have a good warm-up. Repertoire learned measures 122-197"
            },
            new
            {
                Id = 8,
                MusicianId = 7
            },
            new
            {
                Id = 9,
                MusicianId = 10
            },
            new
            {
                Id = 10,
                MusicianId = 8
            }
        );

        modelBuilder.Entity<SessionActivity>().HasData(
            new
            {
                Id = 1,
                SessionId = 1,
                ActivityId = 9,
                Duration = 20
            },
            new
            {
                Id = 2,
                SessionId = 1,
                ActivityId = 49,
                Duration = 15
            },
            new
            {
                Id = 3,
                SessionId = 1,
                ActivityId = 57,
                Duration = 15
            },
            new
            {
                Id = 4,
                SessionId = 1,
                ActivityId = 40,
                Duration = 30
            },
            new
            {
                Id = 5,
                SessionId = 2,
                ActivityId = 30,
                Duration = 10
            },
            new
            {
                Id = 6,
                SessionId = 2,
                ActivityId = 20,
                Duration = 30
            },
            new
            {
                Id = 7,
                SessionId = 2,
                ActivityId = 46,
                Duration = 40
            },
            new
            {
                Id = 8,
                SessionId = 3,
                ActivityId = 10,
                Duration = 25
            },
            new
            {
                Id = 9,
                SessionId = 3,
                ActivityId = 6,
                Duration = 10
            },
            new
            {
                Id = 10,
                SessionId = 3,
                ActivityId = 20,
                Duration = 15
            },
            new
            {
                Id = 11,
                SessionId = 4,
                ActivityId = 38,
                Duration = 20
            },
            new
            {
                Id = 12,
                SessionId = 4,
                ActivityId = 55,
                Duration = 20
            },
            new
            {
                Id = 13,
                SessionId = 5,
                ActivityId = 2,
                Duration = 10
            },
            new
            {
                Id = 14,
                SessionId = 5,
                ActivityId = 33,
                Duration = 20
            },
            new
            {
                Id = 15,
                SessionId = 5,
                ActivityId = 13,
                Duration = 15
            },
            new
            {
                Id = 16,
                SessionId = 6,
                ActivityId = 19,
                Duration = 20
            },
            new
            {
                Id = 17,
                SessionId = 6,
                ActivityId = 40,
                Duration = 30
            },
            new
            {
                Id = 18,
                SessionId = 6,
                ActivityId = 5,
                Duration = 15
            },
            new
            {
                Id = 19,
                SessionId = 7,
                ActivityId = 3,
                Duration = 10
            },
            new
            {
                Id = 20,
                SessionId = 7,
                ActivityId = 11,
                Duration = 40
            },
            new
            {
                Id = 21,
                SessionId = 7,
                ActivityId = 49,
                Duration = 20
            },
            new
            {
                Id = 22,
                SessionId = 8,
                ActivityId = 22,
                Duration = 30
            },
            new
            {
                Id = 23,
                SessionId = 9,
                ActivityId = 16,
                Duration = 15
            },
            new
            {
                Id = 24,
                SessionId = 10,
                ActivityId = 51,
                Duration = 25
            },
            new
            {
                Id = 25,
                SessionId = 10,
                ActivityId = 44,
                Duration = 30
            }
        );

        modelBuilder.Entity<Category>().HasData(
            new
            {
                Id = 1,
                Name = "Tonal Warm-Ups",
                Details = "Start a session with solid tonal development, can also be used as a warm-down"
            },
            new
            {
                Id = 2,
                Name = "Technical Warm-Ups",
                Details = "Start a session getting technically warmed up, vocal chords, fingers, etc."
            },
            new
            {
                Id = 3,
                Name = "Scales",
                Details = "Fundamentals of musical development, scales in multiple forms, modes, ranges"
            },
            new 
            {
                Id = 4,
                Name = "Chords/Arpeggios",
                Details = "Isolated chords, arpeggios, voicings, etc."
            },
            new 
            {
                Id = 5,
                Name = "Extended Techniques",
                Details = "Any techniques not tradtionally taught for producing sound on your instrument or voice"
            },
            new 
            {
                Id = 6,
                Name = "Improvisation",
                Details = "Any activity to develop jazz, rock, pop, etc. improvisation"
            },
            new 
            {
                Id = 7,
                Name = "Tune/Song Learning",
                Details = "Learn class jazz tunes, or songs needed for commercial gigs"
            },
            new 
            {
                Id = 8,
                Name = "Solo Repertoire",
                Details = "Sonatas, Concertos, Solos, etc. for your specific instrument or voice"
            },
            new 
            {
                Id = 9,
                Name = "Chamber Music Repertoire",
                Details = "Learn or pratice any chamber music pieces for upcoming gigs, recitals, etc."
            },
            new 
            {
                Id = 10,
                Name = "Etudes",
                Details = "Essential for developing musicianship, technique, and musical literacy"
            },
            new 
            {
                Id = 11,
                Name = "Sight-Reading",
                Details = "Any variety of music you read down on the first try"
            },
            new 
            {
                Id = 12,
                Name = "Orchestral Excerpts",
                Details = "Specific well-known excerpts for you instrument from the symphonic repertoire"
            },
            new 
            {
                Id = 13,
                Name = "Large Ensemble Repertoire",
                Details = "Learning full-length large ensemle pieces for upcoming concerts"
            },
            new 
            {
                Id = 14,
                Name = "Fun",
                Details = "Whatever keeps you playing!"
            },
            new 
            {
                Id = 15,
                Name = "Other",
                Details = "Anything which doesn't fit securely into a previous category"
            }
        );

        modelBuilder.Entity<Assignment>().HasData(
            new
            {
                Id = 1,
                MusicianId = 3,
                TeacherId = 1,
                SessionId = 6,
                DueDate = new DateTime(2024, 02, 01, 17, 00, 00),
                Complete = true
            },
            new
            {
                Id = 2,
                MusicianId = 4,
                TeacherId = 1,
                SessionId = 7,
                DueDate = new DateTime(2024, 02, 10, 17, 00, 00),
                Complete = true
            },
            new
            {
                Id = 3,
                MusicianId = 4,
                TeacherId = 1,
                SessionId = 8,
                DueDate = new DateTime(2024, 02, 17, 17, 00, 00),
                Complete = false
            },
            new
            {
                Id = 4,
                MusicianId = 8,
                TeacherId = 2,
                SessionId = 9,
                DueDate = new DateTime(2024, 02, 22, 17, 00, 00),
                Complete = false
            },
            new
            {
                Id = 5,
                MusicianId = 9,
                TeacherId = 2,
                SessionId = 10,
                DueDate = new DateTime(2024, 03, 01, 17, 00, 00),
                Complete = false
            }
        );


        modelBuilder.Entity<ActivityObj>().HasData(
            new
            {
                Id = 1,
                Name = "Long-Tones",
                Details = "Any variation of sustained tone with focus on tone quality and proper technique",
                CategoryId = 1
            },
            new
            {
                Id = 2, 
                Name = "Remington Exercises",
                Details = "Any variation of Remington exercise across any register",
                CategoryId = 1
            },
            new
            {
                Id = 3,
                Name = "Mouthpiece Exercises",
                Details = "Playing mouthpiece only, flexibilty or long tones",
                CategoryId = 1
            },
            new
            {
                Id = 4,
                Name = "Clarke Studies",
                Details = "Studies out of the Clarke method book, not intended to be played as fast as possible for long tone warm up",
                CategoryId = 1
            },
            new
            {
                Id = 5,
                Name = "Scale Patterns",
                Details = "Choose a pattern and play in all keys",
                CategoryId = 2
            },
            new
            {
                Id = 6,
                Name = "Hanon Patterns",
                Details = "Patterns from the Hanon book",
                CategoryId = 2
            },
            new
            {
                Id = 7,
                Name = "Fret Fingering Pattern",
                Details = "Slowly build speed on using first three fingers on first three frets",
                CategoryId = 2
            },
            new
            {
                Id = 8,
                Name = "No Thumb - Left Hand",
                Details = "String instruments exercising left hand fingers without support of back thumb",
                CategoryId = 2
            },
            new
            {
                Id = 9,
                Name = "Major",
                Details = "Major Scales - full range of instrument",
                CategoryId = 3
            },
            new
            {
                Id = 10,
                Name = "Harmonic Minor",
                Details = "Harmonic Minor - full range of instrument",
                CategoryId = 3
            },
            new
            {
                Id = 11,
                Name = "Melodic Minor",
                Details = "Melodic Minor - full range of instrument",
                CategoryId = 3
            },
            new
            {
                Id = 12,
                Name = "Natural Minor",
                Details = "Natural Minor - full range of instrument",
                CategoryId = 3
            },
            new
            {
                Id = 13,
                Name = "Major",
                Details = "Major Chords/Arpeggios - all keys",
                CategoryId = 4
            },
            new
            {
                Id = 15,
                Name = "Dominant",
                Details = "Dominant Chords/Arpeggios - all keys",
                CategoryId = 4
            },
            new
            {
                Id = 14,
                Name = "Minor",
                Details = "Minor Chords/Arpeggios - all keys",
                CategoryId = 4
            },
            new
            {
                Id = 16,
                Name = "Half-Diminised",
                Details = "Half-Diminished - all keys",
                CategoryId = 4
            },
            new
            {
                Id = 17,
                Name = "Subtone",
                Details = "Practice and/or listen to subtone examples",
                CategoryId = 5
            },
            new
            {
                Id = 18,
                Name = "Slap Tongue",
                Details = "Pratice slow isolated slap tongues and build speed",
                CategoryId = 5
            },
            new
            {
                Id = 19,
                Name = "Flutter Tongue",
                Details = "Practice isolated flutter tongue on one pitch, then add scales, etc.",
                CategoryId = 5
            },
            new
            {
                Id = 20,
                Name = "Alternate Fingerings",
                Details = "Testing alternate fingerings for tricky passages or tonal effects/intonation",
                CategoryId = 5
            },
            new
            {
                Id = 21,
                Name = "2-5-1 Patterns",
                Details = "Pick a 2-5-1 pattern and apply to all keys",
                CategoryId = 6
            },
            new
            {
                Id = 22,
                Name = "Walk Bass Line",
                Details = "Pick a set of changes or tune and walk a bass line over them",
                CategoryId = 6
            },
            new
            {
                Id = 23,
                Name = "Improvise",
                Details = "Pick a set of changes or tune to improvise over freely",
                CategoryId = 6
            },
            new
            {
                Id = 24,
                Name = "Listen",
                Details = "Listen and mimic high-quality recordings",
                CategoryId = 6
            },
            new
            {
                Id = 25,
                Name = "Donna Lee",
                Details = "Learn changes, form, melody, lyrics, etc.",
                CategoryId = 7
            },
            new
            {
                Id = 26,
                Name = "Misty",
                Details = "Learn changes, form, melody, lyric, etc.",
                CategoryId = 7
            },
            new
            {
                Id = 27,
                Name = "Wonderwall",
                Details = "You can't play guitar unless you play Wonderwall",
                CategoryId = 7
            },
            new
            {
                Id = 28,
                Name = "Careless Whisper",
                Details = "That one George Michael Song",
                CategoryId = 7
            },
            new
            {
                Id = 29,
                Name = "Hummel Concerto",
                Details = "Hummel Concerto for Trumpet",
                CategoryId = 8
            },
            new
            {
                Id = 30,
                Name = "Bach Partita in D minor",
                Details = "Partita for solo vionlin",
                CategoryId = 8
            },
            new
            {
                Id = 31,
                Name = "Cage 4'33\"",
                Details = "John Cage -4'33\" for piano",
                CategoryId = 8
            },
            new
            {
                Id = 32,
                Name = "Berio Sequenza III",
                Details = "Berio - Sequnza III for solo voice",
                CategoryId = 8
            },
            new
            {
                Id = 33,
                Name = "Mozart String Quartet No. 15",
                Details = "Mozart String Quartet No. 15",
                CategoryId = 9
            },
            new
            {
                Id = 34,
                Name = "Ciudades for Saxophone Quartet",
                Details = "Ciudades for saxophone quartet - movement II",
                CategoryId = 9
            },
            new
            {
                Id = 35,
                Name = "Poulenc Sonata for four hands",
                Details = "Poulenc Sonata for four hands",
                CategoryId = 9
            },
            new
            {
                Id = 36,
                Name = "Six Bagatelles",
                Details = "Six Bagatelles - Ligeti - for Woodwind quintet",
                CategoryId = 9
            },
            new
            {
                Id = 37,
                Name = "Ferling Etude No. 14",
                Details = "Ferling 48 Famous Studies Etudes for oboe",
                CategoryId = 10
            },
            new
            {
                Id = 38,
                Name = "Voxman Etude No. 2",
                Details = "From the saxophone Voxman Selected Studies book",
                CategoryId = 10
            },
            new
            {
                Id = 39,
                Name = "Milde Concert Study 3",
                Details = "Milde Concert studies for piano - No. 3",
                CategoryId = 10
            },
            new
            {
                Id = 40,
                Name = "Chopin Etude No. 3",
                Details = "Chopin Etude No. 3 for piano",
                CategoryId = 10
            },
            new
            {
                Id = 41,
                Name = "Sight Reading Factory",
                Details = "Custom exercises on SRF website",
                CategoryId = 11
            },
            new
            {
                Id = 42,
                Name = "Intermediate Method",
                Details = "Sight read lines from easier method book",
                CategoryId = 11
            },
            new
            {
                Id = 43,
                Name = "New Pieces for band",
                Details = "Sight read new pieces for band class",
                CategoryId = 11
            },
            new
            {
                Id = 44,
                Name = "Googled Random tuba pieces",
                Details = "Googled sight-reading excerpts for free online",
                CategoryId = 11
            },
            new
            {
                Id = 45,
                Name = "Mahler 5 opening",
                Details = "Trumpet opening to Mahler Symphony No. 5",
                CategoryId = 12
            },
            new
            {
                Id = 46,
                Name = "Pictures - Promenade",
                Details = "Trumpet opening to Promenade from Pictures at an Exhibition by Mussorgsky",
                CategoryId = 12
            },
            new
            {
                Id = 47,
                Name = "Symphonie Fantastique",
                Details = "Just find something hard in this piece and get better at it",
                CategoryId = 12
            },
            new
            {
                Id = 48,
                Name = "Strauss - Don Juan",
                Details = "Don Juan by Strauss - practiced the horn part",
                CategoryId = 12
            },
            new
            {
                Id = 49,
                Name = "Maslanka 4",
                Details = "Maslanka Symphony No. 4 for band concert coming up",
                CategoryId = 13
            },
            new
            {
                Id = 50,
                Name = "Palestrina",
                Details = "Missa Papae Marcelli - by Palestrina for upcoming gig",
                CategoryId = 13
            },
            new
            {
                Id = 51,
                Name = "Beethoven 7",
                Details = "Practice violin 1 part for upcoming concert in Chattanooga",
                CategoryId = 13
            },
            new
            {
                Id = 52,
                Name = "Gymnopedie for guitar ensemble",
                Details = "Practiced my part for our guitar ensemble recital",
                CategoryId = 13
            },
            new
            {
                Id = 53,
                Name = "Learn Pink Panther",
                Details = "Learned the Pink Panther theme on kazoo",
                CategoryId = 14
            },
            new
            {
                Id = 54,
                Name = "Learn Mandalorian",
                Details = "Learn Mandalorian theme on alto flute",
                CategoryId = 14
            },
            new
            {
                Id = 55,
                Name = "Learn the Rick-Roll song",
                Details = "Never gonna give you up",
                CategoryId = 14
            },
            new
            {
                Id = 56,
                Name = "Scream Into the Mirror",
                Details = "It helps",
                CategoryId = 14
            },
            new
            {
                Id = 57,
                Name = "Take a break",
                Details = "Walk, breathe, rest your eyes, whatever you need!",
                CategoryId = 15
            },
            new
            {
                Id = 58,
                Name = "Stretch",
                Details = "Stretch to prevent repetitive motion injuries",
                CategoryId = 15
            },
            new
            {
                Id = 59,
                Name = "Deep-Breathing",
                Details = "As a pre-warm up or warm-down, or if you get frustrated",
                CategoryId = 15
            },
            new
            {
                Id = 60,
                Name = "Rick-Roll mom",
                Details = "I did it on Bassoon, pick your poison",
                CategoryId = 15
            }
        );
    }
}