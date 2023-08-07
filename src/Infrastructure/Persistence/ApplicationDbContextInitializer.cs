using TestApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace TestApp.Infrastructure.Persistence;

public class ApplicationDbContextInitializer
{
    private readonly ILogger<ApplicationDbContextInitializer> _logger;
    private readonly ApplicationDbContext _context;

    public ApplicationDbContextInitializer(ILogger<ApplicationDbContextInitializer> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task InitialiseAsync()
    {
        try
        {
            if (_context.Database.IsSqlServer())
            {
                await _context.Database.MigrateAsync();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while initialising the database");
            throw;
        }
    }

    public async Task SeedAsync()
    {
        try
        {
            await TrySeedAsync();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An error occurred while seeding the database");
            throw;
        }
    }

    private async Task TrySeedAsync()
    {
        // Default data
        // Seed, if necessary
        if (!_context.Rectangles.Any())
        {
            Random random = new();
            for (int i = 0; i < 200; i++)
            {
                int topLeftX = random.Next(1, 500);   // Random value between 1 and 500 for demo
                int topLeftY = random.Next(1, 500);   // Random value between 1 and 500 for demo
            
                // Ensure that bottomRightX are always greater than topLeftX and bottomRightY always less than topLeftY respectively
                int bottomRightX = random.Next(topLeftX + 1, topLeftX + 500);
                int bottomRightY = random.Next(0, topLeftY-1);

                _context.Rectangles.Add(new Rectangle(topLeftX, topLeftY, bottomRightX, bottomRightY));
            }

            await _context.SaveChangesAsync();
        }
    }
}
