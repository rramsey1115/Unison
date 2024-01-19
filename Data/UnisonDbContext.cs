using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Unison.Models;
using Microsoft.AspNetCore.Identity;

namespace Unison.Data;
public class UnisonDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<UserProfile> UserProfiles { get; set; }
    

    public UnisonDbContext(DbContextOptions<UnisonDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        });

        modelBuilder.Entity<Activity>().HasData(
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
                id = 4,
                Name = "Clarke Studies",
                Details = "Studies out of the Clarke method book, not intended to be played as fast as possible for long tone warm up",
                CategoryId = 1
            },
            new
            {
                id = 5,
                Name = "Scale Patterns",
                Details = "Choose a pattern and play in all keys",
                CategoryId = 2
            },
            new
            {
                id = 6,
                Name = "Hanon Patterns",
                Details = "Patterns from the Hanon book",
                CategoryId = 2
            },
            new
            {
                id = 7,
                Name = "Fret Fingering Pattern",
                Details = "Slowly build speed on using first three fingers on first three frets",
                CategoryId = 2
            },
            new
            {
                id = 8,
                Name = "No Thumb - Left Hand",
                Details = "String instruments exercising left hand fingers without support of back thumb",
                CategoryId = 2
            },
            new
            {
                id = 9,
                Name = "Major",
                Details = "Major Scales - full range of instrument",
                CategoryId = 3
            },
            new
            {
                id = 10,
                Name = "Harmonic Minor",
                Details = "Harmonic Minor - full range of instrument",
                CategoryId = 3
            },
            new
            {
                id = 11,
                Name = "Melodic Minor",
                Details = "Melodic Minor - full range of instrument",
                CategoryId = 3
            },
            new
            {
                id = 12,
                Name = "Natural Minor",
                Details = "Natural Minor - full range of instrument",
                CategoryId = 3
            },
            new
            {
                id = 13,
                Name = "Major",
                Details = "Major Chords - all keys",
                CategoryId = 4
            },
            new
            {
                id = 14,
                Name = "",
                Details = "",
                CategoryId = 4
            },
            new
            {
                id = 15,
                Name = "",
                Details = "",
                CategoryId = 4
            },
            new
            {
                id = 16,
                Name = "",
                Details = "",
                CategoryId = 4
            },
            new
            {
                id = 17,
                Name = "",
                Details = "",
                CategoryId = 5
            },
            new
            {
                id = 18,
                Name = "",
                Details = "",
                CategoryId = 5
            },
            new
            {
                id = 19,
                Name = "",
                Details = "",
                CategoryId = 5
            },
            new
            {
                id = 20,
                Name = "",
                Details = "",
                CategoryId = 5
            },
            new
            {
                id = 21,
                Name = "",
                Details = "",
                CategoryId = 6
            },
            new
            {
                id = 22,
                Name = "",
                Details = "",
                CategoryId = 6
            },
            new
            {
                id = 23,
                Name = "",
                Details = "",
                CategoryId = 6
            },
            new
            {
                id = 24,
                Name = "",
                Details = "",
                CategoryId = 6
            },
            new
            {
                id = 25,
                Name = "",
                Details = "",
                CategoryId = 7
            },
            new
            {
                id = 26,
                Name = "",
                Details = "",
                CategoryId = 7
            },
            new
            {
                id = 27,
                Name = "",
                Details = "",
                CategoryId = 7
            },
            new
            {
                id = 28,
                Name = "",
                Details = "",
                CategoryId = 7
            },
            new
            {
                id = 29,
                Name = "",
                Details = "",
                CategoryId = 8
            },
            new
            {
                id = 30,
                Name = "",
                Details = "",
                CategoryId = 8
            },
            new
            {
                id = 31,
                Name = "",
                Details = "",
                CategoryId = 8
            },
            new
            {
                id = 32,
                Name = "",
                Details = "",
                CategoryId = 8
            },
            new
            {
                id = 33,
                Name = "",
                Details = "",
                CategoryId = 9
            },
            new
            {
                id = 34,
                Name = "",
                Details = "",
                CategoryId = 9
            },
            new
            {
                id = 35,
                Name = "",
                Details = "",
                CategoryId = 9
            },
            new
            {
                id = 36,
                Name = "",
                Details = "",
                CategoryId = 9
            },
            new
            {
                id = 37,
                Name = "",
                Details = "",
                CategoryId = 10
            },
            new
            {
                id = 38,
                Name = "",
                Details = "",
                CategoryId = 10
            },
            new
            {
                id = 39,
                Name = "",
                Details = "",
                CategoryId = 10
            },
            new
            {
                id = 40,
                Name = "",
                Details = "",
                CategoryId = 10
            },
            new
            {
                id = 41,
                Name = "",
                Details = "",
                CategoryId = 11
            },
            new
            {
                id = 42,
                Name = "",
                Details = "",
                CategoryId = 11
            },
            new
            {
                id = 43,
                Name = "",
                Details = "",
                CategoryId = 11
            },
            new
            {
                id = 44,
                Name = "",
                Details = "",
                CategoryId = 11
            },
            new
            {
                id = 45,
                Name = "",
                Details = "",
                CategoryId = 12
            },
            new
            {
                id = 46,
                Name = "",
                Details = "",
                CategoryId = 12
            },
            new
            {
                id = 47,
                Name = "",
                Details = "",
                CategoryId = 12
            },
            new
            {
                id = 48,
                Name = "",
                Details = "",
                CategoryId = 12
            },
            new
            {
                id = 49,
                Name = "",
                Details = "",
                CategoryId = 13
            },
            new
            {
                id = 50,
                Name = "",
                Details = "",
                CategoryId = 13
            },
            new
            {
                id = 51,
                Name = "",
                Details = "",
                CategoryId = 13
            },
            new
            {
                id = 52,
                Name = "",
                Details = "",
                CategoryId = 13
            },
            new
            {
                id = 53,
                Name = "",
                Details = "",
                CategoryId = 14
            },
            new
            {
                id = 54,
                Name = "",
                Details = "",
                CategoryId = 14
            },
            new
            {
                id = 55,
                Name = "",
                Details = "",
                CategoryId = 14
            },
            new
            {
                id = 56,
                Name = "",
                Details = "",
                CategoryId = 14
            },
            new
            {
                id = 57,
                Name = "",
                Details = "",
                CategoryId = 15
            },
            new
            {
                id = 58,
                Name = "",
                Details = "",
                CategoryId = 15
            },
            new
            {
                id = 59,
                Name = "",
                Details = "",
                CategoryId = 15
            },
            new
            {
                id = 60,
                Name = "",
                Details = "",
                CategoryId = 15
            }
        );

    }
}