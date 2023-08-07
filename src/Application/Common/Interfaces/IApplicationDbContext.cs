using TestApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TestApp.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<Rectangle> Rectangles { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
