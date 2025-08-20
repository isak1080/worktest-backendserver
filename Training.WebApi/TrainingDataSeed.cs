using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Training.Data;

namespace Training.WebApi;

/// <summary>
/// Contains seeding of the database.
/// </summary>
public static class TrainingDataSeed
{
    public static async Task SeedData(TrainingDbContext db, CancellationToken cancellationToken = default)
    {
        await db.Database.EnsureCreatedAsync(cancellationToken);

        if (!db.Athletes.Any())
        {
            var seededAthlete = new Athlete
            {
                FullName = "Test Athlete",
                Email = "test.athlete@seeded.local",
                DateOfBirth = new DateTime(1995, 1, 1)
            };
            db.Athletes.Add(seededAthlete);
            await db.SaveChangesAsync(cancellationToken);
        }
        
        if (!db.Users.Any())
        {
            var coachUser = new User
            {
                Username = "coach1",
                PasswordHash = PasswordHashHelper.HashPassword("coach123"), 
                Role = "Coach",
            };
            db.Users.Add(coachUser);
            var athlete = new User
            {
                Username = "athlete1",
                Role = "Athlete",
                AthleteId = db.Athletes.First().Id,
                PasswordHash = PasswordHashHelper.HashPassword("athlete123")
            };
            db.Users.Add(athlete);
            await db.SaveChangesAsync(cancellationToken);
        }
    }

    
}